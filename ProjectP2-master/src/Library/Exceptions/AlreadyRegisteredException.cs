// -----------------------------------------------------------------------
// <copyright file="AlreadyRegisteredException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de registrar un nuevo usuario,
    /// el mismo, o un usuario con el mismo ID, ya se encuentra registrado.
    /// </summary>
    public class AlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AlreadyRegisteredException"/>.
        /// Crea una nueva excepción al momento de registrar un nuevo usuario.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public AlreadyRegisteredException(string message)
            : base(message)
        {
        }
    }
}