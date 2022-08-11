// -----------------------------------------------------------------------
// <copyright file="BoatPosition.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library.BoatUtils
{
    /// <summary>
    /// Representa cada una de las posiciones de un barco.
    /// </summary>
    public class BoatPosition : IEquatable<BoatPosition>
    {
        /// <summary>
        /// Obtiene la posición X en la tabla.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Obtiene la posición Y en la tabla.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Obtiene o establece un valor que indica si el estado de "salud" de esta posición.
        /// </summary>
        public bool WasHit { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoatPosition"/>.
        /// </summary>
        /// <param name="x">Posición X en la tabla.</param>
        /// <param name="y">Posición Y en la tabla.</param>
        public BoatPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.WasHit = default;
        }

        /// <summary>
        /// Compara esta <see cref="BoatPosition"/> con las coordenadas x e y dadas.
        /// Método con sobrecarga.
        /// </summary>
        /// <param name="x">La coordenada X a comparar.</param>
        /// <param name="y">La coordenada Y a comparar.</param>
        /// <returns><code>true</code> si las coordenadas dadas coinciden con las de esta instancia.</returns>
        public bool Equals(int x, int y)
        {
            return this.X == x && this.Y == y;
        }

        /// Método con sobrecarga.
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not BoatPosition)
            {
                return false;
            }

            return ((BoatPosition)obj).X == this.X && ((BoatPosition)obj).Y == this.Y;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        /// Método con sobrecarga.
        /// <inheritdoc />
        public bool Equals(BoatPosition other)
        {
            return other != null && other.X == this.X && other.Y == this.Y;
        }
    }
}