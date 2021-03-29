using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0001_Prueba
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void Refrescar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Acceso.lst;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Acceso.lst.Add(new Persona { Edad = 23, Nombre = "pep" });
            Refrescar();
        }
    }
}
