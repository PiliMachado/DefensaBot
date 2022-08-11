// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace Library.UserUtils
{
    /// <summary>
    /// Clase que representa a un usuario registrado en el programa, vinculado a un ID de telegram.
    /// Contiene información exclusiva de cada usuario, junto con sus estadísticas.
    /// Implementa las interfaces IStatsHolder y IFriendsHolder para luego aplicar DIP y ISP en FriendsHandler
    /// y StatsHandler.
    /// </summary>
    public class User : IStatsHolder, IFriendsHolder
    {
        /// <summary>
        /// Obtiene la ID del usuario de Telegram.
        /// </summary>
        /// <value>La ID de este usuario.</value>
        public long ID { get; }

        /// <summary>
        /// Obtiene el nombre completo del usuario.
        /// </summary>
        /// <value>Nombre del usuario.</value>
        public string FullName { get; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario dentro del juego.
        /// </summary>
        /// <value>Nick del usuario.</value>
        public string NickName { get; set; }

        /// <summary>
        /// Obtiene Lista de usuarios amigos de este usuario.
        /// </summary>
        /// <returns>La lista de amigos.</returns>
        public Collection<IStatsHolder> Friends { get; } = new Collection<IStatsHolder>();

        /// <inheritdoc />
        public UserStats Stats { get; } = new UserStats();

        /// <summary>
        /// Obtiene o establece el estado del jugador respecto a una partida.
        /// </summary>
        public UserStatus UserStatus { get; set; } = UserStatus.Lobby;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="User"/> con los datos recibidos.
        /// </summary>
        /// <param name="id">El ID (telegram) vinculado a este usuario.</param>
        /// <param name="fullName">El nombre de este jugador.</param>
        /// <param name="nickName">El nombre del jugador dentro del juego.</param>
        public User(long id, string fullName, string nickName)
        {
            this.ID = id;
            this.FullName = fullName;
            this.NickName = nickName;
        }

        /// <summary>
        /// Agrega un usuario a la lista de amigos de este usuario.
        /// </summary>
        /// <param name="user">El usuario a agregar a la lista de amigos.</param>
        /// <returns><code>true</code> if the friend was successfully added. <code>false</code> otherwise.</returns>
        public bool AddFriend(IStatsHolder user)
        {
            if (this.Friends.Contains(user))
            {
                return false;
            }

            this.Friends.Add(user);
            return true;
        }

        /// <summary>
        /// Remueve un usuario de la lista de amigos de este usuario.
        /// </summary>
        /// <param name="user">El usuario a eliminar.</param>
        /// <returns>true si el usuario fue eliminado de la lista de amigos,
        /// false si el usuario dado no se encuentra en la lista de amigos de este usuario.</returns>
        public bool RemoveFriend(IStatsHolder user)
        {
            return this.Friends.Remove(user);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return base.Equals(obj) || (obj is User user && user.ID.Equals(this.ID));
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}