using NUnit.Framework;
using System.Collections.Generic;
using Library.BoardUtils;
using Library.BoatUtils;
using System;

namespace LibraryTests
{
    /// <summary>
    /// Test de la clase Board.
    /// </summary>
    public class BoardTests
    {

        /// <summary>
        /// Comprobando el tamaño del tablero pequeño.
        /// </summary>
        [Test]
        public void SmallBoardSize()
        {
            Board SmallBoardSize = new SmallBoard();
            const int expected = 5;
            Assert.AreEqual(expected, SmallBoardSize.Size);
        }

        /// <summary>
        /// Comprobando el tamaño del tablero mediano.
        /// </summary>
        [Test]
        public void MediumBoardSize()
        {
            Board MediumBoardSize = new MediumBoard();
            const int expected = 10;
            Assert.AreEqual(expected, MediumBoardSize.Size);
        }

        /// <summary>
        /// Comprobar el tamaño del tablero grande.
        /// </summary>
        [Test]
        public void LargeBoardSize()
        {
            Board LargeBoardSize = new LargeBoard();
            const int expected = 15;
            Assert.AreEqual(expected, LargeBoardSize.Size);
        }

        /// <summary>
        /// Añadir AircraftCarrier a un tablero pequeño
        /// </summary>
        [Test]
        public void AddAircraftCarrierToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };

            Board AddAircraftCarrierToSmallBoard = new SmallBoard();
            AddAircraftCarrierToSmallBoard.AddBoat("carrier", positions);

            int count = 0;
            for (int i = 0; i < AddAircraftCarrierToSmallBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 5;
            Assert.AreEqual(expected, count);
        }


        /// <summary>
        /// Añadir Cruise a un tablero pequeño
        /// </summary>
        [Test]
        public void AddCruiseToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Board AddCruiseToSmallBoard = new SmallBoard();
            AddCruiseToSmallBoard.AddBoat("cruise", positions);
            int count = 0;
            for (int i = 0; i < AddCruiseToSmallBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 4;
            Assert.AreEqual(expected, count);

        }

        /// <summary>
        /// Añadir Submarine a un tablero pequeño
        /// </summary>
        [Test]
        public void AddSubmarineToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Board addsubmarinetosmallBoard = new SmallBoard();
            addsubmarinetosmallBoard.AddBoat("submarine", positions);
            int count = 0;
            for (int i = 0; i < addsubmarinetosmallBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 3;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Vessel a un tablero pequeño
        /// </summary>
        [Test]
        public void AddVesselToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Board addvesseltosmallboard = new SmallBoard();
            addvesseltosmallboard.AddBoat("vessel", positions);
            int count = 0;
            for (int i = 0; i < addvesseltosmallboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 2;
            Assert.AreEqual(expected, count);
        }
        /// <summary>
        /// Añadir Sailboat a un tablero pequeño
        /// </summary>
        [Test]
        public void AddSailboatToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Board addsailboattosmallboard = new SmallBoard();
            addsailboattosmallboard.AddBoat("sailBoat", positions);
            int count = 0;
            for (int i = 0; i < addsailboattosmallboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 1;
            Assert.AreEqual(expected, count);
        }
        /// <summary>
        /// Añadir AircraftCarrier a un tablero mediano.
        /// </summary>
        [Test]
        public void AddAircraftCarrierToMediumBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };
            Board AddAircraftCarrierToMediumBoard = new MediumBoard();
            AddAircraftCarrierToMediumBoard.AddBoat("carrier", positions);
            int count = 0;
            for (int i = 0; i < AddAircraftCarrierToMediumBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 5;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Cruise a un tablero mediano.
        /// </summary>
        [Test]
        public void AddCruiseToMediumBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Board AddCruiseToMediumBoard = new MediumBoard();
            AddCruiseToMediumBoard.AddBoat("cruise", positions);
            int count = 0;
            for (int i = 0; i < AddCruiseToMediumBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 4;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Submarine a un tablero mediano.
        /// </summary>
        [Test]
        public void AddSubmarineToMediumBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Board addsubmarinetomediumboard = new MediumBoard();
            addsubmarinetomediumboard.AddBoat("submarine", positions);
            int count = 0;
            for (int i = 0; i < addsubmarinetomediumboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 3;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Vessel a un tablero mediano.
        /// </summary>
        [Test]
        public void AddVesselToMediumBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Board addvesseltomediumboard = new MediumBoard();
            addvesseltomediumboard.AddBoat("vessel", positions);
            int count = 0;
            for (int i = 0; i < addvesseltomediumboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 2;
            Assert.AreEqual(expected, count);
        }
        /// <summary>
        /// Añadir Sailboat a un tablero mediano.
        /// </summary>
        [Test]
        public void AddSailboatToMediumBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Board addsailboattomediumboard = new MediumBoard();
            addsailboattomediumboard.AddBoat("sailBoat", positions);
            int count = 0;
            for (int i = 0; i < addsailboattomediumboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 1;
            Assert.AreEqual(expected, count);
        }
        /// <summary>
        /// Añadir AircraftCarrier a un tablero grande.
        /// </summary>
        [Test]
        public void AddAircraftCarrierToLargeBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };
            Board AddAircraftCarrierToLargeBoard = new LargeBoard();
            AddAircraftCarrierToLargeBoard.AddBoat("carrier", positions);
            int count = 0;
            for (int i = 0; i < AddAircraftCarrierToLargeBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 5;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Cruise a un tablero grande.
        /// </summary>
        [Test]
        public void AddCruiseToLargeBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Board AddCruiseToLargeBoard = new LargeBoard();
            AddCruiseToLargeBoard.AddBoat("cruise", positions);
            int count = 0;
            for (int i = 0; i < AddCruiseToLargeBoard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 4;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Submarine a un tablero grande.
        /// </summary>
        [Test]
        public void AddSubmarineToLargeBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Board addsubmarinetolargeboard = new LargeBoard();
            addsubmarinetolargeboard.AddBoat("submarine", positions);
            int count = 0;
            for (int i = 0; i < addsubmarinetolargeboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 3;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Vessel a un tablero grande.
        /// </summary>
        [Test]
        public void AddVesselToLargeBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Board addvesseltolargeboard = new LargeBoard();
            addvesseltolargeboard.AddBoat("vessel", positions);
            int count = 0;
            for (int i = 0; i < addvesseltolargeboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 2;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Añadir Sailboat a un tablero grande.
        /// </summary>
        [Test]
        public void AddSailboatToLargeBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Board addsailboattolargeboard = new LargeBoard();
            addsailboattolargeboard.AddBoat("sailBoat", positions);
            int count = 0;
            for (int i = 0; i < addsailboattolargeboard.Boats[0].Positions.Count; i++)
            {
                count++;
            }

            const int expected = 1;
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Remover AircraftCarrier de un tablero pequeño.
        /// </summary>
        [Test]
        public void RemoveAircraftCarrierToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };
            Board rvaircrafttosmallboard = new SmallBoard();
            Boat aircraft = rvaircrafttosmallboard.AddBoat("carrier", positions);
            rvaircrafttosmallboard.RemoveBoat(aircraft);

            const int expected = 0;
            Assert.AreEqual(expected, rvaircrafttosmallboard.Boats.Count);
        }


        /// <summary>
        /// Remover Cruise de un tablero pequeño.
        /// </summary>
        [Test]
        public void RemoveCruiseToSmallBoard()
        {
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Board rvcruisetosmallboard = new SmallBoard();
            Boat cruise = rvcruisetosmallboard.AddBoat("cruise", positions);
            rvcruisetosmallboard.RemoveBoat(cruise);

            const int expected = 0;
            Assert.AreEqual(expected, rvcruisetosmallboard.Boats.Count);
        }

        /// <summary>
        /// Remover Submarine de un tablero pequeño.
        /// </summary>
        [Test]
        public void RemoveSubmarineToSmallBoard()
        {
            Board rvsmallboard = new SmallBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Boat submarine = rvsmallboard.AddBoat("submarine", positions);
            rvsmallboard.RemoveBoat(submarine);

            const int expected = 0;
            Assert.AreEqual(expected, rvsmallboard.Boats.Count);
        }

        /// <summary>
        /// Remover Vessel de un tablero pequeño.
        /// </summary>
        [Test]
        public void RemoveVesselToSmallBoard()
        {
            Board rvsmallboard = new SmallBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Board rvvesseltosmallboard = new SmallBoard();
            Boat vessel = rvvesseltosmallboard.AddBoat("vessel", positions);
            rvvesseltosmallboard.RemoveBoat(vessel);

            const int expected = 0;
            Assert.AreEqual(expected, rvvesseltosmallboard.Boats.Count);
        }
        /// <summary>
        /// Remover Sailboat de un tablero pequeño.
        /// </summary>
        [Test]
        public void RemoveSailboatToSmallBoard()
        {
            Board rvsmallboard = new SmallBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Boat sailboat = rvsmallboard.AddBoat("sailBoat", positions);
            rvsmallboard.RemoveBoat(sailboat);

            const int expected = 0;
            Assert.AreEqual(expected, rvsmallboard.Boats.Count);
        }
        /// <summary>
        /// Remover AircraftCarrier de un tablero mediano.
        /// </summary>
        [Test]
        public void RemoveAircraftCarrierToMediumBoard()
        {
            Board rvmediumboard = new MediumBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };
            Boat aircraft = rvmediumboard.AddBoat("carrier", positions);
            rvmediumboard.RemoveBoat(aircraft);

            const int expected = 0;
            Assert.AreEqual(expected, rvmediumboard.Boats.Count);
        }

        /// <summary>
        /// Remover Cruise de un tablero mediano.
        /// </summary>
        [Test]
        public void RemoveCruiseToMediumBoard()
        {
            Board rvmediumboard = new MediumBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Boat cruise = rvmediumboard.AddBoat("cruise", positions);
            rvmediumboard.RemoveBoat(cruise);

            const int expected = 0;
            Assert.AreEqual(expected, rvmediumboard.Boats.Count);
        }

        /// <summary>
        /// Remover Submarine de un tablero mediano.
        /// </summary>
        [Test]
        public void RemoveSubmarineToMediumBoard()
        {
            Board rvmediumboard = new MediumBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Boat submarine = rvmediumboard.AddBoat("submarine", positions);
            rvmediumboard.RemoveBoat(submarine);

            const int expected = 0;
            Assert.AreEqual(expected, rvmediumboard.Boats.Count);
        }

        /// <summary>
        /// Remover Vessel de un tablero mediano.
        /// </summary>
        [Test]
        public void RemoveVesselToMediumBoard()
        {
            Board rvmediumboard = new MediumBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Board RemoveVesselToMediumBoard = new MediumBoard();
            Boat vessel = RemoveVesselToMediumBoard.AddBoat("vessel", positions);
            RemoveVesselToMediumBoard.RemoveBoat(vessel);

            const int expected = 0;
            Assert.AreEqual(expected, RemoveVesselToMediumBoard.Boats.Count);
        }
        /// <summary>
        /// Remover Sailboat de un tablero mediano.
        /// </summary>
        [Test]
        public void RemoveSailboatToMediumBoard()
        {
            Board rvmediumboard = new MediumBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Boat sailboat = rvmediumboard.AddBoat("sailBoat", positions);
            rvmediumboard.RemoveBoat(sailboat);

            const int expected = 0;
            Assert.AreEqual(expected, rvmediumboard.Boats.Count);
        }
        /// <summary>
        /// Remover AircraftCarrier de un tablero grande.
        /// </summary>
        [Test]
        public void RemoveAircraftCarrierToLargeBoard()
        {
            Board rvlargeboardaircraft = new LargeBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(4, 0),
            };
            Boat aircraft = rvlargeboardaircraft.AddBoat("carrier", positions);
            rvlargeboardaircraft.RemoveBoat(aircraft);

            const int expected = 0;
            Assert.AreEqual(expected, rvlargeboardaircraft.Boats.Count);
        }

        /// <summary>
        /// Remover Cruise de un tablero grande.
        /// </summary>
        [Test]
        public void RemoveCruiseToLargeBoard()
        {
            Board rvlargeboardcruise = new LargeBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(3, 0),
            };
            Boat cruise = rvlargeboardcruise.AddBoat("cruise", positions);
            rvlargeboardcruise.RemoveBoat(cruise);

            const int expected = 0;
            Assert.AreEqual(expected, rvlargeboardcruise.Boats.Count);
        }

        /// <summary>
        /// Remover Submarine de un tablero grande.
        /// </summary>
        [Test]
        public void RemoveSubmarineToLargeBoard()
        {
            Board rvlargeboardsubmarine = new LargeBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0),
            };
            Boat submarine = rvlargeboardsubmarine.AddBoat("submarine", positions);
            rvlargeboardsubmarine.RemoveBoat(submarine);

            const int expected = 0;
            Assert.AreEqual(expected, rvlargeboardsubmarine.Boats.Count);
        }

        /// <summary>
        /// Remover Vessel de un tablero grande.
        /// </summary>
        [Test]
        public void RemoveVesselToLargeBoard()
        {
            Board rvlargeboardvessel = new LargeBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
            };
            Boat vessel = rvlargeboardvessel.AddBoat("vessel", positions);
            rvlargeboardvessel.RemoveBoat(vessel);

            const int expected = 0;
            Assert.AreEqual(expected, rvlargeboardvessel.Boats.Count);
        }

        /// <summary>
        /// Remover Sailboat de un tablero grande.
        /// </summary>
        [Test]
        public void RemoveSailboatToLargeBoard()
        {
            Board rvlargeboardsailboat = new LargeBoard();
            List<Tuple<int, int>> positions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 0),
            };
            Boat sailboat = rvlargeboardsailboat.AddBoat("sailBoat", positions);
            rvlargeboardsailboat.RemoveBoat(sailboat);

            const int expected = 0;
            Assert.AreEqual(expected, rvlargeboardsailboat.Boats.Count);
        }
    }
}