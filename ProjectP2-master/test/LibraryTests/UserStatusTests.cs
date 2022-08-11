using NUnit.Framework;
using Library.UserUtils;
using System.Collections.ObjectModel;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a UserStatus.
    /// </summary>
    public class UserStatusTests
    {
        /// <summary>
        /// Test de correcta inicializacion de un UserStatus, siempre debe empezar
        /// en UserStatus.Lobby.
        /// </summary>
        [Test]
        public void CorrectInitialUserStatus()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(UserStatus.Lobby, user.UserStatus);
        }
    
        /// <summary>
        /// Test de cambiar status.
        /// </summary>
        [Test]
        public void ChangingUserStatus()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            user.UserStatus = UserStatus.Playing;
            Assert.AreEqual(UserStatus.Playing, user.UserStatus);
            user.UserStatus = UserStatus.WaitingForSecondPlayer;
            Assert.AreEqual(UserStatus.WaitingForSecondPlayer, user.UserStatus);
        }
    }
}