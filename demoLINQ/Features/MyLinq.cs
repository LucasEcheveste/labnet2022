using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Linq
{
    public static class MyLinq
    {
        //Método Count Custom extendiendo IEnumerable. Linq funciona extendiendo esta interfaz.
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            var count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
