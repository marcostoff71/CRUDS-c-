using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasC.Modelos;
namespace ListasC.Logica
{
    public class LPasajero
    {

        private static List<Pasajero> lstPasajeros = new List<Pasajero>();
        public static List<Pasajero> obtenerPasajeros()
        {
            return lstPasajeros;
        }
        public static void AgregarPasajero(Pasajero p1)
        {
            lstPasajeros.Add(p1);
        }
        public static void ModficarPasajero(Pasajero p1, int indice)
        {
            lstPasajeros[indice] = p1;
        }
        public static void EliminarPasajero(int indice)
        {
            lstPasajeros.RemoveAt(indice);
        }
        public static Pasajero ObternPorIndice(int indice)
        {
            return lstPasajeros[indice];
        }

    }
}
