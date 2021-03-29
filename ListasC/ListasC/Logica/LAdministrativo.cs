using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasC.Modelos;

namespace ListasC.Logica
{
    public class LAdministrativo
    {
        private static List<Administrativo> lstAdministrativos = new List<Administrativo>();
        public static List<Administrativo> obtenerAdministrativos()
        {
            return lstAdministrativos;
        }
        public static void AgregarAdministrativo(Administrativo p1)
        {
            lstAdministrativos.Add(p1);
        }
        public static void MoficarAdministrativo(Administrativo p1, int indice)
        {
            lstAdministrativos[indice] = p1;
        }
        public static void EliminarAdministrativo(int indice)
        {
            lstAdministrativos.RemoveAt(indice);
        }
        public static Administrativo ObternPorIndice(int indice)
        {
            return lstAdministrativos[indice];
        }
    }
}
