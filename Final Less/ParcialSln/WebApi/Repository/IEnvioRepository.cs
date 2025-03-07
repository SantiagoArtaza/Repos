using WebApi.Models;

namespace WebApi.Repository
{
    public interface IEnvioRepository
    {
        List<Envio> GetAll();
        List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        bool Update(int id, Envio envio);
    }
}
