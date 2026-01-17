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

    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.siguiente;
            actual.siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }
        cabeza = anterior;
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

        Console.WriteLine("Lista original:");
        lista.Imprimir();

        lista.Invertir();
        Console.WriteLine("Lista invertida:");
        lista.Imprimir();
    }
}
