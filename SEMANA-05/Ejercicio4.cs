using System;
using System.Collections.Generic;

namespace Ejercicio4
{
    class Program
    {
        // Clase para manejar el abecedario
        public class Abecedario
        {
            public List<char> Letras { get; set; }

            // Constructor para inicializar la lista con el abecedario
            public Abecedario()
            {
                Letras = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            }

            // Método para eliminar las letras en posiciones múltiplos de 3
            public void EliminarLetrasMultiploDe3()
            {
                // Iterar desde el final para evitar modificar el índice al eliminar elementos
                for (int i = Letras.Count - 1; i >= 0; i--)
                {
                    if ((i + 1) % 3 == 0)
                    {
                        Letras.RemoveAt(i);
                    }
                }
            }

            // Método para mostrar las letras restantes
            public void MostrarLetras()
            {
                foreach (var letra in Letras)
                {
                    Console.Write(letra + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Crear una instancia de la clase Abecedario
            Abecedario abecedario = new Abecedario();
            
            // Llamar al método para eliminar las letras en posiciones múltiplos de 3
            abecedario.EliminarLetrasMultiploDe3();

            // Llamar al método para mostrar las letras restantes
            abecedario.MostrarLetras();

            // Esperar que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }
}
