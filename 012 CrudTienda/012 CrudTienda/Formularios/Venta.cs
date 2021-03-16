using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _012_CrudTienda.Logica;
using _012_CrudTienda.Modelos;

namespace _012_CrudTienda.Formularios
{
    public partial class Venta : Form
    {
        private Tienda t1;
        public Venta()
        {
            InitializeComponent();
        }
        public void CargarCampos(int id)
        {
            t1 = Acceso.ObtenerPorId(id);
            txtCodigo.Text = t1.Codigo;
            txtNombre.Text = t1.Nombre;
            txtCantidad.Text = t1.Cantidad.ToString();
            txtPrecio.Text = t1.Precio.ToString();
            txtTotal.Text = t1.Total.ToString();
            
        }
        public void Refrescar()
        {
            txtCodigo.Text = t1.Codigo;
            txtNombre.Text = t1.Nombre;
            txtCantidad.Text = t1.Cantidad.ToString();
            txtPrecio.Text = t1.Precio.ToString();
            txtTotal.Text = t1.Total.ToString();
        }
        private bool Validaciones()
        {
            if (txtVenta.Text.Trim() != string.Empty && LTienda.esNum(txtVenta.Text.Trim()))
            {
                int venta = int.Parse(txtVenta.Text);
                if (t1.Cantidad>=venta&&venta!=0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Cantidad insuficiente");
                }
            }
            return false;
        }
        
        private void txtAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                int canv = int.Parse(txtVenta.Text);
                venta(canv);
            }
            
        }
        private void venta(int cantidad)
        {
            double total = cantidad * (double)t1.Precio;
            if(MessageBox.Show("TOtal a pagar" + total.ToString(), "Pagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                t1.Cantidad = t1.Cantidad - cantidad;
                t1.Total = t1.Cantidad * t1.Precio;
                Acceso.Modificar(t1);
                Refrescar();
            }
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
