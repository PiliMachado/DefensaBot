// -----------------------------------------------------------------------
// <copyright file="MediumBoard.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.BoardUtils
{
    /// <summary>
    /// Representa una tabla de un tamaño fijo de 10x10.
    /// </summary>
    public class MediumBoard : Board
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MediumBoard"/>.
        /// </summary>
        public MediumBoard()
            : base(10)
        {
        }

        /// <summary>
        /// Obtiene el nombre de la tabla.
        /// </summary>
        /// <returns>El nombre de este tipo de tabla.</returns>
        public static string BoardTypeName()
        {
            return "Mediana";
        }
    }
}