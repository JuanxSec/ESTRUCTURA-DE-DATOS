using System;
using System.Collections.Generic;
using System.Diagnostics; // Para el análisis de tiempo de ejecución

namespace Practica03_EstructuraDatos
{
    // Clase que representa la entidad Libro
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }

        public override string ToString()
        {
            return $"[ISBN: {ISBN}] Título: {Titulo} | Autor: {Autor} | Género: {Genero}";
        }
    }

    class Program
    {
        // MAPA (Dictionary): Clave única (ISBN) -> Valor (Objeto Libro)
        static Dictionary<string, Libro> inventarioLibros = new Dictionary<string, Libro>();

        // CONJUNTO (HashSet): Almacena géneros únicos sin duplicados
        static HashSet<string> generosRegistrados = new HashSet<string>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- SISTEMA DE GESTIÓN DE BIBLIOTECA (UEA) ---");
                Console.WriteLine("1. Registrar nuevo libro (Insertar en Mapa y Conjunto)");
                Console.WriteLine("2. Reportería: Visualizar inventario completo");
                Console.WriteLine("3. Consulta: Buscar libro por ISBN");
                Console.WriteLine("4. Ver géneros únicos (Uso de HashSet)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: RegistrarLibro(); break;
                    case 2: MostrarInventario(); break;
                    case 3: ConsultarLibro(); break;
                    case 4: MostrarGeneros(); break;
                }
            } while (opcion != 5);
        }

        static void RegistrarLibro()
        {
            Console.Write("Ingrese ISBN: ");
            string isbn = Console.ReadLine();

            if (inventarioLibros.ContainsKey(isbn))
            {
                Console.WriteLine("Error: Ya existe un libro con ese ISBN.");
                return;
            }

            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Género: ");
            string genero = Console.ReadLine();

            Libro nuevoLibro = new Libro { ISBN = isbn, Titulo = titulo, Autor = autor, Genero = genero };

            // Inserción en MAPA (Eficiencia O(1))
            inventarioLibros.Add(isbn, nuevoLibro);
            
            // Inserción en CONJUNTO (Garantiza unicidad de géneros)
            generosRegistrados.Add(genero);

            Console.WriteLine("Libro registrado exitosamente.");
        }

        static void MostrarInventario()
        {
            Console.WriteLine("\n--- REPORTE DE INVENTARIO ---");
            Stopwatch sw = Stopwatch.StartNew(); // Iniciar medición de tiempo

            foreach (var libro in inventarioLibros.Values)
            {
                Console.WriteLine(libro.ToString());
            }

            sw.Stop();
            Console.WriteLine($"\n[Tiempo de ejecución del reporte: {sw.Elapsed.TotalMilliseconds} ms]");
        }

        static void ConsultarLibro()
        {
            Console.Write("Ingrese ISBN a consultar: ");
            string isbn = Console.ReadLine();

            Stopwatch sw = Stopwatch.StartNew();

            // Acceso directo mediante clave (Mapa)
            if (inventarioLibros.TryGetValue(isbn, out Libro libroEncontrado))
            {
                sw.Stop();
                Console.WriteLine("Resultado: " + libroEncontrado.ToString());
            }
            else
            {
                sw.Stop();
                Console.WriteLine("Libro no encontrado.");
            }
            Console.WriteLine($"[Tiempo de búsqueda en Mapa: {sw.Elapsed.TotalMilliseconds} ms]");
        }

        static void MostrarGeneros()
        {
            Console.WriteLine("\n--- GÉNEROS LITERARIOS REGISTRADOS (CONJUNTO ÚNICO) ---");
            foreach (var g in generosRegistrados)
            {
                Console.WriteLine("- " + g);
            }
        }
    }
}
