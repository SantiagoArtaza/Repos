using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Service
{
    public class EnvioService : IEnvioService
    {
        private readonly IEnvioRepository _repository;
        public EnvioService(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public List<Envio> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            if (fecDesde> fecHasta)
            {
                throw new ArgumentException("Debe ingresar la fecha desde válida");
            }
            return _repository.GetEnvios(fecDesde, fecHasta);
        }

        public bool Update(int id, Envio envioActualizado)
        {
            var envio = _repository.GetById(id);
            if (envio == null) 
            {
                throw new ArgumentException("No se encontró el envio para actualizar");
            }
            if (string.IsNullOrEmpty(envioActualizado.DniCliente))
            {
                throw new ArgumentException("Debe ingresar el dni del cliente");
            }
            if (envioActualizado.DniCliente.Length > 10)
            {
                throw new ArgumentException("Debe ingresar correctamente el dni");
            }
            if (string.IsNullOrEmpty(envioActualizado.Direccion))
            {
                throw new ArgumentException("Debe ingresar la dirección");
            }
            if (string.IsNullOrEmpty(envioActualizado.PalabraSecreta) || envioActualizado.PalabraSecreta.Length>11)
            {
                throw new ArgumentException("Debe ingresar la palabra secreta del envio");
            }
            if (envioActualizado.Estado != envio.Estado)
            {
                throw new ArgumentException("No se puede modificar el estado");
            }
            return _repository.Update(id, envioActualizado);
        }
    }
}
