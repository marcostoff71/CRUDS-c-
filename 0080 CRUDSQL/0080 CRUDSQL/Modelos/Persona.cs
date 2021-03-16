using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0080_CRUDSQL.Modelos
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPa { get; set; }
        public string ApellidoMa { get; set; }
        public DateTime Cumpleanios { get; set; }
        public int Edad { get; set; }
    }
}
