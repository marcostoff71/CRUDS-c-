using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _015_EscuelaFramekork.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboBox1.SelectedIndex;
            switch (indice)
            {
                case 0:
                    CargarVista(indice);
                    break;
                case 1:
                    CargarVista(indice);
                    break;
                case 2:
                    CargarVista(indice);
                    break;
                case 3:
                    CargarVista(indice);
                    break;
            }
        }
        private void CargarVista(int id)
        {
            panelContenedor.Controls.Clear();
            Vista v1 = new Vista(id);
            v1.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(v1);
        }

    }
}
