// -----------------------------------------------------------------------
// <copyright file="BoardHitStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.BoardUtils
{
    /// <summary>
    /// Representa el resultado de un ataque.
    /// </summary>
    public enum BoardHitStatus
    {
        /// <summary>
        /// Las coordinadas dadas se ubican fuera de la tabla.
        /// </summary>
        OutOfBoard,

        /// <summary>
        /// No existe ningún bote en las coordenadas dadas.
        /// </summary>
        Water,

        /// <summary>
        /// El jugador había atacado esas coordinadas con anterioridad.
        /// </summary>
        WaterAgain,

        /// <summary>
        /// El ataque resultó en satisfactorio, una parte de un bote ha resultado atacada.
        /// </summary>
        BoatHit,

        /// <summary>
        /// En las coordenadas dadas existe un bote pero ya había sido atacado con anterioridad.
        /// </summary>
        BoatHitAgain,
    }
}