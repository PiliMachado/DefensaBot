// -----------------------------------------------------------------------
// <copyright file="InfoHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.UserUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Handler encargado de manejar la request de información por parte de un jugador.
    /// </summary>
    public class InfoHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InfoHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public InfoHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/info", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder textResult = new StringBuilder();

            textResult.Append($"Información:\n\n");
            textResult.Append($"Tu ID: {message.ID}\n");
            User user = this.userContainer.Search(message.ID);
            if (user != null)
            {
                textResult.Append($"Nombre: {user.FullName}\n");
                textResult.Append($"Nickname: {user.NickName}\n\n");
                if (!user.UserStatus.Equals(UserStatus.Lobby))
                {
                    Game currentGame = this.gameContainer.AvailableGames.Find(g =>
                        g.Players.ContainsKey(user) && !g.GameStatus.Equals(GameStatus.Finished));
                    if (currentGame == null)
                    {
                        user.UserStatus = UserStatus.Lobby;
                        throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
                    }

                    textResult.Append($"ID partida: {currentGame.Identifier}\n");
                    textResult.Append($"Estado actual de partida: {currentGame.GameStatus}\n");
                    textResult.Append($"Visibilidad de partida: {(currentGame.IsPublic ? "Pública" : "Privada")}\n");
                    if (currentGame.Players.Count > 1)
                    {
                        User opponent = currentGame.Players.Keys.First(u => !u.Equals(user));
                        textResult.Append($"ID de oponente: {opponent.ID}\n");
                        textResult.Append($"Nombre de oponente: {opponent.FullName}\n");
                        textResult.Append($"Nickname de oponente: {opponent.NickName}\n");
                        textResult.Append($"Turno de: {currentGame.Turn.NickName}\n");
                    }
                }

                textResult.Append($"Para ver información sobre estadísticas: \'/estadisticas\'");
            }

            return textResult.ToString();
        }
    }
}