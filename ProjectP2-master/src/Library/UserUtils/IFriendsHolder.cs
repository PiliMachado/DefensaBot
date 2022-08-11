// -----------------------------------------------------------------------
// <copyright file="IFriendsHolder.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace Library.UserUtils
{
    /// <summary>
    /// IFriendsHolder es una interfaz que define un tipo que posee información y métodos referentes a amigos.
    /// </summary>
    public interface IFriendsHolder
    {
        /// <summary>
        /// Remueve un usuario de la lista de amigos de este usuario.
        /// </summary>
        /// <param name="user">El usuario a eliminar.</param>
        /// <returns>true si el usuario fue eliminado de la lista de amigos,
        /// false si el usuario dado no se encuentra en la lista de amigos de este usuario.</returns>
        bool RemoveFriend(IStatsHolder user);

        /// <summary>
        /// Agrega un usuario a la lista de amigos de este usuario.
        /// </summary>
        /// <param name="user">El usuario a agregar a la lista de amigos.</param>
        /// <returns>true if the friend was successfully added, false otherwise.</returns>
        bool AddFriend(IStatsHolder user);

        /// <summary>
        /// Obtiene Lista de usuarios amigos de este usuario.
        /// </summary>
        /// <returns>La lista de amigos.</returns>
        Collection<IStatsHolder> Friends { get; }
    }
}