// -----------------------------------------------------------------------
// <copyright file="PlaceBoatsInfoHandler.cs" company="Universidad Católica del Uruguay">
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

namespace Library.Handlers
{
    /// <summary>
    /// Handler encargado de manejar las requests relacionadas a unirse y crear partidas.
    /// </summary>
    public class PlaceBoatsInfoHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlaceBoatsInfoHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public PlaceBoatsInfoHandler(IHandler next = null)
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
                   messageText.StartsWith("/boat info", StringComparison.OrdinalIgnoreCase);
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

            StringBuilder textResult = new StringBuilder();
            BoatsManager boatsManager = Singleton<BoatsManager>.Instance;
            BoardsManager boardsManager = Singleton<BoardsManager>.Instance;

            Dictionary<string, int> addedBoatsToBoard = new Dictionary<string, int>();
            Dictionary<string, int> neededBoatsForBoard = boardsManager.GetManageableByTag(boardsManager.GetTagByType(game.BoardType)).NeededBoatsForBoard;
            Dictionary<string, int> missingBoatsForBoard = new Dictionary<string, int>();

            List<Boat> boats = game.Players[user].Boats;

            // Boat list to (boat_tag, amount) dictionary
            foreach (Boat boat in boats)
            {
                string tagByType = boatsManager.GetTagByType(boat.GetType());
                if (!addedBoatsToBoard.ContainsKey(tagByType))
                {
                    addedBoatsToBoard.Add(tagByType, 0);
                }

                addedBoatsToBoard[tagByType] += 1;
            }

            textResult.Append($"Botes necesarios para tabla {boardsManager.GetTagByType(game.BoardType)} ({game.Players[user].Size}x{game.Players[user].Size}):\n");

            // Compare added vs needed
            foreach (string boatType in neededBoatsForBoard.Keys)
            {
                textResult.Append($"{boatType} x{neededBoatsForBoard[boatType]}\n");
                if (addedBoatsToBoard.ContainsKey(boatType))
                {
                    if (neededBoatsForBoard[boatType] > addedBoatsToBoard[boatType])
                    {
                        missingBoatsForBoard[boatType] = neededBoatsForBoard[boatType] - addedBoatsToBoard[boatType];
                    }
                }
                else
                {
                    missingBoatsForBoard[boatType] = neededBoatsForBoard[boatType];
                }
            }

            textResult.Append("\nBotes faltantes:\n");

            foreach (string boatType in missingBoatsForBoard.Keys)
            {
                textResult.Append($"{boatType} (largo: {boatsManager.GetManageableByTag(boatType).Size}) x{missingBoatsForBoard[boatType]}\n");
            }

            return textResult.ToString();
        }
    }
}