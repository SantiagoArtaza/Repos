using Back.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Datos.Interfaz
{
    public interface IDao
    {
        List<Medico> TraerMedicos();
        bool CrearTurno(Turno turno);
        bool existe(string fecha, string hora,int matricula);
    }
}
