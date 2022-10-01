using Lab.LINQ.Data;
using Lab.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic
{
    public class LINQlogic : Baselogic
    {

        public static void Ejercicio1()
        {
            var context = new NorthwindContext();

            var query = from Customers in context.Customers
                        select Customers;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.CustomerID} - {item.CompanyName} - {item.ContactTitle} - {item.Address} - {item.City} - " +
                    $"{item.Region} - {item.PostalCode} - {item.Country} - {item.Phone} - {item.Fax}");
            }


        }

        public static void Ejercicio2()
        {
            var context = new NorthwindContext();

            var query = from Products in context.Products
                        where Products.UnitsInStock == 0
                        select Products;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductID} - {item.ProductName} - {item.UnitsInStock}");
            }

        }

        public static void Ejercicio3()
        {
            var context = new NorthwindContext();

            var query = context.Products.Where(p => p.UnitsInStock > 0)
                                         .Where(p => p.UnitPrice > 3)
                                 .Select(p => p);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductID} - {item.ProductName} - {item.UnitsInStock} - {item.UnitPrice}");
            }

        }

        public static void Ejercicio4()
        {
            var context = new NorthwindContext();

            var query = from Customers in context.Customers
                        where Customers.Region == "WA"
                        select Customers;

            foreach (var item in query)
            {
                Console.WriteLine($"{item.CustomerID} - {item.CompanyName} - {item.ContactTitle} - {item.Address} - {item.City} - " +
                    $"{item.Region} - {item.PostalCode} - {item.Country} - {item.Phone} - {item.Fax}");
            }

        }

        public static void Ejercicio5()
        {
            var context = new NorthwindContext();

            var query = context.Products.Where(p => p.ProductID = 789)
                                        .Select(p => p);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.CustomerID} - {item.CompanyName} - {item.ContactTitle} - {item.Address} - {item.City} - " +
                   $"{item.Region} - {item.PostalCode} - {item.Country} - {item.Phone} - {item.Fax}");

            }

        }

        public static void Ejercicio6()
        {
            var context = new NorthwindContext();

            var query = from Customers in context.Customers
                        select Products;


            foreach (var item in query)
            {
                Console.WriteLine($"{item.CompanyName}");

            }

        }

    }
}
