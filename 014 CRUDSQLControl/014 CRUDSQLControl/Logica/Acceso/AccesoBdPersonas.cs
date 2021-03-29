using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _014_CRUDSQLControl.Modelos;
using _014_CRUDSQLControl.Logica.Acceso;
using System.Windows.Forms;

namespace _014_CRUDSQLControl.Logica.Acceso
{
    class AccesoBdPersonas
    {
        public static List<Persona> ObtenerPersonas()
        {
            List<Persona> lstPersonas = new List<Persona>();

            try
            {
                ConexionMaestra.ConectarBd();
                string query = "SELECT * FROM Persona";
                SqlCommand obtener = new SqlCommand(query, ConexionMaestra.Conexion);
                SqlDataReader leer = obtener.ExecuteReader();


                while (leer.Read())
                {
                    lstPersonas.Add(
                        new Persona
                        {
                            Id = leer.GetInt32(0),
                            Nombre = leer.GetString(1),
                            Apellido = leer.GetString(2),
                            Edad = leer.GetInt32(3)
                        });
                }
                leer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro al obtener datos " + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
            return lstPersonas;
        }
        public static Persona ObtenerPorId(int id)
        {
            Persona p1 = new Persona();
            try
            {
                ConexionMaestra.ConectarBd();
                string query = "SELECT * FROM Persona where Id=@id";
                SqlCommand obtener = new SqlCommand(query, ConexionMaestra.Conexion);
                obtener.Parameters.AddWithValue("@id", id);



                SqlDataReader leer = obtener.ExecuteReader();

                while (leer.Read())
                {
                    p1 = new Persona
                    {
                        Id = leer.GetInt32(0),
                        Nombre = leer.GetString(1),
                        Apellido = leer.GetString(2),
                        Edad = leer.GetInt32(3)
                    };
                }
                leer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener datos " + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
            return p1;
        }
        public static void EliminarPersona(int id)
        {
            try
            {
                ConexionMaestra.ConectarBd();
                string query = "DELETE FROM Persona where Id=@id";
                SqlCommand cmd = new SqlCommand(query, ConexionMaestra.Conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Erro al eliminar datos " + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }
        public static void ModificarPersona(Persona p1)
        {
            try
            {
                ConexionMaestra.ConectarBd();
                string query = "UPDATE Persona SET Nombre=@Nombre,Apellido=@Apellido,Edad=@Edad where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, ConexionMaestra.Conexion);
                cmd.Parameters.AddWithValue("@Nombre", p1.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", p1.Apellido);
                cmd.Parameters.AddWithValue("@Edad", p1.Edad);
                cmd.Parameters.AddWithValue("@Id", p1.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al modificar a la base de datos" + e);
            }
            finally { ConexionMaestra.CerrarBd(); }
        }
        public static void AgregarPersona(Persona p1)
        {
            try
            {
                ConexionMaestra.ConectarBd();
                string query = "INSERT INTO Persona(Nombre,Apellido,Edad) values (@Nombre,@Apellido,@Edad)";
                SqlCommand cmd = new SqlCommand(query, ConexionMaestra.Conexion);
                cmd.Parameters.AddWithValue("@Nombre", p1.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", p1.Apellido);
                cmd.Parameters.AddWithValue("@Edad",p1.Edad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Error a agregar a la base de datos " + e);
            }
            finally { ConexionMaestra.CerrarBd(); }
        }
    }
}
