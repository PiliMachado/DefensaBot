// -----------------------------------------------------------------------
// <copyright file="AircraftCarrier.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa un <see cref="Boat"/> de tipo AircraftCarrier.
    /// </summary>
    public class AircraftCarrier : Boat
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AircraftCarrier"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que abarca el bote.</param>
        public AircraftCarrier(ICollection<Tuple<int, int>> positions)
            : base(positions, 5)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "carrier";
        }
    }
}