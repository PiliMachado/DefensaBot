// -----------------------------------------------------------------------
// <copyright file="NullPointerException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Excepción creada con la intención de reemplazar <see cref="ArgumentNullException"/>, y así poder agregar
    /// un mensaje personalizado.
    /// </summary>
    public class NullPointerException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NullPointerException"/>.
        /// </summary>
        /// <param name="message">El mensaje a enviar al usuario, detallando la causa de la excepción.</param>
        public NullPointerException(string message)
            : base(message)
        {
        }
    }
}