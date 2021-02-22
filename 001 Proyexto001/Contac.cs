using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Proyexto001
{
    public class Contac
    {
        private int id;
        private string nombre;
        private string apellidoMa;
        private string apellidoPa;
        private string telefono;
        private string direcion;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoMa { get => apellidoMa; set => apellidoMa = value; }
        public string ApellidoPa { get => apellidoPa; set => apellidoPa = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direcion { get => direcion; set => direcion = value; }
        
    }
}
