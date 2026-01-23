using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static int pasos = 0;
    static Stack<int> A = new Stack<int>();
    static Stack<int> B = new Stack<int>();
    static Stack<int> C = new Stack<int>();

    static void Main()
    {
        Console.Write("Número de discos: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        for (int i = n; i >= 1; i--)
            A.Push(i);

        Console.WriteLine("\nEstado inicial:");
        ImprimirTorres();

        ResolverHanoi(n, A, B, C, 'A', 'B', 'C');

        Console.WriteLine($"\nListo. Total de pasos: {pasos}");
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino,
                              char nombreOrigen, char nombreAux, char nombreDestino)
    {
        if (n == 1)
        {
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }

        ResolverHanoi(n - 1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAux);
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);
        ResolverHanoi(n - 1, auxiliar, origen, destino, nombreAux, nombreOrigen, nombreDestino);
    }

    static void MoverDisco(Stack<int> from, Stack<int> to, char nombreFrom, char nombreTo)
    {
        int disco = from.Pop();

        if (to.Count > 0 && to.Peek() < disco)
            throw new InvalidOperationException($"Movimiento inválido: {disco} sobre {to.Peek()}");

        to.Push(disco);
        pasos++;

        Console.WriteLine($"Paso {pasos}: Mover disco {disco} de {nombreFrom} a {nombreTo}");
        ImprimirTorres();
    }

    static void ImprimirTorres()
    {
        Console.WriteLine($"A: [{string.Join(", ", A.ToArray())}]");
        Console.WriteLine($"B: [{string.Join(", ", B.ToArray())}]");
        Console.WriteLine($"C: [{string.Join(", ", C.ToArray())}]");
        Console.WriteLine("----------------------------------");
    }
}
