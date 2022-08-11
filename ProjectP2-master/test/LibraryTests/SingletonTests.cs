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
    /// Tests relacionados a Singleton.
    /// </summary>
    public class SingletonTests
    {
        /// <summary>
        /// Test para verificar que una primera instancia obtenida por Singleton no sea nula.
        /// </summary>
        [Test]
        public void EmptyInstance()
        {
            UserContainer UserContainer = Singleton<UserContainer>.Instance;
            Assert.IsNotNull(UserContainer);
        }

        /// <summary>
        /// Test para verificar que varias instancias del mismo tipo de Singleton sean en verdad una
        /// unica, y sean identicas.
        /// </summary>
        [Test]
        public void SameInstance()
        {
            UserContainer UserContainer = Singleton<UserContainer>.Instance;
            UserContainer.AddElement(123, "Santiago Ferraro", "Ferri");
            UserContainer UserContainer2 = Singleton<UserContainer>.Instance;
            Assert.AreSame(UserContainer2, UserContainer);
        }
    }
}