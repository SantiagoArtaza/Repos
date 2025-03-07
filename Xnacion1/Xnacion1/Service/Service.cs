
using Xnacion1.Repos;
using Xnacion1.Repository;

namespace Xnacion1.Service
{
    public class Service : IService
    {
        private readonly IRepository _reposi;
        public Service(IRepository envios)
        {
            _reposi = envios;
        }

        public TEnvio CrearEnvio(TEnvio envio)
        {
            var envi = _reposi.GeTbyId(envio.Id);
            if (envi != null)
            {
                throw new ArgumentException("El envio ya existe");
            }
            if (envio.Id.ToString()=="") 
            {
                throw new ArgumentException("id Vacia ");
            }
            return _reposi.CrearEnvio(envio);
        }

        public bool DeleteEnvio(int id)
        {
            var envi = _reposi.GeTbyId(id);
            if (envi == null)
            {
                throw new ArgumentException("Debe ingresar un pedido valido");
            }

            return _reposi.DeleteEnvio(id);
        }

        public List<TEnvio> GetAll()
        {
            return _reposi.GetAll();
        }

        public List<TEnvio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            if (fecDesde > fecHasta)
            {
                throw new ArgumentException("Debe ingresar la fecha desde válida");
            }
            return _reposi.GetEnvios(fecDesde, fecHasta);
        }

        public bool Update(int id, TEnvio envioActualizado)
        {
            var envi = _reposi.GeTbyId(id);
            if ( envi == null)
            {
                throw new ArgumentException("Debe ingresar un pedido valido");
            }

            return _reposi.Update(id, envioActualizado);
        }
    }
}
