using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _008_CRUDSQL.Logica
{
    class Conexion
    {
        private static string cadenaConexion;
        public static string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }
            set
            {
                cadenaConexion = value;
            }
        }
       
        public static void Conectar()
        {
            try
            {
               
            }
            catch
            {

            }
        }

    }
}
