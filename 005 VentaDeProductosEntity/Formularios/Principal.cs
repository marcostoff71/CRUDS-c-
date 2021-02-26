using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _005_VentaDeProductosEntity.Logica;
using _005_VentaDeProductosEntity.Modelos;
using _005_VentaDeProductosEntity.Formularios;

namespace _005_VentaDeProductosEntity
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        public void Refrescar()
        {
            dgDatos.DataSource = AccesoBd.ObtenerProductos();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    int id =int.Parse( dgDatos.Rows[e.RowIndex].Cells[3].Value.ToString());
                    if (dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Editar")
                    {
                        ModificarD(id);

                    }else if(dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
                    {
                        EliminarD(id);
                    }else if (dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Vender")
                    {
                        VenderD(id);
                    }
                }
            }
        }
        private void ModificarD(int id)
        {
            Registro r1 = new Registro(id);
            r1.ShowDialog();
            Refrescar();
            
        }
        private void EliminarD(int id)
        {
            if(MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
            {
                AccesoBd.ElimirProductos(id);
            }
           
            Refrescar();
        }
        private void VenderD(int id)
        {
            Venta v1 = new Venta(id);
            v1.ShowDialog();
            Refrescar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            Refrescar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "")
            {
                using(TiendaEntities db = new TiendaEntities())
                {
                    var bus = db.Productos.Where(i => i.Producto == txtBuscar.Text.Trim()).ToList();
                    if (bus.Count > 0)
                    {
                        dgDatos.DataSource = bus;
                    }
                    else
                    {

                    }
                   
                    txtBuscar.Text = string.Empty;
                }
            }
            else Refrescar();
        }
    }
}
