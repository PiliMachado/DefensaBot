using System;
using System.Linq;
using System.Text;
using Library.BoardUtils;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.GameUtils;
using Library.UserUtils;
using Microsoft.VisualBasic.CompilerServices;

namespace Library.Handlers
{
    /// <summary>
    /// Maneja el comando /disparos o /shot para permitir ver los disparos en una partida.
    /// </summary>
    public class GameShotHandler : AbstractHandler
    {
        private readonly UserContainer userContainer = Singleton<UserContainer>.Instance;
        private readonly GameContainer gameContainer = Singleton<GameContainer>.Instance;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameDisparosHandler"/>.
        /// </summary>
        /// <param name="next">El siguiente handler en la cadena de responsabilidad.</param>
        public GameShotHandler(IHandler next = null) : base(next)
        {
        }

        /// <inheritdoc />
        protected override bool CanHandle(Message message)
        {
            User sender = this.userContainer.Search(message.ID);
            string[] messageUsu = message.Text.ToLower().Trim().Split(" ");
            return sender != null && !sender.UserStatus.Equals(UserStatus.Lobby) &&
                   (messageUsu[0].Equals("/shot", StringComparison.OrdinalIgnoreCase)
                    || messageUsu[0].Equals("/disparos", StringComparison.OrdinalIgnoreCase));
        }

        /// <inheritdoc />
        protected override string InternalHandle(Message message)
        {
            StringBuilder resultText = new StringBuilder();
            User user = this.userContainer.Search(message.ID);
            Game game = this.gameContainer.AvailableGames.Find(p => p.Players.ContainsKey(user) && !p.GameStatus.Equals(GameStatus.Finished));

            if (game == null)
            {
                user.UserStatus = UserStatus.Lobby;
                throw new NullPointerException("Un error ha ocurrido en el que aparece que estas en un juego pero no existe un juego en el que te encuentres.");
            }

            string[] messageUsu = message.Text.Trim().Split(" ");
            
            if (messageUsu[1] == "barcos")
            {
                resultText.Append($"Total de disparos:\n");
                resultText.Append($"La cantidad de disparos en el barco fueron: {game.BoatShot}");
            }
            else if (messageUsu[1] == "agua")
            {
                resultText.Append($"Total de disparos:\n");
                resultText.Append($"La cantidad de disparos que se hicieron en el agua fueron: {game.WaterShot}");
            }
            
            return resultText.ToString();

            if (messageUsu.Length != 2)
            {
                throw new InvalidCheckException("El mensaje que has enviado es invalido. Uso del comando: \"/disparos agua\" o \"/disparos barco\"");
            }
            else if (messageUsu[1] != "agua" && messageUsu[1] != "barcos")
            {
                throw new InvalidCheckException("El mensaje que has enviado es invalido. Uso del comando: \"/disparos agua\" o \"/disparos barco\"");
            }
        }
    }
}