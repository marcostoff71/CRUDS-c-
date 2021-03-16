using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Logica;

namespace WindowsFormsApp1.Formularios
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            txtNumeroC.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtEdad.Text = string.Empty;
            cbSexo.SelectedIndex = -1;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }
        private void QuitarEspacios()
        {
            txtNumeroC.Text = txtNumeroC.Text.Trim();
            txtNombre.Text = txtNombre.Text.Trim();
            txtApellidoM.Text = txtApellidoM.Text.Trim();
            txtApellidoP.Text = txtApellidoP.Text.Trim();
            txtEdad.Text = txtEdad.Text.Trim();
            txtTelefono.Text = txtTelefono.Text.Trim();
            txtDireccion.Text = txtDireccion.Text.Trim();
        }
        private bool Validaciones()
        {
            bool valor = false;
            if (txtNumeroC.Text != "")
            {
                if (txtApellidoP.Text != "")
                {
                    if (txtApellidoM.Text != "")
                    {
                        if (txtEdad.Text != "")
                        {
                            if (cbSexo.SelectedIndex >= 0)
                            {
                                if (txtTelefono.Text != "")
                                {
                                    if (txtDireccion.Text != "")
                                    {
                                        valor = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return valor;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            QuitarEspacios();
            if (Validaciones())
            {
                Agregar();
                MessageBox.Show("Agregado con exito");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellene los espacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void Agregar()
        {
            Alumno a1 = new Alumno();
            a1.NumControl = int.Parse(txtNumeroC.Text);
            a1.Nombre = txtNombre.Text;
            a1.AppellidoP = txtApellidoP.Text;
            a1.AppellidoM = txtApellidoM.Text;
            a1.Edad = int.Parse(txtEdad.Text);
            a1.Sexo = cbSexo.Items[cbSexo.SelectedIndex].ToString();
            a1.Telefono = txtTelefono.Text;
            a1.Direccion = txtDireccion.Text;

            Acceso.AgregarAlumno(a1);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cvalidaciones.SoloNumeros(e);
        }

        private void txtNumeroC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cvalidaciones.SoloNumeros(e);
        }
    }
}
