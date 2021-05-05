using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _018_CrudWfvValidado.Logica;
using _018_CrudWfvValidado.Modelos;

namespace _018_CrudWfvValidado.Logica
{
    public class ServiciosPersona : IServiciosPersona
    {
        AccesoBd bd;
        public ServiciosPersona()
        {
            bd = new AccesoBd();
        }

        public async Task<bool> Eliminar(int pId)
        {
            return await this.bd.Eliminar(pId);
        }
        public async Task<bool> Guardar(Persona pPersona)
        {
                bool valor = false;
                if (pPersona.Id == default(int))
                {
                    valor= await this.bd.Agregar(pPersona);
                }
                else
                {
                    valor= await this.bd.Modificar(pPersona);
                }

                return valor;
        }

        public async Task<IEnumerable<Persona>> Obtener()
        {
            return await this.bd.Obtener();
        }

        public async Task<Persona> ObtenerPorId(int pId)
        {
            return await this.bd.ObternerPorId(pId);
        }
        public async Task<IEnumerable<Persona>> BuscarPer(string bus)
        {
            bus = bus.ToLower();
            IEnumerable<Persona> lst = (from p in await this.bd.Obtener()
                                       where p.ApMaterno.ToLower().Contains(bus) ||
                                       p.ApPaterno.ToLower().Contains(bus) ||
                                       p.Nombre.ToLower().Contains(bus)
                                       select p).ToList();

            return lst;
            
        }
    }
}
