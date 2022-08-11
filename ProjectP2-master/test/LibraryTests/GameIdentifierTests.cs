using NUnit.Framework;
using Library.ContainerUtils;
using Library.GameUtils;
using System.Collections.Generic;
namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a GameIdentifier.
    /// </summary>
    public class GameIdentifierTests
    {
        /// <summary>
        /// Test de generar un identificador.
        /// </summary>
        [Test]
        public void GenerateIdentifier()
        {
            string identifier = GameIdentifier.GenerateIdentifier();
            Assert.That(identifier != null);
        }

        /// <summary>
        /// Test de generar un identificador con el largo esperado.
        /// </summary>
        [Test]
        public void GenerateCorrectLengthIdentifier()
        {
            string identifier = GameIdentifier.GenerateIdentifier();
            Assert.That(identifier.Length == 10);
        }
    }
}