using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Lab.LINQ.Entities;
using Lab.LINQ.Logic;

namespace Lab.LINQ.UI
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
                    var LINQlogic = new LINQlogic();
                    Console.Clear();
                    Console.WriteLine("1. Mostrar customers");
                    Console.WriteLine("2. Mostrar todos los productos sin stock");
                    Console.WriteLine("3. Mostrar todos los productos con stock y que cuestan mas de 3 unidades");
                    Console.WriteLine("4. Mostrar todos los customers de la region WA");
                    Console.WriteLine("5. Mostrar el primer elemento o nulo de una lista de productos donde el ID del producto sea igual a 789");
                    Console.WriteLine("6. Mostrar nombre de los Customers en Mayuscula y en Minuscula.");
                    Console.WriteLine("7. Mostrar Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.");

                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            LINQlogic.Ejercicio1();
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Los productos sin stock son: ");
                            LINQlogic.Ejercicio2();
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Los productos productos con stock y que cuestan mas de 3 unidades son: ");
                            LINQlogic.Ejercicio3();
                            Console.ReadKey();
                            break;

                        case 4:

                            Console.Clear();
                            Console.WriteLine("Los consumidores con la region WA son: ");
                            LINQlogic.Ejercicio4();
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("El consumidor con el ID 789 es:  ");
                            LINQlogic.Ejercicio5();
                            Console.ReadKey();
                            break;

                        case 6:

                            break;

                        case 7: 

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

