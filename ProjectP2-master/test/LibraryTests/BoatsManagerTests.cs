using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Library.BoardUtils;
using Library.BoatUtils;
using System;
using Library.Managers;
using Library.Managers.Manageables;
using Library.ContainerUtils;

namespace LibraryTests
{
    /// <summary>
    /// Test de la clase BoatManager.
    /// </summary>
    public class BoatsManagerTests
    {

        /// <summary>
        /// Test del metodo GetAvailableTags.
        /// </summary>
        [Test]
        public void GetAvailableTagsTest()
        {
            BoatsManager bm = Singleton<BoatsManager>.Instance;
            List<string> tags = bm.GetAvailableTags();
            Assert.That(tags.Contains("sailBoat"));
            Assert.That(tags.Contains("vessel"));
            Assert.That(tags.Contains("submarine"));
            Assert.That(tags.Contains("cruise"));
            Assert.That(tags.Contains("carrier"));
        }

        /// <summary>
        /// Test del metodo GetTagByType.
        /// </summary>
        [Test]
        public void GetTagByTypeTest()
        {
            BoatsManager bm = Singleton<BoatsManager>.Instance;
            string tag = bm.GetTagByType(typeof(SailBoat));
            Assert.AreEqual("sailBoat", tag);
            string tag2 = bm.GetTagByType(typeof(Vessel));
            Assert.AreEqual("vessel", tag2);
            string tag3 = bm.GetTagByType(typeof(Submarine));
            Assert.AreEqual("submarine", tag3);
            string tag4 = bm.GetTagByType(typeof(Cruise));
            Assert.AreEqual("cruise", tag4);
            string tag5 = bm.GetTagByType(typeof(AircraftCarrier));
            Assert.AreEqual("carrier", tag5);
        }

        /// <summary>
        /// Test del metodo GetManageableByTag.
        /// </summary>
        [Test]
        public void GetManageableByTagTest()
        {
            BoatsManager bm = Singleton<BoatsManager>.Instance;
            BoatData tag = bm.GetManageableByTag("sailBoat");
            BoatData expected = new BoatData(typeof(SailBoat), 1);
            Assert.That(expected.Type.Equals(tag.Type));
            BoatData tag2 = bm.GetManageableByTag("vessel");
            BoatData expected2 = new BoatData(typeof(Vessel), 2);
            Assert.That(expected2.Type.Equals(tag2.Type));
            BoatData tag3 = bm.GetManageableByTag("submarine");
            BoatData expected3 = new BoatData(typeof(Submarine), 3);
            Assert.That(expected3.Type.Equals(tag3.Type));
            BoatData tag4 = bm.GetManageableByTag("cruise");
            BoatData expected4 = new BoatData(typeof(Cruise), 4);
            Assert.That(expected4.Type.Equals(tag4.Type));
            BoatData tag5 = bm.GetManageableByTag("carrier");
            BoatData expected5 = new BoatData(typeof(AircraftCarrier), 5);
            Assert.That(expected5.Type.Equals(tag5.Type));
        }
    }
}