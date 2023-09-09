using System;
using System.Collections.Generic;

namespace MVC.Model
{
    class Modelo
    {
        public Modelo(string v1, string v2)
        {
            realizar = v1;
            almacenar = v2;
        }
        public string realizar { get; set; }
        public string almacenar { get; set; }

        public static List<serializar> personas = new List<serializar>();
        public static List<Modelo> modelo1 = new List<Modelo>();
        public static List<serializar> insert = new List<serializar>();
        public static List<serializar> delete = new List<serializar>();
        public static List<serializar> patch = new List<serializar>();
        public static List<serializar> resultados = new List<serializar>();
        public static AVLTree arbol = new AVLTree();
    }


    public class Persona
    {
        internal string name;

        public string Nombre { get; set; }
        public string Dpi { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }

    public class serializar
    {
        public serializar(string nombre, string dp, string fechas, string direcciones)
        {
            name = nombre;
            dpi = dp;
            datebirth = fechas;
            address = direcciones;
        }
        public string name { get; set; }
        public string dpi { get; set; }
        public string datebirth { get; set; }
        public string address { get; set; }

    }
    public class AVLNode
    {
        public serializar Data { get; set; }
        public int Height { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }

        public AVLNode(serializar data)
        {
            Data = data;
            Height = 1;
            Left = null;
            Right = null;
        }
    }

    public class AVLTree
    {
        private AVLNode root;

        public AVLTree()
        {
            root = null;   
        }

        public void Insert(serializar data)
        {
            root = Insert(root, data);         
        }

        private AVLNode Insert(AVLNode node, serializar data)
        {
            if (node == null)
            {
                return new AVLNode(data);
            }

            if (data.name.CompareTo(node.Data.name) < 0)
            {
                node.Left = Insert(node.Left, data);
            }
            else if (data.name.CompareTo(node.Data.name) > 0)
            {
                node.Right = Insert(node.Right, data);
            }
            else
            {
                return node;
            }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (data.name.CompareTo(node.Left.Data.name) < 0)
                {
                    return RotateRight(node);
                }
                else
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }
            }

            if (balance < -1)
            {
                if (data.name.CompareTo(node.Right.Data.name) > 0)
                {
                    return RotateLeft(node);
                }
                else
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }
            }

            return node;
        }

        public void Delete(int data)
        {
            root = Delete(root, data);
        }

        private AVLNode Delete(AVLNode node, int data)
        {
            return null;
        }

        private int Height(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        private int GetBalance(AVLNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return Height(node.Left) - Height(node.Right);
        }

        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            // Realizar la rotación
            x.Right = y;
            y.Left = T2;

            // Actualizar las alturas
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            // Devolver nueva raíz
            return x;
        }

        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            // Realizar la rotación
            y.Left = x;
            x.Right = T2;

            // Actualizar las alturas
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            // Devolver nueva raíz
            return y;
        }
        public List<serializar> lista()
        {
            return recorrido(root);
        }
        private List<serializar> recorrido(AVLNode nodo)
        {
            List<serializar> listaor = new List<serializar>();
            if (nodo != null)
            {
                listaor.AddRange(recorrido(nodo.Left));
                listaor.Add(nodo.Data);
                listaor.AddRange(recorrido(nodo.Right));
            }
            return listaor;
        }
        public List<serializar> busqueda(string nombre)
        {
            return encontrado(nombre, root);
        }
        private List<serializar> encontrado(string nombre, AVLNode node)
        {
            List<serializar> listaPersonas = new List<serializar>();

            if (node == null)
            {
                return listaPersonas;
            }
            int comparacion = nombre.CompareTo(node.Data.name);

            if (comparacion < 0)
            {
                listaPersonas.AddRange(encontrado(nombre, node.Left));
            }
            else if (comparacion > 0)
            {
                listaPersonas.AddRange(encontrado(nombre, node.Right));
            }
            else
            {
                listaPersonas.Add(node.Data);

                listaPersonas.AddRange(encontrado(nombre, node.Left));
                listaPersonas.AddRange(encontrado(nombre, node.Right));
            }

            return listaPersonas;
        }
    }
}
