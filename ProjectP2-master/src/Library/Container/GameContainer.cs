// -----------------------------------------------------------------------
// <copyright file="GameContainer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Library.Exceptions;
using Library.GameUtils;
using Library.Managers;

namespace Library.ContainerUtils
{
    /// <summary>
    /// GameContainer contendrá todos los game, y se encargara por el patron Creator de crear instancias de Game.
    /// </summary>
    public class GameContainer
    {
        /// <summary>
        /// Obtiene la lista de juegos disponibles.
        /// </summary>
        public List<Game> AvailableGames { get; } = new List<Game>();

        /// <summary>
        /// Remueve un juego de la lista de juegos.
        /// Designada por Expert ya que GameContainer conoce la lista de games disponibles.
        /// </summary>
        /// <param name="identifier">El ID del juego a remover.</param>
        public void RemoveElement(string identifier)
        {
            Game toRemove = this.Search(identifier);
            this.AvailableGames.Remove(toRemove);
        }

        /// <summary>
        /// Agrega un nuevo objeto de tipo Game a la lista de juegos.
        /// Por Creator ya que GameContainer guarda instacias de Game creara los Games.
        /// Designada por Expert ya que GameContainer conoce la lista de games disponibles.
        /// </summary>
        /// <param name="isPublic">Identifica si este juego es público o privado.</param>
        /// <param name="boardTagType">El tipo de board a utilizar en el juego.</param>
        /// <returns>El nuevo juego creado.</returns>
        /// <exception cref="GameAlreadyRegisteredException">Lanzada cuando al momento de registrar un nuevo juego,
        /// ya existe uno registrado con el mismo identificador.</exception>
        public Game AddElement(bool isPublic, string boardTagType)
        {
            // Creamos game por creator.
            string identifier = GameIdentifier.GenerateIdentifier(); // Ahora GameContainer depende de GameIdentifier, en vez de MatchHandler, aplicamos Low Coupling 
                                                                     // & High Cohession, asi evitamos demasiadas depedencias por parte de MatchHandler.
            Game game = new Game(identifier, isPublic, Singleton<BoardsManager>.Instance.GetTypeByTag(boardTagType));
            if (this.AvailableGames.Any(g => g.Identifier.Equals(identifier, StringComparison.Ordinal)))
            {
                throw new GameAlreadyRegisteredException(
                    $"El juego con identificador {identifier} ya está registrado!");
            }

            this.AvailableGames.Add(game);
            return game;
        }

        /// <summary>
        /// Comrpueba si existe algún juego con el identificador pasado por parámetro.
        /// Designada por Expert ya que GameContainer conoce la lista de games disponibles.
        /// </summary>
        /// <param name="identifier">El ID a buscar.</param>
        /// <returns>True si existe un juego con el identificador dado.</returns>
        public bool IsRegistered(string identifier)
        {
            return this.AvailableGames.Any(g => g.Identifier.Equals(identifier, StringComparison.Ordinal));
        }

        /// <summary>
        /// Obtiene un Game o juego con el identificador dado por parámetro.
        /// Designada por Expert ya que GameContainer conoce la lista de games disponibles.
        /// </summary>
        /// <param name="identifier">El identificador del juego a buscar.</param>
        /// <returns>El juego con el identificador pasado por parámetro, o null si no existe ninguno con ese ID.</returns>
        public Game Search(string identifier)
        {
            // return this.AvailableGames.ContainsKey(identifier) ? this.AvailableGames[identifier] : null;
            return this.AvailableGames.Find(g => g.Identifier.Equals(identifier, StringComparison.Ordinal));
        }
    }
}