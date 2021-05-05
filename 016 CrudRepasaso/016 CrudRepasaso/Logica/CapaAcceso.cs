using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _016_CrudRepasaso.Modelos;
using Dapper;

namespace _016_CrudRepasaso.Logica
{
    public class CapaAcceso
    {
        private readonly SqlConnection Conec;
        public CapaAcceso(string cone)
        {
            Conec = new SqlConnection(cone);
        }
        public async Task<IEnumerable<Alumno>> ObtenerAlumno()
        {
            string quer = "SELECT * FROM Alumno";

            IEnumerable<Alumno> d = await Conec.QueryAsync<Alumno>(quer);

            return d;
        }
        public async Task<Alumno> ObtenerAlumno(int Id)
        {
            string quer = "SELECT * FROM Alumno WHERE Id=@Id";

            Alumno d = await Conec.QueryFirstOrDefaultAsync<Alumno>(quer,new { Id});

            return d;
        }
        public async Task<bool> AgregarAlumno(Alumno per)
        {
            string query = "INSERT INTO Alumno(Nombre,Apellidos,Edad,Sexo,FechaRegistro) values(@Nombre,@Apellidos,@Edad,@Sexo,@FechaRegistro)";

            var re = await Conec.ExecuteAsync(query, new { per.Nombre, per.Apellidos, per.Edad, per.Sexo, per.FechaRegistro });

            return re > 0;
        }

        public async Task<bool> ModificarAlumno(Alumno per)
        {
            string query = "UPDATE Alumno SET Nombre=@Nombre, Apellidos=@Apellidos,Edad=@Edad,Sexo=@Sexo,FechaRegistro=@FechaRegistro " +
                "WHERE Id=@Id";

            var re = await Conec.ExecuteAsync(query, new { per.Nombre, per.Apellidos, per.Edad, per.Sexo, per.FechaRegistro,per.Id });

            return re > 0;
        }
        public async Task<bool> EliminarAlumno(int id)
        {
            string query = "DELETE FROM Alumno Where Id=@id";

            var re = await Conec.ExecuteAsync(query,new { id});

            return re > 0;
        }
    }
}
