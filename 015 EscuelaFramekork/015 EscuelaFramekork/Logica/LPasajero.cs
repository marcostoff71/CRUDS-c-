using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;

namespace _015_EscuelaFramekork.Logica
{
    public class LPasajero
    {
        public static List<Pasajero> BuscarPasa(string bus)
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                return (from p in db.Pasajero
                        where p.Apellido_Materno.Contains(bus) ||
                        p.Nombre.Contains(bus) || p.Apellido_Paterno.Contains(bus)||p.Ocupacion.Contains(bus)
                        select p
                    ).ToList();
            }
        }
        public static List<Pasajero> ObtenerPasajeros()
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                return db.Pasajero.ToList();
            }
        }
        public static Pasajero ObtenerPorid(int id)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                return (from d in db.Pasajero
                        where d.Id == id
                        select d).First();
            }
        }
        public static void AgregarPasajero(Pasajero p1)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                db.Pasajero.Add(p1);
                db.SaveChanges();
            }
        }
        public static void EliminarPasajero(int id)
        {
            using (EscuelaEntities db = new EscuelaEntities())
            {
                Pasajero p1 = db.Pasajero.First(i => i.Id == id);
                db.Pasajero.Remove(p1);
                db.SaveChanges();
            }
        }
        public static void ModificarPasajero(Pasajero p1)
        {
            using(EscuelaEntities db = new EscuelaEntities())
            {
                db.Entry(p1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
