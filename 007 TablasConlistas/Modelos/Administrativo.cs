using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_TablasConlistas.Modelos
{
    public class Administrativo
    {
        public string NombreAdmin { get; set; }
        public string ApellidoPaAdmin { get; set; }
        public string ApellidoMaAdmin { get; set; }
        public int NumeroEmpleAdmin { get; set; }
        public string CurpAdmin { get; set; }
        public string RfcAdmin { get; set; }
        public DateTime FechaNaciAdmin{get;set;}
        public DateTime FechaIngresoAdmin{get; set;}
        public string AreaDeTrabajoAdmin{get;set;}
    }
}
