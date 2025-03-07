using WebApi.Models;

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

        public Envio GetById(int id)
        {
            return _context.TEnvios.FirstOrDefault(e => e.Id == id);
        }

        public List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            return _context.TEnvios.Where(e => e.Fecha >= fecDesde && e.Fecha <= fecHasta).ToList();
        }

        public bool Update(int id, Envio envioActualizado)
        {
            var envio = GetById(id);
            if (envio == null) 
            {
                return false;
            }
            
            envioActualizado.Estado = envio.Estado;

            envio.Fecha = envioActualizado.Fecha;
            envio.DniCliente = envioActualizado.DniCliente;
            envio.Direccion = envioActualizado.Direccion;
            envio.PalabraSecreta = envioActualizado.PalabraSecreta;

            _context.TEnvios.Update(envioActualizado);
            return _context.SaveChanges()>0;
        }
    }
}
