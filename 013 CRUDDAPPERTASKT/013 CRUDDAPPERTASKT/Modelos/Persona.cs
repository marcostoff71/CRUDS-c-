using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_CRUDDAPPERTASKT.Modelos
{
    public class Persona
    {
        /****** Script for SelectTopNRows command from SSMS  ******/
       public int Id { get; set; }
       public string Nombre { get; set; }
       public string Apellido_Paterno { get; set; }
       public string Apellido_Materno { get; set; }
       public int Edad { get; set; }
       public DateTime Cumpleaños { get; set; }
       public string Sexo { get; set; }
    }
}
