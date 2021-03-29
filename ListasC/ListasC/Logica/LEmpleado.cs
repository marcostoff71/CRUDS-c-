using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasC.Modelos;

namespace ListasC.Logica
{
    public class LEmpleado
    {

        private static List<Empleado> lstEmpleados = new List<Empleado>();
        public static List<Empleado> obtenerEmpleados()
        {
            return lstEmpleados;
        }
        public static void AgregarEmpleado(Empleado p1)
        {
            lstEmpleados.Add(p1);
        }
        public static void ModficarEmpleado(Empleado p1, int indice)
        {
            lstEmpleados[indice] = p1;
        }
        public static void EliminarEmpleado(int indice)
        {
            lstEmpleados.RemoveAt(indice);
        }
        public static Empleado ObternPorIndice(int indice)
        {
            return lstEmpleados[indice];
        }


    }
}
