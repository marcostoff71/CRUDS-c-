using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _018_CrudWfvValidado.Logica;
using _018_CrudWfvValidado.Modelos;
namespace _018_CrudWfvValidado.Logica
{
    public interface IServiciosPersona
    {
        Task<IEnumerable<Persona>> Obtener();
        Task<Persona> ObtenerPorId(int pId);
        Task<bool> Guardar(Persona pPersona);
        Task<bool> Eliminar(int pId);
        Task<IEnumerable<Persona>> BuscarPer(string bus);
    }
}
