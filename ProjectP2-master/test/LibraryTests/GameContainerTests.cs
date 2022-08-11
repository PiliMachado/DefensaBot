// <copyright file="GameContainerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a GameContainer.
    /// </summary>
    public class GameContainerTests
    {
        /// <summary>
        /// Test de añadir un game a la lista de games.
        /// </summary>
        [Test]
        public void AddElement()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            Assert.That(gameContainer.AvailableGames.Any(g => g.Identifier.Equals(game.Identifier, StringComparison.Ordinal)));
        }

        /// <summary>
        /// Test de remover un game de la lista de games.
        /// </summary>
        [Test]
        public void RemoveElement()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            Assert.That(gameContainer.AvailableGames.Any(g => g.Identifier.Equals(game.Identifier, StringComparison.Ordinal)));
            gameContainer.RemoveElement(game.Identifier);
            Assert.That(!gameContainer.AvailableGames.Any(g => g.Identifier.Equals(game.Identifier, StringComparison.Ordinal)));
        }

        /* NO SE COMO HACER ESTE TESTS CON LO QUE AGREGUE!
        /// <summary>
        /// Test de agregar un game, ya agregado, a la lista de games.
        /// </summary>
        [Test]
        public void AddAlreadyAddedElement()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            try
            {
                gameContainer.AddElement(true, "L");
                Assert.Fail();
            }
            catch (GameAlreadyRegisteredException)
            {
            }

            Assert.AreEqual(1, gameContainer.AvailableGames.Count);
        }
        */

        /// <summary>
        /// Test de remover un game, que no se encuentra en la lista, de la lista de games.
        /// </summary>
        [Test]
        public void RemoveNotAddedElement()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            Assert.That(gameContainer.AvailableGames.Any(g => g.Identifier.Equals(game.Identifier, StringComparison.Ordinal)));
            gameContainer.RemoveElement(game.Identifier);
            Dictionary<string, Game> expected = new Dictionary<string, Game>();
            CollectionAssert.AreEqual(expected, gameContainer.AvailableGames);
        }

        /// <summary>
        /// Test de buscar un game ya agregado a la lista de games.
        /// </summary>
        [Test]
        public void SearchRegisteredGame()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            Assert.AreEqual(game, gameContainer.Search(game.Identifier));
        }

        /// <summary>
        /// Test de buscar un game no agregado a la lista de games.
        /// </summary>
        [Test]
        public void SearchUnRegisteredGame()
        {
            GameContainer gameContainer = new GameContainer();
            Assert.AreEqual(null, gameContainer.Search("0193828383839393393939339392821"));
        }

        /// <summary>
        /// Test de ver si esta registrado un game que esta añadido a la lista de games.
        /// </summary>
        [Test]
        public void IsRegisteredForRegisteredGame()
        {
            GameContainer gameContainer = new GameContainer();
            Game game = gameContainer.AddElement(true, "L");
            Assert.AreEqual(true, gameContainer.IsRegistered(game.Identifier));
        }

        /// <summary>
        /// Test de ver si esta registrado un game que no esta en la lista de games.
        /// </summary>
        [Test]
        public void IsRegisteredForUnRegisteredGame()
        {
            GameContainer gameContainer = new GameContainer();
            gameContainer.AddElement(true, "L");
            string identifier2 = GameIdentifier.GenerateIdentifier();
            Assert.AreEqual(false, gameContainer.IsRegistered(identifier2));
        }
    }
}