using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _016_CrudRepasaso.Modelos;
using _016_CrudRepasaso.Logica;
using _016_CrudRepasaso.Formularios;

namespace _016_CrudRepasaso.Formularios
{
    public partial class VistaAlumno : UserControl
    {
        private CapaNegocios db = new CapaNegocios();
        public VistaAlumno()
        {
            InitializeComponent();
            
        }
        private async Task Refrescar()
        {
            dgDatos.DataSource = await db.ObtenerAlumnos();
        }

        private async void VistaAlumno_Load(object sender, EventArgs e)
        {
            await Refrescar();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistroAlumno alum = new RegistroAlumno();
            alum.ShowDialog();
            await Refrescar();
        }
    }
}
