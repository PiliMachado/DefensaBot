// -----------------------------------------------------------------------
// <copyright file="TestBot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Library.Handlers;

namespace Library.BotUtils
{
    /// <summary>
    /// Representa un bot no funcional utilizado únicamente para realizar pruebas.
    /// </summary>
    public class TestBot : IBot
    {
        /// <summary>
        /// El último mensaje enviado por este bot.
        /// </summary>
        public string LastMessage { get; private set; }

        /// <summary>
        /// Obtiene o establece la cadena de handlers que utiliza este bot.
        /// </summary>
        public IHandler Cor { get; set; }

        /// <inheritdoc />
        public void SetHandlers(AbstractHandler cor)
        {
            this.Cor = cor;
        }

        /// <inheritdoc />
        public void Send(long id, string message)
        {
            if (message != "")
            {
                this.LastMessage = message;
            }
        }

        /// <inheritdoc />
        public Task SendImage(Message message, string filePath)
        {
            return Task.CompletedTask;
            throw new InvalidOperationException("El TestBot no soporta el envío de imágenes.");
        }

        /// <inheritdoc />
        public Task SendGif(Message message)
        {
            return Task.CompletedTask;
            throw new InvalidOperationException("El TestBot no soporta el envío de gifs.");
        }

        /// <inheritdoc />
        public void OnMessage(long id, string message)
        {
            try
            {
                this.Send(id, this.Cor.Handle(new Message(id, message)));
            }
            catch (Exception e)
            {
                this.Send(id, "Ha ocurrido un error:");
                this.Send(id, e.Message);
            }
        }

        /// <inheritdoc />
        public void StartReceiving()
        {
        }
    }
}