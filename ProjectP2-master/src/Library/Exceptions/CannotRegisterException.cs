// -----------------------------------------------------------------------
// <copyright file="CannotRegisterException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de registrar un nuevo usuario, el mismo no provee los datos necesarios.
    /// </summary>
    public class CannotRegisterException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CannotRegisterException"/>
        /// al momento de registrar un nuevo usuario.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public CannotRegisterException(string message)
            : base(message)
        {
        }
    }
}