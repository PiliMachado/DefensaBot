// -----------------------------------------------------------------------
// <copyright file="FriendsHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.UserUtils;
using Microsoft.VisualBasic.CompilerServices;

namespace Library.Handlers
{
    /// <summary>
    /// FriendsHandler es una clase que hereda de AbstractHandler, sus responsabilidades principales
    /// son verificar si puede manejar el mensaje, y en caso de que si, darle opciones de manejo o
    /// administración de la lista de amigos, y la información de estos.
    /// FriendsHandler depende de abstracciones de User, IStatsHolder y IFriendsHolder, de esta forma aplicamos DIP. FriendsHandler solo precisa
    /// de una información especifica del User, por lo cual podriamos depende de una abstracción de dicha clase
    /// para asi si en un futuro cambia User, no cambiara FriendsHandler.
    /// </summary>
    public class FriendsHandler : AbstractHandler
    {
        /// <summary>
        /// Variable UserContainer para verificar que un usuario este agregado en la
        /// lista de usuarios, y obtener al usuario que manda el mensaje.
        /// </summary>
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FriendsHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public FriendsHandler(IHandler next = null)
            : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            string messageText = message.Text.Trim();
            return messageText.StartsWith("/friends", StringComparison.OrdinalIgnoreCase) ||
                   messageText.StartsWith("/amigos", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            if (!this.userContainer.IsRegistered(message.ID))
            {
                throw new NotRegisteredYetException("No estas registrado/a aun. Usa \"/registrase\".");
            }

            IFriendsHolder user = this.userContainer.Search(message.ID);
            StringBuilder textResult = new StringBuilder();
            string[] args = message.Text.Trim().Split(" ");

            switch (args.Length)
            {
                case 0:
                case 1:
                    textResult.Append("Uso: /friends (add/remove/stats/list) <user_id>");
                    break;
                case 2:
                    if (args[1].Equals("list", StringComparison.OrdinalIgnoreCase))
                    {
                        textResult.Append($"Lista de amigos:\n");
                        foreach (User friend in user.Friends)
                        {
                            textResult.Append($"{friend.NickName} (#{friend.ID})\n");
                        }
                    }
                    else
                    {
                        textResult.Append("Uso: /friends (add/remove/stats/list) <user_id>");
                    }

                    break;
                default:
                    try
                    {
                        LongType.FromString(args[2]);
                    }
                    catch (InvalidCastException)
                    {
                        throw new InvalidIDException("El ID de un jugador debe ser de tipo numérico. (Ej: 123)");
                    }

                    IStatsHolder otherUser = this.userContainer.Search(LongType.FromString(args[2]));
                    if (otherUser == null)
                    {
                        throw new NullPointerException(
                            "El ID de usuario que ingresaste no es válido, o el usuario con ese ID aun no se ha registrado.");
                    }

                    if (args[2].Equals(message.ID.ToString(), StringComparison.Ordinal) || otherUser.Equals(user))
                    {
                        throw new CannotBefriendYourselfException("Tu ya eres tu propio amigo.");
                    }

                    switch (args[1])
                    {
                        case "list":
                            textResult.Append($"Lista de amigos:\n");
                            foreach (IStatsHolder friend in user.Friends)
                            {
                                textResult.Append($"{friend.NickName} (#{friend.ID})\n");
                            }

                            break;
                        case "add":
                            bool added = user.AddFriend(otherUser);
                            textResult.Append(added
                                ? $"Amigo {otherUser.NickName} añadido a lista de amigos!"
                                : $"El usuario {otherUser.NickName} ya se encontraba en tu lista de amigos.");
                            break;
                        case "remove":
                            bool removed = user.RemoveFriend(otherUser);
                            textResult.Append(removed
                                ? $"Usuario {otherUser.NickName} removido de tu lista de amigos!"
                                : $"El usuario {otherUser.NickName} no se encuentra en tu lista de amigos.");
                            break;
                        case "stats":
                            if (user.Friends.Contains(otherUser))
                            {
                                textResult.Append($"Stats de {otherUser.NickName}: \nTotal de victorias {otherUser.Stats.Wins} \n-Total de perdidas {otherUser.Stats.Losses} \n-Total de empatadas{otherUser.Stats.Ties} \n-Porcentaje de aciertos {otherUser.Stats.HitPercentage}% \n-Porcentaje de desaciertos {otherUser.Stats.MissPercentage}%");
                            }
                            else
                            {
                                textResult.Append($"El usuario {otherUser.NickName} no se encuentra en tu lista de amigos.");
                            }

                            break;
                        default:
                            textResult.Append("Uso: /friends (add/remove/stats/list) <user_id>");
                            break;
                    }

                    break;
            }

            return textResult.ToString();
        }
    }
}