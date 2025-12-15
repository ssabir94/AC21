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
            opcion = Convert.ToInt32(Console.ReadLine()); //importante que no nos dejemos esto


            //Ahora vamos con el switch, para que ese "opcion = 0" tome el valor que el usuario ha introducido:
            switch (opcion) 
            {
                case 1:  //Esta está ok, los métodos van abajo del todo, funciona correctamente. No se debe cambiar nada aquí.
                CrearNuevaNave(ref contadorNaves); //Llamamos al método. 
                break;//mejor poner break para no liarla, eh :P

                case 2:
                Console.WriteLine("Función 2(Cambiar nombre de una nave)."); //-->LIZ! Aquí va tu primera función :) 
                break;

                case 3:
                ListarNaves(contadorNaves);  //TODO OK, este método ya está hecho más abajo.
                break;

                case 4:
                Console.WriteLine("Función 4(Eliminar una nave).");
                break;

                case 5:
                Console.WriteLine("Función 5(Eliminar todas las naves).");
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


    // OPCIÓN 2: CAMBIAR NOMBRE DE UNA NAVE (LIZ) -------->






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

    // OPCIÓN 4: ELIMINAR UNA NAVE (SANA)----->

}

