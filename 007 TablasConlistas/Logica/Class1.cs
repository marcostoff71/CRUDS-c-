using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _007_TablasConlistas.Modelos;

namespace _007_TablasConlistas.Logica
{
    public class AccesoBd
    {
        #region pasajeros
        private static List<Pasajero> pasajeros = new List<Pasajero>();
        public static Pasajero ObterPorIndice(int indece)
        {
            return pasajeros[indece];
        }
        public static void EditarPasajeros(Pasajero p1,int indice)
        {
            pasajeros[indice] = p1;
        }
       public static List<Pasajero> MostrarPasajeros()
        {
            return pasajeros;
        }
        public static void AgregarPasajeros(Pasajero p1)
        {
            pasajeros.Add(p1);
        }
        public static void EliminarPasajerps(int indice)
        {
            pasajeros.RemoveAt(indice);
        }
        #endregion
        #region Piloto
        private static List<Piloto> pilotos = new List<Piloto>();
        public static List<Piloto> MostrarPilotos()
        {
            return pilotos;
        }
        public static void AgregarPilotos(Piloto p1)
        {
            pilotos.Add(p1);
        }
        public static void EliminarPilotos(int indice)
        {
            pilotos.RemoveAt(indice);
        }
        #endregion
        #region Administrativo
        private static List<Administrativo> administrativos = new List<Administrativo>();
        public static List<Administrativo> MostrarAdministrativos()
        {
            return administrativos;
        }
        public static void AgregarAdministrativo(Administrativo a1)
        {
            administrativos.Add(a1);
        }
        public static void EliminarAdministrativo(int indice)
        {
            administrativos.RemoveAt(indice);
        }

        #endregion
        #region Directivo
        private static List<Directivo> directivos = new List<Directivo>();
        public static List<Directivo> MostrarDirectivos()
        {
            return directivos;
        }
        public static void AgregarDirectivo(Directivo d1)
        {
            directivos.Add(d1);
        }
        public static void EliminarDirectivos(int indice)
        {
            directivos.RemoveAt(indice);
        }
        #endregion
    }
}
