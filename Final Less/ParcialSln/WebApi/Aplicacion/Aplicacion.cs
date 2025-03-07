using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Aplicacion
{
    public class Aplicacion : IAplicacion
    {
        private readonly IEnvioRepository _repository;
        public Aplicacion(IEnvioRepository repository)
        {
            _repository = repository;
            
        }
        public List<Envio> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            return GetEnvios(fecDesde, fecHasta);
        }

        public bool Update(int id, Envio envio)
        {
            return Update(id, envio);
        }
    }
}
