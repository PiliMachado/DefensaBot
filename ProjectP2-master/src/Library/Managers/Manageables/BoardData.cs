// -----------------------------------------------------------------------
// <copyright file="BoardData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Library.BoardUtils;

namespace Library.Managers.Manageables
{
    /// <summary>
    /// Guarda información sensible sobre un tipo de board.
    /// </summary>
    public class BoardData : Manageable<Board>
    {
        /// <summary>
        /// Obtiene el diccionario de bote - cantidad necesarios para la tabla manejada.
        /// </summary>
        public Dictionary<string, int> NeededBoatsForBoard { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoardData"/> con los datos necesarios
        /// para el tipo de board incluído en este Manageable.
        /// </summary>
        /// <param name="type">La clase de bote a la que pertenecen los datos incluídos en este Manageable.</param>
        /// <param name="neededBoatsForBoard">Los tipos de botes que deben estar incluídos en la board manejada
        /// y sus respectivas cantidades.</param>
        public BoardData(Type type, Dictionary<string, int> neededBoatsForBoard)
            : base(type)
        {
            this.NeededBoatsForBoard = neededBoatsForBoard;
        }
    }
}