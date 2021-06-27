using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _018_CrudWfvValidado.Logica;
using _018_CrudWfvValidado.Modelos;
namespace _018_CrudWfvValidado.Formularios
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private int _id;
        private IServiciosPersona acceso;
        public Registro(int id=0)
        {
            InitializeComponent();
            acceso = new ServiciosPersona();
            this._id = id;
            if (id > 0)
            {
                CargarPersona(id);
            }
        }
        #region carga
        private async void CargarPersona(int id)
        {
            Persona oPersona = await this.acceso.ObtenerPorId(id);
            if (oPersona == null)
            {
                MessageBox.Show("El registro ya no existe");
                this.Close();
            }
            else
            {
                txtNombre.Text = oPersona.Nombre;
                txtApMaterno.Text = oPersona.ApMaterno;
                txtApPaterno.Text = oPersona.ApPaterno;
            }
        }
        #endregion

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidaPersona())
            {
                Persona persona = new Persona();
                persona.Nombre = txtNombre.Text;
                persona.ApMaterno = txtApMaterno.Text;
                persona.ApPaterno = txtApPaterno.Text;
                persona.Id = this._id != 0 ? this._id : 0;
                bool re= await this.acceso.Guardar(persona);

                this.Close();
            }
        }

        private bool ValidaPersona()
        {
            void QuitaEspacios(ref TextBox textbox)
            {
                textbox.Text = textbox.Text.Trim();
            }
            QuitaEspacios(ref txtNombre);
            QuitaEspacios(ref txtApMaterno);
            QuitaEspacios(ref txtApPaterno);

            if (!string.IsNullOrEmpty(txtNombre.Text)&&!string.IsNullOrEmpty(txtApMaterno.Text)&&!string.IsNullOrEmpty(txtApPaterno.Text))
            {
                return true;
            }

            return false;
        }
    }
}
