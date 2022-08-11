// -----------------------------------------------------------------------
// <copyright file="NotRegisteredYetException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de efectuar un comando para el cual se necesita estar registrado,
    /// el usuario que envía el mensaje no está registrado.
    /// </summary>
    public class NotRegisteredYetException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotRegisteredYetException"/>
        /// al momento de utilizar un comando para el cual se necesita estar registrado.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public NotRegisteredYetException(string message)
            : base(message)
        {
        }
    }
}