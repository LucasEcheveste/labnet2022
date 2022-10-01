using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expression<Func<int, int, int>> add = (x, y) => x + y;
            //Console.WriteLine(add);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());

            /* descomentar la linea "InsertData()" para inicializar la base de datos.
               esto debe hacerse solo la primera vez que se ejecuta el programa.
               Para las veces siguientes, dejar la línea comentada.
             */
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();

            //descomentar la siguiente linea para ver por consola el SQL generado
            db.Database.Log = Console.WriteLine;

            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} : {item.Manufacturer}");
            }

            var query2 = db.Cars.OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name)
                                .Take(10)
                                .ToList();

            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Name} : {item.Manufacturer}");
            }

            //join por más de un campo usando query syntax.
            var query3 = from car in db.Cars
                          join manufacturer in db.Manufactures
                          on new { car.Manufacturer, car.Year } 
                            equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                          select new
                          {
                              car.Name,
                              manufacturer.Headquarters
                          };

            foreach (var item in query3)
            {
                Console.WriteLine($"{item.Name} - {item.Headquarters}");
            }

            //join por un solo campo, usando Method Syntax.
            var query4 = db.Cars.Join(db.Manufactures
                                        , c => c.Manufacturer
                                        , m => m.Name
                                        ,(c, m) => new
                                        {
                                            c.Name,
                                            m.Headquarters
                                        });

            //group by usando query syntax.
            var query5 = from car in db.Cars
                         group car by car.Manufacturer into m
                         orderby m.Key descending
                         select m;

            //group by usando Method Syntax.
            var query6 = db.Cars.GroupBy(c => c.Manufacturer)
                                .OrderByDescending(g => g.Key);

            //left join usando Query Syntax.
            var query7 = from car in db.Cars
                         join manufacturer in db.Manufactures
                            on car.Manufacturer equals manufacturer.Name into joined
                            from j in joined.DefaultIfEmpty()
                         select j;

            foreach (var item in query7.Take(10))
            {
                Console.WriteLine(item.Name);
            }
            
            foreach (var group in query6)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.Take(2))
                {
                    Console.WriteLine($"\t {car.Name}");
                }
            }
            //foreach (var item in query4.Take(10))
            //{
            //    Console.WriteLine($"{item.Name} : {item.Headquarters}");
            //}
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();           

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

            var manufacturers = ProcessManufacturers("manufacturers.csv");
            if (!db.Manufactures.Any())
            {
                foreach (var manufac in manufacturers)
                {
                    db.Manufactures.Add(manufac);
                }
                db.SaveChanges();
            }
        }

        private static void QueryXml()
        {
            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = XDocument.Load("fuel.xml");

            var query =
                from element in document.Element(ns + "Cars")?.Elements(ex + "Car")
                                                       ?? Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");

            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = new XDocument();
            var cars = new XElement(ns + "Cars",

                from record in records
                select new XElement(ex + "Car",
                                new XAttribute("Name", record.Name),
                                new XAttribute("Combined", record.Combined),
                                new XAttribute("Manufacturer", record.Manufacturer))
            );

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));

            document.Add(cars);
            document.Save("fuel.xml");
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }

    public class CarStatistics
    {
        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        
        public CarStatistics Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }

    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}
