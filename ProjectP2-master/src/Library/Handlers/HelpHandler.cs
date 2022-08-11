// -----------------------------------------------------------------------
// <copyright file="HelpHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Library.BotUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Handler que maneja la request del comando /ayuda, muestra listas de comandos disponibles.
    /// </summary>
    public class HelpHandler : AbstractHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelpHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public HelpHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/help", StringComparison.OrdinalIgnoreCase) ||
                   messageText.StartsWith("/ayuda", StringComparison.OrdinalIgnoreCase) ||
                   messageText.StartsWith("/iniciar", StringComparison.OrdinalIgnoreCase) ||
                   messageText.StartsWith("/start", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder textResult = new StringBuilder();
            textResult.Append("Listas de comandos: (<> = opcional, %valor% = valor dado por usuario)\n");
            textResult.Append("\nFuera de la partida: ");
            textResult.Append("\n\t - /ayuda - Muestra esta lista de comandos");
            textResult.Append("\n\t - /tutorial - Aprende a jugar");
            textResult.Append("\n\t - /amigos:");
            textResult.Append("\n\t\t - /amigos add %user_id% - Añade un nuevo amigo.");
            textResult.Append("\n\t\t - /amigos remove %user_id% - Remueve un amigo.");
            textResult.Append("\n\t\t - /amigos stats %user_id% - Muestra las estadísticas de un amigo.");
            textResult.Append("\n\t\t - /amigos list - Muestra tu lista de amigos.");
            textResult.Append("\n\t - /partida:");
            textResult.Append("\n\t\t - /partida join <type/ID> - Intenta unirte a una partida, según el tipo de board, el id de la partida, o cualquier partida.");
            textResult.Append("\n\t\t - /partida create %type% <public/private> - Crea una nueva partida del tipo dado y la accesibilidad dada (publico por defecto).");
            textResult.Append("\n\t - /registro %nombre% %apellido% %nickname% - Registro en la lista de usuarios.");
            textResult.Append("\n\t - /stats - Muestra tus estadisticas.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\nEn la partida:");
            textResult.Append("\n\t - /attack %letra% %numero% - Intenta realizar un disparo en la coordenada dada del otro jugador.");
            textResult.Append("\n\t - /boards - Observa tu tabla y la de tu enemigo.");
            textResult.Append("\n\t - /salir - Salir de la partida.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\t\tAgregando botes:");
            textResult.Append("\n\t - /boat list - Muestra los botes que has colocado.");
            textResult.Append("\n\t - /boat add (type) (start) (finish) - Añade un nuevo bote a la tabla.");
            textResult.Append("\n\t - /boat info - Ver la información de tus botes.");
            textResult.Append("\n\t - /boat remove (id) - Remueve un bote por su id a la tabla.");

            return textResult.ToString();
        }
    }
}