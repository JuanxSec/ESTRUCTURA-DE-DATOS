using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    class Program
    {
        // Clase Curso para manejar las asignaturas y las notas
        public class Curso
        {
            public List<string> Asignaturas { get; set; }

            // Constructor que inicializa la lista de asignaturas
            public Curso()
            {
                Asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            }

            // Método para mostrar un mensaje con la asignatura
            public void MostrarAsignaturas()
            {
                foreach (var asignatura in Asignaturas)
                {
                    Console.WriteLine($"Yo estudio {asignatura}");
                }
            }
        }

        static void Main(string[] args)
        {
            // Crear una instancia de la clase Curso
            Curso curso = new Curso();
            
            // Llamar al método para mostrar las asignaturas
            curso.MostrarAsignaturas();

            // Esperar que el usuario presione una tecla antes de cerrar
            Console.ReadKey();
        }
    }
}
