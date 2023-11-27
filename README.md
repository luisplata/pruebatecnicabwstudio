# pruebatecnicabwstudio

Mucho gusto! mi nombre es Luis Plata y voy a documentar que se hizo en alto nivel para que se entienda un poco lo que se trató de hacer.

## Comportamiento

Al ser un onboarding y el comportamiento fijo. Se decidió en hacer toda la parte de las pantallas con el patrón State. Para eso use un script que se llama `Assets/Scripts/Plugins/TeaTime.cs` la cual me va a ayudar a implementar el patrón state.

Otra cosa que se realizo fue crear un comportamiento de *evaluaciones* durante cada pantalla para poder simplificar el comportamiento de cada pantalla. Y con la posibilidad de poder reutilizar *evaluadores* que ya se hayan creado.

### Patrón State

Para el patrón state, lo realice de forma sencilla para poder seguir adelante. Y al crearla con `TeaTime` se debe de estudiar la herramienta para poder entender que se hizo. Y la razón por la que lo hice con este plugin fue, porque esta implementado para que utilice el hilo principal de unity usando `corrutines` para los tiempos de espera.


### Servicios

Para la parte de firebase y del proceso de login, Lo que se hizo fue que en el Servicio de firebase se tenga que identificar si se va a usar google o email. Tenia pensado en crear el patrón strategy, pero al poder usar ambas opciones, me quede con que se deba notificar que API usar.

### ScreenPlay

Esta parte es la que indica cada pantalla. Se utilizo una clase abstracta como padre de todas, para proteger el comportamiento de todo el flow. Y para cada pantalla distinta, se tuvo que crear una clase individual. Las cuales fueron:

- Delay Time
- Select Option
- Click in Button

Para cada una la idea general, fue la de darle comportamiento diferente a cada pantalla para que pueda responder a cada caso de uso.

### Evaladores

Para los evaluadores, lo que se hizo fue que, cada uno de los evaluadores heredaran de una clase abstracta de nuevo, para proteger el comportamiento de los evaluadores. Con ello, poder darle comportamientos distintos, para que puedan abarcar la mayoría de casos de uso.

### ScreenPlayIdentify

También se implementó un scriptableobject para poder identificar cada pantalla y así darle al usuario (no programador), la posibilidad de que pueda armar su propia experiencia con las herramientas creadas.

También nos aseguramos que al nombrar pantallas no haya error humano al nombrarlas con algún string.

### Animaciones

Para las animaciones use DotTween, ya que de momento fue la forma más sencilla de hacer esto.

## Generalidades

En lo personal, me gustó mucho como quedo todo el código, ya que pude aplicar varios patrones y cumplir con algunos principios SOLID. Como el de OpenClose y Single Responsability.


## Que me falto!

- Crear las pantallas para la resolución de tablets.
- Crear en las pantallas de selección de años, meses y lenguaje. La parte del scroll, ya que no me dio tiempo.
- La parte de la documentación en diagramas de clases o de flujo, ya que lo tenía en la cabeza, pero no alcance a documentarlo.

