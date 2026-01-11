using System;
using System.Collections.Generic;

namespace Ejercicio5
{
    class Program
    {
        // Clase para manejar las vocales
        public class ContarVocales
        {
            public List<char> Vocales { get; set; }

            // Constructor para inicializar las vocales
            public ContarVocales()
            {
                Vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            }

            // Método para contar las vocales en una palabra
            public void ContarVocalesEnPalabra(string palabra)
            {
                // Para cada vocal, contar las veces que aparece
                foreach (var vocal in Vocales)
                {
                    int veces = 0;
                    foreach (var letra in palabra.ToLower()) // Convertir a minúsculas para evitar problemas con mayúsculas
                    {
                        if (letra == vocal)
                        {
                            veces++;
                        }
                    }
                    Console.WriteLine($"La vocal {vocal} aparece {veces} veces");
                }
            }
        }

        static void Main(string[] args)
        {
            // Crear una instancia de la clase ContarVocales
            ContarVocales contarVocales = new ContarVocales();

            // Pedir al usuario que ingrese una palabra
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine();

            // Llamar al método para contar las vocales
            contarVocales.ContarVocalesEnPalabra(palabra);

            // Esperar que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }
}
