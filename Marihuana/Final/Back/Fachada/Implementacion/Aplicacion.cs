using Back.Datos.Implementacion;
using Back.Datos.Interfaz;
using Back.Dominio;
using Back.Fachada.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Fachada.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private IDao dao;
        public Aplicacion()
        {
            dao = new Dao();
        }
        public List<Medico> GetMedicos()
        {
            return dao.TraerMedicos();
        }

        public bool GetTurno(string fecha, string hora, int matricula)
        {
            return dao.existe(fecha ,hora, matricula);
        }

        public bool SaveTurno(Turno turno)
        {
            return dao.CrearTurno(turno);
        }
    }
}
