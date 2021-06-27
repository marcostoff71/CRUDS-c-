using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _012_CrudTienda.Modelos;

namespace _012_CrudTienda.Logica
{
    class Acceso
    {
        public static List<Tienda> Obtener()
        {
            List<Tienda> datos = new List<Tienda>();

            using (WpfEntities db = new WpfEntities())
            {
                datos = db.Tienda.ToList();
            }


            return datos;
        }
        public static Tienda ObtenerPorId(int id)
        {
            Tienda t1= new Tienda();
            using (WpfEntities db = new WpfEntities())
            {
                t1 = db.Tienda.FirstOrDefault<Tienda>(i => i.Id == id);

                //foreach (var item in db.Tienda)
                //{
                //    if (item.Id == id)
                //    {
                //        t1 = item;
                //    }
                //}
            }
            return t1;
        }
        public static void Agregar(Tienda t1)
        {
            using(WpfEntities db = new WpfEntities())
            {
                db.Tienda.Add(t1);
                db.SaveChanges();
            }
        }
        public static void Eliminar(int id)
        {
            using (WpfEntities db = new WpfEntities())
            {
                
                db.Tienda.Remove(ObtenerPorId(id));
                db.SaveChanges();
            }

        }
        public static void Modificar(Tienda t1)
        {
            using (WpfEntities db = new WpfEntities())
            {
                db.Entry(t1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
               
            }
            
        }
    }
}
