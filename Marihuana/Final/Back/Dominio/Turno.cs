using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Dominio
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Paciente { get; set; }
        public List<DetalleTurno> lDetalles { get; set; }
        public Turno()
        {
            lDetalles = new List<DetalleTurno>();
        }
        public void AgregarDetalle(DetalleTurno detalle)
        {
            lDetalles.Add(detalle);
        }

        public void QuitarDetalle(int id)
        {
            lDetalles.RemoveAt(id);
        }
    }
}
