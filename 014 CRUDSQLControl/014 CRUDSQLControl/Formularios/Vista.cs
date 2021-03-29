using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _014_CRUDSQLControl.Logica.Acceso;
using _014_CRUDSQLControl.Modelos;
using _014_CRUDSQLControl.Formularios;

namespace _014_CRUDSQLControl.Formularios
{
    public partial class Vista : UserControl
    {
        int? id = null;
        public Vista()
        {
            InitializeComponent();
        }
        private void Refrescar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AccesoBdPersonas.ObtenerPersonas();
        }
        private void Vista_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            Refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
        public int? ObterId()
        {
            int num;
            try
            {
                num =int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                
            }
            catch (Exception)
            {
                return null;
            }
            return num;
        }
        private void Modificar(int id)
        {
            Registro r1 = new Registro(id);
            r1.ShowDialog();
            Refrescar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ObterId().ToString());
            if (ObterId() != null)
            {

            EliminarDatos((int)ObterId());
            }
        }
        private void EliminarDatos(int id)
        {
            AccesoBdPersonas.EliminarPersona(id);
            Refrescar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                Modificar((int)id);
                id = null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
