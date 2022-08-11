// -----------------------------------------------------------------------
// <copyright file="GameBoardsHandlerTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Library;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.GameUtils;
using Library.Handlers;
using Library.UserUtils;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a GameBoardsHandler.
    /// </summary>
    public class GameBoardsHandlerTests
    {
        /// <summary>
        /// Prepara los tests para correr.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            BattleShipSettings.Instance.UsedBot = new TestBot();
        }

        /// <summary>
        /// Impresión de board para una board vacía.
        /// </summary>
        [Test]
        public void CorrectPrintEmptyLargeBoard()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pablo = userContainer.AddElement(2, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(398009, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");
            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
            Assert.That(game.Players.ContainsKey(pablo));
            Assert.That(game.Players.ContainsKey(santiago));
            Assert.That(game.GameStatus != GameStatus.Finished);
            pablo.UserStatus = UserStatus.Playing;
            santiago.UserStatus = UserStatus.Playing;
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();
            Message message = new Message(2, "/boards");
            string actual = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expected = "Tu board:\n\n\n" + game.Players[pablo].GetPrintableBoard(true) + "\n\nBoard de Ferri:\n\n\n" + game.Players[santiago].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Impresión de board para una board con bote.
        /// </summary>
        [Test]
        public void CorrectPrintLargeBoardWithBoats()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pilar = userContainer.AddElement(4, "Pilar Machado", "Pili");
            User leandro = userContainer.AddElement(534, "Leandro Alfonso", "Lea");
            Game game = gameContainer.AddElement(true, "L");
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();

            Message message = new Message(4, "/boards");
            game.AddPlayer(pilar);
            game.AddPlayer(leandro);
            pilar.UserStatus = UserStatus.Playing;
            leandro.UserStatus = UserStatus.Playing;
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            game.Players[pilar].AddBoat("cruise", coords);
            game.Players[leandro].AddBoat("cruise", coords);
            string handler = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expectedString = "Tu board:\n\n\n" + game.Players[pilar].GetPrintableBoard(true) + "\n\nBoard de Lea:\n\n\n" + game.Players[leandro].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expectedString, handler);
        }

        /// <summary>
        /// Impresión de board para una board vacía.
        /// </summary>
        [Test]
        public void CorrectPrintEmptyMediumBoard()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pablo = userContainer.AddElement(5, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(6, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "M");
            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
            Assert.That(game.Players.ContainsKey(pablo));
            Assert.That(game.Players.ContainsKey(santiago));
            Assert.That(game.GameStatus != GameStatus.Finished);
            pablo.UserStatus = UserStatus.Playing;
            santiago.UserStatus = UserStatus.Playing;
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();
            Message message = new Message(5, "/boards");
            string actual = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expected = "Tu board:\n\n\n" + game.Players[pablo].GetPrintableBoard(true) + "\n\nBoard de Ferri:\n\n\n" + game.Players[santiago].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Impresión de board para una board con bote.
        /// </summary>
        [Test]
        public void CorrectPrintMediumBoardWithBoats()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pilar = userContainer.AddElement(7, "Pilar Machado", "Pili");
            User leandro = userContainer.AddElement(8, "Leandro Alfonso", "Lea");
            Game game = gameContainer.AddElement(true, "M");
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();

            Message message = new Message(7, "/boards");
            game.AddPlayer(pilar);
            game.AddPlayer(leandro);
            pilar.UserStatus = UserStatus.Playing;
            leandro.UserStatus = UserStatus.Playing;
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            game.Players[pilar].AddBoat("cruise", coords);
            game.Players[leandro].AddBoat("cruise", coords);
            string handler = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expectedString = "Tu board:\n\n\n" + game.Players[pilar].GetPrintableBoard(true) + "\n\nBoard de Lea:\n\n\n" + game.Players[leandro].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expectedString, handler);
        }

        /// <summary>
        /// Impresión de board para una board vacía.
        /// </summary>
        [Test]
        public void CorrectPrintEmptySmallBoard()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pablo = userContainer.AddElement(9, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");
            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
            Assert.That(game.Players.ContainsKey(pablo));
            Assert.That(game.Players.ContainsKey(santiago));
            Assert.That(game.GameStatus != GameStatus.Finished);
            pablo.UserStatus = UserStatus.Playing;
            santiago.UserStatus = UserStatus.Playing;
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();
            Message message = new Message(9, "/boards");
            string actual = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expected = "Tu board:\n\n\n" + game.Players[pablo].GetPrintableBoard(true) + "\n\nBoard de Ferri:\n\n\n" + game.Players[santiago].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Impresión de board para una board con bote.
        /// </summary>
        [Test]
        public void CorrectPrintSmallBoardWithBoats()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;
            User pilar = userContainer.AddElement(11, "Pilar Machado", "Pili");
            User leandro = userContainer.AddElement(12, "Leandro Alfonso", "Lea");
            Game game = gameContainer.AddElement(true, "S");
            GameBoardsHandler gameBoardHandler = new GameBoardsHandler();

            Message message = new Message(11, "/boards");
            game.AddPlayer(pilar);
            game.AddPlayer(leandro);
            pilar.UserStatus = UserStatus.Playing;
            leandro.UserStatus = UserStatus.Playing;
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            game.Players[pilar].AddBoat("cruise", coords);
            game.Players[leandro].AddBoat("cruise", coords);
            string handler = gameBoardHandler.Handle(message);
            IBot testBot = new TestBot();
            string expectedString = "Tu board:\n\n\n" + game.Players[pilar].GetPrintableBoard(true) + "\n\nBoard de Lea:\n\n\n" + game.Players[leandro].GetPrintableBoard(false) + "\n\n";

            Assert.AreEqual(expectedString, handler);
        }
    }
}