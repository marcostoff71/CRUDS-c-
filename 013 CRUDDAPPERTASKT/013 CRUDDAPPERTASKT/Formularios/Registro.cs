using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _013_CRUDDAPPERTASKT.Modelos;
using _013_CRUDDAPPERTASKT.Logica;

namespace _013_CRUDDAPPERTASKT.Formularios
{
    public partial class Registro : Form
    {
        private int? id = null;
        private CapaNegocios acceso = new CapaNegocios();

        public Registro(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }


        private void Limpiar()
        {
            txtNombre.Clear();
            txtApeMa.Clear();
            txtApePa.Clear();
            txtEdad.Clear();
            dtCumple.Value = DateTime.Now;
            txtSexo.SelectedIndex = -1;
        }
        private bool Validaciones()
        {
            TrimTodo();
            if (txtNombre.Text != "" && txtApePa.Text != "" && txtApeMa.Text != "")
            {
                if (txtEdad.Text != "" && Util.EsNumInt(txtEdad.Text))
                {
                    if (txtSexo.SelectedIndex >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void TrimTodo()
        {
            Util.BorrarEspacios(ref txtNombre);
            Util.BorrarEspacios(ref txtApeMa);
            Util.BorrarEspacios(ref txtApePa);
            Util.BorrarEspacios(ref txtEdad);
            
        }
        private async void CargarCampos(int id)
        {
            Persona p1 = await acceso.ObtenerPersonasId(id);
            txtNombre.Text =    
            txtApeMa.Text = p1.Apellido_Materno;
            txtApePa.Text = p1.Apellido_Paterno;
            txtEdad.Text = p1.Edad.ToString();
            dtCumple.Value = p1.Cumpleaños;
            if (p1.Sexo == "Hombre") txtSexo.SelectedIndex = 0;
            else if (p1.Sexo == "Mujer") txtSexo.SelectedIndex = 1;
            else if (p1.Sexo == "Otro") txtSexo.SelectedIndex = 2;
            
        }
        private void Registro_Load(object sender, EventArgs e)
        {
            if (this.id != null)
            {
                CargarCampos((int)id);
            }
        }
        private async void AgregarModifi()
        {
            Persona per = new Persona();
            per.Nombre = txtNombre.Text;
            per.Apellido_Materno = txtApeMa.Text;
            per.Apellido_Paterno = txtApePa.Text;
            per.Edad = int.Parse(txtEdad.Text);
            per.Cumpleaños = dtCumple.Value;
            per.Sexo = txtSexo.Text;

            if (this.id != null) per.Id = (int)this.id;

            await acceso.AgregarPersona(per);

            if (this.id == null)
                MessageBox.Show("Agregado Corctamente");
            else MessageBox.Show("Modificado correctamente");

            this.Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                AgregarModifi();
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumeros(e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
