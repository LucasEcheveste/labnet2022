using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public static class MyLinq
    {          
        
        public static IEnumerable<double> Random()
        {
            var random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }
         
        //Método Filter Custom simulando el funcionamiento del Where de Linq.
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    /* el yield return me ayuda a construir listas.
                    no se ejecuta nada si no intento acceder a la colección.
                    cuando recupera un elemento, devuelve el control al método que lo invocó y espera
                    hasta que se requiera otro elemento. */
                    yield return item;
                }
            }
        }
    }
}
