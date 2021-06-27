using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _019_CrudDapper.Logica;
using _019_CrudDapper.Modelos;
using _019_CrudDapper.Modelos.ModelosView;
using System.Data.SqlClient;
using Dapper;

namespace _019_CrudDapper.Logica
{
    public class ServicesPersona : IServicesPersona
    {

        private readonly AccesoBd _accesoBdPer;

        public ServicesPersona()
        {
            this._accesoBdPer = new AccesoBd();
        }

        public async Task<bool> Agregar(Persona per)
        {
            if (per.Id == default(int))
            {
                return await this._accesoBdPer.Agregar(per);
            }
            else
            {
                return await this._accesoBdPer.Modificar(per);
            }
        }

        public async Task<bool> Eliminar(int pId)
        {
            return await this._accesoBdPer.Eiliminar(pId);
        }

        public async Task<List<Persona>> Obtener()
        {
            return await this._accesoBdPer.Obtener();
        }

        public async Task<Persona> ObtenerPorId(int pId)
        {
            return await this._accesoBdPer.ObtenerPorId(pId);
        }
    }
}
