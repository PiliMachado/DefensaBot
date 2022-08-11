using Library.BoardUtils;
using Library.BoatUtils;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.Handlers;
using Library.UserUtils;
using Library.Shot;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LibraryTests
{
    public class ShotTest
    {
        WaterShot waterShot;
        BoatShot boatShot;       
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void SumarWaterShot()
        {
            waterShot.Sumar();
            string menssageus = waterShot.ContadorWaterShot.ToString();
            Assert.That(menssageus, Is.EqualTo("1"));
        }
        [Test]
        public void SumarBoatShot()
        {
            boatShot.Sumar();
            string menssageus = boatShot.ContadorBoatShot.ToString();
            Assert.That(menssageus, Is.EqualTo("1"));
        }
        [Test]
        public void SumarWaterShotGame()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User mata = userContainer.AddElement(46854658, "Alvaro Machado", "Mata");
            User pili = userContainer.AddElement(69758715, "Pilar Machado", "Pili");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(mata);
            game.AddPlayer(pili);

            MatchHandler matchHandler = new MatchHandler();
            GameAttackHandler attackHandler = new GameAttackHandler();


            Message message = new Message(46854658, "/attack A 0");
            string num = game.WaterShot.ToString();
            Assert.That(num, Is.EqualTo("1"));
        }
        [Test]
        public void SumarBoatShotGame()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            GameContainer gameContainer = Singleton<GameContainer>.Instance;

            User mata = userContainer.AddElement(56945168, "Alvaro Machado", "Mata");
            User pili = userContainer.AddElement(87429634, "Pilar Machado", "Pili");
            Game game = gameContainer.AddElement(true, "S");

            game.AddPlayer(mata);
            game.AddPlayer(pili);

            MatchHandler matchHandler = new MatchHandler();
            GameAttackHandler attackHandler = new GameAttackHandler();


            Message message = new Message(56945168, "/attack A 0");
            string num = game.WaterShot.ToString();
            Assert.That(num, Is.EqualTo("1"));
        }
    }
}