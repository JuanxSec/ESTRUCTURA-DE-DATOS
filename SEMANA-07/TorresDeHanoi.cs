using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static int pasos = 0;

    static void Main()
    {
        Console.WriteLine("=== Torres de Hanoi (Pilas) ===");
        Console.Write("Número de discos: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        // Torres como pilas (LIFO)
        Stack<int> A = new Stack<int>();
        Stack<int> B = new Stack<int>();
        Stack<int> C = new Stack<int>();

        // Cargar discos en A (grande abajo, pequeño arriba)
        for (int i = n; i >= 1; i--)
            A.Push(i);

        Console.WriteLine("\nEstado inicial:");
        ImprimirTorres(A, B, C);

        // Resolver (recursivo). En clase se relaciona con pilas/recursividad.
        ResolverHanoi(n, A, B, C, 'A', 'B', 'C');

        Console.WriteLine($"\nListo. Total de pasos: {pasos}");
    }

    /// <summary>
    /// Resuelve Hanoi moviendo n discos desde origen -> destino usando auxiliar.
    /// (Las torres se manejan con pilas: Pop/Push/Peek)
    /// </summary>
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino,
                              char nombreOrigen, char nombreAux, char nombreDestino)
    {
        if (n == 1)
        {
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }

        // 1) Mover n-1 de origen a auxiliar
        ResolverHanoi(n - 1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAux);

        // 2) Mover el disco n de origen a destino
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);

        // 3) Mover n-1 de auxiliar a destino
        ResolverHanoi(n - 1, auxiliar, origen, destino, nombreAux, nombreOrigen, nombreDestino);
    }

    /// <summary>
    /// Mueve un disco usando Pop (sacar) y Push (insertar).
    /// Valida con Peek que el movimiento sea legal.
    /// </summary>
    static void MoverDisco(Stack<int> from, Stack<int> to, char nombreFrom, char nombreTo)
    {
        // from no debería estar vacía si el algoritmo está bien
        int disco = from.Pop();

        // Validación: no poner grande sobre pequeño (Peek mira el tope)
        if (to.Count > 0 && to.Peek() < disco)
        {
            throw new InvalidOperationException(
                $"Movimiento inválido: disco {disco} sobre disco {to.Peek()}");
        }

        to.Push(disco);
        pasos++;

        Console.WriteLine($"Paso {pasos}: Mover disco {disco} de {nombreFrom} a {nombreTo}");
        // Nota: para imprimir, necesitamos acceso a las 3 torres. Lo resolvemos imprimiendo desde aquí
        // pasando referencias globales no es ideal; por eso imprimimos en Main tras cada movimiento si quieres.
        // Para mantenerlo simple, imprimimos aquí usando una función auxiliar que se llama desde Main
        // (ver la versión mejorada abajo).
    }

    /// <summary>
    /// Imprime el contenido de cada torre.
    /// ToArray() devuelve desde el tope hacia abajo (cómo se ve la pila).
    /// </summary>
    static void ImprimirTorres(Stack<int> A, Stack<int> B, Stack<int> C)
    {
        Console.WriteLine($"A: [{string.Join(", ", A.ToArray())}]");
        Console.WriteLine($"B: [{string.Join(", ", B.ToArray())}]");
        Console.WriteLine($"C: [{string.Join(", ", C.ToArray())}]");
        Console.WriteLine("----------------------------------");
    }
}
