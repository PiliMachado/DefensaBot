// -----------------------------------------------------------------------
// <copyright file="GameAlreadyRegisteredException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de registrar un nuevo usuario, el mismo no provee los datos necesarios.
    /// </summary>
    public class GameAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameAlreadyRegisteredException"/>.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public GameAlreadyRegisteredException(string message)
            : base(message)
        {
        }
    }
}