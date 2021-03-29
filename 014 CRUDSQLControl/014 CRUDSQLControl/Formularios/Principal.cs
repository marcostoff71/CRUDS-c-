using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _014_CRUDSQLControl.Formularios;

namespace _014_CRUDSQLControl.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContedor.Controls.Clear();
            Vista vistaPersonas = new Vista();
            vistaPersonas.Dock = DockStyle.Fill;
            panelContedor.Controls.Add(vistaPersonas);
            
        }
    }
}
