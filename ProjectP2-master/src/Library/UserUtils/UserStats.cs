// -----------------------------------------------------------------------
// <copyright file="UserStats.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.UserUtils
{
    /// <summary>
    /// Clase que contiene las estadísticas de un usuario.
    /// </summary>
    public class UserStats
    {
        /// <summary>
        /// Obtiene o establece las partidas que este jugador ha ganado.
        /// </summary>
        /// <value>La cantidad de partidas que ha ganado el usuario.</value>
        public int Wins { get; set; }

        /// <summary>
        /// Obtiene o establece las partidas que este jugador ha perdido.
        /// </summary>
        /// <value>La cantidad de partidas que el usuario ha perdido.</value>
        public int Losses { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de partidas que el usuario ha empatado.
        /// </summary>
        /// <value>La cantidad de partidas que el usuario ha empatado.</value>
        public int Ties { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de disparos que el jugador ha efectuado.
        /// </summary>
        /// <value>La cantidad total de disparos efectuados.</value>
        public int TotalHits { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad total de disparos que el jugador ha errado.
        /// </summary>
        /// <value>La cantidad total de disparos fallidos.</value>
        public int TotalMisses { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del jugador respecto a una partida.
        /// </summary>
        public UserStatus UserStatus { get; set; } = UserStatus.Lobby;

        /// <summary>
        /// Obtiene el porcentaje de disparos acertados, respecto al total de disparos efectuados.
        /// </summary>
        /// <returns>El porcentaje de disparos acertados.</returns>
        public double HitPercentage
        {
            get
            {
                if (this.TotalHits > 0 || this.TotalMisses > 0)
                {
                    return this.TotalHits * 100.0 / (this.TotalHits + this.TotalMisses);
                }

                return 0;
            }
        }

        /// <summary>
        /// Obtiene el porcentaje de disparos fallidos, respecto al total de disparos efectuados.
        /// </summary>
        /// <returns>El porcentaje de disparos errados.</returns>
        public double MissPercentage
        {
            get
            {
                if (this.TotalHits > 0 || this.TotalMisses > 0)
                {
                    return this.TotalMisses * 100.0 / (this.TotalHits + this.TotalMisses);
                }

                return 0;
            }
        }
    }
}