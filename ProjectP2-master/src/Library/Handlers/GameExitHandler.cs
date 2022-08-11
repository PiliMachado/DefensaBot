// -----------------------------------------------------------------------
// <copyright file="GameExitHandler.cs" company="Universidad Católica del Uruguay">
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
    public class GameExitHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;
        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameExitHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public GameExitHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            string messageText = message.Text.ToLower().Trim();
            return sender != null && !sender.UserStatus.Equals(UserStatus.Lobby) &&
                   (messageText.Equals("/salir", StringComparison.OrdinalIgnoreCase)
                    || messageText.Equals("/exit", StringComparison.OrdinalIgnoreCase));
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

            game.RemovePlayer(user);
            resultText.Append("Saliendo de la partida...");

            return resultText.ToString();
        }
    }
}