using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductLogic pl = new ProductLogic();

            var products = pl.GetAll();

            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }
            Console.ReadKey();
        }
    }
}
