## README con tópicos importantes sobre la creación y funcionalidad del bot.

# Dificultades

En un principio la creación de las clases no fue demasiado compleja, ya que para la anterior entrega tuvimos que hacer un diagrama UML el cual nos guio en los inicios del bot. Pero luego de haber llevado a cabo la mayoría de las clases, nos dimos cuenta de métodos, y clases que faltaban. Las clases precisaban de aún más clases de lo que pensábamos para que tengan un correcto funcionamiento, el crear dichas clases que en última instancia dieron vida a lo que se había propuesto en el diagrama fue una de las dificultades que nos encontramos.

Otro problema que nos ocurrió seguidamente es la aparición de excepciones en los handlers, para poder resolver dichos problemas fue necesario añadir bloques try catch, y también creamos un montón de excepciones propias cuya función es respaldar casos que no deberían ocurrir, por ejemplo, que un usuario no registrado quiera acceder a un comando que requiera que lo esté.

Otra dificultad que no esta tan relacionada con la programación, sino que con el trabajo grupal fueron los horarios, no todos disponíamos de tiempo libre en los mismos horarios, esto por supuesto dificulto la coordinación y el que todos pudiéramos estar juntos en algunas reuniones, fue posible resolver este incidente encontrando uno de los pocos momentos en los cuales todos estamos libres, que es después de la clase de programación II.

# Completada toda parte de la consigna

- Como jugador debo poder iniciar una partida:
Para completar esta consigna decidimos crear MatchHandler, el cual responde a un comando en específico para
poder jugar una partida. Pero no nos quedamos solo en ese punto, decidimos que una buena idea e implementación
del GameIdentifier creado podría ser que un jugador pueda crear juegos privados a los cuales solo pueden acceder aquellos que conozcan el identificador, de esta forma un jugador podrá jugar contra amigos o conocidos. Por
otro lado si un user decide unirse a un juego tiene dos opciones, unirse a un juego público o unirse a uno privado con el identificador. Al tratar de unirse a un juego publico si no hay ningún juego disponible el user quedara en la lista de espera, esperando a que otro jugador decida jugar también.

- Como jugador debo posicionar mis naves antes de comenzar con el primer movimiento.
Para completar esta consigna decidimos crear varios PlaceBoatsHandler, para que en el primer movimiento el usuario se vea obligado a posicionar sus naves (Con PlaceBoatsAddHandler y el comando /boat add <tipo de bote> <coordenada inicial> <coordenada final>), la idea es que el usuario indique el tipo de bote, y las coordenadas inicial y final, y que según una cierta cantidad de verificaciones (Como la cantidad de botes para la board, cuales botes se han añadido, cuales faltan, etc.), se fije si el bote quedo bien posicionado (Que no este en diagonal, ni fuera de la board). Esto ocurrirá hasta que posicione todos los botes que tiene habilitados para ese gamemode, este valor se vera según el tipo de board en BoatsContainer. Para poder visualizar los botes que se deben poner en el gamemode que se esta jugando se usa el PlaceBoatsListHandler (Con el comando /boat list). Para ver que botes le falta posicionar puede usar el PlaceBoatsInfoHandler (Con el comando /boat info). Y para poder remover un bote que capaz uno quiera posicionar en otro lugar esta el PlaceBoatsRemoveHandler (Con el comando /boat remove <id>).

- Como jugador debo poder acceder a dos tableros, uno para visualizar mis propias naves y otro para que contenga los disparos realizados.
Para completar esta consigna decidimos que esta funcionalidad se encuentre tanto en Board como en GameBoardsHandler. Un jugador tiene acceso a dos boards, la suya y la del oponente, pero para evitar que se imprima las posiciones de los botes del oponente creamos un método GetPrintableBoard que precisa como parámetro un booleano isOwner. De esta forma verificamos si fuéramos a imprimir la board para un user que no es el dueño de ella, los lugares con posiciones de bote que no fueron atacadas aparecerán vacías, es decir el usuario solo podrá ver los ataques que ha hecho a la board enemigas y con ello sus aciertos y desaciertos. Para la impresión de una board propia lo que ocurre es que aparecen las posiciones en las que se encuentra los botes, y las zonas donde hubo ataques (Un círculo si dio al agua, y una cruz si le dio a un bote).

- Como jugador debo poder indicar una posición de ataque.
Para completar esta consigna creamos GameAttackHandler, este se encarga de manejar el comando /attack para asi intentar de atacar a la posicion seleccionada en la board enemiga, el handler devuelve si ocurrio un error por OutOfIndex, si el disparo fue un acierto, un desacierto, o si en algun caso le ataque una misma posicion atacada previamente.

- Como administrador del juego, debo poder registrar usuarios.
Para completar esta consigna creamos RegisterHandler, este se encarga de manejar el comando /register para así registrar un nuevo usuario en el UserContainer, si el usuario ya está registrado entonces no se le permitirá registrarse una segunda vez. Además hicimos que en todos los handlers que precisen de un usuario registrado, si el usuario no lo está gracias a una excepción devuelva un mensaje del tipo, "Debe registrarse use /register".

- Como administrador del juego, debo poder conectar dos jugadores que se encuentren esperando para jugar.
Para completar esta consigna creamos MatchHandler, este se encarga de manejar el comando /match, dependiendo de cuál de las 2 opciones, join o create, se creara un juego nuevo, cuyo estado público o privado lo decide el usuario, o se unirá a un juego ya creado, hay dos rutas posibles para el /match join, en caso de que el usuario indique un identificador, el usuario se unirá al juego del mismo identificador ingresado, si no se especificó ningún identificador el jugador se unirá a una partida publica, si no hay un juego creado el jugador se quedara esperando a que otro se una.

- Como administrador debo poder actualizar el tablero de registro de ataques, cuando un jugador ataca a otro.
Ocurre en GameAttackHandler, y esta consigna esta implementada en la clase Board gracias al enumerable BoardHitStatus, a la hora de que un usuario ataque a una posición de la Board, se llamara al método de ella llamado Hit, y se pasara por parámetro la fila y columna que se desea atacar, verificamos si la posición a la que ataco no está fuera de la board, si le pego a una zona donde no hay un barco, si le pego nuevamente a la misma zona donde había un barco, o si le pego a una nueva posición de un barco. En este último caso el atributo WasHit del BoatPosition cambiara a true, y a la hora de imprimirse la board con el método GetPrintableBoard aparecerá dicha posición como una X. GameBoardsHandler se encargara de llamar al metodo GetPrintableBoard.

- Como administrador debo poder actualizar el tablero de un jugador cuando recibe un ataque.
Esta consigna esta implementada de la misma forma en la que se implementó la consigna anterior.

- Como administrador del juego, debo poder almacenar todas las partidas en juego, junto con sus datos (tableros, jugadores, etc.)
Esta consigna esta implementada en GameContainer, este posee un atributo AvailableGames que es una lista de Games, la cual cada vez que se inicie una nueva partida será actualizada agregando el nuevo Game, y el Game guardado posee todos los datos de Board, Users, y otros.

- Como administrador del juego, se debe permitir tantas rondas como sean necesarias para cada una de las partidas.
Esta consigna esta implementada en GameAttackHandler, un Game no terminara hasta que uno de los dos jugadores pierda o que use el comando /salir uno de los players, en cuyo caso pierde, el handler que maneja dicho comando es GameExitHandler.

- Como administrador del juego, luego de cada ataque debo indicar el resultado del mismo a ambos participantes (si el ataque coincide con la posición de un barco: "Tocado" en caso de haber más partes aún sin atacar, "Hundido" sino quedan partes de la nave por atacar, o bien si no ha tocado ninguna parte de una nave indicará "Agua".
Esta consigna esta implementada en GameAttackHandler, luego de cada ataque que haga un jugador se imprimirá el resultado de dicho ataque, y si fue un ataque exitoso se responderá si el barco ya ha sido hundido, también a su vez en caso de querer ver las boards nuevamente, estas ya se verán actualizadas.

- Como administrador debo indicar que se finalizó la partida cuando todas las naves de un jugador queden hundidas.
Esta consigna esta implementada en GameAttackHandler, un jugador pierde cuando todos sus botes estan hundidos.

# Ideas

Crear partidas privadas fue una de las ideas que se nos ocurrió, para unirse a ellas es necesario un identifier, único de cada Game, también por ello fue necesario crear la clase GameIdentifier cuya función es generar identificadores.

Unirse a juegos públicos, si es que existen juegos públicos ya creados el jugador se unirá al primero de la lista, de esta forma el jugador que lleva la mayor cantidad de tiempo esperando en una partida creada será el primero en tener un usuario que se una.

UserStatus en User, existen ocasiones en las que un jugador no debería poder usar ciertos comandos, por ejemplo, cuando un jugador está en una partida no debería poder usar otros comandos que no sean los referentes a GameHandlers. Para esto se creó un enumerable UserStatus, esta indica si un usuario está en el lobby, esperando por una partida, o jugando, así evitamos el uso de comandos indebidamente.

Timer por turnos, si un jugador demora demasiado en responder perderá su turno, así el segundo jugador no perderá tiempo contra un jugador que se encuentre inactivo, el agregado de este timer también ayuda a obligar a los jugadores a pensar más rápido en sus movimientos, y a hacer que el juego no sea aburrido por una espera indefinida.


# Como aplicamos nuestras funciones personalizadas

- Funcionalidad de stats:
Para cumplir con esta funcionalidad se creó un handler llamado StatsHandler, este permite ver los stats de uno mismo, que incluye las victorias, derrotas, empates, el porcentaje de aciertos, desaciertos, nombre, nickname e ID.

- Funcionalidad de amigos:
Para cumplir con esta funcionalidad se creó un handler llamado FriendsHandler, este permite agregar amigos, remover amigos, ver la lista de amigos, y ver los stats de amigos.

- Funcionalidad de gamemodes:
Para cumplir con esta funcionalidad se crearon 3 tipos de Board, SmallBoard, MediumBoard y LargeBoard, de esta forma puedes decidir con cual jugar según si quieres jugar una partida rápida, normal o larga.

- Funcionalidad de partidas privadas:
Para cumplir con esta funcionalidad se creó GameIdentifier, y se agregó a game un atributo isPublic, y se agregó en MatchHandlers la posibilidad de crear partidas privadas o unirse a ellas.

- Funcionalidad de chatear entre jugadores:
Para cumplir con esta funcionalidad se creó un handler llamado GameChatHandler, este detecta si el mensaje de un usuario en una partida no tiene en su inicio el carácter /, en tal caso envía el mensaje al otro usuario.

- Funcionalidad de tutorial:
Para cumplir con esta funcionalidad se creó un handler llamado TutorialHandler, este detecta si el mensaje de un usuario empieza con /tutorial, y dependiendo de los otros parámetros que mande con el comando podrá ver como registrarse, interactuar con amigos, añadir y ver botes, unirse o crear una partida, ver el tablero, o ver su información.

# Aplicación de patrones/principios

- *Creator* en containers (GameContainer, Game, y UserContainer crean instancias de Game, Boat, y User ya que las guardan)
- *Chain of responsability* en los handlers (Los handlers poseen un atributo Next y métodos para ver si pueden manejar un mensaje, para procesar el mensaje y para en caso de no manejarlo darle al próximo handler la instrucción de manejarlo) - Fuente: Refactoring guru / Clase
- *Singleton* gracias a la clase Singleton (Al crear GameIdentifier, GameContainer y UserContainer se usa la clase Singleton para poseer una única instancia de las clases) - Fuente: Refactoring guru / Clase
- *Expert* en casi todas las clases (Algunos ejemplos son GameContainer añade y remueve los games por que es quien conoce la lista de games, UserContainer añade y remueve los user porque es quien conoce la lista de users, y este tópico sucede con todas las clases que guardan instancias de otras, como Board, Boat, y Game. User es quien calcula el porcentaje de aciertos y desaciertos ya que es el que conoce la cantidad de aciertos y desaciertos, Board obtiene la board a enviar ya que es quien conoce la información de todas las posiciones, y que poseen, GameIdentifier es quien genera los identificadores ya que conoce los caracteres que se pueden usar para crearlos y conoce los identificadores ya creados.) 
- *Polimorfismo* en handlers (Método polimórfico SetNext), y board (Métodos polimórficos AddBoat, y RemoveBoat). también en BoatPositions encontramos sobrecarga en los métodos Equals.
- *OCP* en los handlers, los handler son abiertos a la extensión y cerrados a la modificación, si se quiere agregar un nuevo comando no es necesario cambiar un handler, simplemente creamos un nuevo handler que herede de abstract handler, y se añada al chain of responsability mediante el método polimórfico SetNext.
- *DIP* en FriendsHandler (Depende de abstracciones de User en vez del mismo, IFriendsHolder y IStatsHolder) y StatsHandler (Depende de una abstracción de User, IStatsHolder)
- *ISP* en FriendsHandler (Depende de IFriendsHolder) y StatsHandler (Depende de IStatsHolder): Para aplicarlo en el caso de IFriendsHolder y IStatsHolder, user implementa a las dos ya que hay handlers que precisan solo de una información y otros de otra.
- *Low Coupling & High Cohession* en GameIdentifier, previo al cambio MatchHandler dependía de GameIdentifier y de GameContainer, ahora MatchHandler solo depende de GameContainer, y GameContainer depende de GameIdentifier, el acoplamiento es más bajo evitar que cambios en una clase impliquen cambios en una clase dependiente, por ejemplo, cambios en GameIdentifier afectan ahora sólo a GameContainer pero no a MatchHandler. También se puede ver high cohession en prácticamente todo el código, un ejemplo es el GameIdentifier, para que las responsabilidades de GameContainer sean altamente cohesivas, es decir estén muy entre relacionadas, el crear un identificador no está muy relacionado con el resto de sus responsabilidades, por ello se creó una nueva clase GameIdentifier.
- *SRP* En user pasar ciertos atributos a una clase llamada Stats, ya que si en un futuro quisiéramos agregar una nueva estadística (Ej: Doble desaciertos o especificar partidas perdidas/ganadas por afk) y quisiéramos que el user tenga una lista de otros usuarios bloqueados habrían dos razones de cambio lo cual no cumpliría con SRP, de esta forma Stats pasaría a tener una única razón de cambio que sería el agregado de una nueva estadística, y User también una única razón de cambio, que sería tener jugadores bloqueados.

# Reutilización de código:
- Herencia en handlers
- Herencia en boat
- Herencia en boards
- La clase Singleton hace que no sea necesario que cada clase implemente el código necesario para aplicar el patrón.