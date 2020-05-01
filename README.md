# EmpresaBacEnd

 Al clonar el proyecto se debe hacer lo siguiente para que funcion:
ir al appSettingsJson del proyecto del API y editar la key"EmpresaDb", por la cadena de conexion de la instancia desde dond se quiera probar, adjunto un pdf por si tienen problemas al cambiar la cadena de conexion.
Despues de esto, se debe abrir la consola administardora de paquetes apuntando al proyecto de EmpresaData y se ejecutan los siguientes comandos: "update-database -migration numeroIdentificacionUsuarioLongitud" y validar en la db que se hayan creado las tablas, de seguridad y de negocio.
SOLUCION POSIBLE ERROR EN LA CONEXION CON LA DB: Si se presenta algun error al correr el api, lo que se tiene que hacer es ir a visual studio, despues HERRAMIENTAS, se crea una nueva conexion con base de datos se ponen las credenciales correspondientes, una vez creada la nueva conexion, en la parte superior izquierda del visaul studio en la pestaña de EXPLORADOR DE SERVIDORES, ahi esta la nueva conexion, se selecciona y se oprime la tecla F4, se abren las propiedades y se copia el valor del campo
“Cadena de conexion”: Esa cadena de conexión es la que se debe pegar en el value del key de "LibraryDb" del app.setttings.json, haciendo eso se corrige el error.
