// -----------------------------------------------------------------------
// <copyright file="NoMatchFoundException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de unirse a una partida, no existe una partida a la cual unirse.
    /// </summary>
    public class NoMatchFoundException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NoMatchFoundException"/>.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public NoMatchFoundException(string message)
            : base(message)
        {
        }
    }
}