// -----------------------------------------------------------------------
// <copyright file="IBot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Library.Handlers;

namespace Library.BotUtils
{
    /// <summary>
    /// Interfaz contenedora de los atributos básicos necesarios para un bot.
    /// </summary>
    public interface IBot
    {
        /// <summary>
        /// Establece la cadena de responsabilidad que manejará las requests que envíen los usuarios.
        /// </summary>
        /// <param name="cor">La cadena de handlers que manejará las requests enviadas al bot.</param>
        void SetHandlers(AbstractHandler cor);

        /// <summary>
        /// Envía un mensaje de texto a un usuario.
        /// </summary>
        /// <param name="id">El id del usuario que debe recibir el mensaje.</param>
        /// <param name="message">El mensaje a enviar.</param>
        void Send(long id, string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task SendImage(Message message, string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
                                                                                                                                                                                    /// <returns></returns>
        Task SendGif(Message message);

        /// <summary>
        /// Maneja el recibimiento de un nuevo mensaje.
        /// </summary>
        /// <param name="id">El id del usuario que envía el mensaje.</param>
        /// <param name="message">El mensaje recibido.</param>
        void OnMessage(long id, string message);

        /// <summary>
        /// Empieza a escuchar nuevos mensajes.
        /// </summary>
        void StartReceiving();
    }
}