using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListasC.Modelos;
using ListasC.Logica;
namespace ListasC.Formularios
{
    public partial class RegistroPasa : Form
    {
        public RegistroPasa()
        {
            InitializeComponent();
            
        }
        private void QuitarEspacios()
        {
            txtNombre.Text = txtNombre.Text.Trim();
            txtApellidoPa.Text = txtApellidoPa.Text.Trim();
            txtApellidoMa.Text = txtApellidoMa.Text.Trim();
            txtEdad.Text = txtEdad.Text.Trim();
            txtOcupacion.Text = txtOcupacion.Text.Trim();
        }
        private bool Validaciones()
        {
            QuitarEspacios();

            if (txtNombre.Text != string.Empty && txtApellidoPa.Text != string.Empty && txtApellidoMa.Text != string.Empty&&txtOcupacion.Text!=string.Empty)
            {
                if(int.TryParse(txtEdad.Text,out int num))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Pasajero p1 = new Pasajero(txtNombre.Text, txtApellidoPa.Text, txtApellidoMa.Text, int.Parse(txtEdad.Text), txtOcupacion.Text);
                LPasajero.AgregarPasajero(p1);
                this.Dispose();
                this.Close();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            CValidacionescs.SoloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
