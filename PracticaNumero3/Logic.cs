using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNumero3.Exceptions
{
    internal class Logic
    {
        public static void Logicexceptcion()
        {
			try
			{
				Console.Write("Escriba un numero entero: ");
				int entero = int.Parse(Console.ReadLine());
			}
			catch (OverflowException oex)
			{
				Console.WriteLine("Mensaje de la excepcion: ");
				Console.WriteLine(oex.Message);

                Console.WriteLine("Tipo de excepcion: ");
				Console.WriteLine(oex.GetType().Name);

            }
        }

		public static void Logicexception2()
		{
			try
			{
				Console.WriteLine("Escriba un su edad (Rango posible entre 1 y 120)");
				int edad = int.Parse(Console.ReadLine());
				if (edad < 1 | edad > 120)
				{
					throw new NumeroFueraDeRangoException();
				}

				Console.WriteLine($"Su edad es {edad}");
			}
			catch (NumeroFueraDeRangoException numex)
			{
                Console.WriteLine("Mensaje de la excepcion: ");
                Console.WriteLine(numex.Message);
				 
                Console.WriteLine("Tipo de excepcion: ");
                Console.WriteLine(numex.GetType().Name);

            }
		}
    }
}
