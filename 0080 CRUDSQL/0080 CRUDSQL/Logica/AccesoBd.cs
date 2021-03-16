using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _0080_CRUDSQL.Logica;
using _0080_CRUDSQL.Modelos;
using System.Windows.Forms;

namespace _0080_CRUDSQL.Logica
{
    class AccesoBd
    {
        public static void Agregar(Persona p1)
        {

            try
            {
                ConexionMaestra.ConetarBd();

                string qery = "insert into Persona(Nombre,[Apellido Paterno],[Apellido Materno],Edad,Cumpleaños) values (@Nombre,@ApellidoPa,@ApellidoMa,@Edad,@Cumpleaños)";

                SqlCommand cmdAgregar = new SqlCommand(qery, ConexionMaestra.ConexionBd);

                cmdAgregar.Parameters.AddWithValue("@Nombre", p1.Nombre.ToString());
                //SqlParameter p11 = new SqlParameter();
                //p11.ParameterName = "@Apellido Paterno";
                //p11.Value = p1.ApellidoPa;
                //cmdAgregar.Parameters.Add(p11);
                cmdAgregar.Parameters.AddWithValue("@ApellidoPa", p1.ApellidoPa);
                cmdAgregar.Parameters.AddWithValue("@ApellidoMa", p1.ApellidoMa);
                cmdAgregar.Parameters.AddWithValue("@Edad", p1.Edad);
                cmdAgregar.Parameters.AddWithValue("@Cumpleaños", p1.Cumpleanios);

                cmdAgregar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror al agregar " + ex);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }


        }

        public static List<Persona> ObtenerPersonas()
        {
            List<Persona> p1 = new List<Persona>();
            try
            {
                ConexionMaestra.ConetarBd();

                string query = "Select * from Persona";
                SqlCommand cmdObtener = new SqlCommand(query, ConexionMaestra.ConexionBd);
                SqlDataReader datar = cmdObtener.ExecuteReader();

                while (datar.Read())
                {
                    Persona pe = new Persona()
                    {
                        Id = int.Parse(datar["Id"].ToString()),
                        Nombre = datar["Nombre"].ToString(),
                        ApellidoPa = datar["Apellido Paterno"].ToString(),
                        ApellidoMa = datar["Apellido Materno"].ToString(),
                        Cumpleanios = DateTime.Parse(datar["Cumpleaños"].ToString()),
                        Edad = int.Parse(datar["Edad"].ToString())

                    };

                    p1.Add(pe);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro al obtener datos" + ex);
            }
            finally { ConexionMaestra.CerrarBd(); }

            return p1;
        }
        public static Persona ObternerPersona(int id)
        {
            Persona p1 = new Persona();

            try
            {

                ConexionMaestra.ConetarBd();
                string query = "Select * from Persona where Id=@id";
                
                SqlCommand comndaid = new SqlCommand(query, ConexionMaestra.ConexionBd) ;

                //comndaid.Connection=ConexionMaestra.ConexionBd;
                //comndaid.CommandText = query;
                comndaid.Parameters.AddWithValue("@id", id);

                SqlDataReader data = comndaid.ExecuteReader();
                while (data.Read())
                {

                p1.Id = data.GetInt32(0);
                p1.Nombre = data.GetString(1);
                p1.ApellidoPa = data.GetString(2);
                p1.ApellidoMa = data.GetString(3);
                p1.Cumpleanios = data.GetDateTime(4);
                p1.Edad = data.GetInt32(5);

                }
                
                //string fomato = string.Format("Id: {0} Nomrbe: {1} Apellido Paterno; {2} Apellido Materno: {3} Cumpleaños: {4} Edad: {5}", p1.Id, p1.Nombre, p1.ApellidoPa, p1.ApellidoPa, p1.Cumpleanios.ToString(), p1.Edad);
                //MessageBox.Show(fomato);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro al obtener por id" + ex);
                
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }

            return p1;
        }
        public static void Modifcar(Persona p1)
        {
            try
            {
                ConexionMaestra.ConetarBd();

                string query = "update Persona set " +
                    "Nombre=@Nombre, [Apellido Paterno]=@ApellidoPa, [Apellido Materno]=@ApellidoMa, Cumpleaños=@Cumple," +
                    "Edad=@Edad where Id=@Id";

                SqlCommand comando = new SqlCommand(query,ConexionMaestra.ConexionBd);
                comando.Parameters.AddWithValue("@Nombre", p1.Nombre);
                comando.Parameters.AddWithValue("@ApellidoPa", p1.ApellidoPa);
                comando.Parameters.AddWithValue("@ApellidoMa", p1.ApellidoMa);
                comando.Parameters.AddWithValue("@Cumple", p1.Cumpleanios);
                comando.Parameters.AddWithValue("@Edad", p1.Edad);
                comando.Parameters.AddWithValue("@Id", p1.Id);


                comando.ExecuteNonQuery();


            }
            catch(Exception e)
            {
                MessageBox.Show("Error al modificar"+e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                ConexionMaestra.ConetarBd();
                string query;
                query = "delete from persona where Id=@Id";

                SqlCommand cmdEli = new SqlCommand(query, ConexionMaestra.ConexionBd);
                cmdEli.Parameters.AddWithValue("@id", id);

                cmdEli.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro al eliminar"+e);
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
        }
        public static List<Persona> Buscar(string busqueda)
        {
            List<Persona> bus = new List<Persona>();
            if(int.TryParse(busqueda,out int num))
            {

            }
            else
            {

            }

            return bus;
        }
        public static List<Persona> BuscarLetras(string busqueda)
        {
            List<Persona> p4 = new List<Persona>();
            try
            {
                ConexionMaestra.ConetarBd();



                string query = "select * from Persona where Nombre like @Nombre or [Apellido Paterno] like @ApellidoPa or [Apellido Materno] like @ApellidoMa or Cumpleaños like @cumple";

                SqlCommand comanda = new SqlCommand(query, ConexionMaestra.ConexionBd);
                comanda.Parameters.AddWithValue("@Nombre", $"%{busqueda}%");
                comanda.Parameters.AddWithValue("@ApellidoPa", $"%{busqueda}%");
                comanda.Parameters.AddWithValue("@ApellidoMa", $"%{busqueda}%");
                comanda.Parameters.AddWithValue("@cumple", $"%{busqueda}%");

                SqlDataReader leer = comanda.ExecuteReader();
                while (leer.Read())
                {
                    p4.Add(new Persona()
                    {
                        Id = leer.GetInt32(0),
                        Nombre = leer.GetString(1),
                        ApellidoPa = leer.GetString(2),
                        ApellidoMa = leer.GetString(3),
                        Cumpleanios = leer.GetDateTime(4),
                        Edad = leer.GetInt32(5)
                    }) ;
                }
                leer.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Erro al buscar 1");
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
            return p4;
        }
        public static List<Persona> BuscarNumeros(int num)
        {
            List<Persona> p4 = new List<Persona>();
            try
            {
                ConexionMaestra.ConetarBd();



                string query = "select * from Persona where Edad like @Edad";

                SqlCommand comanda = new SqlCommand(query, ConexionMaestra.ConexionBd);
                comanda.Parameters.AddWithValue("@Edad", $"%{num}%");
                

                SqlDataReader leer = comanda.ExecuteReader();
                while (leer.Read())
                {
                    p4.Add(new Persona()
                    {
                        Id = leer.GetInt32(0),
                        Nombre = leer.GetString(1),
                        ApellidoPa = leer.GetString(2),
                        ApellidoMa = leer.GetString(3),
                        Cumpleanios = leer.GetDateTime(4),
                        Edad = leer.GetInt32(5)
                    });
                }
                leer.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Erro al buscar");
            }
            finally
            {
                ConexionMaestra.CerrarBd();
            }
            return p4;
        }

    }
}
