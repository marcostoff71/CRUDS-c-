using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_CRUD_SQLYENTITY.Modelos
{
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public int Edad { get; set; } 
        public DateTime Cumple { get; set; }
        public string Sexo { get; set; }

    }
}
