using System;

namespace AgendaTelefonicaUEA
{
    /// <summary>
    /// Programa principal (Menú).
    /// Cumple: Reportería (visualizar/consultar) + operaciones básicas.
    /// </summary>
    internal class Program
    {
        static void Main()
        {
            // Configuración: 4 grupos (Familia, Amigos, Trabajo, Otros) y capacidad por grupo
            int grupos = 4;
            int capacidadPorGrupo = 25;

            // POO: instancia de clase que gestiona el sistema
            AgendaTelefonica agenda = new AgendaTelefonica(grupos, capacidadPorGrupo);

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        AgregarContacto(agenda);
                        break;
                    case 2:
                        // Reportería general (usa vector generado desde la matriz)
                        agenda.ReporteGeneral();
                        break;
                    case 3:
                        BuscarContacto(agenda);
                        break;
                    case 4:
                        EditarContacto(agenda);
                        break;
                    case 5:
                        EliminarContacto(agenda);
                        break;
                    case 6:
                        // Reportería por grupo (usa directamente la matriz)
                        agenda.ReportePorGrupo();
                        break;
                    case 0:
                        salir = true;
                        Console.WriteLine("Saliendo... ✅");
                        break;
                    default:
                        Console.WriteLine("Opción inválida ❌");
                        break;
                }

                Console.WriteLine();
            }
        }

        // ------------------------ MENÚ Y ENTRADAS ------------------------

        static void MostrarMenu()
        {
            Console.WriteLine("=== AGENDA TELEFÓNICA (C#) ===");
            Console.WriteLine("1) Agregar contacto");
            Console.WriteLine("2) Reportería: Listado general");
            Console.WriteLine("3) Consultar/Buscar contacto");
            Console.WriteLine("4) Editar contacto (por teléfono)");
            Console.WriteLine("5) Eliminar contacto (por teléfono)");
            Console.WriteLine("6) Reportería: Listado por grupo");
            Console.WriteLine("0) Salir");
            Console.WriteLine("-----------------------------");
        }

        static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string input = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(input, out int valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Debe ingresar un número.");
            }
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            return (Console.ReadLine() ?? "").Trim();
        }

        static int ElegirGrupo()
        {
            Console.WriteLine("Seleccione grupo:");
            Console.WriteLine("0) Familia");
            Console.WriteLine("1) Amigos");
            Console.WriteLine("2) Trabajo");
            Console.WriteLine("3) Otros");

            while (true)
            {
                int g = LeerEntero("Grupo: ");
                if (g >= 0 && g <= 3) return g;
                Console.WriteLine("Grupo inválido. Elija 0 a 3.");
            }
        }

        // ------------------------ ACCIONES DEL MENÚ ------------------------

        static void AgregarContacto(AgendaTelefonica agenda)
        {
            Console.WriteLine("--- Agregar contacto ---");

            string nombre = LeerTexto("Nombre: ");
            string telefono = LeerTexto("Teléfono: ");
            string correo = LeerTexto("Correo (opcional): ");
            string direccion = LeerTexto("Dirección (opcional): ");
            int grupo = ElegirGrupo();

            // Registro/Estructura: Contacto (struct)
            Contacto c = new Contacto(nombre, telefono, correo, direccion);

            bool ok = agenda.Agregar(c, grupo);
            Console.WriteLine(ok ? "Contacto agregado ✅" : "No se pudo agregar (datos inválidos, duplicado o grupo lleno) ❌");
        }

        static void BuscarContacto(AgendaTelefonica agenda)
        {
            Console.WriteLine("--- Consultar / Buscar ---");
            Console.WriteLine("1) Buscar por nombre (parcial)");
            Console.WriteLine("2) Buscar por teléfono (exacto)");
            int tipo = LeerEntero("Elija: ");

            if (tipo == 1)
            {
                string texto = LeerTexto("Ingrese el nombre o parte: ");
                // Vector de resultados
                Contacto[] resultados = agenda.BuscarPorNombre(texto);

                if (resultados.Length == 0)
                {
                    Console.WriteLine("No se encontraron resultados ❌");
                    return;
                }

                Console.WriteLine($"Resultados ✅ ({resultados.Length}):");
                for (int i = 0; i < resultados.Length; i++)
                    Console.WriteLine($"{i + 1}) {resultados[i]}");
            }
            else if (tipo == 2)
            {
                string tel = LeerTexto("Ingrese el teléfono: ");
                Contacto? encontrado = agenda.BuscarPorTelefono(tel);

                if (encontrado == null)
                {
                    Console.WriteLine("No se encontró el contacto ❌");
                    return;
                }

                Console.WriteLine("Encontrado ✅");
                Console.WriteLine(encontrado.Value);
            }
            else
            {
                Console.WriteLine("Opción inválida ❌");
            }
        }

        static void EditarContacto(AgendaTelefonica agenda)
        {
            Console.WriteLine("--- Editar contacto ---");
            string telefonoBuscado = LeerTexto("Teléfono del contacto a editar: ");

            if (!agenda.ExisteTelefono(telefonoBuscado))
            {
                Console.WriteLine("No se encontró el contacto ❌");
                return;
            }

            Console.WriteLine("Deje vacío y presione ENTER para mantener el valor actual.");

            string nuevoNombre = LeerTexto("Nuevo nombre: ");
            string nuevoTelefono = LeerTexto("Nuevo teléfono: ");
            string nuevoCorreo = LeerTexto("Nuevo correo: ");
            string nuevaDireccion = LeerTexto("Nueva dirección: ");

            bool ok = agenda.EditarPorTelefono(telefonoBuscado, nuevoNombre, nuevoTelefono, nuevoCorreo, nuevaDireccion);
            Console.WriteLine(ok ? "Contacto actualizado ✅" : "No se pudo actualizar (teléfono duplicado o error) ❌");
        }

        static void EliminarContacto(AgendaTelefonica agenda)
        {
            Console.WriteLine("--- Eliminar contacto ---");
            string tel = LeerTexto("Teléfono del contacto a eliminar: ");

            bool ok = agenda.EliminarPorTelefono(tel);
            Console.WriteLine(ok ? "Contacto eliminado ✅" : "No se encontró el contacto ❌");
        }
    }

    /// <summary>
    /// REGISTRO / ESTRUCTURA (struct): representa un contacto.
    /// Cumple el requisito de "registros y estructuras".
    /// </summary>
    public struct Contacto
    {
        public string Nombre;
        public string Telefono;
        public string Correo;
        public string Direccion;

        public Contacto(string nombre, string telefono, string correo, string direccion)
        {
            Nombre = (nombre ?? "").Trim();
            Telefono = (telefono ?? "").Trim();
            Correo = (correo ?? "").Trim();
            Direccion = (direccion ?? "").Trim();
        }

        public override string ToString()
        {
            return $"Contacto{{Nombre='{Nombre}', Teléfono='{Telefono}', Correo='{Correo}', Dirección='{Direccion}'}}";
        }
    }

    /// <summary>
    /// POO: Clase que gestiona toda la Agenda.
    /// Estructuras usadas:
    /// - MATRIZ (2D): Contacto?[,] para almacenar contactos por grupo.
    /// - VECTOR (1D): Contacto[] para reportes y resultados (aplanar matriz).
    /// </summary>
    public class AgendaTelefonica
    {
        // MATRIZ: [grupo, posición]
        private readonly Contacto?[,] contactos;
        private readonly int grupos;
        private readonly int capacidadPorGrupo;

        public AgendaTelefonica(int grupos, int capacidadPorGrupo)
        {
            this.grupos = grupos;
            this.capacidadPorGrupo = capacidadPorGrupo;
            contactos = new Contacto?[grupos, capacidadPorGrupo];
        }

        /// <summary>
        /// Agrega un contacto al primer espacio libre del grupo.
        /// Valida: nombre y teléfono obligatorios y teléfono no duplicado.
        /// </summary>
        public bool Agregar(Contacto c, int grupo)
        {
            if (grupo < 0 || grupo >= grupos) return false;
            if (string.IsNullOrWhiteSpace(c.Nombre) || string.IsNullOrWhiteSpace(c.Telefono)) return false;

            // Evitar duplicado por teléfono
            if (ExisteTelefono(c.Telefono)) return false;

            for (int j = 0; j < capacidadPorGrupo; j++)
            {
                if (contactos[grupo, j] == null)
                {
                    contactos[grupo, j] = c;
                    return true;
                }
            }
            return false; // grupo lleno
        }

        /// <summary>
        /// Reportería general: visualizar todos los contactos.
        /// Para cumplir "vectores", se transforma la matriz en un vector 1D.
        /// </summary>
        public void ReporteGeneral()
        {
            Contacto[] vector = AVector(); // VECTOR

            Console.WriteLine("--- REPORTERÍA: LISTADO GENERAL ---");
            if (vector.Length == 0)
            {
                Console.WriteLine("Agenda vacía.");
                return;
            }

            for (int i = 0; i < vector.Length; i++)
                Console.WriteLine($"{i + 1}) {vector[i]}");
        }

        /// <summary>
        /// Reportería por grupo: muestra contactos organizados por grupo (matriz directa).
        /// </summary>
        public void ReportePorGrupo()
        {
            Console.WriteLine("--- REPORTERÍA: LISTADO POR GRUPO ---");
            for (int g = 0; g < grupos; g++)
            {
                Console.WriteLine($"Grupo {g} ({NombreGrupo(g)}):");
                bool tiene = false;

                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null)
                    {
                        Console.WriteLine(" - " + contactos[g, j]!.Value);
                        tiene = true;
                    }
                }

                if (!tiene) Console.WriteLine(" - (sin contactos)");
            }
        }

        /// <summary>
        /// Consultar por teléfono (exacto). Devuelve null si no existe.
        /// </summary>
        public Contacto? BuscarPorTelefono(string telefono)
        {
            telefono = (telefono ?? "").Trim();
            if (telefono.Length == 0) return null;

            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null && contactos[g, j]!.Value.Telefono == telefono)
                        return contactos[g, j]!.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Consultar por nombre (parcial, sin distinguir mayúsculas).
        /// Devuelve un VECTOR con todos los resultados.
        /// </summary>
        public Contacto[] BuscarPorNombre(string texto)
        {
            texto = (texto ?? "").Trim().ToLower();

            // 1) contar coincidencias
            int count = 0;
            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null)
                    {
                        Contacto c = contactos[g, j]!.Value;
                        if ((c.Nombre ?? "").ToLower().Contains(texto))
                            count++;
                    }
                }
            }

            if (count == 0) return Array.Empty<Contacto>();

            // 2) crear vector exacto
            Contacto[] resultados = new Contacto[count];
            int idx = 0;

            // 3) llenar vector
            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null)
                    {
                        Contacto c = contactos[g, j]!.Value;
                        if ((c.Nombre ?? "").ToLower().Contains(texto))
                            resultados[idx++] = c;
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Edita un contacto buscándolo por teléfono.
        /// Si el usuario deja un campo vacío, se mantiene el valor actual.
        /// </summary>
        public bool EditarPorTelefono(string telefonoBuscado,
                                      string nuevoNombre,
                                      string nuevoTelefono,
                                      string nuevoCorreo,
                                      string nuevaDireccion)
        {
            int[] pos = EncontrarPosicionPorTelefono(telefonoBuscado);
            if (pos == null) return false;

            int g = pos[0];
            int j = pos[1];

            Contacto c = contactos[g, j]!.Value;

            if (!string.IsNullOrWhiteSpace(nuevoNombre)) c.Nombre = nuevoNombre.Trim();
            if (!string.IsNullOrWhiteSpace(nuevoCorreo)) c.Correo = nuevoCorreo.Trim();
            if (!string.IsNullOrWhiteSpace(nuevaDireccion)) c.Direccion = nuevaDireccion.Trim();

            // Si cambia teléfono, validar duplicado
            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                string tel = nuevoTelefono.Trim();
                if (!tel.Equals(c.Telefono) && ExisteTelefono(tel)) return false;
                c.Telefono = tel;
            }

            contactos[g, j] = c;
            return true;
        }

        /// <summary>
        /// Elimina un contacto por teléfono: lo marca como null en la matriz.
        /// </summary>
        public bool EliminarPorTelefono(string telefono)
        {
            int[] pos = EncontrarPosicionPorTelefono(telefono);
            if (pos == null) return false;

            contactos[pos[0], pos[1]] = null;
            return true;
        }

        /// <summary>
        /// Verifica si existe un teléfono dentro de la agenda.
        /// </summary>
        public bool ExisteTelefono(string telefono)
        {
            telefono = (telefono ?? "").Trim();
            if (telefono.Length == 0) return false;

            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null && contactos[g, j]!.Value.Telefono == telefono)
                        return true;
                }
            }
            return false;
        }

        // --------------------- MÉTODOS INTERNOS (Vectores/Matrices) ---------------------

        /// <summary>
        /// Convierte la MATRIZ en un VECTOR (1D) para reportes.
        /// </summary>
        private Contacto[] AVector()
        {
            // 1) Contar
            int count = 0;
            for (int g = 0; g < grupos; g++)
                for (int j = 0; j < capacidadPorGrupo; j++)
                    if (contactos[g, j] != null) count++;

            // 2) Crear vector exacto
            Contacto[] vector = new Contacto[count];

            // 3) Llenar vector
            int idx = 0;
            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null)
                        vector[idx++] = contactos[g, j]!.Value;
                }
            }

            return vector;
        }

        /// <summary>
        /// Devuelve [grupo, posicion] del contacto por teléfono; null si no existe.
        /// </summary>
        private int[] EncontrarPosicionPorTelefono(string telefono)
        {
            telefono = (telefono ?? "").Trim();
            if (telefono.Length == 0) return null;

            for (int g = 0; g < grupos; g++)
            {
                for (int j = 0; j < capacidadPorGrupo; j++)
                {
                    if (contactos[g, j] != null && contactos[g, j]!.Value.Telefono == telefono)
                        return new int[] { g, j };
                }
            }
            return null;
        }

        private string NombreGrupo(int g)
        {
            return g switch
            {
                0 => "Familia",
                1 => "Amigos",
                2 => "Trabajo",
                3 => "Otros",
                _ => "Grupo " + g
            };
        }
    }
}
