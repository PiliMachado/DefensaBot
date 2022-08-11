using NUnit.Framework;
using Library.BoatUtils;
using Library.UserUtils;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a BoatPosition.
    /// </summary>
    public class BoatPositionTests
    {
        /// <summary>
        /// Test de creación de un BoatPosition y correcta asignación de variables.
        /// </summary>
        [Test]
        public void BoatPositionCreation()
        {
            BoatPosition BoatPosition = new BoatPosition(1, 2);
            Assert.AreEqual(1, BoatPosition.X);
            Assert.AreEqual(2, BoatPosition.Y);
            Assert.AreEqual(false, BoatPosition.WasHit);
        }

        /// <summary>
        /// Test de los metodos Equals de un BoatPosition.
        /// </summary>
        [Test]
        public void BoatPositionEquals()
        {
            BoatPosition BoatPosition = new BoatPosition(1, 2);
            BoatPosition BoatPosition2 = new BoatPosition(3, 4);
            BoatPosition BoatPosition3 = new BoatPosition(1, 2);
            User user = new User(123, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(true, BoatPosition.Equals(1, 2));
            Assert.AreEqual(false, BoatPosition.Equals(3, 8));
            Assert.AreEqual(false, BoatPosition.Equals(BoatPosition2));
            Assert.AreEqual(true, BoatPosition.Equals(BoatPosition3));
            Assert.AreEqual(false, BoatPosition.Equals(user));
        }
    }
}