using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GraficaArboles
{
    // =============================================
    //  CLASE NODO - Representa cada elemento del árbol
    // =============================================
    class Nodo
    {
        public int Valor;
        public Nodo Izquierda;
        public Nodo Derecha;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierda = null;
            Derecha = null;
        }
    }

    // =============================================
    //  CLASE ÁRBOL BINARIO DE BÚSQUEDA (BST)
    // =============================================
    class ArbolBinario
    {
        private Nodo raiz;
        public string Nombre;

        public ArbolBinario(string nombre)
        {
            raiz = null;
            Nombre = nombre;
        }

        // ---- INSERCIÓN ----
        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);

            return nodo;
        }

        // ---- BÚSQUEDA ----
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null) return false;
            if (nodo.Valor == valor) return true;
            if (valor < nodo.Valor) return BuscarRecursivo(nodo.Izquierda, valor);
            return BuscarRecursivo(nodo.Derecha, valor);
        }

        // ---- RECORRIDO EN ORDEN (Inorden: Izq - Raíz - Der) ----
        public void RecorridoInorden()
        {
            Console.Write("  Inorden  : ");
            InordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void InordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                InordenRecursivo(nodo.Izquierda);
                Console.Write($"{nodo.Valor} ");
                InordenRecursivo(nodo.Derecha);
            }
        }

        // ---- RECORRIDO PREORDEN (Raíz - Izq - Der) ----
        public void RecorridoPreorden()
        {
            Console.Write("  Preorden : ");
            PreordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void PreordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write($"{nodo.Valor} ");
                PreordenRecursivo(nodo.Izquierda);
                PreordenRecursivo(nodo.Derecha);
            }
        }

        // ---- RECORRIDO POSTORDEN (Izq - Der - Raíz) ----
        public void RecorridoPostorden()
        {
            Console.Write("  Postorden: ");
            PostordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void PostordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                PostordenRecursivo(nodo.Izquierda);
                PostordenRecursivo(nodo.Derecha);
                Console.Write($"{nodo.Valor} ");
            }
        }

        // ---- BFS (Búsqueda en Amplitud) ----
        public void RecorridoBFS()
        {
            if (raiz == null)
            {
                Console.WriteLine("  Árbol vacío.");
                return;
            }

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);
            Console.Write("  BFS      : ");

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                Console.Write($"{actual.Valor} ");

                if (actual.Izquierda != null) cola.Enqueue(actual.Izquierda);
                if (actual.Derecha != null) cola.Enqueue(actual.Derecha);
            }
            Console.WriteLine();
        }

        // ---- DFS (Búsqueda en Profundidad) ----
        public void RecorridoDFS()
        {
            if (raiz == null)
            {
                Console.WriteLine("  Árbol vacío.");
                return;
            }

            Stack<Nodo> pila = new Stack<Nodo>();
            pila.Push(raiz);
            Console.Write("  DFS      : ");

            while (pila.Count > 0)
            {
                Nodo actual = pila.Pop();
                Console.Write($"{actual.Valor} ");

                if (actual.Derecha != null) pila.Push(actual.Derecha);
                if (actual.Izquierda != null) pila.Push(actual.Izquierda);
            }
            Console.WriteLine();
        }

        // ---- ALTURA DEL ÁRBOL ----
        public int ObtenerAltura()
        {
            return CalcularAltura(raiz);
        }

        private int CalcularAltura(Nodo nodo)
        {
            if (nodo == null) return 0;
            int altIzq = CalcularAltura(nodo.Izquierda);
            int altDer = CalcularAltura(nodo.Derecha);
            return 1 + Math.Max(altIzq, altDer);
        }

        // ---- CONTAR NODOS ----
        public int ContarNodos()
        {
            return ContarRecursivo(raiz);
        }

        private int ContarRecursivo(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarRecursivo(nodo.Izquierda) + ContarRecursivo(nodo.Derecha);
        }

        // ---- GRÁFICA VISUAL DEL ÁRBOL EN CONSOLA ----
        public void GraficarArbol()
        {
            Console.WriteLine();
            GraficarRecursivo(raiz, "", true);
        }

        private void GraficarRecursivo(Nodo nodo, string prefijo, bool esUltimo)
        {
            if (nodo == null) return;

            Console.WriteLine(prefijo + (esUltimo ? "└── " : "├── ") + nodo.Valor);
            string nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");

            bool tieneIzq = nodo.Izquierda != null;
            bool tieneDer = nodo.Derecha != null;

            if (tieneIzq && tieneDer)
            {
                GraficarRecursivo(nodo.Izquierda, nuevoPrefijo, false);
                GraficarRecursivo(nodo.Derecha, nuevoPrefijo, true);
            }
            else if (tieneIzq)
            {
                GraficarRecursivo(nodo.Izquierda, nuevoPrefijo, true);
            }
            else if (tieneDer)
            {
                GraficarRecursivo(nodo.Derecha, nuevoPrefijo, true);
            }
        }

        // ---- REPORTE COMPLETO ----
        public void MostrarReporte()
        {
            Console.WriteLine($"\n{'='  ,1}".PadRight(50, '='));
            Console.WriteLine($"  ÁRBOL: {Nombre}");
            Console.WriteLine("".PadRight(50, '='));
            Console.WriteLine($"  Total de nodos : {ContarNodos()}");
            Console.WriteLine($"  Altura del árbol: {ObtenerAltura()} niveles");
            Console.WriteLine();
            Console.WriteLine("  [GRÁFICA DEL ÁRBOL]");
            GraficarArbol();
            Console.WriteLine();
            Console.WriteLine("  [RECORRIDOS]");
            RecorridoInorden();
            RecorridoPreorden();
            RecorridoPostorden();
            RecorridoBFS();
            RecorridoDFS();
            Console.WriteLine("".PadRight(50, '='));
        }
    }

    // =============================================
    //  CLASE PRINCIPAL - PROGRAMA
    // =============================================
    class Program
    {
        static ArbolBinario CargarDesdeArchivo(string rutaArchivo, string nombreArbol)
        {
            ArbolBinario arbol = new ArbolBinario(nombreArbol);

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"  [!] Archivo no encontrado: {rutaArchivo}");
                return arbol;
            }

            string[] lineas = File.ReadAllLines(rutaArchivo);
            foreach (string linea in lineas)
            {
                string limpia = linea.Trim();
                if (limpia.StartsWith("#") || string.IsNullOrEmpty(limpia))
                    continue; // ignorar comentarios y líneas vacías

                if (int.TryParse(limpia, out int valor))
                    arbol.Insertar(valor);
                else
                    Console.WriteLine($"  [!] Valor inválido ignorado: '{limpia}'");
            }

            return arbol;
        }

        static void MenuConsultas(ArbolBinario arbol)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine($"\n  -- Consultas para: {arbol.Nombre} --");
                Console.WriteLine("  1. Buscar un valor");
                Console.WriteLine("  2. Ver gráfica del árbol");
                Console.WriteLine("  3. Ver recorridos");
                Console.WriteLine("  4. Ver reporte completo");
                Console.WriteLine("  0. Volver al menú principal");
                Console.Write("\n  Seleccione una opción: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        Console.Write("  Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int buscar))
                        {
                            bool encontrado = arbol.Buscar(buscar);
                            Console.WriteLine(encontrado
                                ? $"  ✔ El valor {buscar} SÍ existe en el árbol."
                                : $"  ✘ El valor {buscar} NO existe en el árbol.");
                        }
                        break;
                    case "2":
                        Console.WriteLine($"\n  [GRÁFICA - {arbol.Nombre}]");
                        arbol.GraficarArbol();
                        break;
                    case "3":
                        Console.WriteLine($"\n  [RECORRIDOS - {arbol.Nombre}]");
                        arbol.RecorridoInorden();
                        arbol.RecorridoPreorden();
                        arbol.RecorridoPostorden();
                        arbol.RecorridoBFS();
                        arbol.RecorridoDFS();
                        break;
                    case "4":
                        arbol.MostrarReporte();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("  Opción inválida.");
                        break;
                }
            }
        }

        static void MostrarAnalisis()
        {
            Console.WriteLine("\n" + "".PadRight(50, '='));
            Console.WriteLine("  ANÁLISIS DE LA ESTRUCTURA");
            Console.WriteLine("".PadRight(50, '='));
            Console.WriteLine(@"
  Estructura utilizada: Árbol Binario de Búsqueda (BST)

  VENTAJAS:
  ✔ Búsqueda eficiente: O(log n) en árboles balanceados
  ✔ Inserción y eliminación ordenadas
  ✔ Recorridos que generan datos ordenados (Inorden)
  ✔ Representación jerárquica clara de datos

  DESVENTAJAS:
  ✘ En el peor caso (datos ya ordenados), degenera
    en una lista con complejidad O(n)
  ✘ No se autobalancea (para eso se usa AVL o RBT)
  ✘ Mayor uso de memoria que arrays por los punteros

  ALGORITMOS DE RECORRIDO:
  • BFS (Cola/FIFO) → Recorre nivel por nivel
  • DFS (Pila/LIFO) → Recorre rama por rama
    - Inorden   → Datos en orden ascendente
    - Preorden  → Útil para copiar el árbol
    - Postorden → Útil para eliminar el árbol
");
            Console.WriteLine("".PadRight(50, '='));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n" + "".PadRight(50, '='));
            Console.WriteLine("   PRÁCTICA #04 - GRÁFICA DE ÁRBOLES");
            Console.WriteLine("   Universidad Estatal Amazónica - UEA");
            Console.WriteLine("   Asignatura: Estructura de Datos");
            Console.WriteLine("".PadRight(50, '='));

            // ---- Cargar los dos árboles desde archivos .txt ----
            Stopwatch sw = Stopwatch.StartNew();

            ArbolBinario arbol1 = CargarDesdeArchivo("arbol1.txt", "Árbol 1 - Notas de Estudiantes");
            ArbolBinario arbol2 = CargarDesdeArchivo("arbol2.txt", "Árbol 2 - Temperaturas Semanales");

            sw.Stop();
            Console.WriteLine($"\n  Tiempo de carga: {sw.ElapsedMilliseconds} ms ({sw.ElapsedTicks} ticks)");

            // ---- Menú principal ----
            bool salirMain = false;
            while (!salirMain)
            {
                Console.WriteLine("\n  ===== MENÚ PRINCIPAL =====");
                Console.WriteLine("  1. Ver reporte - Árbol 1 (Notas)");
                Console.WriteLine("  2. Ver reporte - Árbol 2 (Temperaturas)");
                Console.WriteLine("  3. Consultas - Árbol 1");
                Console.WriteLine("  4. Consultas - Árbol 2");
                Console.WriteLine("  5. Análisis de la estructura");
                Console.WriteLine("  6. Medir tiempo de recorridos (BFS vs DFS)");
                Console.WriteLine("  0. Salir");
                Console.Write("\n  Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        arbol1.MostrarReporte();
                        break;
                    case "2":
                        arbol2.MostrarReporte();
                        break;
                    case "3":
                        MenuConsultas(arbol1);
                        break;
                    case "4":
                        MenuConsultas(arbol2);
                        break;
                    case "5":
                        MostrarAnalisis();
                        break;
                    case "6":
                        Console.WriteLine("\n  [MEDICIÓN DE TIEMPO DE EJECUCIÓN]");

                        Stopwatch t1 = Stopwatch.StartNew();
                        arbol1.RecorridoBFS();
                        t1.Stop();
                        Console.WriteLine($"  Árbol 1 - BFS: {t1.ElapsedTicks} ticks");

                        Stopwatch t2 = Stopwatch.StartNew();
                        arbol1.RecorridoDFS();
                        t2.Stop();
                        Console.WriteLine($"  Árbol 1 - DFS: {t2.ElapsedTicks} ticks");

                        Stopwatch t3 = Stopwatch.StartNew();
                        arbol2.RecorridoBFS();
                        t3.Stop();
                        Console.WriteLine($"  Árbol 2 - BFS: {t3.ElapsedTicks} ticks");

                        Stopwatch t4 = Stopwatch.StartNew();
                        arbol2.RecorridoDFS();
                        t4.Stop();
                        Console.WriteLine($"  Árbol 2 - DFS: {t4.ElapsedTicks} ticks");
                        break;
                    case "0":
                        salirMain = true;
                        Console.WriteLine("\n  Cerrando programa... ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("  Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
