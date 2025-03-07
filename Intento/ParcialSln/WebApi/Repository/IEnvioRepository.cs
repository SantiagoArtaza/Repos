using WebApi.Models;

namespace WebApi.Repository
{
    public interface IEnvioRepository
    {
        List<Envio> GetAll();
        List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        Envio GetById(int id);
        bool Update(int id, Envio envioActualizado);
    }
}
