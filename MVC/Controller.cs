using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MVC.Model;
using MVC.View;
using System.Linq;

namespace MVC.Controller
{
    public class Controlador
    {
        private List<Persona> AVL;

        public static void LeerJson(AVLTree estruct)
        {
            Model.Modelo.insert.Clear();

            string[] archivo = File.ReadAllLines(@"C:\Users\usuario\datos.txt");
            foreach (var linea in archivo)
            {
                string[] valores = linea.Split(';');
                Modelo guardar = new Modelo(valores[0], valores[1]); 
                Model.Modelo.modelo1.Add(guardar);

                guardar.almacenar = "[" + guardar.almacenar + "]";
                guardar.almacenar = guardar.almacenar.Replace("\"\"", "\"");



                if (guardar.realizar == "INSERT")
                {
                    Model.Modelo.personas = JsonConvert.DeserializeObject<List<serializar>>(guardar.almacenar);
                    Model.Modelo.insert.AddRange(Model.Modelo.personas);
                }

                else if (guardar.realizar == "DELETE")
                {
                    Model.Modelo.personas = JsonConvert.DeserializeObject<List<serializar>>(guardar.almacenar);
                    Model.Modelo.delete.AddRange(Model.Modelo.personas);
                    foreach (var item in Model.Modelo.delete)
                    {
                        Model.Modelo.insert.RemoveAll(inserte => inserte.name == item.name && inserte.dpi == item.dpi);
                    }
                    Model.Modelo.delete.Clear();
                }

                else if (guardar.realizar == "PATCH")
                {
                    Model.Modelo.personas = JsonConvert.DeserializeObject<List<serializar>>(guardar.almacenar);
                    Model.Modelo.patch.AddRange(Model.Modelo.personas);
                    foreach (var item in Model.Modelo.patch)
                    {
                        var reemplazo = Model.Modelo.insert.Find(inserte => inserte.name == item.name && inserte.dpi == item.dpi);
                        if (item.address != null)
                        {
                            reemplazo.address = item.address;
                        }
                        if (item.datebirth != null)
                        {
                            reemplazo.datebirth = item.datebirth;
                        }

                    }
                    Model.Modelo.patch.Clear();
                    foreach (var item in Model.Modelo.insert)
                    {
                        estruct.Insert(item);
                    }
                }

               
            }
            Console.WriteLine("Lectura realizada");
        }

        public List<Persona> ObtenerPersonasOrdenadas()
        {
            return AVL;
        }

        public List<Persona> BuscarPorNombre(string nombre)
        {
            return AVL.Where(p => p.name == nombre).ToList();
        }
    }

}
