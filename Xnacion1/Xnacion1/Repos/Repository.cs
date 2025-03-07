
using Microsoft.EntityFrameworkCore;
using Xnacion1.Repository;

namespace Xnacion1.Repos
{
    public class Repository : IRepository
       
    {
         private readonly DbEnviosFinalContext _enviosFinalContext;
        public Repository(DbEnviosFinalContext context) {

            _enviosFinalContext= context;

        }

        public TEnvio CrearEnvio(TEnvio envio)
        {
            _enviosFinalContext.Add(envio);
            _enviosFinalContext.SaveChanges();
            return envio;
        }

        public bool DeleteEnvio(int id)
        {
            var entity = GeTbyId(id);
            _enviosFinalContext.Remove(entity);
             var response= _enviosFinalContext.SaveChanges();

            if (response != 0)
            {
            return true;
            }else { return false; }
        }

        public List<TEnvio> GetAll()
        {
            return  _enviosFinalContext.TEnvios.ToList();
        }

        public TEnvio GeTbyId(int id)
        {
            return _enviosFinalContext.TEnvios.FirstOrDefault(e => e.Id==id);
        }

        public List<TEnvio> GetEnvios(DateTime fecDesde, DateTime fecHasta)
        {
            return _enviosFinalContext.TEnvios.Where(e => e.Fecha >= fecDesde && e.Fecha <= fecHasta).ToList();
        }

        public bool Update(int id, TEnvio envioActualizado)
        {
           var envio1= _enviosFinalContext.TEnvios.FirstOrDefault(e => e.Id == id);
            if (envio1==null)
            {
                return false;
            }
            
            envio1.Fecha = envioActualizado.Fecha;
            envio1.DniCliente = envioActualizado.DniCliente;
            envio1.Direccion = envioActualizado.Direccion;
            envio1.PalabraSecreta = envioActualizado.PalabraSecreta;

            _enviosFinalContext.TEnvios.Update(envio1);


            return _enviosFinalContext.SaveChanges() > 0;
        }
    }
}
