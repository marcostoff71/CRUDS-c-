using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Directivo : Empleado
    {
        private int numeroDeEmpleado;
        private DateTime fechaDeIngreso;
        private string profesion;
        private string puesto;
        private int cantidadDeEmpleados;

        public int NumeroDeEmpleado { get { return numeroDeEmpleado; } set { numeroDeEmpleado = value; } }
        public DateTime FechaDeIngreso { get { return fechaDeIngreso; } set { fechaDeIngreso = value; } }
        public string Profesion { get { return profesion; } set { profesion = value; } }
        public string Puesto { get { return puesto; } set { puesto = value; } }
        public int CantidadDeEmpleados { get { return cantidadDeEmpleados; } set { cantidadDeEmpleados = value; } }
        public Directivo()
        {
        }

        public Directivo(string pNombre, string pApellidoPa, string pApellidoMa, DateTime pFechaNacimiento, string pCurp, string pRfc,
            int pNumeroDeEmpleado, DateTime pFechaDeIngreso, string pProfesion, string pPuesto, int pCantidadDeEmpleados)
            : base(pNombre, pApellidoPa, pApellidoMa, pFechaNacimiento, pCurp, pRfc)
        {
            numeroDeEmpleado = pNumeroDeEmpleado;
            fechaDeIngreso = pFechaDeIngreso;
            profesion = pProfesion;
            puesto = pPuesto;
            cantidadDeEmpleados = pCantidadDeEmpleados;
        }




    }
}
