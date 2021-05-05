using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _016_CrudRepasaso.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            panel2.Controls.Clear();
            Formularios.VistaAlumno v1 = new VistaAlumno();
            v1.Dock = DockStyle.Fill;
            panel2.Controls.Add(v1);
        }
    }
}
