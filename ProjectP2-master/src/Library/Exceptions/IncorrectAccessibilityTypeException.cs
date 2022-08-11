// -----------------------------------------------------------------------
// <copyright file="IncorrectAccessibilityTypeException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando el usuario ingresa un tipo de accesibilidad incorrecto al crear una partida.
    /// </summary>
    public class IncorrectAccessibilityTypeException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="IncorrectAccessibilityTypeException"/>.
        /// Crea una nueva excepción al momento de crear una partida con un argumento de accesibilidad incorrecto.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public IncorrectAccessibilityTypeException(string message)
            : base(message)
        {
        }
    }
}