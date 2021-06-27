using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _019_CrudDapper.Modelos;
using _019_CrudDapper.Modelos.ModelosView;
namespace _019_CrudDapper.Logica
{
    public interface IServicesPersona
    {
        Task<List<Persona>> Obtener();
        Task<Persona> ObtenerPorId(int pId);
        Task<bool> Agregar(Persona pPer);
        Task<bool> Eliminar(int pId);
    }
}
