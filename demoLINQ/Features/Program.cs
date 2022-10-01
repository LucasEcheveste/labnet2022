using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Movie> movies = new List<Movie>
            {
                new Movie { Title = "Dr. No",            Rating = 8.0f, Year = 1962 },
                new Movie { Title = "The Dark Knight",   Rating = 8.9f, Year = 2008 },
                new Movie { Title = "Casablanca",        Rating = 8.5f, Year = 1942 },
                new Movie { Title = "Star Wars V",       Rating = 8.7f, Year = 1980 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Deadpool",          Rating = 8.9f, Year = 2018 }
            };

            //Queremos Filtrar las Peliculas anteriores al 2000
            var query = movies.Where(m => m.Year < 2000);

            var query2 = movies.OrderBy(m => m.Year);

            foreach (var item in query2)
            {
                Console.WriteLine(item.Title);
            }

            var query3 = movies.ToList().Where(m => m.Year < 2000);

            var query4 = movies.Where(m => m.Year < 2000).ToList();



            #region Expresiones Lambda

            /// public delegate TResult Func<in T,out TResult>(T arg);
            /// Crea un delegado que corresponde a una función que devuelve algo del tipo que nosotros le pasemos como TResult
            /// int T hace referencia al parametro de entrada
            /// out TResult hace referencia a lo que devuelve este func
            //Func<int, int> square = x => x * x;

            //Func<int, int, int> add = (x, y) => x + y;


            /// public delegate void Action<in T>(T obj);
            /// Crea un delegado que corresponde a una función que NO devuelve nada, es decir el equivalente a metodo void
            /// int T hace referencia al parametro de entrada
            //Action<int> printScreen = x => Console.WriteLine(x);

            //printScreen(add(square(2), 3));

            #endregion

            Console.ReadLine();
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
