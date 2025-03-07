using Xnacion1.Repository;

namespace Xnacion1.Service
{
    public interface IService
    {
        List<TEnvio> GetAll();
        List<TEnvio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        bool Update(int id, TEnvio envioActualizado);

        TEnvio CrearEnvio(TEnvio envio);

        bool DeleteEnvio(int id);
    }
}
