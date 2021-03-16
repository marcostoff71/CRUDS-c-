using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0080_CRUDSQL.Logica
{
    public class ConexionMaestra
    {
        private static string cadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Pru;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        public static SqlConnection ConexionBd= new SqlConnection(cadenaConexion);
        

        public static void ConetarBd()
        {
            try
            {
                    
                if (ConexionBd.State == ConnectionState.Closed)
                {
                    ConexionBd.Open();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Eror al conectar a la base de datos");
            }
        }
        public static void CerrarBd()
        {
            try
            {
                if (ConexionBd.State == ConnectionState.Open)
                {
                    ConexionBd.Close();

                }
            }
            catch
            {
                MessageBox.Show("Erro al cerrar la conexion");
            }
        }
    }
}
