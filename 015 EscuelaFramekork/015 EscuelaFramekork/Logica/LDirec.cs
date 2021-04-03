using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;

namespace _015_EscuelaFramekork.Logica
{
    public class LDirec
    {
        public static List<Directivo> BuscarDirec(string bus)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return (from p in db.Directivo
                        where p.Apellido_Materno.Contains(bus) ||
                        p.Nombre.Contains(bus) || p.Apellido_Paterno.Contains(bus) || p.Curp.Contains(bus)
                        || p.Rfc.Contains(bus) || p.Profesion.Contains(bus)||p.Puesto.Contains(bus)
                        select p
                    ).ToList();
            }
        }
        public static List<Directivo> ObterDirec()
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return db.Directivo.ToList();
            }
        }
        public static Directivo ObterPodId(int id)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return db.Directivo.Where(i => i.Id == id).First();
            }
        }
        public static void AgregarDire(Directivo a1)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Directivo.Add(a1);
                db.SaveChanges();
            }
        }
        public static void EiliminarDirec(int id)
        {

            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Directivo.Remove(ObterPodId(id));
                db.SaveChanges();
            }
        }
        public static void ModificarDirec(Directivo direc)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Entry(direc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
