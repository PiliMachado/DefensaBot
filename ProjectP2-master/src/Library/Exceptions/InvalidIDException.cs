// -----------------------------------------------------------------------
// <copyright file="InvalidIDException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de agregar un usuario a la lista de amigos,
    /// el id enviado por el jugador es inválido.
    /// </summary>
    public class InvalidIDException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InvalidIDException"/>.
        /// Crea una nueva excepción al momento de agregar un nuevo amigo.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public InvalidIDException(string message)
            : base(message)
        {
        }
    }
}