﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_CrudRepasaso.Modelos
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
