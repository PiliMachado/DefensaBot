using NUnit.Framework;
using Library.Handlers;
using System.Collections.Generic;
using Library.ContainerUtils;
using Library.UserUtils;
using System;
using Library.Exceptions;
using Library.BotUtils;
using Library.Handlers;
using Library.GameUtils;
using Library.BoatUtils;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a PlaceBoatRemoveHandler.
    /// </summary>
    public class PlaceBoatsRemoveHandlerTest
    {
        /// <summary>
        /// Prueba de remover un SailBoat
        /// </summary>
        [Test]
        public void RemoveSailBoat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(32679401, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(434521, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(32679401, "/boat add sailBoat A1 A1");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is SailBoat);
            Message message2 = new Message(32679401, "/boat remove 0 sailBoat");
            string actual2 = removeHandler.Handle(message2);
            Assert.AreEqual($"Eliminado bote con ID: 0, de tipo: sailBoat, en las coordenadas: ( 0,1 )\nVerifica las IDs de tus otros barcos, pueden haber cambiado.", actual2);
            expected.Remove(sailBoat);
            CollectionAssert.AreEqual(expected, game.Players[pili].Boats);
        }

        /// <summary>
        /// Prueba de remover un Vessel
        /// </summary>
        [Test]
        public void RemoveVessel()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(32838491, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(41029321, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(32838491, "/boat add vessel A1 A2");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
            };
            Boat vessel = new Vessel(positions);
            expected.Add(vessel);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is Vessel);
            Message message2 = new Message(32838491, "/boat remove 0 vessel");
            string actual2 = removeHandler.Handle(message2);
            Assert.AreEqual($"Eliminado bote con ID: 0, de tipo: vessel, en las coordenadas: ( 0,1 0,2 )\nVerifica las IDs de tus otros barcos, pueden haber cambiado.", actual2);
            expected.Remove(vessel);
            CollectionAssert.AreEqual(expected, game.Players[pili].Boats);
        }

        /// <summary>
        /// Prueba de remover un Cruise
        /// </summary>
        [Test]
        public void RemoveCruise()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(9494581, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(83924921, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(9494581, "/boat add cruise A1 A4");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(0, 4),
            };
            Boat cruise = new Cruise(positions);
            expected.Add(cruise);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is Cruise);
            Message message2 = new Message(9494581, "/boat remove 0 cruise");
            string actual2 = removeHandler.Handle(message2);
            Assert.AreEqual($"Eliminado bote con ID: 0, de tipo: cruise, en las coordenadas: ( 0,1 0,2 0,3 0,4 )\nVerifica las IDs de tus otros barcos, pueden haber cambiado.", actual2);
            expected.Remove(cruise);
            CollectionAssert.AreEqual(expected, game.Players[pili].Boats);
        }

        /// <summary>
        /// Prueba de remover un Submarine
        /// </summary>
        [Test]
        public void RemoveSubmarine()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(939180039, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(3938238, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(939180039, "/boat add submarine A1 A3");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
            };
            Boat submarine = new Submarine(positions);
            expected.Add(submarine);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is Submarine);
            Message message2 = new Message(939180039, "/boat remove 0 submarine");
            string actual2 = removeHandler.Handle(message2);
            Assert.AreEqual($"Eliminado bote con ID: 0, de tipo: submarine, en las coordenadas: ( 0,1 0,2 0,3 )\nVerifica las IDs de tus otros barcos, pueden haber cambiado.", actual2);
            expected.Remove(submarine);
            CollectionAssert.AreEqual(expected, game.Players[pili].Boats);
        }

        /// <summary>
        /// Prueba de remover un Carrier
        /// </summary>
        [Test]
        public void RemoveCarrier()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(1102039, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(229393948, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(1102039, "/boat add carrier A0 A4");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(0, 4),
            };
            Boat carrier = new AircraftCarrier(positions);
            expected.Add(carrier);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is AircraftCarrier);
            Message message2 = new Message(1102039, "/boat remove 0 carrier");
            string actual2 = removeHandler.Handle(message2);
            Assert.AreEqual($"Eliminado bote con ID: 0, de tipo: carrier, en las coordenadas: ( 0,0 0,1 0,2 0,3 0,4 )\nVerifica las IDs de tus otros barcos, pueden haber cambiado.", actual2);
            expected.Remove(carrier);
            CollectionAssert.AreEqual(expected, game.Players[pili].Boats);
        }

        /// <summary>
        /// Prueba de remover un bote usando letras
        /// </summary>
        [Test]
        public void RemoveWithoutNumber()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(32671, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(44930304, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(32671, "/boat add sailBoat A1 A1");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is SailBoat);
            Message message2 = new Message(32671, "/boat remove a sailBoat");
            bool catched = false;
            string errorMessage = "";
            try
            {
                removeHandler.Handle(message2);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
                errorMessage = e.Message;
            }
            Assert.AreEqual("El ID del bote a eliminar debe ser un número.", errorMessage);
            Assert.AreEqual(true, catched);
        }

        /// <summary>
        /// Prueba de remover un bote cuyo id no existe
        /// </summary>
        [Test]
        public void RemoveNonExistingBoat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(348392671, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(94239403, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler addHandler = new PlaceBoatsAddHandler();
            PlaceBoatsRemoveHandler removeHandler = new PlaceBoatsRemoveHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(348392671, "/boat add sailBoat A1 A1");
            addHandler.Handle(message);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);

            List<BoatPosition> coords = new List<BoatPosition>();
            foreach(Tuple<int, int> Tuple in positions)
            {
                coords.Add(new BoatPosition(Tuple.Item1, Tuple.Item2));
            }
            Assert.AreEqual(game.Players[pili].Boats[0].Positions, coords);
            Assert.AreEqual(true, game.Players[pili].Boats[0] is SailBoat);
            Message message2 = new Message(348392671, "/boat remove 3 sailBoat");
            bool catched = false;
            string errorMessage = "";
            try
            {
                removeHandler.Handle(message2);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
                errorMessage = e.Message;
            }
            Assert.AreEqual("El bote a eliminar no existe, verifica las IDs de tus botes.", errorMessage);
            Assert.AreEqual(true, catched);
        }
    } 
}