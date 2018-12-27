BANKAPP

Jos� Alberto Dom�nguez Illobre

REQUERIMIENTOS:

1. La aplicaci�n ha sido desarrollada para .NET Framework 4.6.1.

INSTALACI�N: 

1. Descargar/clonar repositorio GIT: https://github.com/aldoilsant/testbankapp
2. Abrir carpeta "publish".
3. Ejectutar BankApp.application para instalaci�n en un click.
4. Es posible que se reciba una notificaci�n de Windows Defender la primera vez que se ejecute la aplicaci�n (dado que no est� firmada).

USO:

1. La aplicaci�n incluye dos usuarios de prueba. Se debe utilizar uno de ellos en la pantalla de Login para poder acceder la primera vez.
	a. 
		Usuario: alberto
		Password: changeit
	b.
		Usuario: jesus
		Password: password

LIMITACIONES CONOCIDAS

1. Por simplicidad (y seg�n entiendo el enunciado) un "cliente" y un "usuario" son lo mismo.
2. Un cliente que accede a trav�s de la pantalla de login tiene permisos para leer/editar/borrar cualquier cliente. 
	Lo l�gico ser�a separar el concepto de usuario y cliente, pero est� hecha as� por simplicidad.
3. Es posible eliminar todos los clientes de la base de datos. En este caso, no ser� posible volver a acceder a la aplicaci�n.
	Ser� necesario reinstalarla o restaurar el archivo .MDF
	La aplicaci�n mostrar� un mensaje de advertencia en este caso.

DETALLES DE DESARROLLO

El c�digo fuente est� organizado en tres carpetas:
	a. Context: contiene el ApplicationContext de la aplicaci�n, que gestiona el cierre de la misma variando el formulario principal, y proporciona m�todos de utilidad a la interfaz gr�fica.
	b. UI: contiene 4 formularios:
		1. LoginScreen: la pantalla de login. Se requiere un usuario y un password. En general, para cualquier campo y cualquier formulario, ning�n campo podr� exceder 100 caracteres.
			a. Los passwords no se almacenan en la base de datos directamente, sino que se hashean lo antes posible utilizando SHA-512.
			b. El login es v�lido si el nombre de usuario existe y el hash del password introducido coincide con el hash del password en la base de datos.
		2. CustomerScreen: 
			a. Los c�digos de cliente disponibles se cargan en una ComboBox, con la que se puede seleccionar un cliente existente. 
				Si existe concurrencia, esta lista puede estar desincronizada. 
				La aplicaci�n manejar� casos de desincronizaci�n adecuadamente, pero tambi�n se puede refrescar la lista de c�digos de cliente con el bot�n "Refresh"
			b. Los nombres de usuario con los que se crea cada cliente no se pueden editar (por simplicidad).
			c. Los pa�ses se pueden escoger de una ComboBox. En la base de datos, se almacena el valor ISO Alpha 2 del pa�s.
		3. LoginInformationScreen: 
			a. Cuando se crea un nuevo cliente, se pide seleccionar un nombre de usuario, e introducir dos veces un password (por confirmaci�n).
		4. AccountScreen:
			b. Se muestran las cuentas de un cliente en una DataGridView (s�lo lectura, tal y como sugiere el enunciado).
	c. Model: contiene las clases del modelo y una fachada para las operaciones de la base de datos (ModelFacade).
		1. El modelo considera "concurrencia optimista" de la forma m�s sencilla posible. Cuando se realiza un UPDATE o DELETE de un cliente, se comprueba que todos los campos mantienen sus valores originales (con respecto a cuando se recuperaron desde esta instancia de la aplicaci�n).
		2. Seg�n este mecanismo, si cualquier valor ha sido modificado desde que se ha recuperado la informaci�n de un cliente (considerando adecuadamente nulos), no se realizar� el UPDATE o DELETE. 
		3. Se podr�a haber utilizado otros mecanismos, como un timestamp (de nuevo, simplicidad).
		4. Cuando se elimina un cliente, se eliminan tambi�n todas las cuentas asociadas (utilizando ON DELETE CASCADE en la definici�n de la tabla).

En la ra�z del repositorio tambi�n hay una carpeta SQL con la definici�n SQL de las dos tablas (Client, Account) y los datos iniciales (StartupData)			
