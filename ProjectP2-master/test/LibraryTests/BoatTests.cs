using NUnit.Framework;
using System.Linq;
using System;
using Library.BoatUtils;
using System.Collections.Generic;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a Boat.
    /// </summary>
    public class BoatTests
    {
        /// <summary>
        /// Test de creacion de un Boat y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void VesselCreation()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            coords.Add(position1);
            coords.Add(position2);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Vessel(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de creacion de un Boat y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void SubmarineCreation()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Submarine(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de creacion de un Boat y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void SailBoatCreation()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            coords.Add(position1);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new SailBoat(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de creacion de un Boat y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void CruiseCreation()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Cruise(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de creacion de un Boat y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void AirCraftCarrierCreation()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            Tuple<int, int> position5 = new Tuple<int, int>(1, 5);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            coords.Add(position5);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new AircraftCarrier(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de destrucción de un Boat.
        /// </summary>
        [Test]
        public void VesselIsDestroyed()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            coords.Add(position1);
            coords.Add(position2);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Vessel(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
            foreach(BoatPosition aux in Boat.Positions)
            {
                aux.WasHit = true;
            }
            Assert.AreEqual(true, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de destrucción de un Boat.
        /// </summary>
        [Test]
        public void SubmarineIsDestroyed()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Submarine(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
            foreach(BoatPosition aux in Boat.Positions)
            {
                aux.WasHit = true;
            }
            Assert.AreEqual(true, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de destrucción de un Boat.
        /// </summary>
        [Test]
        public void SailBoatIsDestroyed()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            coords.Add(position1);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new SailBoat(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
            foreach(BoatPosition aux in Boat.Positions)
            {
                aux.WasHit = true;
            }
            Assert.AreEqual(true, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de destrucción de un Boat.
        /// </summary>
        [Test]
        public void CruiseIsDestroyed()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new Cruise(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
            foreach(BoatPosition aux in Boat.Positions)
            {
                aux.WasHit = true;
            }
            Assert.AreEqual(true, Boat.IsDestroyed());
        }

        /// <summary>
        /// Test de destrucción de un Boat.
        /// </summary>
        [Test]
        public void AirCraftCarrierIsDestroyed()
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
            Tuple<int, int> position1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> position2 = new Tuple<int, int>(1, 2);
            Tuple<int, int> position3 = new Tuple<int, int>(1, 3);
            Tuple<int, int> position4 = new Tuple<int, int>(1, 4);
            Tuple<int, int> position5 = new Tuple<int, int>(1, 5);
            coords.Add(position1);
            coords.Add(position2);
            coords.Add(position3);
            coords.Add(position4);
            coords.Add(position5);
            List<BoatPosition> expected = new List<BoatPosition>();
            foreach(Tuple<int, int> tuple in coords)
            {
                expected.Add(new BoatPosition(tuple.Item1, tuple.Item2));
            }
            Boat Boat = new AircraftCarrier(coords);
            Assert.AreEqual(expected, Boat.Positions);
            Assert.AreEqual(false, Boat.IsDestroyed());
            foreach(BoatPosition aux in Boat.Positions)
            {
                aux.WasHit = true;
            }
            Assert.AreEqual(true, Boat.IsDestroyed());
        }
    }
}