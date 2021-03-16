using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_TablasConlistas.Modelos
{
    public class Directivo
    {
        public string NombreDi { get; set; }
        public string ApellidoPaDi { get; set; }
        public string ApellidoMaDi { get; set; }
        public int NumeroEmpleDi { get; set; }
        public string CurpDi { get; set; }
        public string RfcDi { get; set; }
        public DateTime FechaNaciDi{get; set;}
        public DateTime FechaIngresoDi{get; set;}
        public string ProfessionDi{get; set;}
        public string PuestoDi { get; set; }
        public int CanEmpleACaroDi { get; set; }
    }
}
