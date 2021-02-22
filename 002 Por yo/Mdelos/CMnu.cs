using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002_Por_yo.Mdelos
{
    class CMnu
    {
        CAccesobd acceso = new CAccesobd();
        public List<Persona> Obtener()
        {
            return acceso.ObtenerDatos();
        }
        public void Agregar(Persona p1)
        {
            if (p1.Id == 0)
            {
                acceso.Agregar(p1);
            }
            else
            {
                acceso.Modificar(p1);
            }
        }
        public void Eliminar(int id)
        {
            acceso.Eliminar(id);
        }
        public List<Persona> Buscar(string bus)
        {
            return acceso.Buscar(bus);
        }
    }
}
