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
    /// Tests relacionados a RegisterHandler.
    /// </summary>
    public class RegisterHandlerTests
    {
        /// <summary>
        /// Prueba un caso de registro exitoso.
        /// </summary>
        [Test]
        public void FullyCorrectInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            RegisterHandler handler = new RegisterHandler();
            Message message = new Message(123456, "/register Santiago Ferraro Ferri");
            string actual = handler.Handle(message);
            string expected = "Tu nombre ahora es: Santiago Ferraro \nY tu nickname ahora es: Ferri";
            Assert.AreEqual(expected, actual);
            User user = userContainer.Search(123456);
            Assert.That(user != null);
            Assert.That(user.FullName == "Santiago Ferraro");
            Assert.That(user.NickName == "Ferri");
        }

        /// <summary>
        /// Prueba de que llega el siguiente IHandler.
        /// </summary>
        [Test]
        public void IncorrectCommand()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            FriendsHandler friendsHandler = new FriendsHandler();
            RegisterHandler handler = new RegisterHandler();
            handler.SetNext(friendsHandler);
            Message message = new Message(123456, "/friends Santiago Ferraro Ferri");
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
        /// Prueba que el comando no funciona con un formato incorrecto.
        /// </summary>
        [Test]
        public void IncorrectFormat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            FriendsHandler FriendsHandler = new FriendsHandler();
            RegisterHandler handler = new RegisterHandler();
            handler.SetNext(FriendsHandler);
            Message message = new Message(123456, "/register Santiago Ferraro");
            string actual = handler.Handle(message);
            Assert.AreEqual("Formato de comando invalido. Uso: /register <nombre> <apellido> <nickname>", actual);
            Message message2 = new Message(123456, "/register Ferraro");
            string actual2 = handler.Handle(message2);
            Assert.AreEqual("Formato de comando invalido. Uso: /register <nombre> <apellido> <nickname>", actual);
            Message message3 = new Message(123456, "/register");
            string actual3 = handler.Handle(message3);
            Assert.AreEqual("Formato de comando invalido. Uso: /register <nombre> <apellido> <nickname>", actual);
        }
    }
}