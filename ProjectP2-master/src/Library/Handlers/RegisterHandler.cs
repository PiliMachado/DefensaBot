// -----------------------------------------------------------------------
// <copyright file="RegisterHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;

namespace Library.Handlers
{
    /// <summary>
    /// Maneja registros de nuevos Users.
    /// </summary>
    public class RegisterHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public RegisterHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/registro", StringComparison.OrdinalIgnoreCase)
                   || messageText.StartsWith("/register", StringComparison.OrdinalIgnoreCase);
        }

        /// <exception cref="CannotRegisterException">Arrojada cuando al momento de finalizar el registro,
        /// el usuario no ha proveído los datos necesarios.</exception>
        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder resultText = new StringBuilder();
            if (this.userContainer.IsRegistered(message.ID))
            {
                return "Usted ya esta registrado/a";
            }

            string[] args = message.Text.Split(" ");

            if (args.Length != 4)
            {
                resultText.Append("Formato de comando invalido. Uso: /register <nombre> <apellido> <nickname>");
            }
            else
            {
                // args length 5 = /registrarse nombre pepito perez, 4 = /registrarse nombre pepito. mayor a 5 no tiene sentido.
                string fullName = args[1] + " " + args[2];
                string nickName = args[3];

                if (fullName == null || fullName.Trim().Length == 0)
                {
                    throw new CannotRegisterException("El nombre no puede ser nulo o vacío!");
                }

                if (nickName == null || nickName.Trim().Length == 0)
                {
                    throw new CannotRegisterException("El nick no puede ser nulo o vacío!");
                }

                resultText.Append($"Tu nombre ahora es: {fullName} \nY tu nickname ahora es: {nickName}");
                this.userContainer.AddElement(message.ID, fullName, nickName);
            }

            return resultText.ToString();
        }
    }
}
