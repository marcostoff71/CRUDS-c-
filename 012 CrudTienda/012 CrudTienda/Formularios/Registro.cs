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
    public partial class Registro : Form
    {
        Tienda ti=null;
        public Registro(int? id=null)
        {
            InitializeComponent();
            if (id != null)
            {
                CargarCampos((int)id);
            }
        }

        #region Datos
        private void CargarCampos(int id)
        {
            ti=Acceso.ObtenerPorId(id);
            txtNombre.Text = ti.Nombre;
            txtPrecio.Text = ti.Precio.ToString();
            txtCantidad.Text = ti.Cantidad.ToString();
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }
        private void Espacios()
        {
            txtNombre.Text = txtNombre.Text.Trim();
            txtCantidad.Text = txtCantidad.Text.Trim();
            txtPrecio.Text = txtPrecio.Text.Trim();
        }
        private bool validaciones()
        {
            Espacios();
            if (txtNombre.Text != string.Empty)
            {
                if (txtPrecio.Text != string.Empty && LTienda.esNumF(txtPrecio.Text))
                {
                    if (txtCantidad.Text != string.Empty && LTienda.esNum(txtCantidad.Text))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private void Completo(bool regis) 
        {
            if (regis)
            {
                MessageBox.Show("Registro exitoso");
                if(MessageBox.Show("Deseas agregar otro registro", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Limpiar();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Modificacion exitosa");
                this.Close();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (validaciones())
            {
                Tienda t1 = new Tienda();
                
                t1.Nombre = txtNombre.Text;
                t1.Precio = double.Parse(txtPrecio.Text);
                t1.Cantidad = int.Parse(txtCantidad.Text);
                t1.Total = LTienda.ObtenerTotal((double)t1.Precio, (int)t1.Cantidad);
                if (ti != null)
                {
                    t1.Codigo = ti.Codigo;
                    t1.Id = ti.Id;
                    Acceso.Modificar(t1);
                    Completo(false);
                    
                }
                else
                {
                    t1.Codigo = LTienda.ObternCodigoc(Acceso.Obtener());
                    Acceso.Agregar(t1);
                    Completo(true);
                    
                }


            }
            else
            {
                MessageBox.Show("LLeno los compos correctamente");
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
