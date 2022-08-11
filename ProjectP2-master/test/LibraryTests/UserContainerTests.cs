// <copyright file="UserContainerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Library.ContainerUtils;
using Library.Exceptions;
using NUnit.Framework;
using Library.UserUtils;
using System.Collections.ObjectModel;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a UserContainer.
    /// </summary>
    public class UserContainerTests
    {
        /// <summary>
        /// Test de añadir un user a la lista de users.
        /// </summary>
        [Test]
        public void AddElement()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.That(UserContainer.Elements.Contains(user));
            Assert.That(user.ID == 123);
            Assert.That(user.FullName == "Santiago Ferraro");
            Assert.That(user.NickName == "Ferri");
        }

        /// <summary>
        /// Test de remover un user de la lista de users.
        /// </summary>
        [Test]
        public void RemoveElement()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.That(UserContainer.Elements.Contains(user));
            UserContainer.RemoveElement(user);
            Assert.That(!UserContainer.Elements.Contains(user));
        }

        /// <summary>
        /// Test de agregar un user, ya agregado, a la lista de users.
        /// </summary>
        [Test]
        public void AddAlreadyAddedElement()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            try
            {
                UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
                Assert.Fail();
            }
            catch (AlreadyRegisteredException)
            {
            }

            Assert.AreEqual(1, UserContainer.Elements.Count);
        }

        /// <summary>
        /// Test de remover un user, que no se encuentra en la lista, de la lista de users.
        /// </summary>
        [Test]
        public void RemoveNotAddedElement()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.That(UserContainer.Elements.Contains(user));
            UserContainer.RemoveElement(user);
            Collection<User> expected = new Collection<User>();
            CollectionAssert.AreEqual(expected, UserContainer.Elements);
        }

        /// <summary>
        /// Test de buscar un user ya agregado a la lista de users.
        /// </summary>
        [Test]
        public void SearchRegisteredUser()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(user, UserContainer.Search(123));
        }

        /// <summary>
        /// Test de buscar un user no agregado a la lista de users.
        /// </summary>
        [Test]
        public void SearchUnRegistereduser()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            Assert.AreEqual(null, UserContainer.Search(123));
        }

        /// <summary>
        /// Test de ver si esta registrado un user que esta añadido a la lista de users.
        /// </summary>
        [Test]
        public void IsRegisteredForRegistereduser()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(true, UserContainer.IsRegistered(123));
        }

        /// <summary>
        /// Test de ver si esta registrado un user que no esta en la lista de users.
        /// </summary>
        [Test]
        public void IsRegisteredForUnRegistereduser()
        {
            UserContainer UserContainer = new UserContainer();
            UserContainer.Elements = new List<User>();
            User user = UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            Assert.AreEqual(false, UserContainer.IsRegistered(456));
        }
    }
}