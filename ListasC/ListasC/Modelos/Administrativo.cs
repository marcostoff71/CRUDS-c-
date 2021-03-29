using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Administrativo : Empleado
    {
        private int numeroDeEmpleado;
        private DateTime fechaDeIngreso;
        private string areaDeTrabajo;
        public int NumeroDeEmpleado { get => numeroDeEmpleado; set => numeroDeEmpleado = value; }
        public DateTime FechaDeIngreso { get => fechaDeIngreso; set => fechaDeIngreso = value; }
        public string AreaDeTrabajo { get => areaDeTrabajo; set => areaDeTrabajo = value; }

        public Administrativo()
        {
        }

        public Administrativo(string pNombre, string pApellidoPa, string pApellidoMa, DateTime pFechaNacimiento, string pCurp, string pRfc, int pNumeroDeEmpleado, DateTime pFechaDeIngreso, string pAreaDeTrabajo) : base(pNombre, pApellidoPa, pApellidoMa, pFechaNacimiento, pCurp, pRfc)
        {
            numeroDeEmpleado = pNumeroDeEmpleado;
            fechaDeIngreso = pFechaDeIngreso;
            areaDeTrabajo = pAreaDeTrabajo;
        }




    }
}
