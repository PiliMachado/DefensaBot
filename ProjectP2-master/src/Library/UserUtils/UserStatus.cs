// -----------------------------------------------------------------------
// <copyright file="UserStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.UserUtils
{
    /// <summary>
    /// Representa el estado de un usuario respecto a una partida.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Estado de usuario que indica que el mismo está esperando fuera de una partida.
        /// </summary>
        Lobby,

        /// <summary>
        /// Estado de usuario que indica que el mismo está dentro de una partida, esperando por un segundo usuario.
        /// </summary>
        WaitingForSecondPlayer,

        /// <summary>
        /// El usuario está jugando una partida.
        /// </summary>
        Playing,
    }
}