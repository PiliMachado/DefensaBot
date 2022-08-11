// -----------------------------------------------------------------------
// <copyright file="MatchHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.Managers;
using Library.UserUtils;

namespace Library.Handlers
{
    /// <summary>
    /// Handler encargado de manejar las requests relacionadas a unirse y crear partidas.
    /// </summary>
    public class MatchHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MatchHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public MatchHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/match", StringComparison.OrdinalIgnoreCase) ||
                   messageText.StartsWith("/partida", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            if (!this.userContainer.IsRegistered(message.ID))
            {
                throw new NotRegisteredYetException("No estas registrado/a aun. Usa \"/registrase\".");
            }

            User user = this.userContainer.Search(message.ID);
            if (!user.UserStatus.Equals(UserStatus.Lobby))
            {
                throw new AlreadyInGameException("No puedes unirte a una partida porque ya estas participando de una.");
            }

            String[] args = message.Text.Trim().Split(" ");
            if (args.Length < 2)
            {
                return "No hay suficientes argumentos. Uso: \"/match join <type/ID>\" o \"/match create (type) <public/private>\"";
            }

            StringBuilder textResult = new StringBuilder();
            BoardsManager boardsManager = Singleton<BoardsManager>.Instance;

            if (args[1].Equals("create", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length < 3)
                {
                    textResult.Append("No hay suficientes argumentos. Uso: \"/match create (type) <public/private>\"");
                    textResult.Append("<> = opcional. public = cualquiera puede unirse (defecto). private = unirse sólo con código.");
                    textResult.Append("Types disponibles: ");
                    foreach (string boardType in boardsManager.GetAvailableTags())
                    {
                        textResult.Append($" - {boardType}");
                    }
                }
                else
                {
                    string gameType = args[2].ToUpper();
                    List<string> availableBoardTypes = boardsManager.GetAvailableTags();
                    if (!availableBoardTypes.Contains(gameType))
                    {
                        textResult.Append($"Tipo de board \"{gameType}\" inválido. Tipos disponibles: ");
                        foreach (string boardType in boardsManager.GetAvailableTags())
                        {
                            textResult.Append($" - {boardType}");
                        }
                    }
                    else
                    {
                        if (args.Length == 3)
                        {
                            // Crear nueva partida publica -> unirse
                            Game game = this.gameContainer.AddElement(true, gameType);
                            game.AddPlayer(user);
                            textResult.Append($"Creada nueva partida pública de tipo {gameType}. ID: {game.Identifier}");
                        }
                        else
                        {
                            // Crear partida con atributo isPublic = args[2] -> unirse
                            string matchAccessibility = args[3];
                            if (matchAccessibility.Equals("public", StringComparison.OrdinalIgnoreCase) ||
                                matchAccessibility.Equals("private", StringComparison.OrdinalIgnoreCase))
                            {
                                bool isPublic = matchAccessibility.Equals("public", StringComparison.OrdinalIgnoreCase);
                                Game game = this.gameContainer.AddElement(isPublic, gameType);
                                game.AddPlayer(user);
                                textResult.Append($"Creada nueva partida {(isPublic ? "pública" : "privada")} de tipo {gameType}. ID: {game.Identifier}");
                            }
                            else
                            {
                                throw new IncorrectAccessibilityTypeException($"Tipo de accesibilidad \"{matchAccessibility}\" inválido. Debe ser \"public\" o \"private\".");
                            }
                        }
                    }
                }
            }
            else if (args[1].Equals("join", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length == 2)
                {
                    // Buscar partida en curso -> unirse cualquier partida, cualquier tipo.
                    List<Game> availableGames =
                        (from game in this.gameContainer.AvailableGames
                            where game.IsPublic &&
                                  game.GameStatus.Equals(GameStatus.Waiting) &&
                                  game.Players.Count < 2
                                  orderby game.Players.Count
                            select game).ToList();
                    if (availableGames.Count == 0)
                    {
                        throw new NoMatchFoundException("No se pudo encontrar ninguna partida a la cual unirte. " +
                                                        "Intenta crear una nueva partida.");
                    }

                    Game selected = availableGames[0];
                    selected.AddPlayer(user);
                    textResult.Append($"Uniéndote a la partida {(selected.IsPublic ? "pública" : "privada")} " +
                                      $" de tipo {selected.BoardType.GetMethod("BoardTypeName")?.Invoke(null, null)}. ID: {selected.Identifier}");
                }
                else
                {
                    // Buscar partida por ID
                    if (this.gameContainer.AvailableGames.Any(g =>
                            g.Identifier.Equals(args[2], StringComparison.Ordinal)))
                    {
                        Game game = this.gameContainer.Search(args[2]);
                        if (!game.GameStatus.Equals(GameStatus.Waiting) || game.Players.Count > 1)
                        {
                            throw new NoMatchFoundException("La partida a la que quieres unirte ya empezó o" +
                                                            "está llena.");
                        }

                        game.AddPlayer(user);
                        textResult.Append(
                            $"Uniéndote a la partida {(game.IsPublic ? "pública" : "privada")} de tipo " +
                            $"{game.BoardType.GetMethod("BoardTypeName")?.Invoke(null, null)}. " +
                            $"ID: {game.Identifier}");
                    }
                    else
                    {
                        // Buscar partida por tipo de tabla.
                        // join by type.
                        // Buscar partida en curso -> unirse cualquier partida del tipo dado.
                        List<Game> availableGames =
                            (from game in this.gameContainer.AvailableGames
                                where game.IsPublic &&
                                      game.GameStatus.Equals(GameStatus.Waiting) &&
                                      game.Players.Count < 2 &&
                                      boardsManager.GetTagByType(game.BoardType).Equals(args[2], StringComparison.Ordinal)
                                select game).ToList();
                        if (availableGames.Count == 0)
                        {
                            throw new NoMatchFoundException($"No se pudo encontrar ninguna partida de tipo " +
                                                            $"{args[2]} a la cual unirte. Intenta crear una nueva partida.");
                        }

                        Game selected = availableGames[new Random().Next(availableGames.Count)];
                        selected.AddPlayer(user);
                        textResult.Append(
                            $"Uniéndote a la partida {(selected.IsPublic ? "pública" : "privada")} de tipo " +
                            $"{selected.BoardType.GetMethod("BoardTypeName")?.Invoke(null, null)}. " +
                            $"ID: {selected.Identifier}");
                    }
                }
            }
            else
            {
                textResult.Append(
                    $"comando \"{message.Text}\" no reconocido. Uso: \"/match join <type/ID>\" o \"/match create (type) <public/private>\"");
            }

            return textResult.ToString();
        }
    }
}