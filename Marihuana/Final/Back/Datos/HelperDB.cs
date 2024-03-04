using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Datos
{
    public class HelperDB
    {
        private static HelperDB instance;
        private SqlConnection conexion;

        public static HelperDB GetInstance()
        {
            if (instance == null)
            {
                instance = new HelperDB();
            }
            return instance;
        }
        public HelperDB()
        {
            conexion = new SqlConnection(@"Data Source=ABBYS\SQLEXPRESS;Initial Catalog=Prueba1;Integrated Security=True;TrustServerCertificate=true");
        }
        public SqlConnection GetConnection()
        {
            return this.conexion;
        }

        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(nombreSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conexion.Close();
            return dt;
        }
    }
}
