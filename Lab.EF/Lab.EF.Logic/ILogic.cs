using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public interface ILogic<T, TId>
    {
        T GetById(TId id);
        List<T> GetAll();

        bool Agregar(T entity);

        bool Eliminar(TId id);

        string Modificar(TId id, T entity);
    }
}
