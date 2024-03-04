using Back.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Fachada.Interfaz
{
    public interface IAplicacion
    {
        List<Medico> GetMedicos();
        bool SaveTurno(Turno turno);

        bool GetTurno(string fecha, string hora, int matricula);
    }
}
