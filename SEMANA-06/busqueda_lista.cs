public class Nodo
{
    public int valor;
    public Nodo siguiente;
}

public class ListaEnlazada
{
    public Nodo cabeza;

    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo();
        nuevoNodo.valor = valor;
        nuevoNodo.siguiente = cabeza;
        cabeza = nuevoNodo;
    }

    public int Buscar(int valor)
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.valor == valor)
            {
                contador++;
            }
            actual = actual.siguiente;
        }

        if (contador == 0)
        {
            Console.WriteLine("El dato no fue encontrado.");
        }

        return contador;
    }

    public void Imprimir()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.valor + " ");
            actual = actual.siguiente;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();
        
        lista.Agregar(5);
        lista.Agregar(10);
        lista.Agregar(15);
        lista.Agregar(20);
        lista.Agregar(10);

        Console.WriteLine("Lista original:");
        lista.Imprimir();

        int resultado = lista.Buscar(10);
        Console.WriteLine($"El número 10 aparece {resultado} veces.");

        resultado = lista.Buscar(25);
        Console.WriteLine($"El número 25 aparece {resultado} veces.");
    }
}
