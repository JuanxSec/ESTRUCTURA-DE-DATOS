using System;
using System.Collections.Generic;

namespace TraductorBasico
{
    class Program
    {
        // Definición del diccionario: Asociación clave-valor (Key-Value)
        static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            // Inicialización con palabras base del documento
            InicializarDiccionario();

            string opcion = "";
            while (opcion != "0")
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        TraducirFrase();
                        break;
                    case "2":
                        AgregarPalabra();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void InicializarDiccionario()
        {
            // Se agregan pares clave-valor iniciales
            diccionario.Add("Time", "tiempo");
            diccionario.Add("Person", "persona");
            diccionario.Add("Year", "año");
            diccionario.Add("Day", "día");
            diccionario.Add("World", "mundo");
            diccionario.Add("Life", "vida");
            diccionario.Add("Hand", "mano");
            diccionario.Add("Eye", "ojo");
            diccionario.Add("Work", "trabajo");
            diccionario.Add("Week", "semana");
        }

        static void TraducirFrase()
        {
            Console.Write("\nIngrese la frase a traducir: ");
            string frase = Console.ReadLine() ?? "";
            
            // Separamos la frase en palabras individuales para procesarlas
            string[] palabras = frase.Split(' ');
            List<string> fraseTraducida = new List<string>();

            foreach (string p in palabras)
            {
                // Limpiamos puntuación para que coincida con la clave
                string palabraLimpia = p.Trim(',', '.', '!', '?');

                // Verificamos si la clave existe en el diccionario
                if (diccionario.ContainsKey(palabraLimpia))
                {
                    // Obtenemos el valor asociado a la clave
                    fraseTraducida.Add(diccionario[palabraLimpia]);
                }
                else
                {
                    // Si no existe, dejamos la palabra original
                    fraseTraducida.Add(p);
                }
            }

            Console.WriteLine("\nTraducción esperada (parcial): " + string.Join(" ", fraseTraducida));
        }

        static void AgregarPalabra()
        {
            Console.Write("Ingrese la palabra en Inglés (Clave): ");
            string ingles = Console.ReadLine() ?? "";
            Console.Write("Ingrese la traducción al Español (Valor): ");
            string espanol = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(ingles) || string.IsNullOrWhiteSpace(espanol))
            {
                Console.WriteLine("Error: Los campos no pueden estar vacíos.");
                return;
            }

            // Unicidad de la clave: verificamos antes de agregar
            if (!diccionario.ContainsKey(ingles))
            {
                diccionario.Add(ingles, espanol);
                Console.WriteLine("¡Palabra agregada con éxito!");
            }
            else
            {
                Console.WriteLine("Esta palabra ya existe en el diccionario.");
            }
        }
    }
}
