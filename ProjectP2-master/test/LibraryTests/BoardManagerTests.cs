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
    /// Test de la clase BoardManager.
    /// </summary>
    public class BoardManagerTests
    {

        /// <summary>
        /// Test del metodo GetAvailableTagsTest.
        /// </summary>
        [Test]
        public void GetAvailableTagsTest()
        {
            BoardsManager bm = Singleton<BoardsManager>.Instance;
            List<string> tags = bm.GetAvailableTags();
            Assert.That(tags.Contains("S"));
            Assert.That(tags.Contains("M"));
            Assert.That(tags.Contains("L"));
        }

        /// <summary>
        /// Test del metodo GetTagByTypeTest.
        /// </summary>
        [Test]
        public void GetTagByTypeTest()
        {
            BoardsManager bm = Singleton<BoardsManager>.Instance;
            string tag = bm.GetTagByType(typeof(SmallBoard));
            Assert.AreEqual("S", tag);
            string tag2 = bm.GetTagByType(typeof(MediumBoard));
            Assert.AreEqual("M", tag2);
            string tag3 = bm.GetTagByType(typeof(LargeBoard));
            Assert.AreEqual("L", tag3);
        }

        /// <summary>
        /// Test del metodo GetManageableByTag.
        /// </summary>
        [Test]
        public void GetManageableByTagTest()
        {
            Dictionary<string, int> smallBoardBoats = new Dictionary<string, int>();
            Dictionary<string, int> mediumBoardBoats = new Dictionary<string, int>();
            Dictionary<string, int> largeBoardBoats = new Dictionary<string, int>();
            smallBoardBoats.Add("sailBoat", 2);
            smallBoardBoats.Add("vessel", 1);
            smallBoardBoats.Add("carrier", 1);

            mediumBoardBoats.Add("sailBoat", 3);
            mediumBoardBoats.Add("vessel", 2);
            mediumBoardBoats.Add("submarine", 1);
            mediumBoardBoats.Add("cruise", 1);
            mediumBoardBoats.Add("carrier", 1);

            largeBoardBoats.Add("sailBoat", 7);
            largeBoardBoats.Add("vessel", 2);
            largeBoardBoats.Add("submarine", 2);
            largeBoardBoats.Add("cruise", 2);
            largeBoardBoats.Add("carrier", 4);
            BoardsManager bm = Singleton<BoardsManager>.Instance;
            BoardData tag = bm.GetManageableByTag("S");
            BoardData expected = new BoardData(typeof(SmallBoard), smallBoardBoats);
            Assert.That(expected.Type.Equals(tag.Type));
            BoardData tag2 = bm.GetManageableByTag("M");
            BoardData expected2 = new BoardData(typeof(MediumBoard), smallBoardBoats);
            Assert.That(expected2.Type.Equals(tag2.Type));
            BoardData tag3 = bm.GetManageableByTag("L");
            BoardData expected3 = new BoardData(typeof(LargeBoard), smallBoardBoats);
            Assert.That(expected3.Type.Equals(tag3.Type));
        }
    }
}