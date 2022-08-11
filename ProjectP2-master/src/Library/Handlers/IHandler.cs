// -----------------------------------------------------------------------
// <copyright file="IHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using Library.BotUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Representa las características básicas que debe tener un handler.
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Maneja una request, y devuelve una respuesta acorde a la request.
        /// </summary>
        /// <param name="message">El mensaje o request recibido.</param>
        /// <returns>Una respuesta al mensaje.</returns>
        string Handle(Message message);

        /// <summary>
        /// Establece el siguiente handler, en caso de que el actual no sepa manejar la request recibida.
        /// Este es un metodo polimorfico y por ello podemos decir que se aplica polimorfismo en los Handlers.
        /// </summary>
        /// <param name="handler">El siguiente handler.</param>
        /// <returns>El handler recibido por parámetro, para encadenación de llamadas.</returns>
        IHandler SetNext(IHandler handler);

        /// <summary>
        /// Obtiene el siguiente handler.
        /// </summary>
        /// <returns>El siguiente handler.</returns>
        IHandler GetNext();
    }
}