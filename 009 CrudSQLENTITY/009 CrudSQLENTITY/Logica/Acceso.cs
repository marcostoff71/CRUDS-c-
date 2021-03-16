using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _009_CrudSQLENTITY.Modelos;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _009_CrudSQLENTITY.Logica
{
    public class AccesoBdEnti
    {
        public static List<Persona> ObtenerPersonas()
        {
            List<Persona> perso = new List<Persona>();
            using (PruEntities1 bd = new PruEntities1())
            {

                perso = (from n in bd.Persona
                        select n).ToList();
            }

            return perso;
        }
        public static void AgregarPersona(Persona p1)
        {

            using (PruEntities1 db = new PruEntities1())
            {
                db.Persona.Add(p1);
                db.SaveChanges();
            }
        }
        public static void EliminarPersona(int id)
        {
            using(PruEntities1 db = new PruEntities1())
            {
                db.Persona.Remove(db.Persona.Where(i => i.Id == id).First());
                db.SaveChanges();
            }
        }
        public static Persona ObtenerPorId(int id)
        {
            Persona p1 = new Persona();
            using (PruEntities1 db = new PruEntities1())
            {
                List<Persona> per = db.Persona.ToList();
                foreach (var p in per)
                {
                    if (p.Id == id)
                    {
                        p1 = p;
                    }
                }


                //return (from n in db.Persona
                //        where n.Id == id
                //        select n).First();
                //return db.Persona.Where(item => item.Id == id).First();
            }
            return p1;
        }
        public static void EditarPersona(Persona p1)
        {
            using (PruEntities1 db = new PruEntities1())
            {
                db.Entry(p1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
        }
    }
    public class AccesoBdSql
    {
        public static List<Persona> ObtenerPersona()
        {
            List<Persona> per = new List<Persona>();
            try
            {
                ConexionMaestra.ConectarBd();

                string quer = "select * from Persona";

                SqlCommand comando = new SqlCommand(quer,ConexionMaestra.conexion);
                SqlDataReader leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    per.Add(new Persona()
                    {
                        Id = leer.GetInt32(0),
                        Nombre=leer.GetString(1),
                        Apellido_Paterno=leer.GetString(2),
                        Apellido_Materno=leer.GetString(3),
                        Cumpleaños=leer.GetDateTime(4),
                        Edad=leer.GetInt32(5)

                    });
                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Eror al obtener datos" + e);
                
            }
            finally { ConexionMaestra.CerrarBd(); }

            return per;
        }
        public static Persona ObtenerPordId(int id)
        {
            Persona per = new Persona();
            try
            {
                ConexionMaestra.ConectarBd();

                string quer = "select * from Persona where Id=@id";

                SqlCommand comando = new SqlCommand(quer,ConexionMaestra.conexion);
                comando.Parameters.AddWithValue("@id", id);


                SqlDataReader leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    per=new Persona()
                    {
                        Id = leer.GetInt32(0),
                        Nombre = leer.GetString(1),
                        Apellido_Paterno = leer.GetString(2),
                        Apellido_Materno = leer.GetString(3),
                        Cumpleaños = leer.GetDateTime(4),
                        Edad = leer.GetInt32(5)

                    };

                }
                
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Eror al obtener datos" + e);

            }
            finally { ConexionMaestra.CerrarBd(); }

            return per;
        }
        public static void Agregar(Persona p1)
        {
            try
            {
                ConexionMaestra.ConectarBd();

                string quer = "insert into Persona (Nombre,[Apellido Paterno],[Apellido Materno],Cumpleaños,Edad) values(@nombre," +
                    "@apellidoP,@apellidoM,@cumple,@edad)";

                SqlCommand comandoAgregar = new SqlCommand(quer, ConexionMaestra.conexion);
                comandoAgregar.Parameters.AddWithValue("@nombre", p1.Nombre);
                comandoAgregar.Parameters.AddWithValue("@apellidoP", p1.Apellido_Paterno);
                comandoAgregar.Parameters.AddWithValue("@apellidoM", p1.Apellido_Materno);
                comandoAgregar.Parameters.AddWithValue("@cumple", p1.Cumpleaños);
                comandoAgregar.Parameters.AddWithValue("@Edad", p1.Edad);

                comandoAgregar.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error al agregar " + e);
            }
            finally { ConexionMaestra.CerrarBd(); }
        }
        public static void Eliminar(int id)
        {
            try
            {
                ConexionMaestra.ConectarBd();
                string query = "delete from Persona where Id=@id";
                SqlCommand comandoAgregar = new SqlCommand(query, ConexionMaestra.conexion);
                comandoAgregar.Parameters.AddWithValue("@id", id);
                comandoAgregar.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Erro al eliminar " + e);
            }
            finally { ConexionMaestra.CerrarBd(); }
        }
        public static void Modifiicar(Persona p1)
        {

            try
            {
                ConexionMaestra.ConectarBd();
                string query = "update from Persona set Nombre=@nombre, [Apellido Paterno] =@apellidoPa,[Apellido Materno]=@apellidoMa" +
                    ",Cumpleaños=@cumple,Edad=@edad where Id=@id";
                SqlCommand comandoModi = new SqlCommand(query, ConexionMaestra.conexion);
                comandoModi.Parameters.AddWithValue("@nombre",p1.Nombre );
                comandoModi.Parameters.AddWithValue("@apellidoPa",p1.Apellido_Paterno );
                comandoModi.Parameters.AddWithValue("@apellidoMa",p1.Apellido_Materno );
                comandoModi.Parameters.AddWithValue("@cumple",p1.Cumpleaños );
                comandoModi.Parameters.AddWithValue("@edad",p1.Edad);
                comandoModi.Parameters.AddWithValue("@id", p1.Id);


                comandoModi.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Erro al eliminar " + e);
            }
            finally { ConexionMaestra.CerrarBd(); }
        }
    }
    public class ConexionMaestra
    {
        private static string cadenaConexio = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Pru;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        public static SqlConnection conexion = new SqlConnection(cadenaConexio);
        public static void ConectarBd()
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
                MessageBox.Show("Error de conexion"+e);
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

                MessageBox.Show("Errar al cerrar conexion" + e);
            }
        }
    }
}
