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
    public partial class Venta : Form
    {
        Producto pro;
        public Venta()
        {
            InitializeComponent();
        }
        public bool Validaciones()
        {
            bool correc = false;
            txtCanVender.Text = txtCanVender.Text.Trim();
            if (txtCanVender.Text.Trim()!="")
            {
                correc = true;
            }
            return correc;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                int n1, n2;
                double precio = pro.Precio;
                double precioVen;
                n1 = pro.Cantidad;
                n2 = int.Parse(txtCanVender.Text.Trim());

                if (n1 - n2 >= 0)
                {
                    
                    precioVen = precio * n2;
                    vender(n1, n2, precioVen);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Cantidad insuficiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void CargarProducto(Producto p1)
        {
            pro = p1;
            txtNombre.Text = pro.NombreProducto.Trim();
            txtCantidad.Text = pro.Cantidad.ToString();
            txtPrecio.Text = pro.Precio.ToString();
        }
        public void vender(int n1,int n2,double precio)
        {
            if(MessageBox.Show("Tota a pagar " + precio.ToString(),"Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pro.Cantidad -= n2;
                Acceso.ModificarPruducto(pro);
                CargarProducto(pro);
            }
        }
        public void Limpiar()
        {
            txtCanVender.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
