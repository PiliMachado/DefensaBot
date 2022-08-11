// -----------------------------------------------------------------------
// <copyright file="BattleShipSettings.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.BotUtils;
using Library.ContainerUtils;

namespace Library
{
    /// <summary>
    /// Clase que contiene datos importantes sobre como se llevan a cabo las partidas de la batalla naval.
    /// </summary>
    public class BattleShipSettings
    {
        /// <summary>
        /// La única instancia de la clase <see cref="BattleShipSettings"/>.
        /// </summary>
        private static BattleShipSettings _instance;

        private BattleShipSettings()
        {
        }

        /// <summary>
        /// Obtiene la única instancia de la clase <see cref="BattleShipSettings"/>.
        /// </summary>
        public static BattleShipSettings Instance
        {
            get { return _instance ??= new BattleShipSettings(); }
        }

        /// <summary>
        /// Obtiene el tiempo que tiene cada jugador para realizar un movimiento.
        /// Valor en milisegundos.
        /// </summary>
        public int TurnTimerPeriod { get; } = 50_000;

        /// <summary>
        /// Obtiene o establece el bot que se utilizará durante la ejecución del programa.
        /// </summary>
        public IBot UsedBot { get; set; } = Singleton<TelegramBot>.Instance;
    }
}