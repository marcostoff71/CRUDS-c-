using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Logica;

namespace WindowsFormsApp1.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        public void Refrescar()
        {
            dgAlumnos.DataSource = Acceso.ObtenerAlumo();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            Refrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}
