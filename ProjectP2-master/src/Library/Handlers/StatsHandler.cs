// -----------------------------------------------------------------------
// <copyright file="StatsHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.UserUtils;

namespace Library.Handlers
{
    /// <summary>
    /// StatsHandler es una clase que hereda de AbstractHandler, y cuyas responsabilidades principales
    /// son ver si puede manejar un mensaje, y en caso de que esto sea positivo, probar devolver los
    /// stats del usuario.
    /// StatsHandler depende de una abstracción de User (IStatsHolder) por DIP, asi de esta forma StatsHandler
    /// no cambiara sin en un futuro cambia User, y por ISP no conoce lo que otra abstracción IFriendsHolder
    /// contiene, ya que no precisa de ello.
    /// </summary>
    public class StatsHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios, y obtener al usuario que manda el mensaje.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StatsHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public StatsHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/stats", StringComparison.OrdinalIgnoreCase)
                   || messageText.StartsWith("/estadisticas", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            if (!this.userContainer.IsRegistered(message.ID))
            {
                throw new NotRegisteredYetException("No estas registrado/a aun. Usa \"/registrase\".");
            }

            StringBuilder textResult = new StringBuilder();

            if (message.Text.Trim().Split(" ").Length > 1)
            {
                textResult.Append("Para ver las estadísticas de otro jugador utiliza \"/friends stats %id%\"\n\n");
            }

            IStatsHolder user = this.userContainer.Search(message.ID);
            textResult.Append($"Stats de {user.NickName} (#{message.ID}): " +
                              $"\n - Total de victorias: {user.Stats.Wins} " +
                              $"\n - Total de perdidas: {user.Stats.Losses} " +
                              $"\n - Total de empatadas: {user.Stats.Ties} " +
                              $"\n - Porcentaje de aciertos: {user.Stats.HitPercentage}% " +
                              $"\n - Porcentaje de desaciertos: {user.Stats.MissPercentage}%");

            return textResult.ToString();
        }
    }
}