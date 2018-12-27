BANKAPP

José Alberto Domínguez Illobre

REQUERIMIENTOS:

1. La aplicación ha sido desarrollada para .NET Framework 4.6.1.

INSTALACIÓN: 

1. Descargar/clonar repositorio GIT: https://github.com/aldoilsant/testbankapp
2. Abrir carpeta "publish".
3. Ejectutar BankApp.application para instalación en un click.
4. Es posible que se reciba una notificación de Windows Defender la primera vez que se ejecute la aplicación (dado que no está firmada).

USO:

1. La aplicación incluye dos usuarios de prueba. Se debe utilizar uno de ellos en la pantalla de Login para poder acceder la primera vez.
	a. 
		Usuario: alberto
		Password: changeit
	b.
		Usuario: jesus
		Password: password

LIMITACIONES CONOCIDAS

1. Por simplicidad (y según entiendo el enunciado) un "cliente" y un "usuario" son lo mismo.
2. Un cliente que accede a través de la pantalla de login tiene permisos para leer/editar/borrar cualquier cliente. 
	Lo lógico sería separar el concepto de usuario y cliente, pero está hecha así por simplicidad.
3. Es posible eliminar todos los clientes de la base de datos. En este caso, no será posible volver a acceder a la aplicación.
	Será necesario reinstalarla o restaurar el archivo .MDF
	La aplicación mostrará un mensaje de advertencia en este caso.

DETALLES DE DESARROLLO

El código fuente está organizado en tres carpetas:
	a. Context: contiene el ApplicationContext de la aplicación, que gestiona el cierre de la misma variando el formulario principal, y proporciona métodos de utilidad a la interfaz gráfica.
	b. UI: contiene 4 formularios:
		1. LoginScreen: la pantalla de login. Se requiere un usuario y un password. En general, para cualquier campo y cualquier formulario, ningún campo podrá exceder 100 caracteres.
			a. Los passwords no se almacenan en la base de datos directamente, sino que se hashean lo antes posible utilizando SHA-512.
			b. El login es válido si el nombre de usuario existe y el hash del password introducido coincide con el hash del password en la base de datos.
		2. CustomerScreen: 
			a. Los códigos de cliente disponibles se cargan en una ComboBox, con la que se puede seleccionar un cliente existente. 
				Si existe concurrencia, esta lista puede estar desincronizada. 
				La aplicación manejará casos de desincronización adecuadamente, pero también se puede refrescar la lista de códigos de cliente con el botón "Refresh"
			b. Los nombres de usuario con los que se crea cada cliente no se pueden editar (por simplicidad).
			c. Los países se pueden escoger de una ComboBox. En la base de datos, se almacena el valor ISO Alpha 2 del país.
		3. LoginInformationScreen: 
			a. Cuando se crea un nuevo cliente, se pide seleccionar un nombre de usuario, e introducir dos veces un password (por confirmación).
		4. AccountScreen:
			b. Se muestran las cuentas de un cliente en una DataGridView (sólo lectura, tal y como sugiere el enunciado).
	c. Model: contiene las clases del modelo y una fachada para las operaciones de la base de datos (ModelFacade).
		1. El modelo considera "concurrencia optimista" de la forma más sencilla posible. Cuando se realiza un UPDATE o DELETE de un cliente, se comprueba que todos los campos mantienen sus valores originales (con respecto a cuando se recuperaron desde esta instancia de la aplicación).
		2. Según este mecanismo, si cualquier valor ha sido modificado desde que se ha recuperado la información de un cliente (considerando adecuadamente nulos), no se realizará el UPDATE o DELETE. 
		3. Se podría haber utilizado otros mecanismos, como un timestamp (de nuevo, simplicidad).
		4. Cuando se elimina un cliente, se eliminan también todas las cuentas asociadas (utilizando ON DELETE CASCADE en la definición de la tabla).

En la raíz del repositorio también hay una carpeta SQL con la definición SQL de las dos tablas (Client, Account) y los datos iniciales (StartupData)			
