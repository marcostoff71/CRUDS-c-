//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _015_EscuelaFramekork.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Directivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public Nullable<int> Numero_Empleado { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Profesion { get; set; }
        public string Puesto { get; set; }
        public Nullable<int> Cantidad_Empleados { get; set; }
    }
}
