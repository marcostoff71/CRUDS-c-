using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _005_VentaDeProductosEntity.Modelos;
using _005_VentaDeProductosEntity.Logica;

namespace _005_VentaDeProductosEntity.Formularios
{
    public partial class Registro : Form
    {
        private int? id;
        public Registro(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                using(TiendaEntities dB = new TiendaEntities())
                {
                    CargarDatos(dB.Productos.Where(i=>i.Id==id).First());
                }
                
            }
        }
        private bool Validaciones()
        {
            bool valor = false;
            if (txtNombre.Text.Trim() != "")
            {
                if (txtCantidad.Text.Trim() != "")
                {
                    if (txtPrecio.Text.Trim() != "")
                    {
                        valor = true;
                    }
                }
            }

            return valor;
        }
        private void btnAcepar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Productos p1 = new Productos();
                p1.Producto = txtNombre.Text.Trim();
                p1.Cantidad = int.Parse(txtCantidad.Text.Trim());
                p1.Precio = double.Parse(txtPrecio.Text.Trim());
                if (id == null)
                {
                    AccesoBd.AgregarProductos(p1);
                }
                else
                {
                    p1.Id =(int) this.id;
                    AccesoBd.EditarProductos(p1);
                }
                this.Close();
            }
        }
        public void CargarDatos(Productos p1)
        {
            txtNombre.Text = p1.Producto.Trim();
            txtCantidad.Text = p1.Cantidad.ToString().Trim();
            txtPrecio.Text = p1.Precio.ToString().Trim();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
