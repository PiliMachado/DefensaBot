// -----------------------------------------------------------------------
// <copyright file="GameBoardsHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.UserUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Maneja las interacciones de jugadores dentro de una partida.
    /// </summary>
    public class GameBoardsHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;
        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameBoardsHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public GameBoardsHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            string messageText = message.Text.ToLower().Trim();
            return sender != null && !sender.UserStatus.Equals(UserStatus.Lobby) &&
                   (messageText.Equals("/boards", StringComparison.OrdinalIgnoreCase)
                    || messageText.Equals("/tablas", StringComparison.OrdinalIgnoreCase));
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder resultText = new StringBuilder();
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.Find(g =>
                g.Players.ContainsKey(user)
                && !g.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            if (game.Players.Count < 2)
            {
                throw new NullPointerException("Espera que se una un segundo jugador para poder interactuar con las tablas.");
            }

            foreach (User player in game.Players.Keys)
            {
                resultText.Append(player.Equals(user) ? "Tu board:\n" : $"Board de {player.NickName}:\n");
                resultText.Append("\n\n");
                resultText.Append(game.Players[player].GetPrintableBoard(player.Equals(user)));
                resultText.Append("\n\n");
            }

            return resultText.ToString();
        }
    }
}