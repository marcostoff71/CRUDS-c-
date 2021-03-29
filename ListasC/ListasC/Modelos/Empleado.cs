using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Empleado : Persona
    {
        private DateTime fechaNacimiento;
        private string curp;
        private string rfc;

        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Curp { get => curp; set => curp = value; }
        public string Rfc { get => rfc; set => rfc = value; }
        public Empleado()
        {
        }

        public Empleado(string pNombre, string pApellidoPa, string pApellidoMa, DateTime pFechaNacimiento, string pCurp, string pRfc) :
            base(pNombre, pApellidoPa, pApellidoMa)
        {
            fechaNacimiento = pFechaNacimiento;
            curp = pCurp;
            rfc = pRfc;
        }
    }
}
