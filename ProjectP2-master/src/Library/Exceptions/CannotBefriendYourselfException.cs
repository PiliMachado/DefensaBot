// -----------------------------------------------------------------------
// <copyright file="CannotBefriendYourselfException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de agregar un usuario a la lista de amigos,
    /// este ID no pertenece a ningún usuario en la lista de usuarios.
    /// </summary>
    public class CannotBefriendYourselfException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CannotBefriendYourselfException"/>.
        /// Crea una nueva excepción al momento de agregar un nuevo amigo.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public CannotBefriendYourselfException(string message)
            : base(message)
        {
        }
    }
}