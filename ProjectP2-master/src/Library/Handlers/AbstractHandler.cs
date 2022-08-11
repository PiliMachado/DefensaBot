// -----------------------------------------------------------------------
// <copyright file="AbstractHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.BotUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Clase abstracta que implementa <see cref="IHandler"/>, heredada directamente por cada handler.
    /// Los Handlers aplican OCP, ya que son abiertos a la extension, mediante herencia de esta clase y
    /// agregación, se pueden agregar responsabilidades, es decir nuevos comandos. Ademas es cerrado
    /// a la modificación ya que el codigo no precisa y no deberia cambiar.
    /// Con los handlers aplicamos el patron chain of responsability, el cual indica una serie de clases
    /// en la que cada una ve si puede manejar un mensaje y en caso de que no pueda delega la
    /// responsabilidad al proximo Handler.
    /// </summary>
    public abstract class AbstractHandler : IHandler
    {
        private IHandler Next { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AbstractHandler"/> y establece
        /// el siguiente handler en la cadena de responsabilidad.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        protected AbstractHandler(IHandler next = null)
        {
            this.Next = next;
        }

        /// <inheritdoc />
        public string Handle(Message message)
        {
            if (this.CanHandle(message))
            {
                return this.InternalHandle(message);
            }

            return this.Next == null ? "Comando desconocido. Envía \"/ayuda\" para una lista de comandos." : this.GetNext().Handle(message);
        }

        /// <inheritdoc />
        public virtual IHandler SetNext(IHandler handler)
        {
            this.Next = handler;
            return handler;
        }

        /// <inheritdoc />
        public virtual IHandler GetNext()
        {
            return this.Next;
        }

        /// <summary>
        /// Maneja una request, asumiendo que el mensaje cumple los requisitos para que este handler pueda manejar la misma.
        /// </summary>
        /// <param name="message">El mensaje o request.</param>
        /// <returns>La respuesta a la request dada por parámetro.</returns>
        protected abstract string InternalHandle(Message message);

        /// <summary>
        /// Comprueba si el handler actual puede manejar la petición.
        /// </summary>
        /// <param name="message">El mensaje recibido.</param>
        /// <returns>True si este handler puede manejar el mensaje.</returns>
        protected abstract bool CanHandle(Message message);
    }
}