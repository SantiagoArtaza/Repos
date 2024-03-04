using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dominio
{
    public class Medico
    {
        public int Matricula{ get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }


        public Medico(int matricula, string nombre, string apellido, string especialidad)
        {
            Nombre = nombre;
            Matricula = matricula;
            Apellido = apellido;
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }

    }
}
