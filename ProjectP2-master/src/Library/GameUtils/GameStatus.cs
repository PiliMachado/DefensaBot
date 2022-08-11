// -----------------------------------------------------------------------
// <copyright file="GameStatus.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.GameUtils
{
    /// <summary>
    /// Enumerador utilizado para indicar el estado de un juego.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// El juego no ha iniciado, se encuentra esperando jugadores.
        /// </summary>
        Waiting,

        /// <summary>
        /// El juego ya tiene sus jugadores y los mismos están en etapa de colocar sus botes.
        /// </summary>
        PlacingBoats,

        /// <summary>
        /// El juego se encuentra en proceso.
        /// </summary>
        Playing,

        /// <summary>
        /// Los jugadores ya no pueden realizar jugadas, el juego terminó.
        /// </summary>
        Finishing,

        /// <summary>
        /// El juego terminó y no hay mas jugadores dentro de él.
        /// </summary>
        Finished,
    }
}