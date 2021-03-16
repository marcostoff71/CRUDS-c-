using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _0080_CRUDSQL.Modelos;
using _0080_CRUDSQL.Logica;

namespace _0080_CRUDSQL.Formularios
{
    public partial class Registro : Form
    {
        int? indice;
        public Registro(int? id =null)
        {
            InitializeComponent();
            indice = id;
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        public bool Validaciones()
        {
            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Persona p1 = new Persona();
                p1.Nombre = txtNombre.Text;
                p1.ApellidoPa = txtApellidoPa.Text;
                p1.ApellidoMa = txtApellidoMa.Text;
                p1.Cumpleanios = dtCumple.Value;
                p1.Edad = int.Parse(txtEdad.Text);
                if (indice == null)
                {
                    AccesoBd.Agregar(p1);
                }
                else
                {
                    p1.Id = (int)this.indice;
                    AccesoBd.Modifcar(p1);
                }
                this.Close();
                
            }
        }
        public void CargarCampos(int id)
        {
            gBRegistro.Text = "Modificar";
            Persona p1 = AccesoBd.ObternerPersona(id);
            txtNombre.Text = p1.Nombre;
            txtApellidoPa.Text = p1.ApellidoPa;
            txtApellidoMa.Text = p1.ApellidoMa;
            dtCumple.Value = p1.Cumpleanios;
            txtEdad.Text = p1.Edad.ToString();
        }
    }
}
