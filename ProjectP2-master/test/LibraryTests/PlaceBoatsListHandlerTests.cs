using NUnit.Framework;
using Library.BotUtils;
using Library.GameUtils;
using Library.UserUtils;
using Library.ContainerUtils;
using Library.Handlers;
using Library.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;


namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a listar los botes.
    /// </summary>
    public class PlaceBoatsListHandlerTests
    {
        /// <summary>
        /// Prueba si identifica que no se ha colocado ningun barco y se lo comunica al usuario.
        /// </summary>
        [Test]
        public void NoPlaceBoats()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10987, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10988, "Santiago Ferraro", "Ferri");

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10987, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\nNo has colocado ningún barco.";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar un Sailboat.
        /// </summary>
        [Test]
        public void ListSailBoat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10989, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10990, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));

            var boatType = "Sailboat";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10989, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -sailBoat - A,0 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar un Vessel.
        /// </summary>
        [Test]
        public void ListVessel()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10991, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10992, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));

            var boatType = "vessel";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10991, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -vessel - A,0 A,1 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar un Submarine.
        /// </summary>
        [Test]
        public void ListSubmarine()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10993, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10994, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));
            coords.Add(new Tuple<int, int>(0, 2));

            var boatType = "submarine";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10993, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -submarine - A,0 A,1 A,2 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar un Cruise.
        /// </summary>
        [Test]
        public void ListCruise()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10995, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10996, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));
            coords.Add(new Tuple<int, int>(0, 2));
            coords.Add(new Tuple<int, int>(0, 3));

            var boatType = "cruise";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10995, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -cruise - A,0 A,1 A,2 A,3 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar un Carrier.
        /// </summary>
        [Test]
        public void ListCarrier()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10997, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(10998, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));
            coords.Add(new Tuple<int, int>(0, 1));
            coords.Add(new Tuple<int, int>(0, 2));
            coords.Add(new Tuple<int, int>(0, 3));
            coords.Add(new Tuple<int, int>(0, 4));

            var boatType = "carrier";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10997, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -carrier - A,0 A,1 A,2 A,3 A,4 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar dos botes del mismo tipo.
        /// </summary>
        [Test]
        public void List2BoatsSameType()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(10999, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(11000, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));

            List<Tuple<int, int>> coords2 = new List<Tuple<int, int>>();
            coords2.Add(new Tuple<int, int>(0, 1));

            var boatType = "Sailboat";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            var boatType2 = "Sailboat";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType2, StringComparison.OrdinalIgnoreCase))
                {
                    boatType2 = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            game.Players[pablo].AddBoat(boatType2, coords2);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(10999, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -sailBoat - A,0 1 -sailBoat - A,1 ";

            Assert.AreEqual(expected, handler);

        }

        /// <summary>
        /// Prueba si es posible listar dos botes de diferentes tipos.
        /// </summary>
        [Test]
        public void List2BoatsDiffType()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            StringBuilder textResult = new StringBuilder();

            User pablo = userContainer.AddElement(11001, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(11002, "Santiago Ferraro", "Ferri");
            BoatsManager bm = Singleton<BoatsManager>.Instance;

            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);
    
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            coords.Add(new Tuple<int, int>(0, 0));

            List<Tuple<int, int>> coords2 = new List<Tuple<int, int>>();
            coords2.Add(new Tuple<int, int>(3, 0));
            coords2.Add(new Tuple<int, int>(3, 1));
            coords2.Add(new Tuple<int, int>(3, 2));
            coords2.Add(new Tuple<int, int>(3, 3));
            coords2.Add(new Tuple<int, int>(3, 4));

            var boatType = "Sailboat";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType, StringComparison.OrdinalIgnoreCase))
                {
                    boatType = tag;
                    break;
                }
            }

            var boatType2 = "carrier";

            foreach (string tag in bm.GetAvailableTags())
            {
                if (tag.Equals(boatType2, StringComparison.OrdinalIgnoreCase))
                {
                    boatType2 = tag;
                    break;
                }
            }

            game.Players[pablo].AddBoat(boatType, coords);
            game.Players[pablo].AddBoat(boatType2, coords2);
            PlaceBoatsListHandler placeBoatsListHandler = new PlaceBoatsListHandler();
            Message message = new Message(11001, "/boat list");
            
            string handler = placeBoatsListHandler.Handle(message);
            string expected = "Tus botes (ID - tipo - (coordenadas)):\n0 -sailBoat - A,0 1 -carrier - D,0 D,1 D,2 D,3 D,4 ";

            Assert.AreEqual(expected, handler);

        }
    }
}