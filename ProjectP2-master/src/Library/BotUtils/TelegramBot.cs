// -----------------------------------------------------------------------
// <copyright file="TelegramBot.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.Handlers;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Library.BotUtils
{
    /// <summary>
    /// Representa un bot cuya interfaz de comunicación es telegram.
    /// </summary>
    public class TelegramBot : IBot
    {
        private readonly TelegramBotClient client;

        /// <summary>
        /// Obtiene o establece la cadena de handlers que utiliza este bot.
        /// </summary>
        private IHandler Cor { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TelegramBot"/>.
        /// </summary>
        public TelegramBot()
        {
            this.client = new TelegramBotClient(SecretsManager.Instance.Secrets["telegram"]);
        }

        /// <inheritdoc />
        public void SetHandlers(AbstractHandler cor)
        {
            this.Cor = cor;
        }

        /// <inheritdoc />
        public void Send(long id, string message)
        {
            this.client.SendTextMessageAsync(id, message);
        }
        
        /// <inheritdoc />
        public async Task SendImage(Message message, string filePath)
        {
            // Can be null during testing
            if (client != null)
            {
                await this.client.SendChatActionAsync(message.ID, ChatAction.UploadPhoto);

                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await client.SendPhotoAsync(
                    chatId: message.ID,
                    photo: new InputOnlineFile(fileStream, fileName)
                );
            }
        }

        /// <inheritdoc />
        public async Task SendGif(Message message)
        {
            // Can be null during testing
            await this.client.SendChatActionAsync(message.ID, ChatAction.UploadPhoto);

                const string filePath = @"video-waves.mp4";
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await client.SendVideoAsync(
                    chatId: message.ID,
                    video: new InputOnlineFile(fileStream, fileName),
                    caption: "Tutorial!"
                );
        }

        /// <inheritdoc />
        public void OnMessage(long id, string message)
        {
            try
            {
                Console.WriteLine($"{id} envía: {message}");
                if (string.IsNullOrEmpty(message))
                {
                    this.Send(id, "Mensaje inválido.");
                }
                else
                {
                    this.Send(id, this.Cor.Handle(new Message(id, message)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.Send(id, "Ha ocurrido un error:");
                this.Send(id, e.Message);
            }
        }

        /// <inheritdoc />
        public void StartReceiving()
        {
            this.client.StartReceiving(
                this.HandleUpdateAsync,
                this.HandleError,
                new ReceiverOptions(),
                new CancellationTokenSource().Token);
        }

        /// <summary>
        /// Maneja una update por parte de un usuario al bot.
        /// </summary>
        /// <param name="botClient">El cliente del bot que envía la actualización.</param>
        /// <param name="update">La actualización en cuestión.</param>
        /// <param name="cancellationToken">El cancellation token.</param>
        /// <returns>Un resultado.</returns>
        private Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Solo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    Debug.Assert(update.Message != null, "update.Message != null");
                    this.OnMessage(update.Message.Chat.Id, update.Message.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Task.CompletedTask;
        }

        private Task HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}