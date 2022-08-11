// -----------------------------------------------------------------------
// <copyright file="SmallBoard.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.BoardUtils
{
    /// <summary>
    /// Representa una tabla de un tamaño fijo de 5x5.
    /// </summary>
    public class SmallBoard : Board
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SmallBoard"/>.
        /// </summary>
        public SmallBoard()
            : base(5)
        {
        }

        /// <summary>
        /// Obtiene el nombre de la tabla.
        /// </summary>
        /// <returns>El nombre de este tipo de tabla.</returns>
        public static string BoardTypeName()
        {
            return "Pequeña";
        }
    }
}