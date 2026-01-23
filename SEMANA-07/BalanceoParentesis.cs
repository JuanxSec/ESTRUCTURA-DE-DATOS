using System;
using System.Collections.Generic;

class BalanceoParentesis
{
    static void Main()
    {
        Console.Write("Ingresa la expresión: ");
        string expresion = Console.ReadLine() ?? "";

        bool balanceada = EstaBalanceada(expresion);

        Console.WriteLine(balanceada
            ? "Salida: Fórmula balanceada."
            : "Salida: Fórmula NO balanceada.");
    }

    static bool EstaBalanceada(string s)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;

                char tope = pila.Pop();
                if (!EsPar(tope, c)) return false;
            }
        }

        return pila.Count == 0;
    }

    static bool EsPar(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')')
            || (apertura == '[' && cierre == ']')
            || (apertura == '{' && cierre == '}');
    }
}
