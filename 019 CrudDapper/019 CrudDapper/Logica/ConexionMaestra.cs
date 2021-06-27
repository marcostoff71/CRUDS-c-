using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _019_CrudDapper.Logica
{
    public static class ConexionMaestra
    {
        public static SqlConnection connection = new SqlConnection(Properties.Settings.Default.CadenaCon1);

        public static bool Open()
        {
            bool cone = false;
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    cone = true;
                }
            }
            catch(Exception e)
            {
                cone = false;
                throw new ArgumentException("Error al conectar a la base de datos"+e.Message);
            }

            return cone;
        }
        public static bool Claso()
        {
            bool cerrar = false;

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    cerrar = true;
                }
            }
            catch (Exception e)
            {
                cerrar = false;
                throw new ArgumentException("Error al cerrar la conexion "+e.Message);
            }


            return cerrar;
        }
    }
}
