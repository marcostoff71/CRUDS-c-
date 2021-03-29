using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;
using System.Windows.Forms;

namespace _015_EscuelaFramekork.Formularios
{
    public partial class Registro : Form
    {
        Pasajero pasa = null;
        Administrativo admin = null;
        Piloto pilo = null;
        Directivo direc = null;
        public Registro(string datos="")
        {
            InitializeComponent();
        }

        #region CargaDatos
        //private void CargarRegistro(string datos)
        //{
        //    switch (datos)
        //    {
        //        case "Pasajero":
        //            break;
        //        case "Piloto":
        //            break;
        //        case "Administrativo":
        //            break;
        //        case "Directivo":

        //            break;
        //    }
        //}
        public void CargarPasa(Pasajero p1) {
            pasa = p1;
            CamposPasa();
        }
        public void CamposPasa()
        {
            //empleado
            txtFechaNacimiento.Enabled = false;
            txtCurp.Enabled = false;
            txtRfc.Enabled = false;
            //------
            //piloto
            txtTiempoVueloPi.Enabled = false;
            txtTipoNavePi.Enabled = false;
            btnGuardarPi.Enabled = false;
            btnCancelarPi.Enabled = false;
            //----
            //admini
            txtNEmpleAdmin.Enabled = false;
            txtFechaInAdmin.Enabled = false;
            txtAreaTrabaAdmin.Enabled = false;
            btnGuardarAdmin.Enabled = false;
            btnCancelarAdmin.Enabled = false;
            //----
            //direc
            txtNEmpleadoDirec.Enabled = false;
            txtFechaInDirec.Enabled = false;
            txtProfesionDirec.Enabled = false;
            txtPuestoDirec.Enabled = false;
            txtCantidadEmDirec.Enabled = false;
            btnGuardarDirec.Enabled = false;
            btnCancelarDirec.Enabled = false;
            //----
        }
        public void CargarPilo(Piloto p1) {

            pilo = p1;
            CamposPilo();
        }
        public void CamposPilo()
        {
            //Pasajero

            txtEdadPasa.Enabled = false;
            txtOcupacionPasa.Enabled = false;
            btnGuardarPasa.Enabled = false;
            btnCancelarPasa.Enabled = false;
            //empleado

            //------
            //piloto

            //----
            //admini
            txtNEmpleAdmin.Enabled = false;
            txtFechaInAdmin.Enabled = false;
            txtAreaTrabaAdmin.Enabled = false;
            btnGuardarAdmin.Enabled = false;
            btnCancelarAdmin.Enabled = false;
            //----
            //direc
            txtNEmpleadoDirec.Enabled = false;
            txtFechaInDirec.Enabled = false;
            txtProfesionDirec.Enabled = false;
            txtPuestoDirec.Enabled = false;
            txtCantidadEmDirec.Enabled = false;
            btnGuardarDirec.Enabled = false;
            btnCancelarDirec.Enabled = false;
            //----



            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 0;
        }
        public void CargarAdmin(Administrativo a1)
        {
            admin = a1;
            CamposAdmin();
        }
        public void CamposAdmin()
        {
            //Pasajero

            txtEdadPasa.Enabled = false;
            txtOcupacionPasa.Enabled = false;
            btnGuardarPasa.Enabled = false;
            btnCancelarPasa.Enabled = false;

            //-----------
            //empleado
            
            //------
            //piloto
            txtTiempoVueloPi.Enabled = false;
            txtTipoNavePi.Enabled = false;
            btnGuardarPi.Enabled = false;
            btnCancelarPi.Enabled = false;
            //----
            //admini
            
            //----
            //direc
            txtNEmpleadoDirec.Enabled = false;
            txtFechaInDirec.Enabled = false;
            txtProfesionDirec.Enabled = false;
            txtPuestoDirec.Enabled = false;
            txtCantidadEmDirec.Enabled = false;
            btnGuardarDirec.Enabled = false;
            btnCancelarDirec.Enabled = false;
            //----
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 1;
        }
        public void CargarDirec(Directivo d1)
        {
            direc = d1;
            CamposDirec();
        }
        public void CamposDirec()
        {
            //Pasajero

            txtEdadPasa.Enabled = false;
            txtOcupacionPasa.Enabled = false;
            btnGuardarPasa.Enabled = false;
            btnCancelarPasa.Enabled = false;

            //-----------
            //empleado

            //------
            //piloto
            txtTiempoVueloPi.Enabled = false;
            txtTipoNavePi.Enabled = false;
            btnGuardarPi.Enabled = false;
            btnCancelarPi.Enabled = false;
            //----
            //admini
            txtNEmpleAdmin.Enabled = false;
            txtFechaInAdmin.Enabled = false;
            txtAreaTrabaAdmin.Enabled = false;
            btnGuardarAdmin.Enabled = false;
            btnCancelarAdmin.Enabled = false;
            //----
            //direc
            
            //----
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 2;
        }
        #endregion
        private void Registro_Load(object sender, EventArgs e)
        {

        }
        #region Util
        private void TrimTodo()
        {
            //Nombre
            QuitarEspacios(ref txtNombre);
            QuitarEspacios(ref txtApellidoMa);
            QuitarEspacios(ref txtApellidoPa);
            //--
            //pasa
            QuitarEspacios(ref txtEdadPasa);
            QuitarEspacios(ref txtOcupacionPasa);

            //empleado
            QuitarEspacios(ref txtCurp);
            QuitarEspacios(ref txtCurp);

            //piloto;
            QuitarEspacios(ref txtTiempoVueloPi);
            QuitarEspacios(ref txtTipoNavePi);

            //admin
            QuitarEspacios(ref txtNEmpleAdmin);
            QuitarEspacios(ref txtAreaTrabaAdmin);

            //direc
            QuitarEspacios(ref txtNEmpleadoDirec);
            QuitarEspacios(ref txtProfesionDirec);
            QuitarEspacios(ref txtPuestoDirec);
            QuitarEspacios(ref txtCantidadEmDirec);

        }
        private void QuitarEspacios(ref TextBox text)
        {
            text.Text = text.Text.Trim();
        }
        #endregion
        #region Validaciones
        private bool ValiNom()
        {
            TrimTodo();
            if (txtNombre.Text != ""&&txtApellidoMa.Text!=""&&txtApellidoPa.Text!="")
            {
                return true;
            }
            return false;
        }
        private bool ValiEmple()
        {
            if (ValiNom())
            {
                if (txtCurp.Text != "" && txtRfc.Text != "")
                {
                    return true;
                }
            }
            return false;
        }


        #endregion
        //GuardarD Datos de Pasajero y modifica
        #region Pasajero
        private bool ValiPasa()
        {
            if (ValiNom())
            {
                if (txtEdadPasa.Text != "" && int.TryParse(txtEdadPasa.Text, out int num))
                {
                    if (txtOcupacionPasa.Text != "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnGuardarPasa_Click(object sender, EventArgs e)
        {
            if (ValiPasa())
            {
                Pasajero pasa = new Pasajero();
                pasa.Nombre = txtNombre.Text;
                pasa.Apellido_Materno = txtApellidoMa.Text;
                pasa.Apellido_Paterno = txtApellidoPa.Text;
                pasa.Edad = int.Parse(txtEdadPasa.Text);
                pasa.Ocupacion = txtOcupacionPasa.Text;
                if (this.pasa == null)
                {

                }
                else
                {
                    pasa.Id = this.pasa.Id;
                }
            }
        }
        private void btnCancelarPasa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Piloto
        private bool ValiPilo()
        {
            if (ValiEmple())
            {
               if(txtTiempoVueloPi.Text!=""&&float.TryParse(txtTiempoVueloPi.Text,out float num))
                {
                    if (txtTipoNavePi.Text != string.Empty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

    }
}
