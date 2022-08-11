// -----------------------------------------------------------------------
// <copyright file="IStatsHolder.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.UserUtils
{
    /// <summary>
    /// IStatsHolder es una interfaz que define un tipo que posee atributos referentes a los stats.
    /// </summary>
    public interface IStatsHolder
    {
        /// <summary>
        /// Obtiene la ID del usuario de Telegram.
        /// </summary>
        /// <value>La ID de este usuario.</value>
        long ID { get; }

        /// <summary>
        /// Obtiene el nombre completo del usuario.
        /// </summary>
        /// <value>Nombre del usuario.</value>
        string FullName { get; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario dentro del juego.
        /// </summary>
        /// <value>Nick del usuario.</value>
        string NickName { get; set; }

        /// <summary>
        /// Obtiene las estadísticas para este usuario.
        /// </summary>
        /// <value>Clase contenedora de las estadísticas para este usuario.</value>
        UserStats Stats { get; }
    }
}