// -----------------------------------------------------------------------
// <copyright file="BoardsManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Library.BoardUtils;
using Library.Managers.Manageables;

namespace Library.Managers
{
    /// <summary>
    /// Maneja los tipos de boards disponibles y sus respectivos datos.
    /// Agrega los tipos de boards que vienen por defecto en el programa.
    /// </summary>
    public class BoardsManager : AbstractManager<BoardData, Board>
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoardsManager"/>.
        /// Agrega los tipos de botes que vienen por defecto en el programa.
        /// </summary>
        public BoardsManager()
        {
            Dictionary<string, int> smallBoardBoats = new Dictionary<string, int>();
            Dictionary<string, int> mediumBoardBoats = new Dictionary<string, int>();
            Dictionary<string, int> largeBoardBoats = new Dictionary<string, int>();

            smallBoardBoats.Add("sailBoat", 2);
            smallBoardBoats.Add("vessel", 1);
            smallBoardBoats.Add("carrier", 1);

            mediumBoardBoats.Add("sailBoat", 3);
            mediumBoardBoats.Add("vessel", 2);
            mediumBoardBoats.Add("submarine", 1);
            mediumBoardBoats.Add("cruise", 1);
            mediumBoardBoats.Add("carrier", 1);

            largeBoardBoats.Add("sailBoat", 7);
            largeBoardBoats.Add("vessel", 2);
            largeBoardBoats.Add("submarine", 2);
            largeBoardBoats.Add("cruise", 2);
            largeBoardBoats.Add("carrier", 4);

            this.AddAvailableType("S", new BoardData(typeof(SmallBoard), smallBoardBoats));
            this.AddAvailableType("M", new BoardData(typeof(MediumBoard), mediumBoardBoats));
            this.AddAvailableType("L", new BoardData(typeof(LargeBoard), largeBoardBoats));
        }
    }
}