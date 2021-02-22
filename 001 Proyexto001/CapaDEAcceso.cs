using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace _001_Proyexto001
{
    class CapaDeAcceso
    {
        private string cadenaConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=winforms;Data Source=DESKTOP-LNAD\SQLEXPRESS";
        private SqlConnection conexion;
        public CapaDeAcceso()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Actuliazar(Contac con1)
        {
            try
            {
                conexion.Open();
                string query1 = string.Format("UPDATE Contactos SET ApellidoMa = '{0}', ApellidoPa = '{1}', Telefono = '{2}', Direccion = '{3}', Nombre='{4}' Where id={5}", con1.ApellidoMa, con1.ApellidoPa, con1.Telefono, con1.Direcion, con1.Nombre,con1.Id);

                SqlCommand comand1 = new SqlCommand(query1, conexion);
                comand1.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void Insertar(Contac con1)
        {
            
            try
            {
                conexion.Open();

                //string qeru ="INSERT INTO Contactos(ApellidoMa,ApellidoPa,Telefono,Direccion,Nombre) values (@apMa,@apPa,@tele,@dire,@nom";
                //SqlParameter apeMa = new SqlParameter();
                //apeMa.ParameterName = "@apMa";
                //apeMa.Value = con1.ApellidoMa;
                //apeMa.DbType = System.Data.DbType.String;

                //SqlParameter apPa = new SqlParameter("@apPa", con1.ApellidoPa);
                //SqlParameter tele = new SqlParameter("@tele", con1.Telefono);
                //SqlParameter dire = new SqlParameter("@dire", con1.Direcion);
                //SqlParameter nom = new SqlParameter("@nom", con1.Nombre);


                //SqlCommand comando1 = new SqlCommand(qeru, conexion);
                //comando1.Parameters.Add(apPa);
                //comando1.Parameters.Add(apeMa);
                //comando1.Parameters.Add(tele);
                //comando1.Parameters.Add(dire);
                //comando1.Parameters.Add(nom);
                //comando1.ExecuteNonQuery();


                string query1 = string.Format("INSERT INTO Contactos(ApellidoMa,ApellidoPa,Telefono,Direccion,Nombre) values ('{0}','{1}','{2}','{3}','{4}')", con1.ApellidoMa, con1.ApellidoPa, con1.Telefono, con1.Direcion, con1.Nombre);

                SqlCommand comand1 = new SqlCommand(query1, conexion);
                comand1.ExecuteNonQuery();

            }
            catch (Exception)
            {
                
                
            }
            finally
            {
                conexion.Close();
            }
        }
        public List<Contac> ObtenrContactos()
        {
            List<Contac> con1 = new List<Contac>();
            con1.Clear();
            try
            {
                conexion.Open();
                string quer = @"SELECT * FROM Contactos";
                SqlCommand comand2 = new SqlCommand(quer, conexion);
                SqlDataReader reader = comand2.ExecuteReader();
                while (reader.Read())
                {
                    con1.Add(new Contac { 
                        Id = int.Parse(reader["Id"].ToString()), 
                        ApellidoMa = reader["ApellidoMa"].ToString(),
                        ApellidoPa = reader["ApellidoPa"].ToString(), 
                        Telefono = reader["Telefono"].ToString(),
                        Direcion = reader["Direccion"].ToString(),
                        Nombre = reader["Nombre"].ToString() 
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return con1;
        }
        public List<Contac> ObtenrContactos(string busqueda)
        {
            List<Contac> con1 = new List<Contac>();
            con1.Clear();
            try
            {
                
                conexion.Open();
                string quer = string.Format(@"SELECT * FROM Contactos WHERE ApellidoPa LIKE '%{0}%' OR ApellidoMa LIKE '%{0}%' OR Telefono LIKE '%{0}&' OR Direccion LIKE '%{0}%' OR Nombre LIKE '%{0}%'", busqueda);
                SqlCommand comand2 = new SqlCommand(quer, conexion);
                SqlDataReader reader = comand2.ExecuteReader();
                while (reader.Read())
                {
                    con1.Add(new Contac
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        ApellidoMa = reader["ApellidoMa"].ToString(),
                        ApellidoPa = reader["ApellidoPa"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Direcion = reader["Direccion"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    });
                }
                reader.Close();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return con1;
        }
        public void Eliminar(int id)
        {
            try
            {
                conexion.Open();
                string qry = string.Format(@"DELETE FROM Contactos WHERE id = {0}", id);
                SqlCommand comando = new SqlCommand(qry, conexion);
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
