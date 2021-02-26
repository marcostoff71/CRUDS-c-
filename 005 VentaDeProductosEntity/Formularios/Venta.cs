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


namespace _005_VentaDeProductosEntity.Formularios
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }
        Productos p1;
        public Venta(int id)
        {
            InitializeComponent();
            p1 = AccesoBd.ObtenerPorId(id);
            Refrescar();
        }
        public void Refrescar()
        {
            txtNombre.Text = p1.Producto.Trim();
            txtCantidad.Text = p1.Cantidad.ToString().Trim();
            txtPrecio.Text = p1.Precio.ToString().Trim();
        }
        private void Venta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtVenta.Text.Trim() != "")
            {
                if(double.TryParse(txtVenta.Text.Trim(),out double venta))
                {
                    double precio, cantidad, resul;
                    precio = double.Parse(txtPrecio.Text.Trim());
                    cantidad = double.Parse(txtCantidad.Text.Trim());
                    if (cantidad - venta >= 0)
                    {
                        resul = venta * precio;
                        if(MessageBox.Show("Total a vender"+resul,"Informacion venta", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            p1.Cantidad =(int) (cantidad-venta);
                            AccesoBd.EditarProductos(p1);
                            Refrescar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cantidad insuficiente");
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
