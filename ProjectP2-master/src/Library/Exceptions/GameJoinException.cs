// -----------------------------------------------------------------------
// <copyright file="GameJoinException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada al momento que un jugador se une a una partida.
    /// </summary>
    public class GameJoinException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameJoinException"/>.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public GameJoinException(string message)
            : base(message)
        {
        }
    }
}