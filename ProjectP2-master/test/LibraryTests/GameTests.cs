using NUnit.Framework;
using Library.ContainerUtils;
using Library.GameUtils;
using System.Collections.ObjectModel;
using Library.BoardUtils;
using Library.UserUtils;
using System.Collections.Generic;
using System;
namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a Game.
    /// </summary>
    public class GameTests
    {
        /// <summary>
        /// Test de creacion de un Game y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void GameCreation()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            Assert.AreEqual(true, Game.IsPublic);
            Assert.AreEqual(GameStatus.Waiting, Game.GameStatus);
        }

        /// <summary>
        /// Test de agregar un player.
        /// </summary>
        [Test]
        public void AddPlayer()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            Assert.That(Game.Players.ContainsKey(user));
        }

        /// <summary>
        /// Test de remover un player.
        /// </summary>
        [Test]
        public void RemovePlayer()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            Assert.That(Game.Players.ContainsKey(user));
            Game.RemovePlayer(user);
            Assert.That(!Game.Players.ContainsKey(user));
        }

        /// <summary>
        /// Test de agregar un player ya agregado.
        /// </summary>
        [Test]
        public void AddAlreadyAddedPlayer()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            Assert.That(Game.Players.ContainsKey(user));
            bool catchedException = false;
            try
            {
                Game.AddPlayer(user);
            }
            catch (ArgumentException e)
            {
                catchedException = true;
                Assert.That(e.Message == "El jugador ya esta agregado.");
            }
            Assert.That(catchedException);
        }

        /// <summary>
        /// Test de remover un player ya removido.
        /// </summary>
        [Test]
        public void RemoveAlreadyRemovedPlayer()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            Assert.That(Game.Players.ContainsKey(user));
            Game.RemovePlayer(user);
            Assert.That(!Game.Players.ContainsKey(user));
            Game.RemovePlayer(user);
        }

        /// <summary>
        /// Test de cambiar turnos.
        /// </summary>
        [Test]
        public void SwitchTurns()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            User user2 = new User(1436, "Pilar Machado", "Pili");
            Game.AddPlayer(user2);
            Assert.That(!Equals(Game.Turn, user2));
        }

        /// <summary>
        /// Test de ganar partida.
        /// </summary>
        [Test]
        public void Win()
        {
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            Game Game = gameContainer.AddElement(true, "L");
            User user = new User(123123, "Santiago Ferraro", "Ferri");
            Game.AddPlayer(user);
            User user2 = new User(1436, "Pilar Machado", "Pili");
            Game.AddPlayer(user2);
            Game.Win(user);
            Assert.That(user.Stats.Wins == 1);
            Assert.That(user2.Stats.Losses == 1);
        }
    }
}