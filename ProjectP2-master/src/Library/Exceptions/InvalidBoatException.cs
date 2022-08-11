// -----------------------------------------------------------------------
// <copyright file="InvalidBoatException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Extensión lanzada cuando al momento de agregar un bote, sus coordenadas son inválidas o no existe un bote
    /// con el tipo dado.
    /// </summary>
    public class InvalidBoatException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InvalidBoatException"/>.
        /// </summary>
        /// <param name="message">El mensaje que va a contener la excepción.</param>
        public InvalidBoatException(string message)
            : base(message)
        {
        }
    }
}