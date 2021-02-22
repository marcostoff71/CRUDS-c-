using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _001_Proyexto001;

namespace _001_Proyexto001
{
    public partial class Form2 : Form
    {
        private CapaDeNegocios nego1;
        private CValidaciones vali = new CValidaciones();
        private Contac con;
        public Form2()
        {
            nego1 = new CapaDeNegocios();
            InitializeComponent();
        }
        private bool CamposValidados()
        {
            bool campCorrec = false;
            if (txtApellidoMa.Text.Trim() != "")
            {
                if (txtApellidoPa.Text.Trim() != "")
                {
                    if (txtNombre.Text.Trim() != "")
                    {

                        if (txtDireccion.Text.Trim() != "")
                        {
                            if (txtTelefono.Text.Trim() != "" && vali.esNum(txtTelefono.Text) && txtTelefono.Text.Length >= 10)
                            {
                                campCorrec = true;

                            }
                        }
                    }
                }
            }
            return campCorrec;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarContacto();


        }
        
        private void GuardarContacto()
        {
            if (CamposValidados() == true)
            {
                Contac contacto = new Contac();
                contacto.ApellidoMa = txtApellidoMa.Text;
                contacto.ApellidoPa = txtApellidoPa.Text;
                contacto.Nombre = txtNombre.Text;
                contacto.Telefono = txtTelefono.Text;
                contacto.Direcion = txtDireccion.Text;

                contacto.Id = con != null ? con.Id : 0;

                nego1.GuardarContacto(contacto);
                ((Form1)this.Owner).CargarContacot();
                Limpiar();
                this.Close();
                
            }
        }
        
        public void CargarContacto(Contac con1)
        {
            con = con1;
            if (con1 != null)
            {
                txtApellidoMa.Text = con1.ApellidoMa.Trim();
                txtApellidoPa.Text = con1.ApellidoPa.Trim();
                txtDireccion.Text = con1.Direcion.Trim();
                txtNombre.Text = con1.Nombre.Trim();
                txtTelefono.Text = con1.Telefono.Trim();
                
            }

        }
        #region keypress
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.ValidaString(ref txtNombre, e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.ValidaNum(ref txtTelefono, e);
        }

        private void txtApellidoPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.ValidaString(ref txtApellidoPa, e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.ValidaStringNum(ref txtDireccion, e);
        }

        private void txtApellidoMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.ValidaString(ref txtApellidoMa, e);
        }
        #endregion
        private void Limpiar()
        {
            txtApellidoPa.Text = "";
            txtApellidoMa.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        


    }
}
