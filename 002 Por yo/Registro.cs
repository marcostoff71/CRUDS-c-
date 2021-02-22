using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _002_Por_yo.Mdelos;

namespace _002_Por_yo
{
    public partial class Registro : Form
    {
        private CMnu capa1 = new CMnu();//clase de acceso a la base de datos
        Persona aux = new Persona();
        Cvalidaciones vali1 = new Cvalidaciones();
        public Registro()
        {
            InitializeComponent();
        }
        #region validaciones
        public bool Validaciones()
        {
            bool aceptado=false;
            if (txtNombre.Text.Trim() != "") 
            {
                if (txtEdad.Text.Trim() != ""&&vali1.esNum(txtEdad.Text)&&int.Parse(txtEdad.Text.Trim())>0)
                { 
                    aceptado = true;
                }
                else
                {
                    MessageBox.Show("Ingresa una edad valida", "Edad Invalida");
                }
            }
            else { MessageBox.Show("Ingresa un nombre", "Error Nomrbe"); }
            return aceptado;
        }
        #endregion
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Persona aux1 = new Persona();
                aux1.Edad = int.Parse(txtEdad.Text.Trim());
                aux1.Nombre = txtNombre.Text.Trim();
                if (aux == null)aux1.Id = 0;
                else aux1.Id = aux.Id;


                capa1.Agregar(aux1);
                this.Close();
            }
        }
        public void ObtenerPersona(Persona p1)
        {
            aux = p1;
            if (p1 != null) { 
            txtEdad.Text = p1.Edad.ToString().Trim();
            txtNombre.Text = p1.Nombre.Trim();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali1.ValidaNum(e);
        }
    }
}
