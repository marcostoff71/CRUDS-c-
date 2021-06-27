using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _019_CrudDapper.Modelos.ModelosView;
using _019_CrudDapper.Modelos;
using _019_CrudDapper.Logica;


namespace _019_CrudDapper.Formularios
{
    public partial  class FrmRegistro : Form
    {
        private readonly IServicesPersona acceso;
        private int id;
        public  FrmRegistro(int id = 0)
        {
            this.id = id;
            acceso = new ServicesPersona();
            InitializeComponent();
            if (id != 0)
            {
                CargarPersona(id).Wait();
            }
        }

        private void QuitaEspacios(TextBox t)
        {
            t.Text = t.Text.Trim();
        }
        private bool ValidacionesCampos()
        {
            bool correcto = false;
            QuitaEspacios(txtNombre);
            QuitaEspacios(txtApPaterno);
            QuitaEspacios(txtApMaterno);

            if(!string.IsNullOrEmpty(txtNombre.Text)
                &&!string.IsNullOrEmpty(txtApMaterno.Text)
                &&!string.IsNullOrEmpty(txtApPaterno.Text))
            {
                correcto = true;
            }


            return correcto;

        }
        private async Task CargarPersona(int id)
        {
            Persona oPersona = await acceso.ObtenerPorId(id);
            if (oPersona == null)
            {
                MessageBox.Show("El registro que intentas modificar ya no existe");
                this.Close();
            }
            else
            {
                txtNombre.Text = oPersona.Nombre;
                txtApMaterno.Text = oPersona.ApMaterno;
                txtApPaterno.Text = oPersona.ApPaterno;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidacionesCampos())
            {
                Persona oPersona = new Persona();
                oPersona.Nombre = txtNombre.Text;
                oPersona.ApPaterno = txtApPaterno.Text;
                oPersona.ApMaterno = txtApMaterno.Text;

                if (this.id != 0)
                {
                    oPersona.Id = this.id;
                }
                else
                {
                    oPersona.Id = 0;

                }
                //oPersona.Id = this.id == 0 ? 0 : this.id;

                await acceso.Agregar(oPersona);
            }
        }
    }
}
