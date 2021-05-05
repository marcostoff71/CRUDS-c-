using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _016_CrudRepasaso.Logica;
using _016_CrudRepasaso.Modelos;

namespace _016_CrudRepasaso.Formularios
{
    public partial class RegistroAlumno : Form
    {
        int id;
        CapaNegocios db = new CapaNegocios();
        public RegistroAlumno(int id = 0)
        {
            InitializeComponent();
            this.id = id;
        }
        private bool ValidacionesAlumno()
        {
            return true;
        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidacionesAlumno())
            {
                Alumno a1 = new Alumno();
                a1.Nombre = txtNombre.Text;
                a1.Apellidos = txtApellidos.Text;
                a1.Sexo = char.Parse(cbSexo.Text);
                a1.FechaRegistro = DateTime.Now;
                if (id != 0) a1.Id = this.id;
                await db.GuardarAlumno(a1);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
