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
- ***Mensaje o imagen de aviso en VR ?? Posibilidad aplicación en VR (si da tiempo)

-------------------------------------------------------------------------------
16/05/2022

Se ha creado una esfera contenedora del laberinto para testear cómo hacer que el lápiz sea atraído al centro del espacio de trabajo al inicio del juego. Posteriormente, se parametrizará el script para que vaya a la zona central del mapa, pudiendo aplicar simplemente el script a cualquier mapa sin tener que crear la esfera.

Por otro lado, se creó un script referenciado al objeto "HapticDeviceWithGrabber > Grabber > Sphere" de modo que, cuando se inicia el test (el puntero se posiciona en la zona inicial verde) se comienzan a guardar en un fichero .txt (Assets/trajs/trajectory.txt) las posiciones (X,Y,Z) del puntero cada 0.1s. Una vez finaliza el programa, se cierra el archivo de escritura y es accesible para otros programas o para revisarlo.
Seguidamente, se creó un script en Python 3.9 que lee las coordenadas del archivo .txt y crea un array de puntos 3D. A partir de este array, se muestra una gráfica con al trayectoria seguida por el paciente como se puede observar en la siguiente figura:

![testTraj1](https://user-images.githubusercontent.com/69549100/168579924-7bc50965-900f-49b0-ae96-dd0fdaab68d0.png)

En esta prueba, se comenzó en la zona inicial, se subió el puntero hacia arriba (en Y) y se dibujó un circulo alrededor de la zona de inicio. Seguidamente, se alejó el puntero de la zona inicial hacia fuera, en el sentido del eje Z.

También fue necesario realizar algunos ajustes para que los ejes de la gráfica mostrada correspondieran a los de la escena en Unity, de modo que es mucho más fácil manejar y entender la gráfica y observar los movimientos realizados. Adicionalmente, se mostraron dos esferas características para mostrar el punto inicial de la trayectoria (color verde) y el punto final (color rojo).

Por otro lado, también se intentó parametrizar el efecto retenedor del lápiz al laberinto para no emplear polyshapes a modo de paredes, sino referenciando al GameObject de la linea central existente en todos los laberintos. De esta forma, la idea sería que, según la distancia mínima entre el punto y esta línea central, hacer una fuerza de atracción de magnitud mayor o menor. Es decir, si el puntero está muy cerca de la zona central del laberinto, la magnitud será mínima y no se notará ninguna fuerza. No obstante, si el lápiz se aleja demasiado de la zona central, la magnitud irá aumentando, atrayendo al usuario hacia el laberinto.
Desafortunadamente, durante las pruebas se observó que la distancia calculada entre ambos objetos no se realiza con todos los puntos del PolyShape, sino con el punto final, como vemos en la siguiente imagen:

![distance](https://user-images.githubusercontent.com/69549100/168580993-78c9ffe2-7322-437b-8f77-27a3c505012f.png)

Tras realizar numerosas búsquedas en internet, no se logró llegar a ninguna solución, por lo que se abrió un tema en el foro de la comunidad de Unity para pedir ayuda (https://answers.unity.com/questions/1902394/get-distance-from-moving-gameobject-and-probuilder.html). Quedará estar a la espera de alguna respuesta o solución.

-------------------------------------------------------------------------------
23/05/2022

De momento la visualización se ve bien -> añadir unidades a ejes y escalar (eje Z va de 0.005 y X e Y de 2 en 2).
Hacer la visualización directamente al acabar el laberinto (o crear un .bat del código python y que unity lo ejecute al acabar o mirar si hay forma de llamar python desde unity)
Para futuro, la idea del proyecto sería:
- Modular la entrada de control de la bola para poder seleccionar entre el OmniPhantom, ratón navigator (3D?) y posteriormente brazo robótico. Así se podría trabajar tanto evaluación fina (muñeca y movimientos pequeños) como evaluación grande (movimiento del brazo completo).
- 3 modos: 
  -  sin asistencia (todo libre, solo plano para no caer)
  -  atracción (intentar atraer a segmentos de laberintos o coins más cercano para ir guiando al usuario)
  -  repulsión (túnel que expulsa bola cuando se acerca a paredes, es decir, se sale mucho del laberinto) para la parametrización del túnel se podría buscar alguna forma de, a partir de un conjunto de puntos (los que definen el polyshape), crear un objeto con esa forma, como extruir una U muchas veces a lo largo del laberinto, así se podría adaptar a cualquier escena.
-  *Echar un ojo a Barracuda y Input Manager API de Unity (para ver si existe alguna clase que permita ajustar fácilmente que el control del puntero sea con Omni Phantom, ratón o brazo robótico).
