 # Tarea # 01

1. En que consiste CORS?
R/ CORS (Cross Origin Resource Sharing, o bien en español Intercambio de Recursos de Origen Cruzado) es un mecanismo en el que permite solicitar recursos restringidos desde una página web de un dominio a otro recurso web de otro dominio. De esta manera, CORS define una manera en la que el navegador y el servidor puedan interactuar para determinar si la petición de origen cruzado es segura.

2. Incluir un ejemplo de solucion en C#, JavaScript, Python, Go o algun otro lenguaje
3. Que es Docker y en que consiste el concepto de Imagen y Contenedor?
R/ 
Que es Docker?
Docker es un proyecto de código abierto para automatizar la implementación de aplicaciones como contenedores portátiles y autosuficientes que se pueden ejecutar en la nube o localmente. 
Los contenedores de Docker se pueden ejecutar en cualquier lugar, localmente en el centro de recursos de cliente, en un proveedor de servicios externo o en la nube, en Azure. Los contenedores de imágenes de Docker también se pueden ejecutar de forma nativa en Linux y Windows. Sin embargo, las imágenes de Windows solo pueden ejecutarse en hosts de Windows y las imágenes de Linux pueden ejecutarse en hosts de Linux y hosts de Windows (con una máquina virtual Linux de Hyper-V, hasta el momento), donde host significa un servidor o una máquina virtual.

Imagen de contenedor: un paquete con todas las dependencias y la información necesarias para crear un contenedor. Una imagen incluye todas las dependencias (por ejemplo, los marcos), así como la configuración de implementación y ejecución que usará el runtime de un contenedor. Normalmente, una imagen se deriva de varias imágenes base que son capas que se apilan unas encima de otras para formar el sistema de archivos del contenedor. Una vez que se crea una imagen, esta es inmutable.

Contenedor: una instancia de una imagen de Docker. Un contenedor representa la ejecución de una sola aplicación, proceso o servicio. Está formado por el contenido de una imagen de Docker, un entorno de ejecución y un conjunto estándar de instrucciones. Al escalar un servicio, crea varias instancias de un contenedor a partir de la misma imagen. O bien, un proceso por lotes puede crear varios contenedores a partir de la misma imagen y pasar parámetros diferentes a cada instancia.

Entregar por escrito en la carpeta `entregables/tarea-01` de su repositorio de estudiante.
