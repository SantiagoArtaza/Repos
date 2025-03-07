using Xnacion1.Repository;

namespace Xnacion1.Repos
{
    public interface IRepository
    {
        List<TEnvio> GetAll();
        TEnvio GeTbyId(int id );
        List<TEnvio> GetEnvios(DateTime fecDesde, DateTime fecHasta);
        bool Update(int id, TEnvio envioActualizado);

        TEnvio CrearEnvio(TEnvio envio);

        bool DeleteEnvio(int id);

    }
}
