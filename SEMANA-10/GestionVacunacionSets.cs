using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVacunacionMinsa
{
    // POO: Clase que representa la entidad Ciudadano
    public class Ciudadano
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public Ciudadano(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        // Es vital sobrescribir estos métodos para que HashSet identifique duplicados por ID
        public override bool Equals(object obj)
        {
            if (obj is Ciudadano otro)
                return Id == otro.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    // POO: Clase que gestiona la lógica de conjuntos y operaciones de teoría de conjuntos
    public class ProcesadorVacunas
    {
        private HashSet<Ciudadano> universo = new HashSet<Ciudadano>();
        private HashSet<Ciudadano> pfizer = new HashSet<Ciudadano>();
        private HashSet<Ciudadano> astraZeneca = new HashSet<Ciudadano>();

        public void CargarDatosFicticios()
        {
            // 1. Crear conjunto ficticio de 500 ciudadanos (Conjunto Universal)
            for (int i = 1; i <= 500; i++)
                universo.Add(new Ciudadano($"ID-{i}", $"Ciudadano {i}"));

            // 2. Crear conjunto de 75 ciudadanos vacunados con Pfizer (Ciudadanos 1 al 75)
            for (int i = 1; i <= 75; i++)
                pfizer.Add(new Ciudadano($"ID-{i}", $"Ciudadano {i}"));

            // 3. Crear conjunto de 75 ciudadanos con AstraZeneca (Ciudadanos 50 al 124)
            // Esto genera automáticamente una intersección del 50 al 75 (ambas dosis)
            for (int i = 50; i <= 124; i++)
                astraZeneca.Add(new Ciudadano($"ID-{i}", $"Ciudadano {i}"));
        }

        public void GenerarReportes()
        {
            // --- OPERACIONES DE CONJUNTOS ---

            // A. Ciudadanos que han recibido ambas dosis (Intersección A ∩ B)
            var ambasDosis = new HashSet<Ciudadano>(pfizer);
            ambasDosis.IntersectWith(astraZeneca); // Operación de Intersección

            // B. Ciudadanos que solo han recibido Pfizer (Diferencia A - B)
            var soloPfizer = new HashSet<Ciudadano>(pfizer);
            soloPfizer.ExceptWith(astraZeneca); // Operación de Diferencia

            // C. Ciudadanos que solo han recibido AstraZeneca (Diferencia B - A)
            var soloAstra = new HashSet<Ciudadano>(astraZeneca);
            soloAstra.ExceptWith(pfizer); // Operación de Diferencia

            // D. Ciudadanos que no se han vacunado (Universo - (A ∪ B))
            var todosVacunados = new HashSet<Ciudadano>(pfizer);
            todosVacunados.UnionWith(astraZeneca); // Operación de Unión

            var noVacunados = new HashSet<Ciudadano>(universo);
            noVacunados.ExceptWith(todosVacunados); // Diferencia final

            // MOSTRAR RESULTADOS
            Console.WriteLine("REPORTE DE CAMPAÑA DE VACUNACIÓN COVID-19");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Total Ciudadanos: {universo.Count}");
            Console.WriteLine($"1. No vacunados: {noVacunados.Count}");
            Console.WriteLine($"2. Recibieron ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"3. Solo vacuna Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"4. Solo vacuna AstraZeneca: {soloAstra.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProcesadorVacunas app = new ProcesadorVacunas();
            app.CargarDatosFicticios();
            app.GenerarReportes();
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
