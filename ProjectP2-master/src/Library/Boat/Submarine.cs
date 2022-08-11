// -----------------------------------------------------------------------
// <copyright file="Submarine.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa un <see cref="Boat"/> de tipo Submarino.
    /// </summary>
    public class Submarine : Boat
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Submarine"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que abarca el bote.</param>
        public Submarine(ICollection<Tuple<int, int>> positions)
            : base(positions, 3)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "submarine";
        }
    }
}