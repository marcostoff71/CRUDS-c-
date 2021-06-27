using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using _019_CrudDapper.Modelos.ModelosView;
using _019_CrudDapper.Modelos;
using System.Data.SqlClient;
namespace _019_CrudDapper.Logica
{
    public class AccesoBd
    {
        public async  Task<List<Persona>> Obtener()
        {
            List<Persona> lstPersona = new List<Persona>();



            try
            {
                string qery = "SELECT * FROM Persona";
                lstPersona = (await ConexionMaestra.connection.QueryAsync<Persona>(qery)).ToList();
            }
            catch (Exception e)
            {

                throw new ArgumentException("Eror " + e);
            }



            return lstPersona;
        }
        public async Task<Persona> ObtenerPorId(int id)
        {
            Persona oPersona = new Persona();



            try
            {
                string qery = "SELECT * FROM Persona WHERE Id=@id";
                oPersona = await ConexionMaestra.connection.QueryFirstOrDefaultAsync<Persona>(qery,new{id});
            }
            catch (Exception e)
            {

                throw new ArgumentException("Eror " + e);
            }



            return oPersona;
        }
        public async Task<bool> Agregar(Persona pPersona)
        {
            int corre=0;
            try
            {
                string query = "INSERT INTO Persona (Nombre,ApPaterno,ApMaterno) values(@Nombre,@ApPaterno,@ApMaterno)";

                corre = await ConexionMaestra.connection.ExecuteAsync(query, pPersona);
            }
            catch (Exception)
            {

                throw;
            }


            return corre > 0;
        }

        public async Task<bool> Modificar(Persona pPersona)
        {
            int corre = 0;
            try
            {
                string query = "UPDATE PERSONA SET Nombre=@Nombre, ApPaterno=@ApPatenro, ApMaterno=@ApMaterno WHERE Id=@Id";

                corre = await ConexionMaestra.connection.ExecuteAsync(query, pPersona);
            }
            catch (Exception)
            {

                throw;
            }


            return corre > 0;
        }
        public async Task<bool> Eiliminar(int Id)
        {
            int corre = 0;
            try
            {
                string query = "DELETE FROM Persona Where Id=@Id";

                corre = await ConexionMaestra.connection.ExecuteAsync(query, new { Id });
            }
            catch (Exception)
            {

                throw;
            }


            return corre > 0;
        }

    }
}
