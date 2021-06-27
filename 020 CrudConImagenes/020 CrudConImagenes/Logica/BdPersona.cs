using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _020_CrudConImagenes.Modelos;
namespace _020_CrudConImagenes.Logica
{
    public class BdPersona
    {
        public IEnumerable<Persona> Obtener()
        {
            List<Persona> lstPersonas = new List<Persona>();
            using(PrubaContraEntities db = new PrubaContraEntities())
            {
                lstPersonas=db.Persona.ToList();
                
            }

            return lstPersonas;
        }
        public Persona ObtenerPorId(int id)
        {
            Persona per = null;

            using(PrubaContraEntities db= new PrubaContraEntities())
            {
                per = db.Persona.FirstOrDefault(e => e.Id == id);
            }

            return per;
        }

        public bool Agregar(Persona pPersona)
        {
            int re = 0;
            using (PrubaContraEntities db = new PrubaContraEntities())
            {
                db.Persona.Add(pPersona);
                re=db.SaveChanges();

            }

            return re > 0;
        }
        public bool Modificar(Persona pPersona)
        {
            int re = 0;
            using (PrubaContraEntities db = new PrubaContraEntities())
            {
                Persona per=(from persona in db.Persona
                where persona.Id == pPersona.Id
                select persona).FirstOrDefault();

                per.Nombre = pPersona.Nombre;
                per.ApellidoMaterno = pPersona.ApellidoMaterno;
                per.ApellidoPaterno = pPersona.ApellidoPaterno;
                per.Edad = pPersona.Edad;
                per.FechaNaci = pPersona.FechaNaci;
                per.Foto = pPersona.Foto;


                re = db.SaveChanges();

            }

            return re > 0;
        }
        public bool Eliminar(int id)
        {
            int re = 0;
            using (PrubaContraEntities db = new PrubaContraEntities())
            {
                Persona per = db.Persona.FirstOrDefault(i => i.Id == id);
                db.Persona.Remove(per);
                re = db.SaveChanges();

            }

            return re > 0;
        }

    }
}
