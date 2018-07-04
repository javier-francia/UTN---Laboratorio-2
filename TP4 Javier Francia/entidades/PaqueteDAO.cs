using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

 
namespace Entidades
{
    public class PaqueteDAO
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public PaqueteDAO()
        {
            conexion = new SqlConnection(Entidades.Properties.Settings.Default.connStr);
        }
        public bool Insertar(Paquete p)
        {
            string query = string.Format("INSERT INTO Paquetes VALUES('{0}','{1}','{2}')",p.DireccionEntrega, p.TrackingID,"Javier Francia");
            comando = new SqlCommand(query, conexion);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
    }
}
