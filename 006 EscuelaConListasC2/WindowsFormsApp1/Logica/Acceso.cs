using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1.Logica
{
    class Acceso
    {
        private static List<Alumno> alumnos = new List<Alumno>();
        public static List<Alumno> ObtenerAlumo()
        {
            return alumnos;
        }
        public static void AgregarAlumno(Alumno a1)
        {
            alumnos.Add(a1);
        }
        public static void ModificarAlumno(Alumno a1)
        {
            if (alumnos.Contains(a1))
            {
                
            }
        }
    }
}
