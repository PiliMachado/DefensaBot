// -----------------------------------------------------------------------
// <copyright file="FriendsHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Nito.AsyncEx;
using Library.BotUtils;

namespace Library.Handlers
{
  /// <summary>
  /// 
  /// </summary>
  public class TutorialHandler : AbstractHandler
  {

    /// <inheritdoc />
   

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    public TutorialHandler(IHandler next = null)
            : base(next)
        {
        }

    /// <inheritdoc />
    protected override bool CanHandle(BotUtils.Message message)
    {
      string messageText = message.Text.Trim();

      return messageText.StartsWith("/Tutorial", StringComparison.OrdinalIgnoreCase);
    }

    /// <inheritdoc />
    protected override string InternalHandle(BotUtils.Message message)
    {

      IBot bot = BattleShipSettings.Instance.UsedBot;

      if (message.Text.StartsWith("/Tutorial", StringComparison.OrdinalIgnoreCase))
      {
        StringBuilder textResult = new StringBuilder();
        string[] args = message.Text.Trim().Split(" ");

        if(args.Length == 1){
            textResult.Append("¿Que quieres aprender?\n");
            textResult.Append("\n\t - /Tutorial Register - Como registrarse.");
            textResult.Append("\n\t - /Tutorial Friends - Como interactuar con tus amigos.");
            textResult.Append("\n\t - /Tutorial Boat - Como añadir y ver botes.");
            textResult.Append("\n\t - /Tutorial Match - Como unirse o crear una partida.");
            textResult.Append("\n\t - /Tutorial Board - Como ver el tablero.");
            textResult.Append("\n\t - /Tutorial Stats - Como ver tu información.");

            return textResult.ToString();
        }

        args[1] = args[1].ToLower();

        if(args[1] == "register") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\Register.PNG"));
          textResult.Append("Asi podrás registrar tu usuario.");
          return textResult.ToString();
        }

        if(args[1] == "friends") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\FriendsAdd.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\FriendsRemove.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\FriendsList.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\FriendsStats.PNG"));
          textResult.Append("Asi podrás interactuar con tus amigos en el sistema.");
          return textResult.ToString();
        }

        if(args[1] == "boat") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\BoatAdd.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\BoatInfo.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\BoatList.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\BoatRemove.PNG"));
          textResult.Append("Cuando inicies la partida asi podrás añadir botes, remover, listar y ver los botes que tienes y/o te faltan por agregar");
          return textResult.ToString();
        }

        if(args[1] == "match") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\JoinMatch.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\CreateMatch.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\Exit.PNG"));
          textResult.Append("Asi podrás unirte, crear una partida o salir de alguna de ellas.");
          return textResult.ToString();
        }

        if(args[1] == "board") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\ViewBoard1.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\ViewBoard3.PNG"));
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\ViewBoard2.PNG"));
          textResult.Append("Aqui se ve como puedes visualizar el tablero en medio de una partida.");
          return textResult.ToString();
        }

        if(args[1] == "stats") {
          AsyncContext.Run(() => bot.SendImage(message, @"..\Program\TutorialResources\BoatStats.PNG"));
          textResult.Append("Puedes ver tus estadisticas personales.");
          return textResult.ToString();
        }


          return textResult.ToString();
      }
      else
      {
        return this.GetNext().Handle(message);
      }
    }

    
  }
}
