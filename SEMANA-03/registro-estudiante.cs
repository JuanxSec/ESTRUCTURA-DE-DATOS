using System;

namespace RegistroEstudiante
{
    // Definición de la clase Estudiante
    class Estudiante
    {
        // Atributos de la clase
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }  // Array de teléfonos

        // Método para mostrar los datos del estudiante
        public void MostrarDatos()
        {
            Console.WriteLine("\n--- Datos del Estudiante ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");

            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación del objeto Estudiante
            Estudiante estudiante = new Estudiante();

            // Ingreso de datos
            Console.Write("Ingrese el ID del estudiante: ");
            estudiante.Id = int.Parse(Console.ReadLine());

            Console.Write("Ingrese los nombres: ");
            estudiante.Nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            estudiante.Apellidos = Console.ReadLine();

            Console.Write("Ingrese la dirección: ");
            estudiante.Direccion = Console.ReadLine();

            // Inicialización del array de teléfonos
            estudiante.Telefonos = new string[3];

            for (int i = 0; i < estudiante.Telefonos.Length; i++)
            {
                Console.Write($"Ingrese el teléfono {i + 1}: ");
                estudiante.Telefonos[i] = Console.ReadLine();
            }

            // Mostrar datos ingresados
            estudiante.MostrarDatos();

            Console.WriteLine("\nPresione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
