// -----------------------------------------------------------------------
// <copyright file="PlaceBoatsListHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
    /// Handler encargado de manejar las requests relacionadas a listar botes agregados por el usuario.
    /// </summary>
    public class PlaceBoatsListHandler : AbstractHandler
    {
        private static readonly string[] Alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlaceBoatsListHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public PlaceBoatsListHandler(IHandler next = null)
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
            return messageText.StartsWith("/boat list", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.Find(g =>
                g.Players.ContainsKey(user)
                && !g.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            StringBuilder textResult = new StringBuilder();
            List<Boat> boats = game.Players[user].Boats;
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            textResult.Append("Tus botes (ID - tipo - (coordenadas)):\n");
            if (boats.Count == 0)
            {
                textResult.Append("No has colocado ningún barco.");
            }

            for (int i = 0; i < boats.Count; i++)
            {
                Boat boat = boats[i];
                StringBuilder positions = new StringBuilder();
                foreach (BoatPosition bp in boat.Positions)
                {
                    positions.Append($"{Alphabet[bp.X]},{bp.Y} ");
                }

                textResult.Append($"{i} -{bm.GetTagByType(boat.GetType())} - {positions}");
            }

            return textResult.ToString();
        }
    }
}