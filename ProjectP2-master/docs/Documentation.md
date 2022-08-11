# Acordamos hacer las clases, metodos y en general codigo del programa en ingles. Pero los comentarios
# en español.

## ¿ Como nos repartiremos las clases para cada integrante del equipo ? (En un inicio)

# Clases:

# Game depende de muchas clases asi que se dejara para despues de terminar las clases individuales.


- TelegramBot (Viene hecho)

# Los handlers son complejos, ademas de que precisan el resto de clases terminadas, posponemos el repartirlas
- IHandler
- BaseHandler
- TutorialHandler
- StartGameHandler
- GameHandler

# Santiago Ferraro
- User
- UserHandlerStatus
- HandlerStatus
- Organizer
- FriendsHandler
- RegistarseHandler
- StatsHandler

# Pablo Mendez
- Boat
- SailBoat
- AircraftCarrier
- Vessel
- Submarine
- Cruise

# Pilar Machado
- Container<T>
- UserContainer<User>
- GameContainer<Game>

# Leandro Alfonso
- Game
- GameStatus
- Board
- SmallBoard
- MediumBoard
- LargeBoard

# Otros temas a repartir (Para despues):
- Serialización
- Estetica
- Tests (¿ Cada uno hace de sus clases ?)
- Comentarios (¿ Cada uno hace de sus clases ?)

# ¿ Que sucedió posterior a este reparte inicial ?
Lo comentado previamente fue como nos repartimos en un inicio, luego sucedió que todos terminamos interactuando con la mayoría de las clases, ya que las clases interactúan entre sí, y usualmente ocurría que compañeros se encontraban con ideas ingeniosas para mejorar la eficiencia y calidad del trabajo. Esto paso seguido por ejemplo en el caso de excepciones, y a la hora de hacer tests. Además, a medida que terminábamos dichas clases iniciales nos debamos cuenta de nuevas clases que precisaríamos, y añadidos que permitirían agregar nuevos patrones y principios.

# ¿ Como nos organizamos en el repositorio ?
En el repositorio cada uno de nosotros posee su propia rama donde haremos nuestros cambios, master posee el código funcional, que obligatoriamente debe compilar y sus tests deben pasar. Nunca se hacen commits o push directos a master desde master, siempre los cambios que se manden a master deben ser hechos mediante un Pull Request desde la rama de cada uno. A la hora de hacer un PullRequest a master desde nuestras ramas nos aseguramos resolver conflictos, en caso de ser necesario hacer reseñas en partes que puedan precisar algún cambio, y por último hacer el merge, el cual debe ser hecho por un integrante que no sea aquel que mando el Pull Request. Siempre intentamos de hacer pulls desde la master a nuestra rama cada vez que hacemos un merge a está, así todos tenemos en nuestras ramas código funcional, y en caso de crear tests o clases que se relacionen con otras, tener los últimos cambios para no hacer código con respecto a algo viejo que se pudo haber cambiado.
