// -----------------------------------------------------------------------
// <copyright file="LargeBoard.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.BoardUtils
{
    /// <summary>
    /// Representa una tabla de un tamaño fijo de 15x15.
    /// </summary>
    public class LargeBoard : Board
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LargeBoard"/>.
        /// </summary>
        public LargeBoard()
            : base(15)
        {
        }

        /// <summary>
        /// Obtiene el nombre de la tabla.
        /// </summary>
        /// <returns>El nombre de este tipo de tabla.</returns>
        public static string BoardTypeName()
        {
            return "Grande";
        }
    }
}