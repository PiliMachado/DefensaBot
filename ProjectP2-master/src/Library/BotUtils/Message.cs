// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using Telegram.Bot.Types;

namespace Library.BotUtils
{
    /// <summary>
    /// Representa un mensaje recibido por un bot.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Obtiene el id del usuario que envía el mensaje.
        /// </summary>
        public long ID { get; }

        /// <summary>
        /// Obtiene el texto que contiene el mensaje.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Message"/>.
        /// </summary>
        /// <param name="id">El id del usuario que envía el mensaje.</param>
        /// <param name="text">El texto contenido en el mensaje.</param>
        public Message(long id, string text)
        {
            this.ID = id;
            this.Text = text;
        }
    }
}