using WebApi.Models;

namespace WebApi.Service
{
    public interface IEnvioService
    {
        List<Envio> GetAll();
        List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        bool Update(int id, Envio envioActualizado);
    }
}
