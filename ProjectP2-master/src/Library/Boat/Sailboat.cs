// -----------------------------------------------------------------------
// <copyright file="Sailboat.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa un <see cref="Boat"/> de tipo SailBoat.
    /// </summary>
    public class SailBoat : Boat
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SailBoat"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que abarca el bote.</param>
        public SailBoat(ICollection<Tuple<int, int>> positions)
            : base(positions, 1)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "sailBoat";
        }
    }
}