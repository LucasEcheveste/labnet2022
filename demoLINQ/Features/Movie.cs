using System;

namespace Features
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        int _year;
        public int Year
        {   get
            {
                Console.WriteLine("Accediendo al valor: " + _year);
                return _year;
            }
            set
            {
                _year = value;
            }
        }
    }
}
