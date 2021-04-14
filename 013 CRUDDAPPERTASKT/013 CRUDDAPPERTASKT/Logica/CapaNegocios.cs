using _013_CRUDDAPPERTASKT.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_CRUDDAPPERTASKT.Logica
{
    class CapaNegocios : Logica.IAcceso
    {
        private Logica.Acceso acceso;

        public CapaNegocios()
        {
            acceso = new Acceso();
        }
        public async Task<bool> AgregarPersona(Persona per)
        {
            if (per.Id == 0)
            {
                return await acceso.AgregarPersona(per);
            }
            else
            {
                return await acceso.MofificarPersona(per);
            }
        }

        public async Task<List<Persona>> BuscarPersona(string bus)
        {
            return await acceso.BuscarPersona(bus);
        }

        public async Task<bool> EliminarPersona(int id)
        {
            return await acceso.EliminarPersona(id);
        }

        public async Task<bool> MofificarPersona(Persona per)
        {
            return await acceso.MofificarPersona(per);
        }

        public async Task<List<Persona>> ObtenerPersonas()
        {
            return await acceso.ObtenerPersonas();
        }

        public async Task<Persona> ObtenerPersonasId(int id)
        {
            return await acceso.ObtenerPersonasId(id);
        }
    }
}
