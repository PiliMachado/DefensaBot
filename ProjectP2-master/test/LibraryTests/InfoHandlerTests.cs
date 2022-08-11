using Library.BoardUtils;
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
  /// Test del Handler de información.
  /// </summary>
  public class InfoHandlerTests
  {
    /// <summary>
    /// Prueba que el usuario puede contemplar su propia información.
    /// </summary>
    [Test]
    public void MyInfo()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(22, "Pablo Méndez", "Pablillo");

      InfoHandler infoHandler = new InfoHandler();

      Message message2 = new Message(22, "/info");

      string handler = infoHandler.Handle(message2);
      string expected = "Información:\n\nTu ID: 22\nNombre: Pablo Méndez\nNickname: Pablillo\n\nPara ver información sobre estadísticas: '/estadisticas'";

      Assert.AreEqual(expected, handler);
    }

    /// <summary>
    /// Prueba que el usuario puede ver la información de la partida en que se encuentra.
    /// </summary>
    [Test]
    public void MatchInfo()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      GameContainer gameContainer = Singleton<GameContainer>.Instance;
      User pablo = userContainer.AddElement(23, "Pablo Méndez", "Pablillo");
      Game game = gameContainer.AddElement(true, "L");

      InfoHandler infoHandler = new InfoHandler();

      game.AddPlayer(pablo);
      Message message2 = new Message(23, "/info");

      string handler = infoHandler.Handle(message2);
      string expected = $"Información:\n\nTu ID: 23\nNombre: Pablo Méndez\nNickname: Pablillo\n\nID partida: {game.Identifier}\nEstado actual de partida: Waiting\nVisibilidad de partida: Pública\nPara ver información sobre estadísticas: '/estadisticas'";

      Assert.AreEqual(expected, handler);
    }


  }
}