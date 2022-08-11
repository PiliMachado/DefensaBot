// -----------------------------------------------------------------------
// <copyright file="Cruise.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa un <see cref="Boat"/> de tipo Cruise.
    /// </summary>
    public class Cruise : Boat
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Cruise"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que abarca el bote.</param>
        public Cruise(ICollection<Tuple<int, int>> positions)
            : base(positions, 4)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "cruise";
        }
    }
}