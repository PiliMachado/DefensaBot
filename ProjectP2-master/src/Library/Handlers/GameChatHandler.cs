// -----------------------------------------------------------------------
// <copyright file="GameChatHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
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
    public class GameChatHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;
        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameChatHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public GameChatHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            return sender != null && !sender.UserStatus.Equals(UserStatus.Lobby) &&
                   !message.Text.Trim().StartsWith("/", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.Find(g =>
                g.Players.ContainsKey(user) && !g.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            // Solo un mensaje
            if (user.UserStatus.Equals(UserStatus.Playing) || game.Players.Count > 1)
            {
                IBot bot = BattleShipSettings.Instance.UsedBot;
                User otherUser = game.Players.Keys.First(p => !p.ID.Equals(user.ID));
                bot.Send(otherUser.ID, $"{user.NickName}: {message.Text}");
            }

            return string.Empty;
        }
    }
}