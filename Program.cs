using System;

internal class Program
{
    // ----->VARIABLES GLOBALES AQUÍ<------

    static string[] naves = new string[100]; //aquí almacenaremos las naves creadas(requisitos técnicos)

    //Usaremos ""  como cadena vacía para indicar que una posición del array no está ocupada por una nave.


    static Random random = new Random(); //Generador de nombres aleatorios, tal y como pides en los requisitos técnicos.

    static string[] modelos = { "HALCONMILENARIO", "CAZAESTELAR", "SUPERDESTRUCTOR", "YWING", "XWING" }; // Modelos de naves disponibles para creación

    //Aquí ya empieza el MAIN:
    private static void Main(string[] args)
    {
        
        //--->ARRAY aquí<----
        for (int i = 0; i < naves.Length; i++)
        {
            naves[i] = ""; //inicializamos todas las posiciones del array a cadena vacía, indicando que no hay naves creadas al inicio.
        }   
        
        
        //---->VARIABLES LOCALES AQUÍ<------

        int contadorNaves = 0; //El Main controla cuántas naves hay creadas y los métodos lo modificarán por REF cuando sea necesario.

        int opcion = 0; //Tenemos que declarar la variable que usaremos para el menú!!

        //Nos interesa que el menú se ejecute sí o sí, al menos la primera vez, por tanto, hemos escogido este bucle:
        do
        {
            Console.WriteLine("=== SISTEMA DE FABRICACIÓN DE NAVES ESTELARES ===");//empieza menú interactivo (requisitos técnicos)
            Console.WriteLine(); //los espacios que propone Marc
            Console.WriteLine("1. Crear nueva nave");
            Console.WriteLine("2. Cambiar nombre de una nave");
            Console.WriteLine("3. Listar todas las naves");
            Console.WriteLine("4. Eliminar una nave");
            Console.WriteLine("5. Eliminar todas las naves");
            Console.WriteLine("6. Salir"); //última opción pero no menos importante, que sino será la historia interminable...
            Console.WriteLine(); //otro espacio más
            Console.Write("Seleccione una opción: ");
            bool esNumero = int.TryParse(Console.ReadLine(), out opcion);//Nuevo cambio
            //Hay que poner este TryParse para evitar que el programa se "cuelgue" si el usuario escribe algo que no sea un número.
            //Antes teniamos "opcion = Convert.ToInt32(Console.ReadLine());" que daba error si el usuario escribía letras o símbolos.

            //Validamos que la opción sea numérica y esté entre 1 y 6 para cumplir la validación del menú.
            if (!esNumero || opcion < 1 || opcion > 6)
            {
                Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 6.");
                opcion = 0; //0 para que el programa siga y vuelva a mostrar el menú.
                Console.WriteLine();
                continue; //Inicio del do-while sin entrar al switch.
            }

            //Ahora vamos con el switch, para que ese "opcion = 0" tome el valor que el usuario ha introducido:
            switch (opcion) 
            {
                case 1:  //Esta está ok, los métodos van abajo del todo, funciona correctamente. No se debe cambiar nada aquí.
                CrearNuevaNave(ref contadorNaves); //Llamamos al método. 
                break;//mejor poner break para no liarla, eh :P

                case 2:
                CambiarNombreNave(contadorNaves);
                break;  
                
                case 3:
                ListarNaves(contadorNaves);  //TODO OK, este método ya está hecho más abajo.
                break;

                case 4:
                EliminarNave(ref contadorNaves); //Llamada al método 
                break;

                case 5:
                EliminarTodas(ref contadorNaves);
                break;
                
                case 6:
                Console.WriteLine("Programa finalizado.");//Este ya está bien, no hay que modificarlo!
                break;

                default:
                Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 6.");
                break;

            }

            Console.WriteLine(); //espacio entre cada iteración del menú

        } while (opcion != 6); //mientras la opción no sea salir, el menú se seguirá mostrando.

    }

    //---->MÉTODOS AQUÍ<------
    // OPCIÓN 1: CREAR NUEVA NAVE:

    private static void CrearNuevaNave(ref int contadorNaves)
    {
        // 1) VALIDACIÓN: comprobamos que todavía hay espacio en el array para guardar otra nave.
        if (contadorNaves >= naves.Length) // Hemos validado si el array está lleno para evitar escribir fuera de rango.
        {
            Console.WriteLine("No se pueden crear más naves. El almacén está lleno.");
            return; // Salimos del método si no se pueden crear más naves.
        }

        // 2) GENERACIÓN:
        string nombre = GenerarNombreUnico(contadorNaves); 
        // Generamos un nombre único para la nueva nave: palabra aleatoria + "-" + número aleatorio entre 10 y 99.

        // 3) GUARDADO: almacenamos la nave en la siguiente posición libre (contadorNaves).
        naves[contadorNaves] = nombre;
 
        // 4) ACTUALIZACIÓN DE ESTADO: aumentamos el contador porque ahora hay una nave más.
        contadorNaves++; // Se pasa por referencia porque el método debe modificar el contador que vive en el Main.

        // 5) MENSAJE INFORMATIVO:
        Console.WriteLine("✓ Nave creada: " + nombre);
    }

    private static string GenerarNombreUnico(int contadorNaves)
    {
        string nombre; //Variable para almacenar el nombre generado.
        bool repetido; //Variable para controlar si el nombre ya existe.

        do
        {
            string palabra = modelos[random.Next(0, modelos.Length)]; // Seleccionamos un modelo aleatorio.

            int numero = random.Next(10, 100); // Hemos generado un número entre 10 y 99 inclusive.
            // Next(10, 100) funciona porque el 100 no se incluye.

            nombre = palabra + "-" + numero; // Construimos el nombre completo.

            repetido = false;//Comprobando que el nombre no exista ya para que sea único

            for (int i = 0; i < contadorNaves; i++)
            {
                if (naves[i] == nombre) //Comparamos con las naves ya creadas.
                {
                    repetido = true;
                    break; //Salimos del bucle si encontramos un nombre repetido.
                }
            }

        }while (repetido); //Repetimos hasta que encontremos un nombre único.

        return nombre; //Devolvemos el nombre único generado.
    }


    // OPCIÓN 2: CAMBIAR NOMBRE DE UNA NAVE

   private static void CambiarNombreNave(int contadorNaves)
   {
    if (contadorNaves == 0) // Hemos comprobado si hay naves creadas, porque no se puede cambiar nombre si el contador es 0.
    {
        Console.WriteLine("No hay naves para renombrar.");
        return;
    }

    // Con esta opción listamos las naves disponibles para que el usuario pueda elegir cuál renombrar, si quiere verlas en la misma opción 2.
    //No obstante, como ya tenemos la opción 3, y no queremos ser repetitivas, vamos a comentarla:
    //ListarNaves(contadorNaves, "=== NAVES DISPONIBLES ===");

    Console.Write("Ingrese el índice de la nave a renombrar: "); // Pedimos el índice porque el enunciado indica que la nave se identifica por su índice.
    int indice;
    bool esNumero = int.TryParse(Console.ReadLine(), out indice); // TryParse evita errores si el usuario no escribe un número
    // out guarda el valor convertido en indice.

    if (!esNumero || indice < 0 || indice >= contadorNaves) // Validamos que el índice sea número y esté dentro del rango
    {
        Console.WriteLine("Índice inválido.");
        return;
    }

    Console.Write("Ingrese el nuevo nombre: "); // Pedimos el nuevo nombre para la nave.

    string nuevoNombre = GenerarNombreUnico(contadorNaves); //Como nos dijiste, hacemos un "random" y no ponemos el nombre nosotras xD
    Console.WriteLine(nuevoNombre); //Mostramos el nombre generado automáticamente.


    // Nombre no nulo ni con cadena vacía, para evitar nombres inválidos.
    if (nuevoNombre == null || nuevoNombre == "")
    {
        Console.WriteLine("Nombre inválido.");
        return;
    }

    // Por si pasa algo raro y saliera repe, lo evitamos.
    string primerNombre = naves[indice]; //Esto es el nombre actual de la nave.
    while (nuevoNombre == primerNombre)
    {
        nuevoNombre = GenerarNombreUnico(contadorNaves);
    }

    naves[indice] = nuevoNombre; // Actualizamos el nombre de la nave en el array.

    Console.WriteLine($"✓ Nave renombrada: {primerNombre} → {nuevoNombre}"); // Mensaje informativo del cambio.
   }


    // OPCIÓN 3: LISTAR NAVES
    private static void ListarNaves(int contadorNaves, string titulo = "=== NAVES FABRICADAS ===")
    //Lo hacemos así con el título porque pedías que se pasara por parámetro opcional.
    {
        Console.WriteLine(titulo); // Mostramos el título pasado por parámetro.

        if (contadorNaves == 0)
        {
            Console.WriteLine("No hay naves creadas.");
            return; // Salimos del método si no hay naves.
        }

        // Listamos todas las naves creadas hasta el contadorNaves.
        for (int i = 0; i < contadorNaves; i++)
        {
            Console.WriteLine("[" + i + "] " + naves[i]); // Listamos las naves con su índice.
        }
        
    }

    // OPCIÓN 4: ELIMINAR UNA NAVE----->
    private static void EliminarNave(ref int contadorNaves)
    {
        if (contadorNaves == 0)
        {
            Console.WriteLine("¡No hay naves! No se puede eliminar ninguna.");
            return;
        }


        Console.Write("Ingrese el índice de la nave a eliminar: "); //La nave se identifica por su índice.
        int indice;
        bool esNumero = int.TryParse(Console.ReadLine(), out indice); // TryParse evita errores si el usuario no escribe un número, como en opción 2.


        if (!esNumero || indice < 0 || indice >= contadorNaves) // Validamos que el índice sea número y esté dentro del rango
        {
            Console.WriteLine("Índice inválido.");
            return;
        }

        string eliminada = naves[indice]; // Guardamos el nombre de la nave eliminada para el mensaje informativo.
        
        //Esto es lógico, ya que si eliminamos una nave, no debería apareceer más su índice en el listado.
        for (int i = indice; i < contadorNaves - 1; i++) 
        {
            naves[i] = naves[i + 1]; // Desplazamos las naves hacia la izquierda para llenar el hueco.
            //¿Qué significa esto? Que la nave que estaba en la posición "indice + 1" pasa a estar en la posición "indice", y así sucesivamente.
        }

        naves[contadorNaves - 1] = ""; // Limpiamos la última posición del array. Porque ahora hay una nave menos.

        contadorNaves--; // Disminuimos el contador de naves. Importante.

        Console.WriteLine("✓ Nave eliminada: " + eliminada); // Mensaje informativo de la eliminación.
    
    }



    // OPCIÓN 5: ELIMINAR TODAS LAS NAVES ----->

    private static void EliminarTodas(ref int contadorNaves, bool confirmar = true) //Parámetro de confirmación opcional.
    {
        if (contadorNaves == 0)
        {
            Console.WriteLine("¡No hay naves! No se puede eliminar ninguna.");
            return;
        }

        if (confirmar)  //Parámetro opcional para confirmar la eliminación masiva.
        {
            Console.Write("¿Está seguro de que desea eliminar todas las naves? (S/N): ");
            string respuesta = Console.ReadLine();

            if (respuesta != "S" && respuesta != "s") //Evitamos eliminar si la respuesta no es afirmativa.
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }
        }

        for (int i = 0; i < contadorNaves; i++)
        {
            naves[i] = ""; // Limpiamos todas las posiciones del array.
        }

        contadorNaves = 0; // Reseteamos el contador de naves.

        Console.WriteLine("✓ Se han eliminado todas las naves.");

    }
}