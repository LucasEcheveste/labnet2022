using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaNumero3.Exceptions
{
    public class NumeroFueraDeRangoException : Exception
    {
        public NumeroFueraDeRangoException(): base("El numero no está dentro del rango solicitado")
        {
        
        }
    }
}
