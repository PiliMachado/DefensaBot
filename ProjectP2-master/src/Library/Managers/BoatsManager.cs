// -----------------------------------------------------------------------
// <copyright file="BoatsManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.BoatUtils;
using Library.Managers.Manageables;

namespace Library.Managers
{
    /// <summary>
    /// Maneja los tipos de botes disponibles y sus respectivos datos.
    /// </summary>
    public class BoatsManager : AbstractManager<BoatData, Boat>
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoatsManager"/>.
        /// Agrega los tipos de botes que vienen por defecto en el programa.
        /// </summary>
        public BoatsManager()
        {
            this.AddAvailableType("sailBoat", new BoatData(typeof(SailBoat), 1));
            this.AddAvailableType("vessel", new BoatData(typeof(Vessel), 2));
            this.AddAvailableType("submarine", new BoatData(typeof(Submarine), 3));
            this.AddAvailableType("cruise", new BoatData(typeof(Cruise), 4));
            this.AddAvailableType("carrier", new BoatData(typeof(AircraftCarrier), 5));
        }
    }
}