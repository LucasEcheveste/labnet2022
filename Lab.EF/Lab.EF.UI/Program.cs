using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    TerritoriesLogic territoriesLogic = new TerritoriesLogic();
                    Console.WriteLine("1. Mostrar territorios");
                    Console.WriteLine("2. Mostrar categorias");
                    Console.WriteLine("3. Agregar un territorio");
                    Console.WriteLine("4. Borrar un territorio");
                    Console.WriteLine("5. Modificar un territorio");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            TerritoriesLogic tl = new TerritoriesLogic();

                            var territories = tl.GetAll();

                            Console.WriteLine("");
                            Console.WriteLine("ID:     Descripcion:                                       Region:");
                            foreach (var item in territories)
                            {
                                Console.WriteLine($"{item.TerritoryID} - {item.TerritoryDescription} - {item.RegionID}");
                            }

                            
                            Console.WriteLine("Presiona una tecla para volver al menu");

                            Console.ReadKey();

                            Console.Clear();

                            break;

                        case 2:

                            CategoriesLogic ct = new CategoriesLogic();

                            var categories = ct.GetAll();

                            Console.WriteLine("");
                            Console.WriteLine("ID:              Categoria:                                  Descripcion:");

                            foreach (var item in categories)
                            {
                                
                                Console.WriteLine($"{item.CategoryID}               - {item.CategoryName} -                                     {item.Description}");
                            }
                            Console.WriteLine("Presiona una tecla para volver al menu");

                            Console.ReadKey();

                            Console.Clear();

                            break;

                        case 3:

                           
                                Console.WriteLine("Ingrese el ID (numerico) del territorio");
                                string idTerritorio = Console.ReadLine();

                                try
                                    {
                                        int idTerritorioInt = Int32.Parse(idTerritorio);
                                    }
                                catch (Exception ex)
                                    {
                                 Console.WriteLine("Debe escribir un ID numérico");

                                 Console.ReadKey();

                                 Console.Clear();
                                break;

                                    }
                                
                                Console.WriteLine("Ingrese la descripción del territorio");
                                string descTerritorio = Console.ReadLine();

                                if (descTerritorio.All(char.IsDigit))
                                 {
                                Console.WriteLine("Debe escribir una descripcion sin valores numericos.");

                                Console.ReadKey();

                                Console.Clear();
                                break;
                                 }

                                else
                                 {
                                Console.WriteLine("Ingrese la region del territorio");
                                int regTerritorio = Int32.Parse(Console.ReadLine());


                                bool condicionAgregar = territoriesLogic.Agregar(new Territories
                                {
                                    TerritoryID = idTerritorio.ToString(),
                                    TerritoryDescription = descTerritorio,
                                    RegionID = regTerritorio,
                                });

                                if (condicionAgregar)
                                {

                                    Console.WriteLine("Agregado con exito!!");

                                    Console.WriteLine("Presiona una tecla para volver al menu");

                                    Console.ReadKey();

                                    Console.Clear();
                                }

                                else
                                {

                                    Console.WriteLine("Usted ha ingresado un dato incorrecto.");

                                    Console.WriteLine("Presiona una tecla para volver al menu");

                                    Console.ReadKey();

                                    Console.Clear();
                                }

                                break;
                                 }
                            
                          
                        case 4:

                            
                            Console.WriteLine("Ingrese el ID del territorio");
                            string idTerritorio2 = Console.ReadLine();

                            try
                            {
                                
                                if (territoriesLogic.Eliminar(idTerritorio2))
                                {
                                    Console.WriteLine("Eliminado con exito!!");

                                    Console.WriteLine("Presiona una tecla para volver al menu");

                                    Console.ReadKey();

                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Usted ha ingresado un ID inválido, es decir, no hay ningun registro con ese ID como para eliminarlo,");

                                    Console.ReadKey();

                                    Console.Clear();
                                }
                                
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("Usted no puede borrrar este registro debido a que se encuentra relacionado con otro (registro) en otra tabla. ");

                                Console.ReadKey();

                                Console.Clear();
                            }

                            



                            break;


                        case 5:
                            
                            Console.WriteLine("Ingrese el ID del territorio");
                            string idTerritorio3 = Console.ReadLine();
                            //Console.WriteLine("Ingrese el nuevo ID del territorio");
                            //string nuevoIdTerritorio = Console.ReadLine();
                            Console.WriteLine("Ingrese la nueva descripcion del territorio");
                            string nuevaDescripciondelTerritorio = Console.ReadLine();
                            Console.WriteLine("Ingrese el nuevo ID de la region del territorio");
                            int nuevaRegionTerritorio = Int32.Parse(Console.ReadLine());

                            string condicion = territoriesLogic.Modificar(idTerritorio3, new Territories
                            {
                                //TerritoryID = nuevoIdTerritorio,
                                TerritoryDescription = nuevaDescripciondelTerritorio,
                                RegionID = nuevaRegionTerritorio
                            }
                                );


                            if (condicion == "exito")
                            {

                                Console.WriteLine("Modificado con exito!!");

                                Console.WriteLine("Presiona una tecla para volver al menu");

                                Console.ReadKey();

                                Console.Clear();
                            }
                            
                            else if (condicion == "errorDato")
                            {

                                Console.WriteLine("Usted ha ingresado un dato incorrecto.");

                                Console.WriteLine("Presiona una tecla para volver al menu.");

                                Console.ReadKey();

                                Console.Clear();
                            }

                            else
                            {
                                Console.WriteLine("Usted ha ingresado un ID inválido, es decir, no hay ningun registro con ese ID como para modificarlo.");

                                Console.WriteLine("Presiona una tecla para volver al menu.");

                                Console.ReadKey();

                                Console.Clear();
                            } 

                            break;

                        case 6:
                            Console.WriteLine("Has elegido salir de la aplicación, presiona una tecla para continuar.");
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 6");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
