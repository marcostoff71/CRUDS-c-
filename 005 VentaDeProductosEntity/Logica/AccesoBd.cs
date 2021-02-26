using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _005_VentaDeProductosEntity.Modelos;
using System.Data.SqlClient;
using System.Data.Sql;


namespace _005_VentaDeProductosEntity.Logica
{
    public class AccesoBd
    {
        public static List<Productos> ObtenerProductos()
        {
            List<Productos> pro = new List<Productos>();
            using(TiendaEntities db = new TiendaEntities())
            {
                pro = db.Productos.ToList();
                var j = from k in db.Productos
                        select k;
            }

            return pro;
        }
        public static void EditarProductos(Productos p1)
        {
            using(TiendaEntities db = new TiendaEntities())
            {
                db.Entry(p1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void AgregarProductos(Productos p1)
        {
            using(TiendaEntities db = new TiendaEntities())
            {
                db.Productos.Add(p1);
                db.SaveChanges();
            }
        }
        public static Productos ObtenerPorId(int id)
        {
            Productos pro = new Productos();
           using(TiendaEntities db = new TiendaEntities())
            {
                pro = db.Productos.Where(i => i.Id == id).FirstOrDefault();
            }

            return pro;
        }
        public static void ElimirProductos(int id)
        {
            using(TiendaEntities db = new TiendaEntities())
            {
                var p1 = from a in db.Productos
                               where a.Id == id
                               select a;
                Productos p3 = db.Productos.Where(i => i.Id == id).First();
                Productos p2 = p1.First();
                db.Productos.Remove(p2);
                db.SaveChanges();
            }
        }
    }
}
