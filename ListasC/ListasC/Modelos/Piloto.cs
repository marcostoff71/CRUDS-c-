using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasC.Modelos
{
    public class Piloto : Empleado
    {
        private double tiempoDeVuelo;
        private string tipoDeNave;
        public double TiempoDeVuelo { get => tiempoDeVuelo; set => tiempoDeVuelo = value; }
        public string TipoDeNave { get => tipoDeNave; set => tipoDeNave = value; }
        public Piloto()
        {
        }

        public Piloto(string pNombre, string pApellidoPa, string pApellidoMa, DateTime pFechaNacimiento, string pCurp, string pRfc, double pTiempoDeVuelo, string pTipoDeNave) : base(pNombre, pApellidoPa, pApellidoMa, pFechaNacimiento, pCurp, pRfc)
        {
            tiempoDeVuelo = pTiempoDeVuelo;
            tipoDeNave = pTipoDeNave;
        }
    }
}
