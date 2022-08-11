using Library.BoardUtils;
using Library.BoatUtils;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.Handlers;
using Library.UserUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace LibraryTests
{
    /// <summary>
    /// Test de la clase Board.
    /// </summary>
    public class GameAttackHandlerTests
    {   
        /// <summary>
        /// Prueba que un usuario no puede atacar durante el turno del adversario
        /// </summary>
        [Test]
        public void ItsNotYourTurnYet() {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pablo = userContainer.AddElement(321, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(4321, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            GameAttackHandler attackHandler = new GameAttackHandler();
            
            matchHandler.SetNext(attackHandler);
            game.StartPlacingBoats();
            Message message = new Message(321, "/attack A 0");
            bool check = false;
            try {
                matchHandler.Handle(message);
            }
            catch {
                check = true;
            }
            

            Assert.AreEqual(true, check);
        }

        /// <summary>
        /// Prueba que el usuario atacante puede disparar en agua.
        /// </summary>
        [Test]
        public void ShootWater() {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User pablo = userContainer.AddElement(40, "Pablo Méndez", "Pablillo");
            User santiago = userContainer.AddElement(41, "Santiago Ferraro", "Ferri");
            Game game = gameContainer.AddElement(true, "L");

            game.AddPlayer(pablo);
            game.AddPlayer(santiago);

            MatchHandler matchHandler = new MatchHandler();
            GameAttackHandler attackHandler = new GameAttackHandler();
            matchHandler.SetNext(attackHandler);
            Message message = new Message(40, "/attack A 0");
            bool check = false;
            try
            {
                matchHandler.Handle(message);
            }
            catch (InvalidAttackException)
            {
                
                check=true;
            } 

            Assert.That(check);
        }

        

    }
}
