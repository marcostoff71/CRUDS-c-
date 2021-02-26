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
    public partial class Registro : Form
    {
        private int? id;
        public Registro(int? Id=null)
        {
            InitializeComponent();
            this.id = Id;
        }

        private bool ValidacionesTxtBox()
        {
            bool correc=false;

            if (txtNomProducto.Text!="")
            {
                if(txtCan.Text!=""&&int.TryParse(txtCan.Text,out int num))
                {
                    if (int.Parse(txtCan.Text) >= 1)
                    {
                        if (txtPrecio.Text != "" && double.TryParse(txtPrecio.Text, out double n))
                        {
                            if (double.Parse(txtPrecio.Text) >= 0.1)
                            {
                                correc = true;
                            }
                           
                        }
                    }
                    
                }
                        
            }
            return correc;
        }
        public void Limpiar()
        {
            txtCan.Text = string.Empty;
            txtNomProducto.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                if (ValidacionesTxtBox())
                {
                    Producto p1 = new Producto();
                    p1.NombreProducto = txtNomProducto.Text.Trim();
                    p1.Cantidad = int.Parse(txtCan.Text.Trim());
                    p1.Precio = double.Parse(txtPrecio.Text.Trim());
                    Acceso.AgregarProducto(p1);
                    Limpiar();
                    this.Close();
                }
            }
            else
            {
                if (ValidacionesTxtBox())
                {
                    Producto p1 = new Producto();
                    p1.Id = (int)this.id;
                    p1.NombreProducto = txtNomProducto.Text.Trim();
                    p1.Cantidad = int.Parse(txtCan.Text.Trim());
                    p1.Precio = double.Parse(txtPrecio.Text.Trim());
                    Acceso.ModificarPruducto(p1);
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CargarValores(Producto p1)
        {
            txtNomProducto.Text = p1.NombreProducto.Trim();
            txtCan.Text = p1.Cantidad.ToString().Trim();
            txtPrecio.Text = p1.Precio.ToString().Trim();
            id = p1.Id;
        }

        private void txtCan_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacionestelcas.SoloNumeros(e);
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
