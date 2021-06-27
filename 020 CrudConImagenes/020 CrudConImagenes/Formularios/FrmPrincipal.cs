using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _020_CrudConImagenes.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Controls.Clear();
            Formularios.CtrRegistro re = new CtrRegistro();
            re.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(re);
        }
    }
}
