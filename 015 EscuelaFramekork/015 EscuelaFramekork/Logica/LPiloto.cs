using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;

namespace _015_EscuelaFramekork.Logica
{
    public class LPiloto
    {
        public static List<Piloto> BuscarPilo(string bus)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return (from p in db.Piloto
                        where p.Apellido_Materno.Contains(bus) ||
                        p.Nombre.Contains(bus) || p.Apellido_Paterno.Contains(bus) || p.Curp.Contains(bus)
                        || p.Rfc.Contains(bus) || p.Tipo_De_Nave.Contains(bus)
                        select p
                    ).ToList();
            }
        }
        public static List<Piloto> ObtenerPilotos()
        {
            List<Piloto> lstPitos = new List<Piloto>();
            using (EscuelaEntities db = new EscuelaEntities())
                
            {
                lstPitos = (from d in db.Piloto
                           select d).ToList();
            }
            return lstPitos;
        }
        public static void AgregarPiloto(Piloto p1)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Piloto.Add(p1);
                db.SaveChanges();
            }
        }
        public static Piloto ObtenerPorId(int id)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return db.Piloto.FirstOrDefault(I => I.Id == id);
            }
        }
        public static void EliminarPiloto(int id)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Piloto.Remove(db.Piloto.First(item=>item.Id==id));
                db.SaveChanges();
            }
        }
        public static void ModificarPiloto(Piloto p1)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Entry(p1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
