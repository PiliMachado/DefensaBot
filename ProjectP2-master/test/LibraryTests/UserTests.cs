// -----------------------------------------------------------------------
// <copyright file="UserTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using Library.UserUtils;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a user.
    /// </summary>
    public class UserTests
    {
        /// <summary>
        /// Test de creacion de un user y correcta asignacion de variables.
        /// </summary>
        [Test]
        public void UserCreation()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(123456, user.ID);
            Assert.AreEqual("Santiago Ferraro", user.FullName);
            Assert.AreEqual("Ferri", user.NickName);
        }

        /// <summary>
        /// Test de añadir un amigo a los amigos de un user.
        /// </summary>
        [Test]
        public void AddFriend()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            User user2 = new User(126456, "Julieta Ferraro", "Juli");
            user.AddFriend(user2);
            Assert.That(user.Friends.Contains(user2));
        }

        /// <summary>
        /// Test de remover un amigo de la lista de amigos de un user.
        /// </summary>
        [Test]
        public void RemoveFriend()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            User user2 = new User(126456, "Julieta Ferraro", "Juli");
            user.AddFriend(user2);
            Assert.That(user.Friends.Contains(user2));
            user.RemoveFriend(user2);
            Assert.That(!user.Friends.Contains(user2));
        }

        /// <summary>
        /// Test de agregar un amigo que ya esta en la lista de amigos de un user.
        /// </summary>
        [Test]
        public void AddAlreadyAddedFriend()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            User user2 = new User(126456, "Julieta Ferraro", "Juli");
            user.AddFriend(user2);
            user.AddFriend(user2);
            Collection<User> expected = new Collection<User>();
            expected.Add(user2);
            Assert.AreEqual(expected, user.Friends);
        }

        /// <summary>
        /// Test de remover un amigo que no esta en la lista de amigos de un user.
        /// </summary>
        [Test]
        public void RemoveNotAddedFriend()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            User user2 = new User(126456, "Julieta Ferraro", "Juli");
            user.RemoveFriend(user2);
            Collection<User> expected = new Collection<User>();
            Assert.AreEqual(expected, user.Friends);
        }

        /// <summary>
        /// Test de calculo del porcentaje de fallas.
        /// </summary>
        [Test]
        public void GetMissPercentage()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            user.Stats.TotalHits = 300;
            user.Stats.TotalMisses = 150;
            double expected = 150 * 100.0 / (300 + 150);
            Assert.AreEqual(expected, user.Stats.MissPercentage);
        }

        /// <summary>
        /// Test de calculo del porcentaje de aciertos.
        /// </summary>
        [Test]
        public void GetHitPercentage()
        {
            User user = new User(123456, "Santiago Ferraro", "Ferri");
            user.Stats.TotalHits = 300;
            user.Stats.TotalMisses = 150;
            double expected = 300 * 100.0 / (300 + 150);
            Assert.AreEqual(expected, user.Stats.HitPercentage);
        }
    }
}