using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dominio
{
    public class DetalleTurno
    {
        public Medico Medico { get; set; }
        public string MotivoConsulta { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public DetalleTurno(Medico medico, string motivoconsulta, string fecha, string hora)
        {
            Medico = medico;
            MotivoConsulta = motivoconsulta;
            Fecha = fecha;
            Hora = hora;

        }
    }
}
