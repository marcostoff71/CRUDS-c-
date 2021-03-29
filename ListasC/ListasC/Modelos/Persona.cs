using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Persona
    {
        private string nombre;
        private string apellidoPa;
        private string apellidoMa;

        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPa { get => apellidoPa; set => apellidoPa = value; }
        public string ApellidoMa { get => apellidoMa; set => apellidoMa = value; }

        public Persona()
        {

        }
        public Persona(string pNombre, string pApellidoPa, string pApellidoMa)
        {
            nombre = pNombre;
            this.apellidoPa = pApellidoPa;
            this.apellidoMa = pApellidoMa;
        }
    }
}
