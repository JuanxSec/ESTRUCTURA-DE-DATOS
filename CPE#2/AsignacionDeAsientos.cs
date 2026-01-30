using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Cliente
{
    public string Nombre { get; private set; }

    public Cliente(string nombre)
    {
        Nombre = nombre;
    }
}

public class SistemaAsignacion
{
    private Queue<Cliente> colaClientes;

    public SistemaAsignacion()
    {
        colaClientes = new Queue<Cliente>();
    }

    public void EncolarCliente(Cliente cliente)
    {
        colaClientes.Enqueue(cliente);
    }

    public void AsignarAsiento()
    {
        if (colaClientes.Count > 0)
        {
            Cliente cliente = colaClientes.Dequeue();
            Console.WriteLine($"{cliente.Nombre} ha sido asignado a un asiento.");
        }
        else
        {
            Console.WriteLine("No hay más clientes en la cola.");
        }
    }

    public void VisualizarCola()
    {
        Console.WriteLine("\nCola de clientes esperando:");
        foreach (var cliente in colaClientes)
        {
            Console.WriteLine(cliente.Nombre);
        }
    }

    public int ObtenerNumeroDeClientes()
    {
        return colaClientes.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SistemaAsignacion sistema = new SistemaAsignacion();

        for (int i = 1; i <= 30; i++)
        {
            Cliente cliente = new Cliente("Cliente " + i);
            sistema.EncolarCliente(cliente);
        }

        sistema.VisualizarCola();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 1; i <= 30; i++)
        {
            sistema.AsignarAsiento();
        }

        stopwatch.Stop();
        Console.WriteLine($"\nTiempo de ejecución para asignar los 30 asientos: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine($"\nNúmero de clientes restantes en la cola: {sistema.ObtenerNumeroDeClientes()}");
    }
}
