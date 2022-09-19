using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNumero3.Exceptions
{
    internal class TodasLasException
    {

        public static void DivsionDeDosValores()
        {
			try
			{
                int numero = 0;
                Console.WriteLine("Ingrese un numero");
                numero = Convert.ToInt32(Console.ReadLine());
                int resultado = numero / 0;

            }
			catch (DivideByZeroException dex)
			{
                Console.WriteLine(dex.Message);
			}
            finally
            {
                Console.WriteLine("La operación ha finalizado.");
            }
        }

        public static void Divisíon (int n, int m)
        {
            try
            {
                int resultado = n / m;
                Console.WriteLine($"El resultado es {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine ("Solo Chuck Norris divide por cero!");
                Console.WriteLine(ex.Message);
            }

            catch (FormatException fex)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
            }
        }

    }
}
