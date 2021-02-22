using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _005_VentaDEProductos.Logica
{
    public class ConexionMaestra
    {
        public static string cadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Tienda;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        public static SqlConnection Conexion = new SqlConnection(cadenaConexion);

        public static void Conectar()
        {
            try
            {
                Conexion.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectarme a la base de datos");
            }
        }
        public static void Cerrar()
        {
            try
            {
                Conexion.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Eror al cerrar a la base de datos");
            }
        }
    }
}
