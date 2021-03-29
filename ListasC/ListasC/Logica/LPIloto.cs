using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasC.Modelos;

namespace ListasC.Logica
{
    public class LPiloto
    {
        private static List<Piloto> lstPilotos = new List<Piloto>();
        public static List<Piloto> obtenerPilotos()
        {
            return lstPilotos;
        }
        public static void AgregarPiloto(Piloto p1)
        {
            lstPilotos.Add(p1);
        }
        public static void ModficarPiloto(Piloto p1, int indice)
        {
            lstPilotos[indice] = p1;
        }
        public static void EliminarPilotos(int indice)
        {
            lstPilotos.RemoveAt(indice);
        }
        public static Piloto ObternPorIndice(int indice)
        {
            return lstPilotos[indice];
        }
    }
}
