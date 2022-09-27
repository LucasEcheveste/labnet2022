using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Data;
using Lab.EF.Entities;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic<Categories, int>
    {
        public override bool Agregar(Categories entity)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Categories> GetAll()
        {
             return context.Categories.ToList();
        }

        public override Categories GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override string Modificar(int id, Categories entit)
        {
            throw new NotImplementedException();
        }
    }
}
