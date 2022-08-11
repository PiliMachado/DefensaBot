using System.Collections.Generic;
using System.Text;
using Library.BotUtils;
using Library.ContainerUtils;
using Library.Handlers;
using Library.UserUtils;
using NUnit.Framework;

namespace LibraryTests
{
    /// <summary>
    /// Tests relacionados a AyudaHandler.
    /// </summary>
    public class HelpHandlerTests
    {

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void NotRegistratedStillHandles()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            HelpHandler helpHandler = new HelpHandler();
            Message message = new Message(123456, "/ayuda");
            string actual = helpHandler.Handle(message);
            StringBuilder textResult = new StringBuilder();
            textResult.Append("Listas de comandos: (<> = opcional, %valor% = valor dado por usuario)\n");
            textResult.Append("\nFuera de la partida: ");
            textResult.Append("\n\t - /ayuda - Muestra esta lista de comandos");
            textResult.Append("\n\t - /tutorial - Aprende a jugar");
            textResult.Append("\n\t - /amigos:");
            textResult.Append("\n\t\t - /amigos add %user_id% - Añade un nuevo amigo.");
            textResult.Append("\n\t\t - /amigos remove %user_id% - Remueve un amigo.");
            textResult.Append("\n\t\t - /amigos stats %user_id% - Muestra las estadísticas de un amigo.");
            textResult.Append("\n\t\t - /amigos list - Muestra tu lista de amigos.");
            textResult.Append("\n\t - /partida:");
            textResult.Append("\n\t\t - /partida join <type/ID> - Intenta unirte a una partida, según el tipo de board, el id de la partida, o cualquier partida.");
            textResult.Append("\n\t\t - /partida create %type% <public/private> - Crea una nueva partida del tipo dado y la accesibilidad dada (publico por defecto).");
            textResult.Append("\n\t - /registro %nombre% %apellido% %nickname% - Registro en la lista de usuarios.");
            textResult.Append("\n\t - /stats - Muestra tus estadisticas.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\nEn la partida:");
            textResult.Append("\n\t - /attack %letra% %numero% - Intenta realizar un disparo en la coordenada dada del otro jugador.");
            textResult.Append("\n\t - /boards - Observa tu tabla y la de tu enemigo.");
            textResult.Append("\n\t - /salir - Salir de la partida.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\t\tAgregando botes:");
            textResult.Append("\n\t - /boat list - Muestra los botes que has colocado.");
            textResult.Append("\n\t - /boat add (type) (start) (finish) - Añade un nuevo bote a la tabla.");
            textResult.Append("\n\t - /boat info - Ver la información de tus botes.");
            textResult.Append("\n\t - /boat remove (id) - Remueve un bote por su id a la tabla.");

            string expected = textResult.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RegistratedStillHandles()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            HelpHandler helpHandler = new HelpHandler();
            Message message = new Message(123456, "/ayuda");
            string actual = helpHandler.Handle(message);
            StringBuilder textResult = new StringBuilder();
            textResult.Append("Listas de comandos: (<> = opcional, %valor% = valor dado por usuario)\n");
            textResult.Append("\nFuera de la partida: ");
            textResult.Append("\n\t - /ayuda - Muestra esta lista de comandos");
            textResult.Append("\n\t - /tutorial - Aprende a jugar");
            textResult.Append("\n\t - /amigos:");
            textResult.Append("\n\t\t - /amigos add %user_id% - Añade un nuevo amigo.");
            textResult.Append("\n\t\t - /amigos remove %user_id% - Remueve un amigo.");
            textResult.Append("\n\t\t - /amigos stats %user_id% - Muestra las estadísticas de un amigo.");
            textResult.Append("\n\t\t - /amigos list - Muestra tu lista de amigos.");
            textResult.Append("\n\t - /partida:");
            textResult.Append("\n\t\t - /partida join <type/ID> - Intenta unirte a una partida, según el tipo de board, el id de la partida, o cualquier partida.");
            textResult.Append("\n\t\t - /partida create %type% <public/private> - Crea una nueva partida del tipo dado y la accesibilidad dada (publico por defecto).");
            textResult.Append("\n\t - /registro %nombre% %apellido% %nickname% - Registro en la lista de usuarios.");
            textResult.Append("\n\t - /stats - Muestra tus estadisticas.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\nEn la partida:");
            textResult.Append("\n\t - /attack %letra% %numero% - Intenta realizar un disparo en la coordenada dada del otro jugador.");
            textResult.Append("\n\t - /boards - Observa tu tabla y la de tu enemigo.");
            textResult.Append("\n\t - /salir - Salir de la partida.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\t\tAgregando botes:");
            textResult.Append("\n\t - /boat list - Muestra los botes que has colocado.");
            textResult.Append("\n\t - /boat add (type) (start) (finish) - Añade un nuevo bote a la tabla.");
            textResult.Append("\n\t - /boat info - Ver la información de tus botes.");
            textResult.Append("\n\t - /boat remove (id) - Remueve un bote por su id a la tabla.");

            string expected = textResult.ToString();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void IncorrectCommand()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            HelpHandler helpHandler = new HelpHandler();
            StatsHandler handler = new StatsHandler();
            helpHandler.SetNext(handler);
            Message message = new Message(123456, "/stats");
            string actual = helpHandler.Handle(message);
            string expected = "Stats de Ferri (#123456): \n - Total de victorias: 0 \n - Total de perdidas: 0 \n - Total de empatadas: 0 \n - Porcentaje de aciertos: 0% \n - Porcentaje de desaciertos: 0%";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void IncorrectFormat()
        {
            UserContainer userContainer = Singleton<UserContainer>.Instance;
            userContainer.Elements = new List<User>();
            userContainer.AddElement(123456, "Santiago Ferraro", "Ferri");
            HelpHandler helpHandler = new HelpHandler();
            Message message = new Message(123456, "/ayuda help help");
            string actual = helpHandler.Handle(message);
            Message message2 = new Message(123456, "/help ayuda");
            string actual2 = helpHandler.Handle(message2);
            StringBuilder textResult = new StringBuilder();
            textResult.Append("Listas de comandos: (<> = opcional, %valor% = valor dado por usuario)\n");
            textResult.Append("\nFuera de la partida: ");
            textResult.Append("\n\t - /ayuda - Muestra esta lista de comandos");
            textResult.Append("\n\t - /tutorial - Aprende a jugar");
            textResult.Append("\n\t - /amigos:");
            textResult.Append("\n\t\t - /amigos add %user_id% - Añade un nuevo amigo.");
            textResult.Append("\n\t\t - /amigos remove %user_id% - Remueve un amigo.");
            textResult.Append("\n\t\t - /amigos stats %user_id% - Muestra las estadísticas de un amigo.");
            textResult.Append("\n\t\t - /amigos list - Muestra tu lista de amigos.");
            textResult.Append("\n\t - /partida:");
            textResult.Append("\n\t\t - /partida join <type/ID> - Intenta unirte a una partida, según el tipo de board, el id de la partida, o cualquier partida.");
            textResult.Append("\n\t\t - /partida create %type% <public/private> - Crea una nueva partida del tipo dado y la accesibilidad dada (publico por defecto).");
            textResult.Append("\n\t - /registro %nombre% %apellido% %nickname% - Registro en la lista de usuarios.");
            textResult.Append("\n\t - /stats - Muestra tus estadisticas.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\nEn la partida:");
            textResult.Append("\n\t - /attack %letra% %numero% - Intenta realizar un disparo en la coordenada dada del otro jugador.");
            textResult.Append("\n\t - /boards - Observa tu tabla y la de tu enemigo.");
            textResult.Append("\n\t - /salir - Salir de la partida.");
            textResult.Append("\n\t - /info - Muestra información relevante.");
            textResult.Append("\n\t\tAgregando botes:");
            textResult.Append("\n\t - /boat list - Muestra los botes que has colocado.");
            textResult.Append("\n\t - /boat add (type) (start) (finish) - Añade un nuevo bote a la tabla.");
            textResult.Append("\n\t - /boat info - Ver la información de tus botes.");
            textResult.Append("\n\t - /boat remove (id) - Remueve un bote por su id a la tabla.");

            string expected = textResult.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual2);
        }
    }
}