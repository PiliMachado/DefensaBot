using NUnit.Framework;
using Library.BotUtils;
using System.Collections.ObjectModel;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a Message.
    /// </summary>
    public class MessageTests
    {
        /// <summary>
        /// Test de creacion de un Message y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void MessageCreation()
        {
            Message Message = new Message(123, "Buenas!");
            Assert.AreEqual(123, Message.ID);
            Assert.AreEqual("Buenas!", Message.Text);
        }
    }
}