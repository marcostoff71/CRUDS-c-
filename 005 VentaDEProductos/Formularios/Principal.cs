using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _005_VentaDEProductos.Modelos;
using _005_VentaDEProductos.Logica;

namespace _005_VentaDEProductos.Formularios
{
    public partial class Principal : Form
    {
        Producto p1 = new Producto();
        public Principal()
        {
            InitializeComponent();
        }
        public void Refrescar()
        {
            List<Producto> productos = new List<Producto>();
            productos = Acceso.ObtenerProducto();
            tabla.DataSource = productos;
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
            Refrescar();
        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    if (tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Editar")
                    {
                        int id = int.Parse(tabla.Rows[e.RowIndex].Cells[0].Value.ToString());
                        EditarPro(id);
                    }
                    else if (tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
                    {
                        int id = int.Parse(tabla.Rows[e.RowIndex].Cells[0].Value.ToString());
                        EliminarPro(id);

                    }else if(tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Vender")
                    {
                        int id = int.Parse(tabla.Rows[e.RowIndex].Cells[0].Value.ToString());
                        VenderPro(id);

                    }
                }
            }
        }
        public void EditarPro(int id)
        {
            Producto pro = Acceso.ObternerPorid(id);
            Registro r1 = new Registro();
            r1.CargarValores(pro);
            r1.ShowDialog();
            Refrescar();

        }
        public void EliminarPro(int id)
        {
            if (MessageBox.Show("Seguro de eliminar: ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Acceso.EliminarProducto(id);
                Refrescar();
            }
        }
        public void VenderPro(int id)
        {
            Producto pro = Acceso.ObternerPorid(id);
            Venta v1 = new Venta();
            v1.CargarProducto(pro);
            v1.ShowDialog();
            
            Refrescar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                
                List<Producto> bus = Acceso.BuscarProducto(txtBuscar.Text);
                if (bus.Count > 0)
                {
                    tabla.DataSource = bus;
                }
                else
                {
                    MessageBox.Show(txtBuscar.Text + " no encontrado");
                }
                txtBuscar.Text = string.Empty;
            }
            else
            {
                Refrescar();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}
