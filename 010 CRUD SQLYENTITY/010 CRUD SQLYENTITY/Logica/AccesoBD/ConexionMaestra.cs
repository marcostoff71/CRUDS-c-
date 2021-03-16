using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _010_CRUD_SQLYENTITY.Logica.AccesoBD
{
    class ConexionMaestra
    {
        public static string cadenaConexio = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Casa;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        public static SqlConnection conexion = new SqlConnection(cadenaConexio);

        public static void Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a la base de datos" + e);
            }
        }

        public static void CerrarBd()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                { 
                    conexion.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cerrar la base de datos"+e);
            }
        }
    }
}
