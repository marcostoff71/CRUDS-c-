using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _013_CRUDDAPPERTASKT.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            MostrarVistaDatos();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MostrarVistaDatos()
        {
            panelContenedor.Controls.Clear();
            VistaDatos v1 = new VistaDatos();
            v1.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(v1);
        }
    }
}
