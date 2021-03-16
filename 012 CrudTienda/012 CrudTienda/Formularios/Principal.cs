using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _012_CrudTienda.Formularios;
using _012_CrudTienda.Modelos;
using _012_CrudTienda.Logica;

namespace _012_CrudTienda
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Refrescar()
        {
            dataGridView1.DataSource = Acceso.Obtener();
            dataGridView1.AutoResizeColumns();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Registro re = new Registro();
            re.ShowDialog();
            Refrescar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void EliminarRe(int id)
        {
            if (MessageBox.Show("Eliminar", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Acceso.Eliminar(id);
            }
        }
        private void ModificarTien(int id)
        {
            Registro r1 = new Registro(id);
            r1.ShowDialog();
            Refrescar();
        }
        private void VenderRe(int id)
        {
            Venta v1 = new Venta();
            v1.CargarCampos(id);
            v1.ShowDialog();
            Refrescar();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 5)
                {
                    DataGridViewRow roe = dataGridView1.Rows[e.RowIndex];
                    int id = int.Parse(roe.Cells[0].Value.ToString());
                    if (roe.Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
                    {
                        EliminarRe(id);
                       
                    }else if (roe.Cells[e.ColumnIndex].Value.ToString() == "Editar")
                    {
                        ModificarTien(id);

                    }else if (roe.Cells[e.ColumnIndex].Value.ToString() == "Vender")
                    {
                        VenderRe(id);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
