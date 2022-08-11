// -----------------------------------------------------------------------
// <copyright file="UserContainer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Library.Exceptions;
using Library.UserUtils;

namespace Library.ContainerUtils
{
    /// <summary>
    /// UserContainer es una clase que contiene una lista de instancias de tipo User.
    /// UserContainer contendrá todos los User, y se encargara por el patron Creator de crear instancias de User.
    /// </summary>
    public class UserContainer
    {
        /// <summary>
        /// Lista de usuarios. Singleton por definición, no puede haber dos listas de todos los usuarios.
        /// </summary>
        public List<User> Elements = Singleton<List<User>>.Instance;

        /// <summary>
        /// Remueve un usuario de la lista de usuarios.
        /// </summary>
        /// <param name="user">El usuario a remover de la lista.</param>
        public void RemoveElement(User user)
        {
            this.Elements.Remove(user);
        }

        /// <summary>
        /// Agrega un nuevo usuario a la lista de usuarios registrados.
        /// Por Creator ya que UserContainer guarda instancias de User creara los Users.
        /// Designada por Expert ya que UserContainer conoce los Users registrados.
        /// </summary>
        /// <param name="ID">El ID del nuevo usuario.</param>
        /// <param name="name">El nombre del nuevo usuario.</param>
        /// <param name="nickName">El nombre del nuevo usuario dentro del juego.</param>
        /// <returns>El nuevo usuario.</returns>
        /// <exception cref="AlreadyRegisteredException">Lanzada cuando ya existe un jugador con la misma ID.</exception>
        public User AddElement(long ID, string name, string nickName)
        {
            if (this.Elements.Any(u => u.ID.Equals(ID)))
            {
                throw new AlreadyRegisteredException("Un usuario con el mismo ID ya se encuentra registrado!");
            }

            User user = new User(ID, name, nickName); // Creamos user por creator.
            this.Elements.Add(user);
            return user;
        }

        /// <summary>
        /// IsRegistered es un método para verificar si un usuario ya esta en la lista de usuarios o no. Para corroborarlo
        /// buscamos el ID del usuario entre los usuarios de la lista.
        /// Designada por Expert ya que UserContainer conoce los Users registrados.
        /// </summary>
        /// <param name="ID">El ID a buscar.</param>
        /// <returns><code>true</code> si existe un usuario registrado con el mismo ID. <code>false</code>
        /// de otra manera.</returns>
        public bool IsRegistered(long ID)
        {
            User user = this.Elements.FirstOrDefault(x => x.ID == ID);
            return user != null;
        }

        /// <summary>
        /// Search es un método para encontrar un usuario en la lista de usuarios, mediante un valor
        /// ID del user que se busca, pasado por parámetro.
        /// Designada por Expert ya que UserContainer conoce los Users registrados.
        /// </summary>
        /// <param name="ID">El ID de usuario a buscar.</param>
        /// <returns>El usuario encontrado con el ID pasado por parámetro, o nulo.</returns>
        public User Search(long ID)
        {
            User user = this.Elements.FirstOrDefault(x => x.ID == ID);
            return user;
        }
    }
}