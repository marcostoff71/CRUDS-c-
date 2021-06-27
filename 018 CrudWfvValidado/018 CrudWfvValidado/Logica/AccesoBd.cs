using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _018_CrudWfvValidado.Modelos;
using System.Windows;
using System.Windows.Controls;
namespace _018_CrudWfvValidado.Logica
{
    public class AccesoBd
    {
        private string cadenaCone = @"Data Source=.;Initial Catalog=DbPersona;Integrated Security=True";
        private SqlConnection connection;
        public AccesoBd()
        {
            this.connection = new SqlConnection(this.cadenaCone);
        }
        public async Task<IEnumerable<Persona>> Obtener()
        {
            List<Persona> lst = new List<Persona>();
            string query = "SELECT * FROM Persona";

            try
            {
                await this.connection.OpenAsync();
                SqlCommand comando = new SqlCommand(query, this.connection);

                SqlDataReader reader = await comando.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    lst.Add(new Persona()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        ApMaterno = reader["ApMaterno"].ToString(),
                        ApPaterno = reader["ApPaterno"].ToString()
                    });
                }
            }
            catch 
            {
                return null;
            }
            finally
            {
                this.connection.Close();
            }
            return lst;
        }
        public async Task<Persona> ObternerPorId(int id)
        {
            Persona p1 = new Persona();

            try
            {
                await this.connection.OpenAsync();
                string query = "SELECT * FROM Persona WHERE Id=@Id";

                SqlParameter para = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                para.Value = id;

                SqlCommand comando = new SqlCommand(query, this.connection);
                comando.Parameters.Add(para);

                SqlDataReader re= await comando.ExecuteReaderAsync();
                await re.ReadAsync();
                p1.Id = re.GetInt32(0);
                p1.Nombre = re.GetString(1);
                p1.ApMaterno = re.GetString(2);
                p1.ApPaterno = re.GetString(3);
            }
            catch 
            {

                return null;
            }
            finally
            {
                this.connection.Close();
            }
            return p1;
        }
        public async Task<bool> Agregar(Persona oPersona)
        {
            bool exito = false;
            try
            {
                await this.connection.OpenAsync();
                string query = "INSERT INTO Persona(Nombre,ApMaterno,ApPaterno) VALUES(@Nombre,@ApMaterno,@ApPaterno)";
                SqlCommand comando = new SqlCommand(query, this.connection);
                comando.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter(){DbType=System.Data.DbType.String,Value=oPersona.Nombre,ParameterName="@Nombre"},
                new SqlParameter(){DbType=System.Data.DbType.String,Value=oPersona.ApMaterno,ParameterName="@ApMaterno"},
                new SqlParameter(){DbType=System.Data.DbType.String,Value=oPersona.ApPaterno,ParameterName="@ApPaterno"}

                });

                int re = await comando.ExecuteNonQueryAsync();

                exito = re > 0;
            }
            catch 
            {

                exito = false;
            }
            finally
            {
                this.connection.Close();
            }
            return exito;
        }
        public async Task<bool> Modificar(Persona oPersona)
        {
            Persona aux =await this.ObternerPorId(oPersona.Id);
            if (aux == null) return false;
            bool exito = false;
            try
            {
                this.connection.Open();
                string query = "UPDATE Persona SET Nombre=@Nombre, ApMaterno =@ApMaterno,ApPaterno=@ApPaterno WHERE Id=@Id";

                SqlCommand comando = new SqlCommand(query, this.connection);

                comando.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter(){SqlDbType=System.Data.SqlDbType.VarChar,Value=oPersona.Nombre,ParameterName="@Nombre"},
                new SqlParameter(){SqlDbType=System.Data.SqlDbType.VarChar,Value=oPersona.ApMaterno,ParameterName="@ApMaterno"},
                new SqlParameter(){SqlDbType=System.Data.SqlDbType.VarChar,Value=oPersona.ApPaterno,ParameterName="@ApPaterno"},
                new SqlParameter(){SqlDbType=System.Data.SqlDbType.Int,Value=oPersona.Id,ParameterName="@Id"}
                });

                int re = await comando.ExecuteNonQueryAsync();

                exito = re > 0;
            }
            catch
            {

                exito = false;
            }
            finally
            {
                this.connection.Close();
            }
            return exito;
        }
        public async Task<bool> Eliminar(int pId)
        {
            bool valor = false;
            try
            {
                await this.connection.OpenAsync();

                string query = "DELETE FROM Persona WHERE Id=@Id";

                SqlCommand comando = new SqlCommand(query,this.connection);


                SqlParameter para = new SqlParameter("@Id", pId);
                para.SqlDbType = System.Data.SqlDbType.Int;

                comando.Parameters.Add(para);

                int re = await comando.ExecuteNonQueryAsync();
                valor = re > 0;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                valor = false;
                MessageBox.Show(e.ToString());
            }
            finally { this.connection.Close(); }
            return valor;
        }
    }
}
