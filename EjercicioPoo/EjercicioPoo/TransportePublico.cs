using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    public abstract class TransportePublico
    {
        public int pasajeros { get; set; }

        public TransportePublico (int pasajeros)
        {
            this.pasajeros = pasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
