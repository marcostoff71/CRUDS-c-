using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Pasajero : Persona
    {
        private int edad;
        private string ocupacion;
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        public string Ocupacion
        {
            get { return ocupacion; }
            set { ocupacion = value; }
        }
        public Pasajero(string pNombre, string pApellidoPa, string pApellidoMa, int pEdad, string pOcupacion)
            : base(pNombre, pApellidoPa, pApellidoMa)
        {
            edad = pEdad;
            ocupacion = pOcupacion;
        }
        public Pasajero()
        {

        }
    }
}
