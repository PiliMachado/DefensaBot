using NUnit.Framework;
using Library.Handlers;
using System.Collections.Generic;
using Library.ContainerUtils;
using Library.UserUtils;
using Library.Exceptions;
using Library.BotUtils;
using Library.Handlers;
using Library.GameUtils;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a PlaceBoatsInfoHandler.
    /// </summary>
    public class PlaceBoatsInfoHandlerTest
    {
        /// <summary>
        /// Prueba caso de una interaccion correcta para una Board L.
        /// </summary>
        [Test]
        public void FullyCorrectInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(321, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(4321, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsInfoHandler placeBoatsInfoHandler = new PlaceBoatsInfoHandler();
            
            matchHandler.SetNext(placeBoatsInfoHandler);
            game.StartPlacingBoats();
            Message message = new Message(321, "/boat info");
            string actual = matchHandler.Handle(message);
            Assert.AreEqual($"Botes necesarios para tabla L (15x15):\nsailBoat x7\nvessel x2\nsubmarine x2\ncruise x2\ncarrier x4\n\nBotes faltantes:\nsailBoat (largo: 1) x7\nvessel (largo: 2) x2\nsubmarine (largo: 3) x2\ncruise (largo: 4) x2\ncarrier (largo: 5) x4\n", actual);
        }

        /// <summary>
        /// Prueba caso de una interaccion correcta para una Board M.
        /// </summary>
        [Test]
        public void FullyCorrectInteractionM()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(12568, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(89654, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "M");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsInfoHandler placeBoatsInfoHandler = new PlaceBoatsInfoHandler();
            
            matchHandler.SetNext(placeBoatsInfoHandler);
            game.StartPlacingBoats();
            Message message = new Message(12568, "/boat info");
            string actual = matchHandler.Handle(message);
            Assert.AreEqual($"Botes necesarios para tabla M (10x10):\nsailBoat x3\nvessel x2\nsubmarine x1\ncruise x1\ncarrier x1\n\nBotes faltantes:\nsailBoat (largo: 1) x3\nvessel (largo: 2) x2\nsubmarine (largo: 3) x1\ncruise (largo: 4) x1\ncarrier (largo: 5) x1\n", actual);
        }
        
        /// <summary>
        /// Prueba caso de una interaccion correcta para una Board S.
        /// </summary>
        [Test]
        public void FullyCorrectInteractionS()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(456987, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(142563, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsInfoHandler placeBoatsInfoHandler = new PlaceBoatsInfoHandler();
            
            matchHandler.SetNext(placeBoatsInfoHandler);
            game.StartPlacingBoats();
            Message message = new Message(456987, "/boat info");
            string actual = matchHandler.Handle(message);
            Assert.AreEqual($"Botes necesarios para tabla S (5x5):\nsailBoat x2\nvessel x1\ncarrier x1\n\nBotes faltantes:\nsailBoat (largo: 1) x2\nvessel (largo: 2) x1\ncarrier (largo: 5) x1\n", actual);
        }
    } 
}