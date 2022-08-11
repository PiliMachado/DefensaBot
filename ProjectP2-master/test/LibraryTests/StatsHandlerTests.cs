using System;
using NUnit.Framework;
using Library.Handlers;
using System.Collections.Generic;
using Library.ContainerUtils;
using Library.UserUtils;
using Library.Exceptions;
using Library.BotUtils;
namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a StatsHandler.
    /// </summary>
    public class StatsHandlerTests
    {

        /// <summary>
        /// Prueba que un usuario no puede acceder a acciones si no está registrado.
        /// </summary>
        [Test]
        public void NotRegistrated()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            FriendsHandler friendsHandler = new FriendsHandler();
            StatsHandler handler = new StatsHandler();
            handler.SetNext(friendsHandler);
            Message message = new Message(123456, "/stats");
            bool exceptionCatched = false;
            try
            {
                handler.Handle(message);
            }
            catch (NotRegisteredYetException)
            {
                exceptionCatched = true;
            }
            Assert.AreEqual(true, exceptionCatched);
        }

        /// <summary>
        /// Prueba un caso de como ver tus estadisticas correctamente.
        /// </summary>
        [Test]
        public void FullyCorrectInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            StatsHandler handler = new StatsHandler();
            Message message = new Message(123456, "/stats");
            string actual = handler.Handle(message);
            string expected = "Stats de Ferri (#123456): \n - Total de victorias: 0 \n - Total de perdidas: 0 \n - Total de empatadas: 0 \n - Porcentaje de aciertos: 0% \n - Porcentaje de desaciertos: 0%";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Prueba que llega el IHandler.
        /// </summary>
        [Test]
        public void IncorrectCommand()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            FriendsHandler friendsHandler = new FriendsHandler();
            StatsHandler handler = new StatsHandler();
            handler.SetNext(friendsHandler);
            string actual = String.Empty;
            Message message = new Message(123456, "/friends add eerf");
            try
            {
                handler.Handle(message);
            }
            catch (InvalidIDException e)
            {
                actual = e.Message;
            }

            string expected = "El ID de un jugador debe ser de tipo numérico. (Ej: 123)";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Prueba que el handler no funciona si se da en un formato incorrecto.
        /// </summary>
        [Test]
        public void IncorrectFormat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            FriendsHandler FriendsHandler = new FriendsHandler();
            StatsHandler handler = new StatsHandler();
            handler.SetNext(FriendsHandler);
            Message message = new Message(123456, "/stats Santiago Ferraro");
            string actual = handler.Handle(message);
            string expected =
                "Para ver las estadísticas de otro jugador utiliza \"/friends stats %id%\"\n\nStats de Ferri (#123456): \n - Total de victorias: 0 \n - Total de perdidas: 0 \n - Total de empatadas: 0 \n - Porcentaje de aciertos: 0% \n - Porcentaje de desaciertos: 0%";
            Assert.AreEqual(expected, actual);
        }
    }
}