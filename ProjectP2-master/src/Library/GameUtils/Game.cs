// -----------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.BoardUtils;
using Library.BotUtils;
using Library.Exceptions;
using Library.UserUtils;

namespace Library.GameUtils
{
    /// <summary>
    /// Clase que representa cada juego iniciado en el programa.
    /// </summary>
    public class Game
    {
        private readonly BattleShipSettings battleShipSettings = BattleShipSettings.Instance;

        /// <summary>
        /// Obtiene un valor que indica si este juego es público (cualquiera puede unirse)
        /// o es privado (solo se puede unir con un código de juego).
        /// </summary>
        public bool IsPublic { get; }

        /// <summary>
        /// Obtiene el estado de la partida.
        /// </summary>
        public GameStatus GameStatus { get; private set; } = GameStatus.Waiting;

        /// <summary>
        /// Obtiene el identificador único de este Game.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Obtiene el tipo de board que se utilizará en este Game.
        /// </summary>
        public Type BoardType { get; }

        /// <summary>
        /// Obtiene diccionario de cada <see cref="UserUtils.User"/>
        /// con su respectiva <see cref="BoardUtils.Board"/>.
        /// </summary>
        public Dictionary<User, Board> Players { get; }

        /// <summary>
        /// Obtiene quien lleva el turno en la partida.
        /// </summary>
        public User Turn { get; private set; }

        private Timer TurnsTimer { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        /// <param name="identifier">El identificador único de este Game.</param>
        /// <param name="isPublic">Identifica si la nueva partida es pública o privada.</param>
        /// <param name="boardType">El tipo de board a utilizar en este Game.</param>
        public Game(string identifier, bool isPublic, Type boardType)
        {
            this.Players = new Dictionary<User, Board>();
            this.Identifier = identifier;
            this.IsPublic = isPublic;
            this.BoardType = boardType;
        }

        /// <summary>
        /// Finaliza una instancia de la clase <see cref="Game"/>.
        /// </summary>
        ~Game()
        {
            this.TurnsTimer?.Dispose();
        }

        /// <summary>
        /// Agrega un usuario al diccionario de User, Board.
        /// Designada por Expert, ya que conoce los users del juego.
        /// </summary>
        /// <param name="newPlayer">El jugador que se une.</param>
        /// <exception cref="NullPointerException">Excepción que surge en caso de que el jugador sea null.</exception>
        /// <exception cref="GameJoinException">Excepción que surge si el juego ya esta lleno.</exception>
        public void AddPlayer(User newPlayer)
        {
            if (newPlayer == null)
            {
                throw new NullPointerException("el jugador a agregar a una nueva partida no puede ser null.");
            }

            if (this.Players.ContainsKey(newPlayer))
            {
                throw new ArgumentException("El jugador ya esta agregado.");
            }

            if (!this.GameStatus.Equals(GameStatus.Waiting))
            {
                throw new GameJoinException("La partida no acepta nuevos jugadores.");
            }

            if (this.Players.Count == 0)
            {
                this.Players.Add(newPlayer, null);
                this.Turn = newPlayer;
                newPlayer.UserStatus = UserStatus.WaitingForSecondPlayer;
            }
            else if (this.Players.Count == 1)
            {
                User otherUser = this.Players.Keys.First();
                BattleShipSettings.Instance.UsedBot.Send(otherUser.ID, $"{newPlayer.NickName} se ha unido a la partida!");
                this.Players[otherUser] = (Board)Activator.CreateInstance(this.BoardType);
                this.Players.Add(newPlayer, (Board)Activator.CreateInstance(this.BoardType));
                this.StartPlacingBoats();
            }
            else
            {
                throw new GameJoinException("La partida ya cuenta con dos jugadores!");
            }
        }

        /// <summary>
        /// Remueve el jugador del diccionario de User, Board.
        /// Designada por Expert ya que conoce el diccionario de User, Board.
        /// </summary>
        /// <param name="user">El usuario que se borrara del diccionario.</param>
        public void RemovePlayer(User user)
        {
            if (user == null)
            {
                throw new NullPointerException("El jugador a remover no puede ser null");
            }

            user.UserStatus = UserStatus.Lobby;
            this.Players.Remove(user);

            foreach (User player in this.Players.Keys)
            {
                IBot bot = BattleShipSettings.Instance.UsedBot;
                bot.Send(player.ID, $"{user.NickName} ha salido de la partida.");
            }

            switch (this.GameStatus)
            {
                case GameStatus.Finished:
                case GameStatus.Finishing:
                    break;
                case GameStatus.Waiting:
                case GameStatus.PlacingBoats:
                    this.EndGame();
                    break;
                default:
                    this.Win(this.Players.Keys.First());
                    break;
            }
        }

        /// <summary>
        /// Cambia el jugador que debe hacer el próximo movimiento.
        /// Designada por Expert ya que Game es quien conoce de que User es el turno.
        /// </summary>
        public void SwitchTurns()
        {
            User actual = this.Turn;
            User newTurn = this.Players.Keys.First(u => !u.Equals(actual));

            IBot bot = BattleShipSettings.Instance.UsedBot;
            bot.Send(actual.ID, $"Es el turno de {newTurn.NickName}.");
            bot.Send(newTurn.ID, "Es tu turno.");

            this.Turn = newTurn;

            // Reset timer.
            int timerPeriod = BattleShipSettings.Instance.TurnTimerPeriod;
            this.TurnsTimer.Change(timerPeriod, timerPeriod);
        }

        /// <summary>
        /// Establece un ganador del juego y prepara el juego para terminar.
        /// </summary>
        /// <param name="winner">El jugador que ganó la partida.</param>
        public async void Win(User winner)
        {
            IBot bot = BattleShipSettings.Instance.UsedBot;

            User loser = this.Players.Keys.First(u => !u.Equals(winner));
            loser.Stats.Losses++;
            winner.Stats.Wins++;
            bot.Send(loser.ID, $"Has perdido, {winner.NickName} ha destrozado todos tus botes. Mejor suerte la próxima");
            bot.Send(winner.ID, $"Has ganado! {loser.NickName} no sabe donde meterse.");
            this.GameStatus = GameStatus.Finishing;

            // Start delay para kickear jugadores fuera de la sala.
            await Task.Delay(5_000);
            this.EndGame();
        }

        /// <summary>
        /// Inicia el juego, permitiendo a los jugadores colocar sus botes.
        /// </summary>
        public void StartPlacingBoats()
        {
            this.GameStatus = GameStatus.PlacingBoats;
            IBot bot = BattleShipSettings.Instance.UsedBot;
            foreach (User user in this.Players.Keys)
            {
                user.UserStatus = UserStatus.Playing;
                bot.Send(user.ID, $"El juego ha comenzado! Es momento de colocar tus botes.");
            }
        }

        /// <summary>
        /// Inicia el juego, permitiendo a los jugadores atacar a sus oponentes.
        /// </summary>
        public void StartGame()
        {
            this.StarTimer();
            this.GameStatus = GameStatus.Playing;
            foreach (User user in this.Players.Keys)
            {
                user.UserStatus = UserStatus.Playing;
            }

            IBot bot = BattleShipSettings.Instance.UsedBot;
            this.Turn = this.Players.Keys.ToList()[new Random().Next(2)];
            bot.Send(
                this.Players.Keys.First(p => !p.Equals(this.Turn)).ID,
                $"El juego ha comenzado! El turno es de {this.Turn.NickName}");

            bot.Send(this.Turn.ID, $"Es tu turno de jugar! Envía una coordenada para mandar tu primer ataque o envía /ayuda para recibir ayuda.");
        }

        private void EndGame()
        {
            IBot bot = BattleShipSettings.Instance.UsedBot;
            this.GameStatus = GameStatus.Finished;
            foreach (User user in this.Players.Keys)
            {
                bot.Send(user.ID, "El juego ha finalizado. Saliendo de la sala...");
                this.RemovePlayer(user);
                user.UserStatus = UserStatus.Lobby;
            }

            this.StopTimer();
        }

        /// <summary>
        /// Empieza a correr el timer que contabiliza los segundos de cada turno.
        /// </summary>
        private void StarTimer()
        {
            this.TurnsTimer = new Timer(this.OnTimerEnd);
            this.TurnsTimer.Change(
                this.battleShipSettings.TurnTimerPeriod,
                this.battleShipSettings.TurnTimerPeriod);
        }

        /// <summary>
        /// Finaliza el timer para que no siga corriendo en el fondo.
        /// </summary>
        private void StopTimer()
        {
            if (this.TurnsTimer != null)
            {
                this.TurnsTimer.Dispose();
            }
        }

        /// <summary>
        /// Método llamado automáticamente por el timer, cada vez que este termina un ciclo.
        /// </summary>
        /// <param name="state">El estado del timer al momento de llamar este método.</param>
        private void OnTimerEnd(object state)
        {
            long previousTurnUserId = this.Turn.ID;
            string previousTurnUserName = this.Turn.NickName;
            this.Turn = this.Players.Keys.First(user => !user.Equals(this.Turn));
            IBot bot = BattleShipSettings.Instance.UsedBot;
            bot.Send(previousTurnUserId, $"Se te ha acabado el tiempo para realizar un movimiento por lo que el turno ahora pasa a {this.Turn.NickName}.");
            bot.Send(this.Turn.ID, $"Se le ha acabado el tiempo para realizar un movimiento a {previousTurnUserName} por lo que el turno ahora pasa a ti.");
        }
    }
}