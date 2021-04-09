using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _013_CRUDDAPPERTASKT.Logica
{
    public class Conexion
    {
        private SqlConnection conexion;
        public Conexion(string cadena)
        {
            conexion = new SqlConnection(cadena);
        }
        public SqlConnection obtenerCo()
        {
            return this.conexion;
        }

    }
}
