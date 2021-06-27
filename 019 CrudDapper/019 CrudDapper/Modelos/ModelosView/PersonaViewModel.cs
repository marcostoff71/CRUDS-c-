using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_CrudDapper.Modelos.ModelosView
{
    public class PersonaViewModel
    {
        [Display(Name ="ID")]
        public int Id { get; set; }
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        public string ApPaterno { get; set; }
        [Display(Name ="Apellido Materno")]
        public string ApMaterno { get; set; }
    }
}
