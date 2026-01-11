using System;
using System.Collections.Generic;

namespace Ejercicio1
{
    class Program
    {
        // Clase Curso para manejar las asignaturas
        public class Curso
        {
            // Lista de asignaturas
            public List<string> Asignaturas { get; set; }

            // Constructor para inicializar la lista de asignaturas
            public Curso()
            {
                Asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            }

            // Método para mostrar las asignaturas por pantalla
            public void MostrarAsignaturas()
            {
                Console.WriteLine("Las asignaturas del curso son:");
                foreach (var asignatura in Asignaturas)
                {
                    Console.WriteLine(asignatura);
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
