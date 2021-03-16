using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _010_CRUD_SQLYENTITY.Logica.AccesoBD;
using _010_CRUD_SQLYENTITY.Formularios;

namespace _010_CRUD_SQLYENTITY.Formularios
{
    public partial class Principal : Form
    {
        private int id;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        #region Datos

        private void Refrescar()
        {
            dgDatosPer.DataSource = AccesoSql.ObtenerPersonas();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            Refrescar();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void EliminarPer(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                AccesoSql.EliminarPerosna(id);
                Refrescar();

            }
        }

        private void EditarPer(int id)
        {
            Registro r1 = new Registro(id);
            r1.Text = "Editar";
            r1.ShowDialog();
            Refrescar();
        }

        private void Buscar(string bus)
        {
            if (int.TryParse(bus, out int num))
            {

            }
            else
            {
                var buscar = AccesoSql.Buscar(bus);
                dgDatosPer.DataSource = buscar;
            }
        }

        #endregion
        private void dgDatosPer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    DataGridViewCell cell = dgDatosPer.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    int id=int.Parse(dgDatosPer.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (cell.Value.ToString() == "Eliminar")
                    {
                        EliminarPer(id);

                    }else if (cell.Value.ToString() == "Modificar")
                    {
                        EditarPer(id);
                    }
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text.Trim()==string.Empty)
            {
                Refrescar();
            }
            else
            {
                Buscar(txtBuscar.Text.Trim());
            }
        }
        
    }
}
