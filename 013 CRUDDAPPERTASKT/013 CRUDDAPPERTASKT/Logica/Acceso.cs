using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _013_CRUDDAPPERTASKT.Modelos;
using Dapper;

namespace _013_CRUDDAPPERTASKT.Logica
{
    public interface IAcceso
    {
        Task<List<Persona>> ObtenerPersonas();
        Task<Persona> ObtenerPersonasId(int id);
        Task<List<Persona>> BuscarPersona(string bus);
        Task<bool> AgregarPersona(Persona per);
        Task<bool> MofificarPersona(Persona per);
        Task<bool> EliminarPersona(int id);
    }
    public class Acceso:IAcceso
    {
        private  string CadenaConexion = @"Data Source=DESKTOP-LNAD\SQLEXPRESS;Initial Catalog=Casa;Integrated Security=True";
        private Conexion conexion;
        
        public Acceso()
        {
            conexion= new Conexion(this.CadenaConexion);
        }

        public async Task<bool> AgregarPersona(Persona per)
        {
            SqlConnection co = conexion.obtenerCo();
            try
            {
                string qeri = @"INSERT INTO Persona (Nombre,[Apellido Paterno],[Apellido Materno],Edad,Cumpleaños,Sexo)  
            values (@Nombre,@Apellido_Paterno,@Apellido_Materno,@Edad,@Cumpleaños,@Sexo)";

                int re = await co.ExecuteAsync(qeri, new { per.Nombre, per.Apellido_Paterno, per.Apellido_Materno, per.Edad, per.Cumpleaños, per.Sexo });

                return re > 0;
            }
            catch (Exception)
            {
                return false;
                
            }
            
        }
        public async Task<bool> EliminarPersona(int id)
        {
            SqlConnection co = conexion.obtenerCo();

            string qeri = @"DELETE FROM Persona WHERE Id=@id";
            int re = await co.ExecuteAsync(qeri, new { id});

            return re > 0;
        }
        public async Task<bool> MofificarPersona(Persona per)
        {
            SqlConnection co = conexion.obtenerCo();

            string queri = @"UPDATE Persona
                            SET Nombre=@Nombre,[Apellido Paterno]=@Apellido_Paterno,[Apellido Materno]=@Apellido_Materno,    Edad=@Edad,Cumpleaños=@Cumpleaños,Sexo=@Sexo WHERE Id=@Id";
            int re = await co.ExecuteAsync(queri, new { per.Nombre, per.Apellido_Paterno, per.Apellido_Materno, per.Edad, per.Cumpleaños, per.Sexo,per.Id });


            return re > 0;


        }
        public async Task<List<Persona>> ObtenerPersonas()
        {
            SqlConnection co = conexion.obtenerCo();

            string qeri = @"SELECT Id,Nombre, [Apellido Paterno] as Apellido_Paterno,[Apellido Materno] as Apellido_Materno,Edad,Cumpleaños,Sexo  FROM Persona";

            IEnumerable<Persona> lst =await co.QueryAsync<Persona>(qeri);
            return lst.ToList();
        }
        public async Task<Persona> ObtenerPersonasId(int id)
        {
            SqlConnection co = conexion.obtenerCo();

            string qeri = @"SELECT Id,Nombre, [Apellido Paterno] as Apellido_Paterno,[Apellido Materno] as Apellido_Materno,Edad,Cumpleaños,Sexo  FROM Persona WHERE Id=@id";

            Persona p= await co.QueryFirstOrDefaultAsync<Persona>(qeri,new {id});
            return p;
        }
        public async Task<List<Persona>> BuscarPersona(string Bus)
        {
            Bus = "%" + Bus + "%";
            SqlConnection co = conexion.obtenerCo();

            string queri = @"SELECT Id,Nombre, [Apellido Paterno] as Apellido_Paterno,[Apellido Materno] as Apellido_Materno,Edad,Cumpleaños,Sexo FROM Persona                                                         Where Nombre LIKE @Bus OR [Apellido Paterno] Like @Bus";

            IEnumerable<Persona> re = await co.QueryAsync<Persona>(queri, new { Bus });

            return re.ToList();
        }
    }
}
