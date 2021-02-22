using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Proyexto001
{
    
    class CapaDeNegocios
    {
        private CapaDeAcceso acceso;
        public CapaDeNegocios()
        {
            acceso = new CapaDeAcceso();
        }
        public Contac GuardarContacto(Contac contacto)
        {
            if (contacto.Id == 0)
            {
                acceso.Insertar(contacto);
               
            }
            else
            {
                acceso.Actuliazar(contacto);
            }

            return contacto;

        }
        public List<Contac> ObtenerContactos()
        {
            List<Contac> c1 = acceso.ObtenrContactos();
            return c1;
        }
        public List<Contac> ObtenerContactos(string buscar)
        {
            List<Contac> c1 = acceso.ObtenrContactos(buscar);
            return c1;
        }
        public void EliminarContacto(int id)
        {
            acceso.Eliminar(id);
        }
    }
}
