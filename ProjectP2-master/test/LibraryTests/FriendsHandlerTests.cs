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
    /// Tests relacionados a FriendsHandler.
    /// </summary>
    public class FriendsHandlerTests
    {

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void NotRegistered()
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
        /// 
        /// </summary>
        [Test]
        public void FullyCorrectAddInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends add 3");
            string actual = handler.Handle(message);
            string expected = "Amigo Pili añadido a lista de amigos!";
            Assert.AreEqual(expected, actual);
            Assert.That(user.Friends.Contains(friend));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void FullyCorrectRemoveInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            user.AddFriend(friend);
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends remove 3");
            string actual = handler.Handle(message);
            string expected = "Usuario Pili removido de tu lista de amigos!";
            Assert.AreEqual(expected, actual);
            Assert.That(!user.Friends.Contains(friend));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void FullyCorrectStatsInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            user.AddFriend(friend);
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends stats 3");
            string actual = handler.Handle(message);
            string expected = $"Stats de {friend.NickName}: \nTotal de victorias {friend.Stats.Wins} \n-Total de perdidas {friend.Stats.Losses} \n-Total de empatadas{friend.Stats.Ties} \n-Porcentaje de aciertos {friend.Stats.HitPercentage}% \n-Porcentaje de desaciertos {friend.Stats.MissPercentage}%";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void FullyCorrectListInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            User friend2 = userContainer.AddElement(123, "Leandro Alfonso", "Lea");
            User friend3 = userContainer.AddElement(456, "Pablo Mendez", "Pab");
            user.AddFriend(friend);
            user.AddFriend(friend2);
            user.AddFriend(friend3);
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends list");
            string actual = handler.Handle(message);
            string expected = "Lista de amigos:\nPili (#3)\nLea (#123)\nPab (#456)\n";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void IncorrectCommand()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            RegisterHandler RegisterHandler = new RegisterHandler();
            FriendsHandler handler = new FriendsHandler();
            handler.SetNext(RegisterHandler);
            Message message = new Message(123456, "/register Santiago Ferraro Ferri");
            string actual = handler.Handle(message);
            Assert.AreEqual("Tu nombre ahora es: Santiago Ferraro \nY tu nickname ahora es: Ferri", actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void IncorrectFormat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends 3 7");
            string actual = String.Empty;
            try
            {
                handler.Handle(message);
            }
            catch (NullPointerException e)
            {
                actual = e.Message;
            }

            string expected = "El ID de usuario que ingresaste no es válido, o el usuario con ese ID aun no se ha registrado.";
            Assert.AreEqual(expected, actual);
            Message message2 = new Message(123456, "/friends adder 3");
            string actual2 = handler.Handle(message2);
            string expected2 = "Uso: /friends (add/remove/stats/list) <user_id>";
            Assert.AreEqual(expected2, actual2);
            Message message3 = new Message(123456, "/friends");
            string actual3 = handler.Handle(message3);
            string expected3 = "Uso: /friends (add/remove/stats/list) <user_id>";
            Assert.AreEqual(expected3, actual3);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void AddAlreadyAddedInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            user.AddFriend(friend);
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends add 3");
            string actual = handler.Handle(message);
            string expected = "El usuario Pili ya se encontraba en tu lista de amigos.";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RemoveNotAddedFriendInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends remove 3");
            string actual = handler.Handle(message);
            string expected = "El usuario Pili no se encuentra en tu lista de amigos.";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void StatsNotAddedUserInteraction()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            User user = userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            User friend = userContainer.AddElement(3, "Pilar Machado", "Pili");
            FriendsHandler handler = new FriendsHandler();
            Message message = new Message(123456, "/friends stats 3");
            string actual = handler.Handle(message);
            string expected = "El usuario Pili no se encuentra en tu lista de amigos.";
            Assert.AreEqual(expected, actual);
        }
    }
}