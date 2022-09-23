using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Data;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class ProductLogic
    {
        private NorthwindContext _context;
        public ProductLogic()
        {
            _context = new NorthwindContext();
        }
    
    public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }
    
    }
}
