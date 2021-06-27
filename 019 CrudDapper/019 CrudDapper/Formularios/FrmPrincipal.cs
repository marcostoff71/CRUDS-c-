using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _019_CrudDapper.Formularios;

namespace _019_CrudDapper.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

           
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new UCVista() { Dock=DockStyle.Fill});
            
        }
    }
}
