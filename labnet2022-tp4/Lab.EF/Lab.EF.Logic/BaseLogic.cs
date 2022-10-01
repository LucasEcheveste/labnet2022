using Lab.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public abstract class BaseLogic<T, TId> : ILogic<T, TId>
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            context = new NorthwindContext();
        }

        public abstract bool Agregar(T entity);

        public abstract bool Eliminar(TId id);

        public abstract List<T> GetAll();

        public abstract T GetById(TId id);

        public abstract string Modificar(TId id, T entity);
    }
}
