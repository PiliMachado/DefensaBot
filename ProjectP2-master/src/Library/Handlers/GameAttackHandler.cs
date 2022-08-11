// -----------------------------------------------------------------------
// <copyright file="GameAttackHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using Library.BoardUtils;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.UserUtils;
using Microsoft.VisualBasic.CompilerServices;

namespace Library.Handlers
{
    /// <summary>
    /// Maneja las interacciones de jugadores dentro de una partida.
    /// </summary>
    public class GameAttackHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;
        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameAttackHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public GameAttackHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            string[] args = message.Text.ToLower().Trim().Split(" ");
            return sender != null && !sender.UserStatus.Equals(UserStatus.Lobby) &&
                   (args[0].Equals("/attack", StringComparison.OrdinalIgnoreCase)
                    || args[0].Equals("/ataque", StringComparison.OrdinalIgnoreCase));
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder resultText = new StringBuilder();
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.Find(g =>
                g.Players.ContainsKey(user) && !g.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            string[] args = message.Text.Trim().Split(" ");

            if (!game.GameStatus.Equals(GameStatus.Playing) || game.Players.Count < 2)
            {
                throw new InvalidAttackException("No puedes atacar en este momento.");
            }

            if (args.Length < 2)
            {
                throw new InvalidAttackException("Debes pasar las coordenadas en las que quieres atacar.");
            }

            string attackCoords = args[1];
            string[] attackCoordsArgs;

            if (attackCoords.Contains(",", StringComparison.Ordinal))
            {
                attackCoordsArgs = attackCoords.Split(",");
            }
            else if (attackCoords.Length == 2)
            {
                attackCoordsArgs = new string[] { attackCoords.Substring(0, 1), attackCoords.Substring(1, 1) };
            }
            else if (attackCoords.Length == 3)
            {
                attackCoordsArgs = new string[] { attackCoords.Substring(0, 1), attackCoords.Substring(1, 2) };
            }
            else
            {
                throw new InvalidAttackException(
                    $"Coordenadas de inicio \"({attackCoords})\" inválidas. Deben ser \"LETRANUMERO\" o \"LETRA,NUMERO\", ej: A5 o A,5");
            }

            try
            {
                IntegerType.FromString(attackCoordsArgs[1]);
            }
            catch (InvalidCastException)
            {
                throw new InvalidAttackException("La segunda coordenada debe ser numérica.");
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidAttackException("La segunda coordenada debe ser numérica.");
            }

            if (!game.Turn.Equals(user))
            {
                throw new InvalidAttackException("No puedes atacar porque no es tu turno.");
            }

            User opponent = game.Players.Keys.First(u => !u.Equals(user));
            Board opponentBoard = game.Players[opponent];
            BoardHitStatus hitResult = opponentBoard.Hit(attackCoordsArgs[0], IntegerType.FromString(attackCoordsArgs[1]));
            IBot bot = BattleShipSettings.Instance.UsedBot;
            switch (hitResult)
            {
                case BoardHitStatus.OutOfBoard:
                    user.Stats.TotalMisses++;
                    resultText.Append("El disparo ha caído fuera de la tabla! (Quizás ingresaste mal las coordenadas.)\n");
                    bot.Send(opponent.ID, $"{user.NickName} ha disparado: Fuera de la tabla.");
                    break;
                case BoardHitStatus.Water:
                    user.Stats.TotalMisses++;
                    resultText.Append("Tu disparo ha caído en el agua, mejor suerte la próxima!\n");
                    bot.Send(opponent.ID, $"{user.NickName} ha disparado: Ha pegado en el agua.");
                    break;
                case BoardHitStatus.WaterAgain:
                    resultText.Append("Ya habías disparado a esa posición y no hay más que agua!\n");
                    bot.Send(opponent.ID, $"{user.NickName} ha disparado: Ha pegado en una coordenada que ya había disparado y no hay mas que agua.");
                    break;
                case BoardHitStatus.BoatHit:
                    user.Stats.TotalHits++;
                    resultText.Append("Le pegaste!\n");
                    bot.Send(opponent.ID, $"{user.NickName} ha disparado: Le ha pegado a un bote!.");
                    break;

                // case BoardHitStatus.BoatHitAgain:
                default:
                    resultText.Append("Hay un barco en esa posición, pero ya lo habías golpeado!\n");
                    bot.Send(opponent.ID, $"{user.NickName} ha disparado: Ha pegado en una coordenada que ya había disparado y había un bote.");
                    break;
            }

            User loser = null;
            if (hitResult.Equals(BoardHitStatus.BoatHit))
            {
                foreach (User player in game.Players.Keys)
                {
                    if (game.Players[player].Boats.All(boat => boat.IsDestroyed()))
                    {
                        loser = player;
                        break;
                    }
                }

                if (loser != null)
                {
                    User winner = game.Players.Keys.First(u => !u.Equals(loser));
                    game.Win(winner);
                }
            }

            if (loser == null)
            {
                game.SwitchTurns();
                resultText.Append("Envía \"/boards\" para ver tu board y la de tu oponente.");
            }

            return resultText.ToString();
        }
    }
}