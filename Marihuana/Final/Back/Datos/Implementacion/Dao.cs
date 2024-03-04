using Back.Datos.Interfaz;
using Back.Dominio;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Back.Datos.Implementacion
{
    public class Dao : IDao
    {
        public List<Medico> TraerMedicos()
        {
            List<Medico> lMedicos = new List<Medico>();
            DataTable dt = HelperDB.GetInstance().Consultar("SP_CONSULTAR_MEDICOS");
            foreach (DataRow dr in dt.Rows) 
            {
                int id = Convert.ToInt32(dr["matricula"]);
                string nombre = dr["nombre"].ToString();
                string apellido = dr["apellido"].ToString();
                string especialidad = dr["especialidad"].ToString();
                lMedicos.Add(new Medico(id, nombre, apellido, especialidad));
            }
            return lMedicos;
        }
        public bool CrearTurno(Turno turno)
        {
            SqlConnection conexion = HelperDB.GetInstance().GetConnection();
            SqlTransaction transaction = null;
            bool ok = true;

            try
            {
                conexion.Open();
                transaction = conexion.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand("INSERTAR_MAESTRO", conexion, transaction);
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@id", DbType.Int32);

                param.Direction = ParameterDirection.Output;

                cmdMaestro.Parameters.Add(param);
                cmdMaestro.Parameters.AddWithValue("@paciente", turno.Paciente);
                cmdMaestro.ExecuteNonQuery();

                int nroTurno = (int)param.Value;

                foreach (DetalleTurno detalle in turno.lDetalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", conexion, transaction);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;

                    cmdDetalle.Parameters.AddWithValue("@matricula", detalle.Medico.Matricula);
                    cmdDetalle.Parameters.AddWithValue("@id_turno", nroTurno);
                    cmdDetalle.Parameters.AddWithValue("@motivo", detalle.MotivoConsulta);
                    cmdDetalle.Parameters.AddWithValue("@fecha", detalle.Fecha);
                    cmdDetalle.Parameters.AddWithValue("@hora", detalle.Hora);                 
                    cmdDetalle.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (conexion != null)
                {
                    transaction.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return ok;
        }

        public bool existe(string fecha, string hora,int matricula)
        {
            SqlConnection conexion = HelperDB.GetInstance().GetConnection();
            SqlTransaction transaction = null;
            bool existe = false;

            conexion.Open();

            transaction = conexion.BeginTransaction();
            SqlCommand cmdMaestro = new SqlCommand("[SP_CONTAR_TURNOS]", conexion, transaction);
            cmdMaestro.CommandType = CommandType.StoredProcedure;


            SqlParameter param = new SqlParameter("@ctd_turnos", DbType.Int32);
            param.Direction = ParameterDirection.Output;

            cmdMaestro.Parameters.Add(param);
            cmdMaestro.Parameters.AddWithValue("@fecha",fecha);
            cmdMaestro.Parameters.AddWithValue("@hora", hora);
            cmdMaestro.Parameters.AddWithValue("@matricula", matricula);
            cmdMaestro.ExecuteNonQuery();
            if (0 != (int)param.Value)
            {
                existe = true;  

            }

            return existe;
            
        }
    }
}
