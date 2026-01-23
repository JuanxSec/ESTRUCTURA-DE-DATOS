using System;
using System.Collections.Generic;

class BalanceoParentesis
{
    static void Main()
    {
        Console.WriteLine("=== Verificación de paréntesis/llaves/corchetes (Pilas) ===");
        Console.Write("Ingresa la expresión: ");
        string expresion = Console.ReadLine() ?? "";

        bool balanceada = EstaBalanceada(expresion);

        Console.WriteLine(balanceada
            ? "Salida: Fórmula balanceada."
            : "Salida: Fórmula NO balanceada.");
    }

    /// <summary>
    /// Verifica si (), [] y {} están correctamente balanceados usando una pila (LIFO).
    /// </summary>
    static bool EstaBalanceada(string s)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in s)
        {
            // 1) Si es apertura, se apila (Push)
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // 2) Si es cierre, se compara con el tope (Peek/Pop)
            else if (c == ')' || c == ']' || c == '}')
            {
                // isEmpty -> si no hay nada para comparar, está mal
                if (pila.Count == 0) return false;

                char tope = pila.Pop(); // Pop: saca el último abierto

                if (!EsPar(tope, c)) return false;
            }
        }

        // Si quedaron aperturas sin cerrar, no está balanceado
        return pila.Count == 0;
    }

    /// <summary>
    /// Devuelve true si la apertura coincide con el cierre.
    /// </summary>
    static bool EsPar(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')')
            || (apertura == '[' && cierre == ']')
            || (apertura == '{' && cierre == '}');
    }
}
