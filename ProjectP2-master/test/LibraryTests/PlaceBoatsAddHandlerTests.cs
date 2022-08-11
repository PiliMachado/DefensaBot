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
using Library.BoardUtils;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a PlaceBoatsAddHandler.
    /// </summary>
    public class PlaceBoatsAddHandlerTests
    {
        /// <summary>
        /// Prueba un caso de añadir botes existoso en una board s.
        /// </summary>
        [Test]
        public void BoatdAddS()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(494856, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(9483012, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(494856, "/boat add sailBoat A1 A1");
            string actual = placeBoatsHandler.Handle(message);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,1 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[0] is SailBoat);
            
            Message message2 = new Message(494856, "/boat add sailBoat A2 A2");
            string actual2 = placeBoatsHandler.Handle(message2);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual2);
            List<Tuple<int, int>> positions2 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 2),
            };
            Boat sailBoat2 = new SailBoat(positions2);
            expected.Add(sailBoat2);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[1] is SailBoat);

            Message message3 = new Message(494856, "/boat add vessel B1 B2");
            string actual3 = placeBoatsHandler.Handle(message3);
            Assert.AreEqual($"Añadido barco de tipo vessel en las coordenadas ( B,1 B,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual3);
            List<Tuple<int, int>> positions3 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 2),
            };
            Boat vessel = new Vessel(positions3);
            expected.Add(vessel);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);   
            }
            Assert.That(game.Players[pili].Boats[2] is Vessel);

            Message message4 = new Message(494856, "/boat add carrier C0 C4");
            string actual4 = placeBoatsHandler.Handle(message4);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( C,0 C,1 C,2 C,3 C,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\nYa has añadido todos los botes necesarios! El juego iniciará cuando tu contrincante también los haya colocado.\n", actual4);
            List<Tuple<int, int>> positions4 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(2, 4),
            };
            Boat carrier = new AircraftCarrier(positions4);
            expected.Add(carrier);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            } 
            Assert.That(game.Players[pili].Boats[3] is AircraftCarrier);          
        }

        /// <summary>
        /// Prueba un caso de añadir botes existoso en una board M.
        /// </summary>
        [Test]
        public void BoatdAddM()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(789, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(930128, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "M");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(789, "/boat add sailBoat A1 A1");
            string actual = placeBoatsHandler.Handle(message);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,1 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[0] is SailBoat);
            
            Message message2 = new Message(789, "/boat add sailBoat A2 A2");
            string actual2 = placeBoatsHandler.Handle(message2);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual2);
            List<Tuple<int, int>> positions2 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 2),
            };
            Boat sailBoat2 = new SailBoat(positions2);
            expected.Add(sailBoat2);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[1] is SailBoat);

            Message message3 = new Message(789, "/boat add sailBoat A3 A3");
            string actual3 = placeBoatsHandler.Handle(message3);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,3 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual3);
            List<Tuple<int, int>> positions3 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 3),
            };
            Boat sailBoat3 = new SailBoat(positions3);
            expected.Add(sailBoat3);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[2] is SailBoat);

            Message message4 = new Message(789, "/boat add vessel B1 B2");
            string actual4 = placeBoatsHandler.Handle(message4);
            Assert.AreEqual($"Añadido barco de tipo vessel en las coordenadas ( B,1 B,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual4);
            List<Tuple<int, int>> positions4 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 2),
            };
            Boat vessel = new Vessel(positions4);
            expected.Add(vessel);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[3] is Vessel);

            Message message5 = new Message(789, "/boat add vessel B4 B5");
            string actual5 = placeBoatsHandler.Handle(message5);
            Assert.AreEqual($"Añadido barco de tipo vessel en las coordenadas ( B,4 B,5 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual5);
            List<Tuple<int, int>> positions5 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(1, 5),
            };
            Boat vessel1 = new Vessel(positions5);
            expected.Add(vessel1);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[4] is Vessel);

            Message message6 = new Message(789, "/boat add submarine D1 D3");
            string actual6 = placeBoatsHandler.Handle(message6);
            Assert.AreEqual($"Añadido barco de tipo submarine en las coordenadas ( D,1 D,2 D,3 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual6);
            List<Tuple<int, int>> positions6 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(3, 3),
            };
            Boat submarine = new Submarine(positions6);
            expected.Add(submarine);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[5] is Submarine);

            Message message7 = new Message(789, "/boat add cruise E1 E4");
            string actual7 = placeBoatsHandler.Handle(message7);
            Assert.AreEqual($"Añadido barco de tipo cruise en las coordenadas ( E,1 E,2 E,3 E,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual7);
            List<Tuple<int, int>> positions7 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(4, 1),
                new Tuple<int, int>(4, 2),
                new Tuple<int, int>(4, 3),
                new Tuple<int, int>(4, 4),
            };
            Boat cruise = new Cruise(positions7);
            expected.Add(cruise);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[6] is Cruise);

            Message message8 = new Message(789, "/boat add carrier C0 C4");
            string actual8 = placeBoatsHandler.Handle(message8);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( C,0 C,1 C,2 C,3 C,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\nYa has añadido todos los botes necesarios! El juego iniciará cuando tu contrincante también los haya colocado.\n", actual8);
            List<Tuple<int, int>> positions8 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(2, 4),
            };
            Boat carrier = new AircraftCarrier(positions8);
            expected.Add(carrier);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[7] is AircraftCarrier);
        }

        /// <summary>
        /// Prueba un caso de añadir botes existoso en una board L.
        /// </summary>
        [Test]
        public void BoatdAddL()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(84839, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(9348437, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(84839, "/boat add sailBoat A1 A1");
            string actual = placeBoatsHandler.Handle(message);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,1 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual);
            List<Boat> expected = new List<Boat>();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
            };
            Boat sailBoat = new SailBoat(positions);
            expected.Add(sailBoat);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[0] is SailBoat);
            
            Message message2 = new Message(84839, "/boat add sailBoat A2 A2");
            string actual2 = placeBoatsHandler.Handle(message2);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual2);
            List<Tuple<int, int>> positions2 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 2),
            };
            Boat sailBoat2 = new SailBoat(positions2);
            expected.Add(sailBoat2);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[1] is SailBoat);

            Message message3 = new Message(84839, "/boat add sailBoat A3 A3");
            string actual3 = placeBoatsHandler.Handle(message3);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,3 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual3);
            List<Tuple<int, int>> positions3 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 3),
            };
            Boat sailBoat3 = new SailBoat(positions3);
            expected.Add(sailBoat3);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[2] is SailBoat);

            Message message4 = new Message(84839, "/boat add vessel B1 B2");
            string actual4 = placeBoatsHandler.Handle(message4);
            Assert.AreEqual($"Añadido barco de tipo vessel en las coordenadas ( B,1 B,2 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual4);
            List<Tuple<int, int>> positions4 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 2),
            };
            Boat vessel = new Vessel(positions4);
            expected.Add(vessel);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[3] is Vessel);

            Message message5 = new Message(84839, "/boat add vessel B4 B5");
            string actual5 = placeBoatsHandler.Handle(message5);
            Assert.AreEqual($"Añadido barco de tipo vessel en las coordenadas ( B,4 B,5 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual5);
            List<Tuple<int, int>> positions5 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(1, 5),
            };
            Boat vessel1 = new Vessel(positions5);
            expected.Add(vessel1);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[4] is Vessel);

            Message message6 = new Message(84839, "/boat add submarine D1 D3");
            string actual6 = placeBoatsHandler.Handle(message6);
            Assert.AreEqual($"Añadido barco de tipo submarine en las coordenadas ( D,1 D,2 D,3 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual6);
            List<Tuple<int, int>> positions6 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(3, 3),
            };
            Boat submarine = new Submarine(positions6);
            expected.Add(submarine);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[5] is Submarine);

             Message message7 = new Message(84839, "/boat add cruise E1 E4");
            string actual7 = placeBoatsHandler.Handle(message7);
            Assert.AreEqual($"Añadido barco de tipo cruise en las coordenadas ( E,1 E,2 E,3 E,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual7);
            List<Tuple<int, int>> positions7 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(4, 1),
                new Tuple<int, int>(4, 2),
                new Tuple<int, int>(4, 3),
                new Tuple<int, int>(4, 4),
            };
            Boat cruise = new Cruise(positions7);
            expected.Add(cruise);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[6] is Cruise);

            Message message8 = new Message(84839, "/boat add carrier C0 C4");
            string actual8 = placeBoatsHandler.Handle(message8);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( C,0 C,1 C,2 C,3 C,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual8);
            List<Tuple<int, int>> positions8 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(2, 4),
            };
            Boat carrier = new AircraftCarrier(positions8);
            expected.Add(carrier);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[7] is AircraftCarrier);

            Message message9 = new Message(84839, "/boat add sailBoat A4 A4");
            string actual9 = placeBoatsHandler.Handle(message9);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual9);
            List<Tuple<int, int>> positions9 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 4),
            };
            Boat sailBoat4 = new SailBoat(positions9);
            expected.Add(sailBoat4);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[8] is SailBoat);

            Message message10 = new Message(84839, "/boat add sailBoat A5 A5");
            string actual10 = placeBoatsHandler.Handle(message10);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,5 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual10);
            List<Tuple<int, int>> positions10 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 5),
            };
            Boat sailBoat5 = new SailBoat(positions10);
            expected.Add(sailBoat5);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[9] is SailBoat);

            Message message11 = new Message(84839, "/boat add sailBoat A6 A6");
            string actual11 = placeBoatsHandler.Handle(message11);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,6 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual11);
            List<Tuple<int, int>> positions11 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 6),
            };
            Boat sailBoat6 = new SailBoat(positions11);
            expected.Add(sailBoat6);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[10] is SailBoat);

            Message message12 = new Message(84839, "/boat add sailBoat A7 A7");
            string actual12 = placeBoatsHandler.Handle(message12);
            Assert.AreEqual($"Añadido barco de tipo sailBoat en las coordenadas ( A,7 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual12);
            List<Tuple<int, int>> positions12 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 7),
            };
            Boat sailBoat7 = new SailBoat(positions12);
            expected.Add(sailBoat7);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[11] is SailBoat);

            Message message13 = new Message(84839, "/boat add submarine D4 D6");
            string actual13 = placeBoatsHandler.Handle(message13);
            Assert.AreEqual($"Añadido barco de tipo submarine en las coordenadas ( D,4 D,5 D,6 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual13);
            List<Tuple<int, int>> positions13 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(3, 5),
                new Tuple<int, int>(3, 6),
            };
            Boat submarine1 = new Submarine(positions13);
            expected.Add(submarine1);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[12] is Submarine);

            Message message14 = new Message(84839, "/boat add cruise E6 E9");
            string actual14 = placeBoatsHandler.Handle(message14);
            Assert.AreEqual($"Añadido barco de tipo cruise en las coordenadas ( E,6 E,7 E,8 E,9 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual14);
            List<Tuple<int, int>> positions14 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(4, 6),
                new Tuple<int, int>(4, 7),
                new Tuple<int, int>(4, 8),
                new Tuple<int, int>(4, 9),
            };
            Boat cruise1 = new Cruise(positions14);
            expected.Add(cruise1);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions); 
            }
            Assert.That(game.Players[pili].Boats[13] is Cruise);

            Message message15 = new Message(84839, "/boat add carrier C8 C12");
            string actual15 = placeBoatsHandler.Handle(message15);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( C,8 C,9 C,10 C,11 C,12 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual15);
            List<Tuple<int, int>> positions15 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(2, 8),
                new Tuple<int, int>(2, 9),
                new Tuple<int, int>(2, 10),
                new Tuple<int, int>(2, 11),
                new Tuple<int, int>(2, 12),
            };
            Boat carrier1 = new AircraftCarrier(positions15);
            expected.Add(carrier1);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[14] is AircraftCarrier);

            Message message16 = new Message(84839, "/boat add carrier F8 F12");
            string actual16 = placeBoatsHandler.Handle(message16);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( F,8 F,9 F,10 F,11 F,12 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\n", actual16);
            List<Tuple<int, int>> positions16 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(5, 8),
                new Tuple<int, int>(5, 9),
                new Tuple<int, int>(5, 10),
                new Tuple<int, int>(5, 11),
                new Tuple<int, int>(5, 12),
            };
            Boat carrier2 = new AircraftCarrier(positions16);
            expected.Add(carrier2);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[15] is AircraftCarrier);

            Message message17 = new Message(84839, "/boat add carrier F0 F4");
            string actual17 = placeBoatsHandler.Handle(message17);
            Assert.AreEqual($"Añadido barco de tipo carrier en las coordenadas ( F,0 F,1 F,2 F,3 F,4 )\nPara comprobar cuantos barcos has añadido y cuantos te faltan, envía \"/boat info\"\nYa has añadido todos los botes necesarios! El juego iniciará cuando tu contrincante también los haya colocado.\n", actual17);
            List<Tuple<int, int>> positions17 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(5, 0),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(5, 2),
                new Tuple<int, int>(5, 3),
                new Tuple<int, int>(5, 4),
            };
            Boat carrier3 = new AircraftCarrier(positions17);
            expected.Add(carrier3);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Positions, game.Players[pili].Boats[i].Positions);
            }
            Assert.That(game.Players[pili].Boats[16] is AircraftCarrier);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar un tipo de bote invalido.
        /// </summary>
        [Test]
        public void InvalidTypeError()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(842743318, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(83472378, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(842743318, "/boat add comida A1 A1");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar una coordenada de bote invalida.
        /// </summary>
        [Test]
        public void InvalidCoords()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(2132041419, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(00192372, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(2132041419, "/boat add sailBoat 11 11");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);

            Message message2 = new Message(2132041419, "/boat add sailBoat A 1 A 1");
            bool catched2 = false;
            try
            {
                placeBoatsHandler.Handle(message2);
            }
            catch (InvalidBoatException e)
            {
                catched2 = true;
            }
            Assert.That(catched2);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar una coordenada de bote invalido,
        /// por estar fuera de la tabla.
        /// </summary>
        [Test]
        public void OutOfRangeError()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(1634547, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(01029381, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(1634547, "/boat add sailBoat A100 A100");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar una coordenada de bote invalido,
        /// por estar en diagonal.
        /// </summary>
        [Test]
        public void DiagonalBoteError()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(03921387, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(7237193, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(03921387, "/boat add vessel A1 B2");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar una coordenada de bote invalido,
        /// por poner un largo mayor o menor al del tipo.
        /// </summary>
        [Test]
        public void NotRightSizeError()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(3024822493, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(374732, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(3024822493, "/boat add vessel A1 A4");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);

            Message message2 = new Message(3024822493, "/boat add vessel A1 A1");
            bool catched2 = false;
            try
            {
                placeBoatsHandler.Handle(message2);
            }
            catch (InvalidBoatException e)
            {
                catched2 = true;
            }
            Assert.That(catched2);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote mandar un tipo que no esta habilitado
        /// para el gamemode.
        /// </summary>
        [Test]
        public void NotValidBoteTypeForGamemode()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(3181372, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(38198139, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(3181372, "/boat add submarine A1 A3");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }
        
        /// <summary>
        /// Test de a la hora de agregar un bote cuando ya has agregado todos.
        /// </summary>
        [Test]
        public void AlreadyAddedAllBotes()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(13817331, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(1291417421, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(13817331, "/boat add sailBoat A1 A1");
            placeBoatsHandler.Handle(message);
            Message message2 = new Message(13817331, "/boat add sailBoat A2 A2");
            placeBoatsHandler.Handle(message2);
            Message message3 = new Message(13817331, "/boat add vessel A3 A4");
            placeBoatsHandler.Handle(message3);
            Message message4 = new Message(13817331, "/boat add carrier B0 B4");
            placeBoatsHandler.Handle(message4);
            Message message5 = new Message(13817331, "/boat add sailBoat C1 C1");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message5);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }

        /// <summary>
        /// Test de a la hora de agregar un bote a coordenados donde ya hay uno.
        /// </summary>
        [Test]
        public void CannotHaveSameCoordsAsOtherBoats()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pili = userContainer.AddElement(3842434217, "Pilar Machado", "Pili");
            User santiago = userContainer.AddElement(02312488, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(pili);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            PlaceBoatsAddHandler placeBoatsHandler = new PlaceBoatsAddHandler();
        
            game.StartPlacingBoats();
            Message message = new Message(3842434217, "/boat add sailBoat A1 A1");
            placeBoatsHandler.Handle(message);
            Message message2 = new Message(3842434217, "/boat add sailBoat A1 A1");
            bool catched = false;
            try
            {
                placeBoatsHandler.Handle(message2);
            }
            catch (InvalidBoatException e)
            {
                catched = true;
            }
            Assert.That(catched);
        }
    } 
}