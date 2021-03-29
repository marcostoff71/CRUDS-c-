using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListasC.Formularios;

namespace ListasC.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }



        private void MenuSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MenuSeleccion.SelectedIndex >= 0)
            {

                if (MenuSeleccion.Text == "Pasajeros")
                {
                    CargarD("Pasajero");
                }
                else if (MenuSeleccion.Text == "Empleados")
                {
                    CargarD("Empleado");
                }
                else if (MenuSeleccion.Text == "Pilotos")
                {
                    CargarD("Piloto");
                }
                else if (MenuSeleccion.Text == "Administrativos")
                {
                    CargarD("Administrativo");
                }
                else if (MenuSeleccion.Text == "Directivos")
                {
                    CargarD("Directivo");
                }
            }
           
        }
        private void CargarD(string persona)
        {
            VistaDatos v1 = new VistaDatos(persona);
            v1.Dock = DockStyle.Fill;
            v1.Show();
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(v1);
        }

    }
}
