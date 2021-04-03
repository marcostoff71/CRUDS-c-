using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;

namespace _015_EscuelaFramekork.Logica
{
    public class LAdmin
    {
        public static List<Administrativo> BuscarAdmin(string bus)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return (from p in db.Administrativo
                        where p.Apellido_Materno.Contains(bus) ||
                        p.Nombre.Contains(bus) || p.Apellido_Paterno.Contains(bus) || p.Curp.Contains(bus)
                        || p.Rfc.Contains(bus) || p.Area_Trabajo.Contains(bus)
                        select p
                    ).ToList();
            }
        }
        public static List<Administrativo> ObtenerAdmin()
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                return db.Administrativo.ToList();
            }
        }
        public static Administrativo ObterPodId(int id)
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                return (from d in db.Administrativo
                       where d.Id == id
                       select d).First();
            }
        }
        public static void AgregarAdmin(Administrativo a1)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Administrativo.Add(a1);
                db.SaveChanges();
            }
        }
        public static void EiliminarAdmin(int id)
        {

            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Administrativo.Remove(db.Administrativo.First(i => i.Id == id));
                db.SaveChanges();
            }
        }
        public static void ModificarAdmin(Administrativo admin)
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
