using System;
using System.Collections.Generic;
using MVC.Model;
using MVC.Controller;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace MVC.View
{
    public class Vista
    {
        public static AVLTree arbol = new AVLTree();
        public static void MostrarMenu()
        {
            List<serializar> inserte = new List<serializar>(); 

            bool retornar = true;

            while (retornar)
            {
                try
                {
                    Console.Clear();
                    int opcion;
                    Console.WriteLine("Menu Principal");
                    Console.WriteLine("1. Leer Json");
                    Console.WriteLine("2. Mostrar Json Con Funciones");
                    Console.WriteLine("3. Buscar un dato por nombre");
                    Console.WriteLine("4. Recomendaciones");
                    Console.WriteLine("5. Salir");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                          
                            Controlador.LeerJson(arbol);
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            List<serializar> listaOrdenada = new List<serializar>();
                            listaOrdenada = arbol.lista();
                        
                            foreach (var item in Model.Modelo.insert)
                            {
                                Console.WriteLine($"name: {item.name}, dpi: {item.dpi}, datebirth: {item.datebirth}, address: {item.address}");

                            }
                            Console.WriteLine("Retornar");
                            retornar = true;
                            Console.ReadLine();
                            break;
                        case 3:
                            
                            Console.Clear();
                            Console.WriteLine("Ingrese el nombre:");
                            string busqueda = Console.ReadLine();
                            Console.Clear();
                            List<serializar> ltem = arbol.busqueda(busqueda);
                           
                            foreach (var item in Model.Modelo.insert)
                            {
                                if (item.name == busqueda)
                                {
                                    Console.WriteLine($"name: {item.name}, dpi: {item.dpi}, datebirth: {item.datebirth}, address: {item.address}");
                                    Model.Modelo.resultados.Add(item);
                                }
                            }
                            Console.WriteLine("");
                            Console.ReadLine();
                            string jsonl = "ArchivoGuardado.jsonl";
                            //Funcion para guardar el archivo
                            using (StreamWriter escritura = new StreamWriter(jsonl))
                            {
                                foreach (var resul in Model.Modelo.resultados)
                                {
                                    string jsons = JsonConvert.SerializeObject(resul);
                                    escritura.WriteLine(jsons);
                                }
                            }
                            Console.WriteLine($"Archivo guardado en :{jsonl}");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Regresar");
                            retornar = true;
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Las recomendaciones son las siguientes:");
                            Console.WriteLine("");
                            Console.WriteLine("1. Es muy necesario ingresar el nombre completo de la persona, sin tildez y con espacio, por ejemplo, “Valeria Rodriguez” y no solo “Valeria” o “Rodríguez”, esto sirve para mejorar la búsqueda y que sea algo completamente breve y precisa.");
                            Console.WriteLine("");
                            Console.WriteLine("2. Se pueden agregar, eliminar y actualizar, datos dentro del json, es necesario respetar el formato del json para evitar tener problemas al ejecutar el problema.");
                            Console.WriteLine("");
                            Console.WriteLine("3. Hay una opcion para visualizar el json con las funciones ejecutadas, esto para tener una idea de que tantos datos tenemos registrados en el programa");

                            Console.ReadLine();
                            break;
                        case 5:
                            retornar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Error");
                    Console.ReadLine();
                }
            }
        }
    }
}