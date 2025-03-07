using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly EnviosDBContext _context;

        public EnvioRepository(EnviosDBContext context)
        {
            _context = context;
        }

        public List<Envio> GetAll()
        {
            return _context.TEnvios.ToList();
        }

        public List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            if (fecDesde > fecHasta)
                throw new ArgumentException("La fecha ingresada en 'desde' no puede ser mayor a la fecha ingresada en 'hasta'.");

            return _context.TEnvios
                .Where(e => e.Fecha >= fecDesde && e.Fecha <= fecHasta)
                .ToList();
        }

        public List<Envio> GetEnviosPorDireccion(string direccion)
        {
            return _context.TEnvios
                .Where(e => e.Direccion.Contains(direccion))
                .ToList();
        }

        public bool Update(int id, Envio envio)
        {
            var envioExistente = _context.TEnvios.FirstOrDefault(e => e.Id == id);

            if (envioExistente == null)
                return false;

            envioExistente.DniCliente = envio.DniCliente;
            envioExistente.Direccion = envio.Direccion;
            envioExistente.Fecha = envio.Fecha;
            envioExistente.PalabraSecreta = envio.PalabraSecreta;

            if (string.IsNullOrEmpty(envioExistente.DniCliente) ||
                string.IsNullOrEmpty(envioExistente.Direccion) ||
                string.IsNullOrEmpty(envioExistente.PalabraSecreta))
            {
                throw new ArgumentException("Todos los campos obligatorios deben estar completos.");
            }

            _context.SaveChanges();
            return true;
        }

   
    }
}
