// -----------------------------------------------------------------------
// <copyright file="IrregularBoatSizeException.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.Exceptions
{
    /// <summary>
    /// Extensión lanzada cuando al momento de crear un nuevo bote, la cantidad de coordenadas pasadas al nuevo
    /// bote no coinciden con el tamaño del bote.
    /// </summary>
    public class IrregularBoatSizeException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="IrregularBoatSizeException"/>.
        /// </summary>
        /// <param name="message">El mensaje que va a contener la excepción.</param>
        public IrregularBoatSizeException(string message)
            : base(message)
        {
        }
    }
}