using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _010_CRUD_SQLYENTITY.Modelos;
using System.Data;
using System.Windows.Forms;
using _010_CRUD_SQLYENTITY.Logica.AccesoBD;

namespace _010_CRUD_SQLYENTITY.Logica.AccesoBD
{
    class AccesoSql
    {
        public static List<Persona> ObtenerPersonas()
        {
            List<Persona> lstPersonas = new List<Persona>();
            try
            {
                ConexionMaestra.Conectar();
                string query = "select * from Persona";
                SqlCommand cmdObter = new SqlCommand(query, ConexionMaestra.conexion);
                SqlDataReader reader = cmdObter.ExecuteReader();
                while (reader.Read())
                {
                    Persona p1 = new Persona();
                    p1.Id = reader.GetInt32(0);
                    p1.Nombre = reader.GetString(1);
                    p1.Apellido_Paterno = reader.GetString(2);
                    p1.Apellido_Materno = reader.GetString(3);
                    p1.Edad = reader.GetInt32(4);
                    p1.Cumple = reader.GetDateTime(5);
                    p1.Sexo = reader.GetString(6);
                    lstPersonas.Add(p1);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener datos de la base de datos" + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }

            return lstPersonas;
        }
        public static List<Persona> Buscar(string bus)
        {
            List<Persona> lstPersonas = new List<Persona>();
            try
            {
                ConexionMaestra.Conectar();
                string query = "select * from Persona where Nombre like @bus or [Apellido Paterno] like @bus or [Apellido Materno] like @bus or Sexo like @bus";
                SqlCommand cmdObter = new SqlCommand(query, ConexionMaestra.conexion);
                cmdObter.Parameters.AddWithValue("@bus", "%"+bus+"%");

                SqlDataReader reader = cmdObter.ExecuteReader();
                while (reader.Read())
                {
                    Persona p1 = new Persona();
                    p1.Id = reader.GetInt32(0);
                    p1.Nombre = reader.GetString(1);
                    p1.Apellido_Paterno = reader.GetString(2);
                    p1.Apellido_Materno = reader.GetString(3);
                    p1.Edad = reader.GetInt32(4);
                    p1.Cumple = reader.GetDateTime(5);
                    p1.Sexo = reader.GetString(6);
                    lstPersonas.Add(p1);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener datos de la base de datos" + e);
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
                ConexionMaestra.Conectar();
                string query = "select * from Persona where Id=@id";
                SqlCommand cmdObter = new SqlCommand(query, ConexionMaestra.conexion);
                cmdObter.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmdObter.ExecuteReader();
                while (reader.Read())
                {
                    p1.Id = reader.GetInt32(0);
                    p1.Nombre = reader.GetString(1);
                    p1.Apellido_Paterno = reader.GetString(2);
                    p1.Apellido_Materno = reader.GetString(3);
                    p1.Edad = reader.GetInt32(4);
                    p1.Cumple = reader.GetDateTime(5);
                    p1.Sexo = reader.GetString(6);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener datos de la base de datos" + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }

            return p1;
        }

        public static void AgregarPersona(Persona per)
        {
            try
            {
                ConexionMaestra.Conectar();
                string query =
                    "INSERT INTO Persona (Nombre,[Apellido Paterno],[Apellido Materno],Edad,Cumpleaños,Sexo)" +
                    " VALUES(@Nombre,@ApellidoPa,@ApellidoMa,@Edad,@Cumple,@Sexo)";
                SqlCommand cmdAgregar = new SqlCommand(query, ConexionMaestra.conexion);
                cmdAgregar.Parameters.AddWithValue("@nombre", per.Nombre);
                cmdAgregar.Parameters.AddWithValue("@ApellidoPa", per.Apellido_Paterno);
                cmdAgregar.Parameters.AddWithValue("@ApellidoMa", per.Apellido_Materno);
                cmdAgregar.Parameters.AddWithValue("@Edad", per.Edad);
                cmdAgregar.Parameters.AddWithValue("@Cumple", per.Cumple);
                cmdAgregar.Parameters.AddWithValue("@Sexo", per.Sexo);
                cmdAgregar.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Eror al agregar " + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }

        public static void ModificarPersona(Persona per)
        {
            try
            {
                ConexionMaestra.Conectar();
                string query =
                    "UPDATE Persona SET Nombre=@Nombre,[Apellido Paterno]=@ApellidoPa,[Apellido Materno]=@ApellidoMa," +
                    "Edad=@Edad,Cumpleaños=@Cumple,Sexo=@Sexo where Id=@Id";
                SqlCommand cmdModi = new SqlCommand(query, ConexionMaestra.conexion);
                cmdModi.Parameters.AddWithValue("@Nombre", per.Nombre);
                cmdModi.Parameters.AddWithValue("@ApellidoPa", per.Apellido_Paterno);
                cmdModi.Parameters.AddWithValue("@ApellidoMa", per.Apellido_Materno);
                cmdModi.Parameters.AddWithValue("@Edad", per.Edad);
                cmdModi.Parameters.AddWithValue("@Cumple", per.Cumple);
                cmdModi.Parameters.AddWithValue("@Sexo", per.Sexo);
                cmdModi.Parameters.AddWithValue("@Id", per.Id);
                cmdModi.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro al atulizar" + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }

        public static void EliminarPerosna(int id)
        {
            try
            {
                ConexionMaestra.Conectar();
                string queery = "DELETE FROM Persona where Id=@id";
                SqlCommand cmdBorrar = new SqlCommand(queery, ConexionMaestra.conexion);
                cmdBorrar.Parameters.AddWithValue("@id", id);
                cmdBorrar.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al moficiar" + e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }
    }
}