# Act-4-2939586

Instrucciones:

Mecánicas de Juego
Movimiento del Jugador: El jugador puede moverse en cuatro direcciones (arriba, abajo, izquierda, derecha) utilizando las teclas de dirección o las teclas W, A, S, D. El movimiento se controla a través de un componente Rigidbody2D que aplica velocidad al jugador.

Ataque: El jugador puede atacar a los enemigos al tocarlos. Cuando el jugador colisiona con un enemigo, este recibe daño y puede ser destruido si su salud llega a cero. Esto se implementa mediante un sistema de colisiones utilizando OnTriggerEnter2D.

Enemigos: Los enemigos se moverán hacia el jugador si están dentro de un rango de detección específico. Cada enemigo tiene una cantidad máxima de salud, y al recibir daño, su salud disminuirá. Cuando la salud de un enemigo llega a cero, este es destruido.

Estructura del Proyecto
Scripts:

PlayerController.cs: Controla el movimiento y la interacción del jugador con los enemigos.
Enemy.cs: Define el comportamiento de los enemigos, incluyendo su movimiento y cómo reciben daño.
Sprites: Se utilizan sprites para representar al jugador y a los enemigos, permitiendo cambiar la apariencia del jugador según la dirección en la que se mueva.

Controles
Movimiento: Usa las teclas de dirección o W, A, S, D para mover al búho.
Ataque: Toca a un enemigo para infligir daño.
