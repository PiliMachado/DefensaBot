// -----------------------------------------------------------------------
// <copyright file="PlaceBoatsAddHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.BoatUtils;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.Managers;
using Library.UserUtils;
using Microsoft.VisualBasic.CompilerServices;

namespace Library.Handlers
{
    /// <summary>
    /// Handler encargado de manejar las requests relacionadas a unirse y crear partidas.
    /// </summary>
    public class PlaceBoatsAddHandler : AbstractHandler
    {
        private static readonly string[] Alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlaceBoatsAddHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public PlaceBoatsAddHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            if (sender == null || sender.UserStatus.Equals(UserStatus.Lobby))
            {
                return false;
            }

            string messageText = message.Text.ToLower().Trim();
            Game current = this.gameContainer.AvailableGames.FirstOrDefault(g =>
                g.Players.ContainsKey(sender) &&
                !g.GameStatus.Equals(GameStatus.Finished));

            return current != null && current.GameStatus.Equals(GameStatus.PlacingBoats) &&
                   messageText.StartsWith("/boat add", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.FirstOrDefault(g =>
                g.Players.ContainsKey(user) &&
                !g.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            // /boat add (type) (start) (finish)
            // ej: /boat add cruise A,0 A,3

            // /boat list
            // /boat add (type) (start) (finish)
            // /boat remove index
            String[] args = message.Text.Trim().Split(" ");

            if (args.Length < 5)
            {
                return "No hay suficientes argumentos. Uso: \"/boat add (type) (start_coord) (finish_coord)\"";
            }

            StringBuilder textResult = new StringBuilder();
            BoatsManager bm = Singleton<BoatsManager>.Instance;
            BoardsManager boardsManager = Singleton<BoardsManager>.Instance;

            string boatType = args[2];
            string startCoords = args[3];
            string finishCoords = args[4];

            // Corrige el input para que sea idéntico al tag que se intentó ingresar.
            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            if (!bm.GetAvailableTags().Contains(boatType))
            {
                textResult.Append($"No existe un bote de tipo \"{boatType}\"\n");
                textResult.Append("Tipos disponibles:\n");
                foreach (string bt in bm.GetAvailableTags())
                {
                    textResult.Append($" - {bt} (largo: {bm.GetManageableByTag(bt).Size})\n");
                }

                throw new InvalidBoatException(textResult.ToString());
            }

            string[] startCoordsArgs;
            string[] finishCoordsArgs;

            if (startCoords.Contains(',', StringComparison.Ordinal))
            {
                startCoordsArgs = startCoords.Split(",");
            }
            else if (startCoords.Length == 2)
            {
                startCoordsArgs = new string[] { startCoords.Substring(0, 1), startCoords.Substring(1, 1) };
            }
            else if (startCoords.Length == 3)
            {
                startCoordsArgs = new string[] { startCoords.Substring(0, 1), startCoords.Substring(1, 2) };
            }
            else
            {
                throw new InvalidBoatException(
                    $"Coordenadas de inicio \"({startCoords})\" inválidas. Deben ser \"LETRANUMERO\" o \"LETRA,NUMERO\", ej: A5 o A,5");
            }

            if (finishCoords.Contains(',', StringComparison.Ordinal))
            {
                finishCoordsArgs = finishCoords.Split(",");
            }
            else if (finishCoords.Length == 2)
            {
                finishCoordsArgs = new string[] { finishCoords.Substring(0, 1), finishCoords.Substring(1, 1) };
            }
            else if (finishCoords.Length == 3)
            {
                finishCoordsArgs = new string[] { finishCoords.Substring(0, 1), finishCoords.Substring(1, 2) };
            }
            else
            {
                throw new InvalidBoatException(
                    $"Coordenadas de fin \"({finishCoords})\" inválidas. Deben ser \"LETRANUMERO\" o \"LETRA,NUMERO\", ej: A5 o A,5");
            }

            if (!(this.IsLetter(startCoordsArgs[0]) && this.IsLetter(finishCoordsArgs[0]) &&
                  this.IsNumber(startCoordsArgs[1]) &&
                  this.IsNumber(finishCoordsArgs[1])))
            {
                throw new InvalidBoatException(
                    $"Coordenadas \"({startCoords})\" y/o \"({finishCoords})\" inválidas. Deben ser \"LETRANUMERO\" o \"LETRA,NUMERO\", ej: A5 o A,5");
            }

            int startCoordLetter = this.LetterCoordToNumber(startCoordsArgs[0]);
            int startCoordNumber = IntegerType.FromString(startCoordsArgs[1]);
            int finishCoordLetter = this.LetterCoordToNumber(finishCoordsArgs[0]);
            int finishCoordNumber = IntegerType.FromString(finishCoordsArgs[1]);
            int boardSize = game.Players[user].Size;
            if (startCoordLetter >= boardSize || startCoordNumber >= boardSize)
            {
                throw new InvalidBoatException(
                    $"La coordenada de inicio del bote esta fuera de la tabla. Tamaño de la tabla = {boardSize}");
            }

            if (finishCoordLetter >= boardSize || finishCoordNumber >= boardSize)
            {
                throw new InvalidBoatException(
                    $"La coordenada de fin del bote esta fuera de la tabla. Tamaño de la tabla = {boardSize}");
            }

            // A,3 A,4 ESTA BIEN
            // A,3 B,3 ESTA BIEN
            // A,3 B,4 ESTA MAL
            if (startCoordLetter != finishCoordLetter && startCoordNumber != finishCoordNumber)
            {
                throw new InvalidBoatException(
                    "El bote no se puede colocar en diagonal.");
            }

            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

            if (startCoordLetter == finishCoordLetter)
            {
                int from = Math.Min(startCoordNumber, finishCoordNumber);
                int to = Math.Max(startCoordNumber, finishCoordNumber);

                for (int i = from; i <= to; i++)
                {
                    coords.Add(new Tuple<int, int>(startCoordLetter, i));
                }
            }
            else
            {
                int from = Math.Min(startCoordLetter, finishCoordLetter);
                int to = Math.Max(startCoordLetter, finishCoordLetter);

                for (int i = from; i <= to; i++)
                {
                    coords.Add(new Tuple<int, int>(i, startCoordNumber));
                }
            }

            int correctSize = bm.GetManageableByTag(boatType).Size;
            if (coords.Count != correctSize)
            {
                throw new InvalidBoatException($"El tamaño de un {boatType} debe ser {correctSize}. Recibido: {coords.Count}");
            }

            foreach (var coord in coords)
            {
                if (game.Players[user].GetBoatAt(coord.Item1, coord.Item2) != null)
                {
                    throw new InvalidBoatException(
                        $"Ya existe un bote en {Alphabet[coord.Item1]},{coord.Item2}. Los botes no se pueden superponer.");
                }
            }

            Dictionary<string, int> neededBoatsForBoard = boardsManager.GetManageableByTag(boardsManager.GetTagByType(game.BoardType)).NeededBoatsForBoard;
            if (!neededBoatsForBoard.ContainsKey(boatType))
            {
                throw new InvalidBoatException($"La board de la partida en la que participas no toma botes del tipo {boatType}");
            }

            Dictionary<string, int> addedBoats = this.GetAddedBoats(game, user);

            if (addedBoats.ContainsKey(boatType) && neededBoatsForBoard[boatType] <= addedBoats[boatType])
            {
                throw new InvalidBoatException($"La board de la partida en la que participas tiene un máximo " +
                                               $"de {neededBoatsForBoard[boatType]} {boatType}. Ya los has colocado todos.");
            }

            game.Players[user].AddBoat(boatType, coords);
            StringBuilder postions = new StringBuilder();
            postions.Append("( ");
            foreach (var coord in coords)
            {
                postions.Append($"{Alphabet[coord.Item1]},{coord.Item2} ");
            }

            postions.Append(')');
            textResult.Append($"Añadido barco de tipo {boatType} en las coordenadas {postions}\n");
            textResult.Append($"Para comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n");

            if (this.AllAdded(game, user))
            {
                textResult.Append(
                    "Ya has añadido todos los botes necesarios! El juego iniciará cuando tu contrincante también los haya colocado.\n");
                User enemy = game.Players.Keys.First(p => !p.Equals(user));
                BattleShipSettings.Instance.UsedBot.Send(enemy.ID, "Tu oponente ha terminado de colocar sus botes!");
                if (this.AllAdded(game, enemy))
                {
                    textResult.Append("Tu oponente también ha finalizado de agregar sus botes! Iniciando la partida.");
                    game.StartGame();
                }
            }

            return textResult.ToString();
        }

        private bool IsLetter(string input)
        {
            return Alphabet.Contains(input.ToUpper());
        }

        private bool IsNumber(string input)
        {
            try
            {
                IntegerType.FromString(input);
                return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        private int LetterCoordToNumber(string input)
        {
            return Array.IndexOf(Alphabet, input.ToUpper());
        }

        private bool AllAdded(Game game, User user)
        {
            BoardsManager boardsManager = Singleton<BoardsManager>.Instance;
            Dictionary<string, int> added = this.GetAddedBoats(game, user);
            Dictionary<string, int> needed = boardsManager.GetManageableByTag(boardsManager.GetTagByType(game.BoardType)).NeededBoatsForBoard;

            foreach (string boatType in needed.Keys)
            {
                if (!added.ContainsKey(boatType) || added[boatType] < needed[boatType])
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, int> GetAddedBoats(Game game, User user)
        {
            Dictionary<string, int> userBoats = new Dictionary<string, int>();
            BoatsManager boatsManager = Singleton<BoatsManager>.Instance;

            foreach (Boat boat in game.Players[user].Boats)
            {
                string boatType = boatsManager.GetTagByType(boat.GetType());
                if (!userBoats.ContainsKey(boatType))
                {
                    userBoats.Add(boatType, 0);
                }

                userBoats[boatType] = userBoats[boatType] + 1;
            }

            return userBoats;
        }
    }
}