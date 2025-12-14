using System;

internal class Program
{
    // ----->VARIABLES GLOBALES AQUÍ<------

    static string[] naves = new string[]; //aquí almacenaremos las naves creadas(requisitos técnicos)

    // Usaremos ""  como cadena vacía para indicar que una posición del array no está ocupada por una nave.


    static Random random = new Random(); // Generador de nombres aleatorios, tal y como pides en los requisitos técnicos.

    static string[] modelos = { "HALCONMILENARIO", "CAZAESTELAR", "SUPERDESTRUCTOR", "YWING", "XWING" }; // Modelos de naves disponibles para creación

    //Aquí ya empieza el MAIN:
    private static void Main(string[] args)
    {
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
            Console.WriteLine(); //el espacio entre el menñu interactivo y la acción que se va a realizar


            //Ahora vamos con el switch, para que ese "opcion = 0" tome el valor que el usuario ha introducido:
            switch (opcion) 
            {
                case 1:
                Console.WriteLine("Función 1(Crear nueva nave).");
                break;//mejor poner break para no liarla, eh :P

                case 2:
                Console.WriteLine("Función 2(Cambiar nombre de una nave)."); //-->LIZ! Aquí va tu función :) 
                break;

                case 3:
                Console.WriteLine("Función 3(Listar todas las naves).");
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

}