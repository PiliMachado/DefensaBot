using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.Handlers;
using Library.UserUtils;
using NUnit.Framework;
using System;


namespace LibraryTests
{
  /// <summary>
  /// Tests relacionados a GameExitHandler.
  /// </summary>
  public class GameExitHandlerTests
  {

    /// <summary>
    /// Test de correcto uso del comando salir.
    /// </summary>
    [Test]
    public void CorrectGameExit()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      GameContainer gameContainer = Singleton<GameContainer>.Instance;
      User pablo = userContainer.AddElement(993939, "Pablo Méndez", "Pablillo");
      Game game = gameContainer.AddElement(true, "L");
      GameExitHandler gameExitHandler = new GameExitHandler();

      Message message = new Message(993939, "/match create L public");
      game.AddPlayer(pablo);
      Message message2 = new Message(993939, "/salir");

      string handler = gameExitHandler.Handle(message2);
      string expected = "Saliendo de la partida...";

      Assert.AreEqual(expected, handler);
    }

  }
}