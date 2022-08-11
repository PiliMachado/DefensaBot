// -----------------------------------------------------------------------
// <copyright file="InvalidAttackException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando al momento de atacar en una partida, no es momento de atacar.
    /// </summary>
    public class InvalidAttackException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InvalidAttackException"/>.
        /// Crea una nueva excepción al momento de atacar en una partida.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public InvalidAttackException(string message)
            : base(message)
        {
        }
    }
}