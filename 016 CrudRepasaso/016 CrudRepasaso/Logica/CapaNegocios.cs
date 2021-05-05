using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _016_CrudRepasaso.Logica;
using _016_CrudRepasaso.Modelos;

namespace _016_CrudRepasaso.Logica
{
    public class CapaNegocios

    {
        private CapaAcceso  bd;
        public CapaNegocios()
        {
            bd = new CapaAcceso(@"Data Source=DESKTOP-LNAD\SQLEXPRESS;Initial Catalog=AlumnosDb;Integrated Security=True");
        }
        public async Task<IEnumerable<Alumno>> ObtenerAlumnos()
        {
            IEnumerable<Alumno> result = await bd.ObtenerAlumno();
            return result;
        }
        public async Task<Alumno> ObtenerAlumnoId(int id)
        {
            Alumno result = await bd.ObtenerAlumno(id);
            return result;
        }
        public async Task<bool> ModificarAlumno(Alumno alum)
        {
            return await bd.ModificarAlumno(alum);
        }
        public async Task<bool> GuardarAlumno(Alumno alum)
        {
            if (alum.Id > 0)
            {
                return await bd.ModificarAlumno(alum);
            }
            else
            {
                return await bd.AgregarAlumno(alum);
                
            }
        } 
        public async Task<bool> EliminarAlumno(int id)
        {
            return await bd.EliminarAlumno(id);
        }
    }
}
