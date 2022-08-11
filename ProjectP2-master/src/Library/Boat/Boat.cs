// -----------------------------------------------------------------------
// <copyright file="Boat.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Library.Exceptions;

namespace Library.BoatUtils
{
    /// <summary>
    /// Clase que representa a cada uno de los botes dentro de una <see cref="BoardUtils.Board"/>.
    /// Cada bote contiene más de una coordenada.
    /// </summary>
    public abstract class Boat
    {
        /// <summary>
        /// Obtiene la lista que contiene todas las posiciones de este bote.
        /// </summary>
        public List<BoatPosition> Positions { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Boat"/>.
        /// </summary>
        /// <param name="positions">Las posiciones que ocupa el nuevo bote.</param>
        /// <param name="size">El tamaño del bote a crear.</param>
        /// <exception cref="IrregularBoatSizeException">Arrojada cuando el numero de posiciones pasadas por
        /// parámetro es distinto del número de posiciones que este Boat debe tener.</exception>
        /// <exception cref="ArgumentNullException">Arrojada en caso de que la lista de posiciones sea nula.</exception>
        protected Boat(ICollection<Tuple<int, int>> positions, int size)
        {
            if (positions == null)
            {
                throw new NullPointerException("Las posiciones pasadas al nuevo barco no pueden ser null!");
            }

            if (positions.Count != size)
            {
                throw new IrregularBoatSizeException("La cantidad de coordenadas pasadas al bote " +
                                                     $"({positions.Count}) no coincide con el tamaño del bote ({size})!");
            }

            this.Positions = new List<BoatPosition>();
            foreach (var (x, y) in positions)
            {
                this.Positions.Add(new BoatPosition(x, y));
            }
        }

        /// <summary>
        /// Verifica el estado de "salud" del bote.
        /// Responsabilidad asignada por Expert, ya que el bote conoce sus posiciones y el estado de ellas.
        /// </summary>
        /// <returns>True si todas las posiciones del barco fueron destruidas.</returns>
        public bool IsDestroyed()
        {
            return this.Positions.All(p => p.WasHit);
        }

        /// <inheritdoc />
        public abstract override string ToString();
    }
}