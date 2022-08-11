using System.Collections.Generic;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Handlers;
using Library.UserUtils;
using Library.GameUtils;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a GameChatHandler.
    /// </summary>
    public class GameChatHandlerTests
    {

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MessagesAreSent()
        {
            UserContainer userContainer = new UserContainer();
            BattleShipSettings settings = BattleShipSettings.Instance;
            settings.UsedBot = new TestBot();
            AbstractHandler corInRightOrder =
                new InfoHandler(
                    new GameExitHandler(
                        new GameAttackHandler(
                            new GameBoardsHandler(
                                new GameChatHandler(
                                    new HelpHandler(
                                        new FriendsHandler(
                                            new MatchHandler(
                                                new RegisterHandler(
                                                    new StatsHandler())))))))));

            TestBot bot = BattleShipSettings.Instance.UsedBot as TestBot;
            bot.SetHandlers(corInRightOrder);
            RegisterHandler registerHandler = new RegisterHandler();
            Message registration = new Message(65693845, "/register Santiago Ferraro Ferri");
            registerHandler.Handle(registration);
            Message registration2 = new Message(563563456, "/register Pilar Machado Pili");
            registerHandler.Handle(registration2);
            MatchHandler matchHandler = new MatchHandler();
            Message message = new Message(65693845, "/match create S");
            matchHandler.Handle(message);
            message = new Message(563563456, "/match join S");
            matchHandler.Handle(message);
            PlaceBoatsAddHandler boatsHandler = new PlaceBoatsAddHandler();
            message = new Message(65693845, "/boat add sailBoat a1 a1");
            boatsHandler.Handle(message);
            message = new Message(65693845, "/boat add sailBoat a2 a2");
            boatsHandler.Handle(message);
            message = new Message(65693845, "/boat add vessel a3 a4");
            boatsHandler.Handle(message);
            message = new Message(65693845, "/boat add carrier b0 b4");
            boatsHandler.Handle(message);

            bot.OnMessage(65693845, "Hola!");
            Assert.AreEqual("Ferri: Hola!", bot.LastMessage);
        }
    }
}