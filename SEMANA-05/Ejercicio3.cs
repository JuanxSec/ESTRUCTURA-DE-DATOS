using System;
using System.Collections.Generic;

namespace Ejercicio3
{
    class Program
    {
        // Clase para manejar los números
        public class Numeros
        {
            public List<int> ListaNumeros { get; set; }

            // Constructor que inicializa la lista con los números del 1 al 10
            public Numeros()
            {
                ListaNumeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }

            // Método para mostrar los números en orden inverso
            public void MostrarNumerosInversos()
            {
                // Revertir la lista
                ListaNumeros.Reverse();
                // Mostrar los números separados por comas
                foreach (var numero in ListaNumeros)
                {
                    Console.Write(numero + ", ");
                }
            }
        }

        static void Main(string[] args)
        {
            // Crear una instancia de la clase Numeros
            Numeros numeros = new Numeros();
            
            // Llamar al método para mostrar los números en orden inverso
            numeros.MostrarNumerosInversos();

            // Esperar que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }
}
