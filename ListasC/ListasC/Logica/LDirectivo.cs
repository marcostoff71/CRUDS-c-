using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasC.Modelos;
namespace ListasC.Logica
{
    public class LDirectivo
    {
        private static List<Directivo> lstDirectivos = new List<Directivo>();
        public static List<Directivo> ObtenerDirectivos()
        {
            return lstDirectivos;
        }
        public static void AgregarDirectivo(Directivo d1)
        {
            lstDirectivos.Add(d1);
        }
        public static void EliminarDirectivo(int indice)
        {
            lstDirectivos.RemoveAt(indice);
        }
        public static void ModificarDirectivo(Directivo d1, int indice)
        {
            lstDirectivos[indice] = d1;
        }
        public static Directivo ObtenerPorIndice(int indice)
        {
            return lstDirectivos[indice];
        }
    }
}
