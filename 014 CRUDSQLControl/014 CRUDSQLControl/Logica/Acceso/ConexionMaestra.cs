using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _014_CRUDSQLControl.Logica.Acceso
{
    public static class ConexionMaestra
    {
        private static string cadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Pruebita;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        public static SqlConnection Conexion = new SqlConnection(cadenaConexion);
        public static void ConectarBd()
        {
            try
            {
                if (Conexion.State != ConnectionState.Open)
                {
                    Conexion.Open();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al abrir la conexion " + e);
            }
        }
        public static void CerrarBd()
        {
            try
            {
                if (Conexion.State != ConnectionState.Closed)
                {
                    Conexion.Close();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al cerrar la conexion "+e);
            }
        }
    }
}
