// -----------------------------------------------------------------------
// <copyright file="PlaceBoatsRemoveHandler.cs" company="Universidad Católica del Uruguay">
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
using Microsoft.VisualBasic.CompilerServices;

namespace Library.Handlers
{
    /// <summary>
    /// Handler encargado de manejar las requests relacionadas a listar botes agregados por el usuario.
    /// </summary>
    public class PlaceBoatsRemoveHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlaceBoatsRemoveHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public PlaceBoatsRemoveHandler(IHandler next = null)
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
            return messageText.StartsWith("/boat remove", StringComparison.OrdinalIgnoreCase);
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
            string[] args = message.Text.Trim().Split(" ");

            if (args.Length < 3)
            {
                throw new InvalidBoatException("Debes especificar el ID del bote que quieres remover.\nPara verificar tus botes y sus IDs, envía \"/boats list\".");
            }

            try
            {
                IntegerType.FromString(args[2]);
            }
            catch (InvalidCastException)
            {
                throw new InvalidBoatException("El ID del bote a eliminar debe ser un número.");
            }

            int index = IntegerType.FromString(args[2]);
            List<Boat> boats = game.Players[user].Boats;
            if (index >= boats.Count)
            {
                throw new InvalidBoatException("El bote a eliminar no existe, verifica las IDs de tus botes.");
            }

            Boat toRemove = boats[index];
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            boats.Remove(toRemove);

            StringBuilder positions = new StringBuilder();
            foreach (BoatPosition bp in toRemove.Positions)
            {
                positions.Append($"{bp.X},{bp.Y} ");
            }

            textResult.Append(
                $"Eliminado bote con ID: {index}, de tipo: {bm.GetTagByType(toRemove.GetType())}, en las coordenadas: ( {positions})\n");
            textResult.Append("Verifica las IDs de tus otros barcos, pueden haber cambiado.");

            return textResult.ToString();
        }
    }
}