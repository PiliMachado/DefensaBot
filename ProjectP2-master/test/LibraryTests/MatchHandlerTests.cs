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
  /// Clase encargada de probar los handlers de match.
  /// </summary>
  public class MatchHandlerTests
  {
    /// <summary>
    /// Prueba que no puede entrar en un match un jugador no registrado.
    /// </summary>
    public void NotRegistered()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      MatchHandler matchHandler = new MatchHandler();
      RegisterHandler regHandler = new RegisterHandler();
      regHandler.SetNext(matchHandler);
      Message message = new Message(1, "/match create public");
      bool exceptionCatched = false;

      try
      {
        regHandler.Handle(message);
      }
      catch (NotRegisteredYetException)
      {
        exceptionCatched = true;
      }

      Assert.AreEqual(true, exceptionCatched);
    }

    /// <summary>
    /// Prueba que no se puede crear una partida sin especificar tipo de board.
    /// </summary>
    [Test]
    public void InsufficientArgumentsCreateMatchAvailableBoards()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;

      User user1 = userContainer.AddElement(1, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(1, "/match create");

      string handler = matchHandler.Handle(message);
      string expected = "No hay suficientes argumentos. Uso: \"/match create (type) <public/private>\"<> = opcional. public = cualquiera puede unirse (defecto). private = unirse sólo con código.Types disponibles:  - S - M - L";

      Assert.AreEqual(expected, handler);
    }

    /// <summary>
    /// Prueba que no se puede crear una partida sin especificar el create.
    /// </summary>
    [Test]
    public void InsufficientArgumentsCreateMatch()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      GameContainer gameContainer = Singleton<GameContainer>.Instance;
      User pablo = userContainer.AddElement(3, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(3, "/match");

      string handler = matchHandler.Handle(message);
      string expected = "No hay suficientes argumentos. Uso: \"/match join <type/ID>\" o \"/match create (type) <public/private>\"";

      Assert.AreEqual(expected, handler);
    }

    /// <summary>
    /// Prueba que no se puede entrar en un game estando ya en otro.
    /// </summary>
    [Test]
    public void AlreadyInGame()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      GameContainer gameContainer = Singleton<GameContainer>.Instance;
      User pablo = userContainer.AddElement(4, "Pablo Méndez", "Pablillo");
      Game game = gameContainer.AddElement(false, "L");
      Game game2 = gameContainer.AddElement(true, "M");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(4, $"/match join {game.Identifier}");
      game.AddPlayer(pablo);
      Message message2 = new Message(4, $"/match join {game2.Identifier}");
      game2.AddPlayer(pablo);

      bool exceptionCatched = false;
      try
      {
        matchHandler.Handle(message2);
      }
      catch (AlreadyInGameException)
      {
        exceptionCatched = true;
      }
      Assert.AreEqual(true, exceptionCatched);
    }

    /// <summary>
    /// Prueba un caso de unirse a una partida privada.
    /// </summary>
    [Test]
    public void JoinToPrivateMatch()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      GameContainer gameContainer = Singleton<GameContainer>.Instance;
      User pablo = userContainer.AddElement(5, "Pablo Méndez", "Pablillo");
      Game game = gameContainer.AddElement(false, "M");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(5, $"/match join {game.Identifier}");

            string handler = matchHandler.Handle(message);
            string expected = $"Uniéndote a la partida privada de tipo Mediana. ID: {game.Identifier}";
            
            Assert.AreEqual(expected, handler);
        }

    /// <summary>
    /// Prueba que no entrará a ningun match si el tipo de board especificado no está disponible.
    /// </summary>
    [Test]
    public void NotMatchFoundByBoardType()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(7, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(7, "/match join S");

      bool exceptionCatched = false;

      try
      {
        matchHandler.Handle(message);
      }
      catch (NoMatchFoundException)
      {
        exceptionCatched = true;
      }

      Assert.AreEqual(true, exceptionCatched);
    }

    /// <summary>
    /// Prueba que no entrará a ningun match si la id especificada no existe. 
    /// </summary>
    [Test]
    public void NotMatchFoundByID()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(8, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(8, "/match join 14");

      bool exceptionCatched = false;

      try
      {
        matchHandler.Handle(message);
      }
      catch (NoMatchFoundException)
      {
        exceptionCatched = true;
      }

      Assert.AreEqual(true, exceptionCatched);
    }

    /// <summary>
    /// Caso de prueba de crear una partida pública.
    /// </summary>
    [Test]
    public void CreatePublicMatch()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(9, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(9, "/match create L");

      string handler = matchHandler.Handle(message);
      String[] args = handler.Split(".");
      string expected = "Creada nueva partida pública de tipo L";

      Assert.AreEqual(expected, args[0]);
    }

    /// <summary>
    /// Caso de prueba de crear una partida privada.
    /// </summary>
    [Test]
    public void CreatePrivateMatch()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(10, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(10, "/match create L private");
      string handler = matchHandler.Handle(message);
      String[] args = handler.Split(".");
      string expected = "Creada nueva partida privada de tipo L";

      Assert.AreEqual(expected, args[0]);
    }

    /// <summary>
    /// Prueba que no se puede crear una partida si el tipo de partida no es pública o privada.
    /// </summary>
    [Test]
    public void IncorrectAccesibiltyType()
    {
      UserContainer userContainer = Singleton<UserContainer>.Instance;
      User pablo = userContainer.AddElement(11, "Pablo Méndez", "Pablillo");

      MatchHandler matchHandler = new MatchHandler();
      Message message = new Message(11, "/match create L normal");

      bool exceptionCatched = false;

      try
      {
        matchHandler.Handle(message);
      }
      catch (IncorrectAccessibilityTypeException)
      {
        exceptionCatched = true;
      }


      Assert.AreEqual(true, exceptionCatched);
    }
  }
}