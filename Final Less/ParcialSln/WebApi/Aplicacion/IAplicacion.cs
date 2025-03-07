using WebApi.Models;

namespace WebApi.Aplicacion
{
    public interface IAplicacion
    {
        List<Envio> GetAll();
        List<Envio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        bool Update(int id, Envio envio);
    }
}
