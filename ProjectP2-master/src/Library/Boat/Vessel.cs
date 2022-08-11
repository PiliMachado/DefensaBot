// -----------------------------------------------------------------------
// <copyright file="Vessel.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa un <see cref="Boat"/> de tipo Vessel.
    /// </summary>
    public class Vessel : Boat
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Vessel"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que abarca el bote.</param>
        public Vessel(ICollection<Tuple<int, int>> positions)
            : base(positions, 2)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "vessel";
        }
    }
}