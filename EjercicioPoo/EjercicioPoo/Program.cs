using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> transportesPublicos = new List<TransportePublico>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Introduzca la cantidad de pasajeros para un ómnibus: ");
                string cantidad;
                cantidad = Console.ReadLine();
                int x = Int32.Parse(cantidad);
                Omnibus nuevoOmnibus = new Omnibus(x);
                transportesPublicos.Add(nuevoOmnibus);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Introduzca la cantidad de pasajeros para un taxi: ");
                string cantidad;
                cantidad = Console.ReadLine();
                int x = Int32.Parse(cantidad);
                Taxi nuevoTaxi = new Taxi(x);
                transportesPublicos.Add(nuevoTaxi);
            }

            Console.WriteLine("");

            for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Omnibus: " + transportesPublicos[i].pasajeros);
                }

            Console.WriteLine("");

            for (int i = 5; i < 10; i++)
                {
                    Console.WriteLine("Taxi: " + transportesPublicos[i].pasajeros);
                }

            Console.ReadLine();
        }

          




        }
    }
