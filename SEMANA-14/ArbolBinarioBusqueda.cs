using System;

namespace ArbolBinarioApp
{
    // 1. CLASE NODO
    public class Node
    {
        public string Value;
        public Node Left;
        public Node Right;

        public Node(string item)
        {
            Value = item;
            Left = null;
            Right = null;
        }
    }

    // 2. CLASE DEL ÁRBOL BINARIO DE BÚSQUEDA
    public class BinarySearchTree
    {
        public Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        // --- Inserción ---
        public void Insert(string value)
        {
            Root = InsertRec(Root, value);
        }

        private Node InsertRec(Node root, string value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (string.Compare(value, root.Value) < 0)
            {
                root.Left = InsertRec(root.Left, value);
            }
            else 
            {
                root.Right = InsertRec(root.Right, value);
            }

            return root;
        }

        // --- Búsqueda ---
        public Node Search(Node root, string value)
        {
            if (root == null || root.Value == value)
            {
                return root;
            }

            if (string.Compare(value, root.Value) < 0)
            {
                return Search(root.Left, value);
            }
            else
            {
                return Search(root.Right, value);
            }
        }

        // --- Eliminación ---
        public Node Delete(Node root, string value)
        {
            if (root == null) return root;

            if (string.Compare(value, root.Value) < 0)
            {
                root.Left = Delete(root.Left, value);
            }
            else if (string.Compare(value, root.Value) > 0)
            {
                root.Right = Delete(root.Right, value);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.Value = MinValue(root.Right);
                root.Right = Delete(root.Right, root.Value);
            }
            return root;
        }

        private string MinValue(Node root)
        {
            string minv = root.Value;
            while (root.Left != null)
            {
                minv = root.Left.Value;
                root = root.Left;
            }
            return minv;
        }

        // --- Recorridos ---
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        public void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.Write(node.Value + " ");
                InOrder(node.Right);
            }
        }

        public void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        // --- Mínimo y Máximo ---
        public Node FindMin(Node root)
        {
            if (root == null) return null;
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }

        public Node FindMax(Node root)
        {
            if (root == null) return null;
            while (root.Right != null)
            {
                root = root.Right;
            }
            return root;
        }

        // --- Altura del Árbol ---
        public int Height(Node root)
        {
            if (root == null)
            {
                return -1;
            }
            
            int leftHeight = Height(root.Left);
            int rightHeight = Height(root.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // --- Limpiar Árbol ---
        public void Clear()
        {
            Root = null;
        }
    }

    // 3. CLASE PRINCIPAL (MENÚ)
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ DEL ÁRBOL BINARIO DE BÚSQUEDA ---");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorridos (Pre-Orden, In-Orden, Post-Orden)");
                Console.WriteLine("5. Mostrar Mínimo, Máximo y Altura");
                Console.WriteLine("6. Limpiar árbol");
                Console.WriteLine("7. Salir");
                Console.Write("Elige una opción: ");
                
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa el valor a insertar: ");
                        string valInsertar = Console.ReadLine();
                        bst.Insert(valInsertar);
                        Console.WriteLine($"Valor '{valInsertar}' insertado.");
                        break;

                    case "2":
                        Console.Write("Ingresa el valor a buscar: ");
                        string valBuscar = Console.ReadLine();
                        Node encontrado = bst.Search(bst.Root, valBuscar);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"El valor '{valBuscar}' SÍ se encuentra en el árbol.");
                        }
                        else
                        {
                            Console.WriteLine($"El valor '{valBuscar}' NO existe en el árbol.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingresa el valor a eliminar: ");
                        string valEliminar = Console.ReadLine();
                        // El PDF indica que Delete devuelve el Node modificado
                        bst.Root = bst.Delete(bst.Root, valEliminar);
                        Console.WriteLine($"Operación de eliminación ejecutada para '{valEliminar}'.");
                        break;

                    case "4":
                        if (bst.Root == null)
                        {
                            Console.WriteLine("El árbol está vacío.");
                            break;
                        }
                        Console.Write("Pre-Orden: ");
                        bst.PreOrder(bst.Root);
                        Console.WriteLine();

                        Console.Write("In-Orden:  ");
                        bst.InOrder(bst.Root);
                        Console.WriteLine();

                        Console.Write("Post-Orden:");
                        bst.PostOrder(bst.Root);
                        Console.WriteLine();
                        break;

                    case "5":
                        if (bst.Root == null)
                        {
                            Console.WriteLine("El árbol está vacío.");
                        }
                        else
                        {
                            Console.WriteLine($"Valor Mínimo: {bst.FindMin(bst.Root).Value}");
                            Console.WriteLine($"Valor Máximo: {bst.FindMax(bst.Root).Value}");
                            Console.WriteLine($"Altura del árbol: {bst.Height(bst.Root)}");
                        }
                        break;

                    case "6":
                        bst.Clear();
                        Console.WriteLine("El árbol ha sido limpiado completamente.");
                        break;

                    case "7":
                        salir = true;
                        Console.WriteLine("¡Hasta pronto y mucho éxito con tu código!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }
    }
}
