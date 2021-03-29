using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0001_Prueba
{
    public class Persona
    {
        public int Edad { get; set; }
        public string Nombre { get; set; }
    }
    public class Acceso
    {
        public static List<Persona> lst = new List<Persona>();
    }
}
