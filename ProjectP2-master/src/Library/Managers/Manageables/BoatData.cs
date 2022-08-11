// -----------------------------------------------------------------------
// <copyright file="BoatData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Library.BoatUtils;

namespace Library.Managers.Manageables
{
    /// <summary>
    /// Guarda información sensible sobre un tipo de bote.
    /// </summary>
    public class BoatData : Manageable<Boat>
    {
        /// <summary>
        /// Obtiene el tamaño necesario para este bote.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoatData"/> con los datos necesarios
        /// para el tipo de bote incluído en este Manageable.
        /// </summary>
        /// <param name="type">La clase de bote a la que pertenecen los datos incluídos en este Manageable.</param>
        /// <param name="size">El tamaño del bote.</param>
        public BoatData(Type type, int size)
            : base(type)
        {
            this.Size = size;
        }
    }
}