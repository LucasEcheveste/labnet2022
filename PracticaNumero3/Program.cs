using PracticaNumero3.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNumero3
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

                    Console.WriteLine("1. Opción 1");
                    Console.WriteLine("2. Opción 2");
                    Console.WriteLine("3. Opción 3");
                    Console.WriteLine("4. Opción 4");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            TodasLasException.DivsionDeDosValores();
                            break;

                        case 2:
                            Console.WriteLine("Elija el dividendo: ");
                            int dividendo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Elija el divisor: ");
                            int divisor = Convert.ToInt32(Console.ReadLine());
                            TodasLasException.Divisíon(dividendo, divisor);

                            break;

                        case 3:
                            Logic.Logicexceptcion();
                            break;

                        case 4:
                            Logic.Logicexception2();
                            break;
                        case 5:
                            Console.WriteLine("Has elegido salir de la aplicación");
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 5");
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
