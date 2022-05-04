PROGRESO TFM

En primer lugar, se instalaron los drivers y programas necesarios para poder emplear el dispositivo háptico "Phantom Omni" en el ordenador,
así como Unity para la programación. Así mismo, se descargó e importó el paquete de Omni para Unity de modo que se pudiera utilizar en los
proyectos. Así mismo, también contenía ya diferentes scripts, demos de ejemplo, "Prefabs" los cuales se fueron observando para entender
el funcionamiento y como agregar este dispositivo a los proyectos de Unity así como sus funcionalidades.

Así, a modo de prueba, se creó un proyecto con dos esferas atracivas. Ambas contenían una zona común y se observó cómo el "lápiz"
en dicha zona se mantenía "libre", pero al acercarse al centro de alguna de las esferas, era rápidamente atraído al mismo, como se observa
en el video "Testing_Esferas" de este repositorio.

Seguidamente, una vez se dispuso de acceso a los archivos de "TFM_Maria" el cual consistía en un Serious Game con diferentes mapas, registro
de resultados para usuarios, ejercicios rehabilitación, entre otros, se comenzó observando el funcionamiento y el código de los mismos para entender
qué hacía cada cosa.

A continuación, se tomó la escena de un laberinto como base (7.1Path) y se trató de aplicar el lápiz háptico en lugar de la bola a la hora de
desplazarse por el laberinto hasta el objetivo final. Para ello, se agregó el Prefab "HapticDeviceWithGrabber" el cual ya agregaba los scripts
necesarios para mostrar el puntero en la escena del juego al moverlo. Seguidamente, se modificaron y crearon nuevos scripts (PointerController)
para sustituir la bola por el lápiz a la hora de recorrer el laberinto y lanzar los eventos y señales necesarios para contar las salidas del tablero,
el tiempo de recorrido, cuando llega al final para mostrar la ventana de éxito...

En primer lugar, a la escena se agregó un plano "debajo" del laberinto de modo que el puntero no pudiera atravesarlo y pudiera moverse libremente,
limitando todos sus desplazamientos a 2 dimensiones (XY) para un mejor control y comprensión de los movimientos por el laberinto.

![plano_restr_2D](https://user-images.githubusercontent.com/69549100/166656751-8b97314e-f0d9-450a-9e29-0022a221d20f.png)

Como primer planteamiento, se creó un "Polyshape" invertido con la forma del laberinto y se agregaron las propiedades necesarias para que el puntero
colisionara con el mismo. De esta forma, una vez que el lápiz se ha colocado dentro de este objeto, no se permite que salga, de modo que si el puntero
háptico se intenta salir del laberinto, notará una fuerza que se lo impide.

![polyshape_restr](https://user-images.githubusercontent.com/69549100/166656771-10afb031-3c52-4435-8c16-ba44fc99a010.png)

Posteriormente, se plantearon diversos métodos de realimentación para los laberintos:
- Polyshape restringe movimiento (sensación de contacto con las paredes)
- Vibración al entrar en contacto con dichas paredes
- SIN PAREDES. Vibración más intensa conforme se aleja el puntero del laberinto (mayor error o desviación, mayor vibración) -> complejo de implementar ?
- ?? Implementar fuerza atractiva hacia centro del laberinto (ayuda). Cuando más lejos el puntero, mayor la fuerza
- Sonido al salirse. El volumen podría variar según distancia del puntero al laberinto. (realimentación auditiva)
  - Sonido agudo*
  - Sonido grave* -> estudiar resultados según tipo de sonido ??
- Mensaje de aviso cuando se sale (realimentación visual)
