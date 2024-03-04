using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Datos
{
    public class Parametro
    {
        public int Clave { get; set; }
        public object Valor { get; set; }
        public Parametro(int clave, object valor)
        {
            Clave = clave;
            Valor = valor;
        }
    }
}
