ESTUDIANTES

- Juan Manuel Arcila Torres:000547026
- Carolina Garcia Ortega:000528089
- Sara Ruiz Arboleda:000542378

NOTA MUY IMPORTANTE. POR FAVOR LEER ANTES DE REVISAR :(
Se desconoce si las pruebas si quiera corren. Tuvimos otro problema faltando unos minutos para que se acabara el tiempo, ya que descubrimos que nadie podia ejecutar las pruebas, dando paso a otra dificultad que esta vez no pudimos solucionar. Por ende enviamos nuestra evaluacion asi como la teniamos porque YA NO HABIA TIEMPO.

Hoy, 18 de septiembre, con mas calma decidimos revisar que era lo que estaba pasando. 
El error respecto a las pruebas se debe a que la version del Nunit del estudiante que creo el documento tenia dependencia al NET.08. por ende los otros estudiantes que teniamos una version NET diferente o superior no podiamos correrlo. 

NO OBSTANTE...
Ni siquiera la estudiante que creo el archivo originalmente (es decir, quien tenia el NET.08.) podia correr las pruebas. A ella le salia un error completamente diferente. Segun lo que investigamos y lo que 2 IAs diferentes respodnieron (GPT y Claude) es que el Nunit de la estudiante estaba corrupto (algo extraño porque el dia anterior al examen ella estuvo estudiando con normalidad)

Por ende, la calidad de lo que entregamos es incluso desconocida para nosotros.

Cabe aclarar, que este mensaje es con el objetivo de que puedas evidenciar que hicimos lo posible por realizar el examen de manera consiente, pero asi mismo resaltar que las dificutades con el repositorio, gitignore y ahora con la version del Nunit nos dejaron sin tiempo ni posibilidad de corregir lo que hicimos. No buscamos que esto mejore o empeore nuestra calificacion, solo queremos que entiendas que hicimos nuestro mejor esfuerzo durante la evaluacion.

------------------------------------------------------------------------------------------------------------------------------------------

ADICIONALMENTE. Dado a que el archivo cuenta con dificultades y no hay pruebas para evidenciar que esta bien o que esta mal. decidimos dejar por escrito una breve explicacion de nuestra froma de solucionar la evaluacion. Quizas asi puedas evidenciar mejor las cosas erroneas y las buenas para asi facilitarse el proceso de evaluacion


1. ¿QUÉ QUERIAMOS HACER RESPECTO LA PROGRAMACION ORIENTADA A OBJETOS?

- Clase Item

Primero, decidimos crear una clase llamada Item, donde hay nombre y precio, ademas que es una clase madre para la clase Armor, Weapon, Accesory y Supply. Con el objetivo de que las clases hijas tuviesen un atributo donde se evidenciara que eran objetos consumibles o portables.

- Subclases Armor, Weapon, Accesory y Supply

El motivo por el cual decidimos crear las clases hijas era por la implementacion de la herencia. Al ser hijas de Item, tienen sus atributos de precio y nombre, ademas de sus atributos individuales extras y una categoria definida por ItemCategory (la cual es un Enum).

- Player

Luego, creamos a player, que tiene atributos de oro y el inventario del jugador. El constructor cumple la funcion de validar la cantidad de oro y tiene un metodo llamado SpendGold que es para que el jugador no pueda gastar mas oro del que tiene y tambien para descontar el oro gastado en compras.

- PlayerInventory

Esta clase contiene dos listas que es lo que permite separar los objetos entre consumibles y portables, tambien tiene el metodo encargado de agregar items a las distintas listas y otro que se encarga de hacer una lista del inventario del jugador, que se encarga de calcular los tipos de items que tiene el jugador y la cantidad del respectivo item.

- PurchaseItem

Esta clase tiene dos atributos, una de item y otra de cantidad, y un constructor que verifica su cantidad a la hora de hacer la compra. Es decir verifica que es lo que se va a comprar y cuanto se quiere comprar.

- Store

Este tiene un solo atributo que se trata del inventario de la tienda, con un constructor que verifica que el inventario tenga al menos un item. Tambien tiene un metodo que se encarga de agregar los items al invetanrio verificando que exista y que los precios no sean distintos para el mismo item.

Tambien tiene otro metodo booleano que es de compra, el cual verifica el PurchaseItem que es lo que nos permite saber si la compra se puede realizar o no, si que el jugador pueda comprar items; generando un total y pasa los items al inventario del jugador.

- InventoryEntry

Esta clase tiene dos atributos que son el item y la cantidad, con un constructor que verifica que la cantidad de los items dentro de la tienda sean mayores a 0, tambien tiene un metodo para agregar items y otro para quitarlos.

2. ¿QUÉ QUERIAMOS HACER CON LAS PRUEBAS?

- Crear arma, armadura, accesorio y suplemento 

Aqui lo que valida es que el nombre no sea nulo y que el precio de los items sea mayor a 0. 
Las pruebas se realizaron con objetos de los items.

- Store valida con un item, store valida con multiples items

Aqui se crean tiendas, validando que la tienda se creo y en caso de no crearse sale erroneo. 
Las pruebas se realizaron con una de los items que debia tener la tienda.

- Jugador Con Oro Valido, Jugador Con Mucho Oro

Aqui se valida que se cree el jugador y que se le asigen correctamente el oro. Tambien se verifica que no se pueda crear un jugador con oro negativo.
Las pruebas se realizaron con atributos y con un player al cual se le asigan el atributo.

- Compra Exitosa Simple, Compra Con Suficiente Oro

Aqui se ingresan los datos de oro, precio y cantidad, y se crea un item, player y un store para simular el proceso de compra. Luego el resultado de la compra se almacena en una variable y con eso se verifica que el resultado sea positivo (es decir que si se podia comprar) y que el oro del jugador sea efectivamente la cantidad que ya tenia - el valor de la compra. 

- Falla Por Falta De Oro y Falla Por Falta De Stock

Aqui a proposito queremos que falle. se le ingresa el oro, precio y cantidad que va a comprar y se crea lo mismo que la prueba anterior, un item, player y store. y luego almacena la variable y debe verificar que esta de negativa dando fallo a la compra y depsues verificando que el dinero del player siga intacta dado a que se reverso la compra

- Item Va a Consumibles y Item Va a Equipamiento

Aqui se crean los objetos como un supply y un weapon, tambien un inventario de player y aqui se ingresaba el item, verificando que el iventario no sea nulo y que en efecto no haya nada nulo



