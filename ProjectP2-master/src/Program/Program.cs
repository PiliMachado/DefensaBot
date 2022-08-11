//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using Library;
using Library.BotUtils;
using Library.Handlers;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            AbstractHandler corInRightOrder =
                new InfoHandler(
                    new PlaceBoatsRemoveHandler(
                        new PlaceBoatsListHandler(
                            new PlaceBoatsInfoHandler(
                                new PlaceBoatsAddHandler(
                                    new GameExitHandler(
                                        new GameAttackHandler(
                                            new GameBoardsHandler(
                                                new GameChatHandler(
                                                    new TutorialHandler(
                                                        new HelpHandler(
                                                            new FriendsHandler(
                                                                new MatchHandler(
                                                                    new RegisterHandler(
                                                                        new StatsHandler()))))))))))))));

            IBot bot = BattleShipSettings.Instance.UsedBot;
            bot.SetHandlers(corInRightOrder);
            bot.StartReceiving();

            Console.Write("Enter para salir del programa...");
            Console.ReadLine();
        }
    }
}