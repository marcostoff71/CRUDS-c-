using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _002_Por_yo.Mdelos
{
    class CAccesobd
    {
        string cadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Personas;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        SqlConnection conexion ;
        public CAccesobd()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public List<Persona> ObtenerDatos()
        {
            List<Persona> person = new List<Persona>();
            try
            {
                conexion.Open();
                string query = string.Format("Select * from Persona");
                SqlCommand comandoObtenr = new SqlCommand(query, conexion);
                SqlDataReader leer = comandoObtenr.ExecuteReader();
                while (leer.Read())
                {
                    person.Add(new Persona
                    {
                        Id = int.Parse(leer["Id"].ToString()),
                        Edad = int.Parse(leer["Edad"].ToString()),
                        Nombre = leer["Nombre"].ToString()
                    }) ; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally{conexion.Close();}
            return person;
        }
        public void Agregar(Persona p)
        {
            try
            {
                conexion.Open();
                string quey = string.Format("INSERT INTO Persona(Edad,Nombre) values({0},'{1}')", p.Edad, p.Nombre);
                SqlCommand comandaAgregar = new SqlCommand(quey, conexion);
                comandaAgregar.ExecuteNonQuery();
            }

            catch (Exception)
            {

                throw;
            }
            finally { conexion.Close(); };
        }
        public void Modificar(Persona p)
        {
            try
            {
                conexion.Open();
                string que = string.Format("UPDATE Persona SET Edad={0},Nombre='{1}' WHERE id={2}", p.Edad, p.Nombre, p.Id);
                SqlCommand comandoActu = new SqlCommand(que, conexion);
                comandoActu.ExecuteNonQuery();
            }
            catch (Exception)
            {

                
            }
            finally { conexion.Close(); }
        }
        public void Eliminar(int id)
        {
            try
            {
                conexion.Open();
                string query = string.Format("DELETE FROM Persona WHERE Id={0}", id);
                SqlCommand comnada1 = new SqlCommand(query, conexion);
                comnada1.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conexion.Close(); }
        }
        public List<Persona> Buscar(string busqueda)
        {
            List<Persona> person = new List<Persona>();
            try
            {
                conexion.Open();
                string quer= string.Format("Select * From Persona where  Nombre like '%{0}%' ",busqueda);
                SqlCommand comandBusqueda = new SqlCommand(quer, conexion);
                SqlDataReader data = comandBusqueda.ExecuteReader();

                while (data.Read())
                {
                    person.Add(new Persona
                    {
                        Id = int.Parse(data["Id"].ToString()),
                        Edad = int.Parse(data["Edad"].ToString()),
                        Nombre = data["Edad"].ToString()

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conexion.Close(); }
            return person;
        }
    }
}
