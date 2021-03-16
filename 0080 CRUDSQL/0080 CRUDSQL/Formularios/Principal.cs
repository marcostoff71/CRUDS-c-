using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _0080_CRUDSQL.Logica;
using _0080_CRUDSQL.Formularios;
namespace _0080_CRUDSQL
{
    public partial class Form1 : Form
    {
        int? id = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Refrescar()
        {
            dgPersona.DataSource = AccesoBd.ObtenerPersonas();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            Refrescar();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (id != null)
            {
                EliminarPer((int)id);
                
            }
        }
        private void dgPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow ce = dgPersona.Rows[e.RowIndex];
                id = int.Parse(ce.Cells[0].Value.ToString());
            }
        }
        private void EliminarPer(int indi)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AccesoBd.Eliminar((int)id);
                Refrescar();
                id = null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                Modificar((int)id);
                
            }
        }
        public void Modificar(int id)
        {
            Registro r1 = new Registro(id);
            r1.Text = "Modificar";
            r1.CargarCampos(id);
            r1.ShowDialog();
            Refrescar();
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBus.Text.Length==0)
            {
                Refrescar();
            }
            else
            {
            Buscar();

            }
        }
        public void Buscar()
        {
            if (txtBus.Text != "")
            {
                if (int.TryParse(txtBus.Text, out int num))
                {
                    dgPersona.DataSource = AccesoBd.BuscarNumeros(num);
                }
                else
                {
                    dgPersona.DataSource = AccesoBd.BuscarLetras(txtBus.Text);
                }
                
            }
            
        }

        private void dgPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell aq =dgPersona.Rows[e.RowIndex].Cells[e.ColumnIndex];
            DataGridViewRow rw = dgPersona.Rows[e.RowIndex];
            int id= int.Parse(rw.Cells[0].Value.ToString()); ;
            if (aq.Value.ToString() == "Eliminar")
            {
                EliminarPer(id);
            }else if (aq.Value.ToString() == "Editar")
            {
                Modificar(id);
            }
        }
    }
}
