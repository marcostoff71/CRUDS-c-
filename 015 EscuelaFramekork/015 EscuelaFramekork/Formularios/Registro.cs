using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _015_EscuelaFramekork.Modelos;
using _015_EscuelaFramekork.Logica;
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
            txtNombre.Text= pasa.Nombre;
            txtApellidoMa.Text=pasa.Apellido_Materno;
            txtApellidoPa.Text=pasa.Apellido_Paterno;
            txtEdadPasa.Text=pasa.Edad.ToString();
            txtOcupacionPasa.Text= pasa.Ocupacion;
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
            txtNombre.Text = p1.Nombre;
            txtApellidoMa.Text = p1.Apellido_Materno;
            txtApellidoPa.Text = p1.Apellido_Paterno;
            txtFechaNacimiento.Value = p1.Fecha_Nacimiento.Value;
            txtCurp.Text = p1.Curp;
            txtRfc.Text = p1.Rfc;
            txtTiempoVueloPi.Text = p1.Tiempo_De_Vuelo.ToString();
            txtTipoNavePi.Text = p1.Tipo_De_Nave;
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
            txtNombre.Text = a1.Nombre;
            txtApellidoMa.Text = a1.Apellido_Materno;
            txtApellidoPa.Text = a1.Apellido_Paterno;
            txtFechaNacimiento.Value = a1.Fecha_Nacimiento.Value;
            txtCurp.Text = a1.Curp;
            txtRfc.Text = a1.Rfc;
            txtNEmpleAdmin.Text = a1.Numero_Empleado.ToString();
            txtFechaInAdmin.Value = a1.Fecha_Ingreso.Value;
            txtAreaTrabaAdmin.Text = a1.Area_Trabajo;
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
            txtNombre.Text = d1.Nombre;
            txtApellidoMa.Text = d1.Apellido_Materno;
            txtApellidoPa.Text = d1.Apellido_Paterno;
            txtFechaNacimiento.Value = d1.Fecha_Nacimiento.Value;
            txtCurp.Text = d1.Curp;
            txtRfc.Text = d1.Rfc;
            txtNEmpleadoDirec.Text = d1.Numero_Empleado.ToString();
            txtFechaInDirec.Value = d1.Fecha_Ingreso.Value;
            txtProfesionDirec.Text = d1.Profesion;
            txtPuestoDirec.Text = d1.Profesion;
            txtCantidadEmDirec.Text = d1.Cantidad_Empleados.ToString();
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
                    LPasajero.AgregarPasajero(pasa);
                }
                else
                {
                    pasa.Id = this.pasa.Id;
                    LPasajero.ModificarPasajero(pasa);
                }
                this.Close();
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
        private void btnCancelarPi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarPi_Click(object sender, EventArgs e)
        {
            if (ValiPilo())
            {
                Piloto p1 = new Piloto();
                p1.Nombre = txtNombre.Text;
                p1.Apellido_Materno = txtApellidoMa.Text;
                p1.Apellido_Paterno = txtApellidoPa.Text;
                p1.Fecha_Nacimiento = txtFechaNacimiento.Value;
                p1.Curp = txtCurp.Text;
                p1.Rfc = txtRfc.Text;
                p1.Tiempo_De_Vuelo = double.Parse(txtTiempoVueloPi.Text);
                p1.Tipo_De_Nave = txtTipoNavePi.Text;
                if (pilo != null)
                {
                    p1.Id = pilo.Id;
                    LPiloto.ModificarPiloto(p1);
                }
                else
                {
                    LPiloto.AgregarPiloto(p1);
                }
                this.Close();
            }
        }
        #endregion

        #region Admin
        private bool ValidaAmin()
        {
            if (ValiEmple())
            {
                if (txtNEmpleAdmin.Text != "" &&int.TryParse(txtNEmpleAdmin.Text,out int num)&& txtAreaTrabaAdmin.Text != "")
                {
                    return true;
                }
            }
            return false;
        }
        private void btnGuardarAdmin_Click(object sender, EventArgs e)
        {
            if (ValidaAmin()) {
                Administrativo ad = new Administrativo();
                ad.Nombre = txtNombre.Text;
                ad.Apellido_Materno = txtApellidoMa.Text;
                ad.Apellido_Paterno = txtApellidoPa.Text;
                ad.Fecha_Nacimiento = txtFechaNacimiento.Value;
                ad.Curp = txtCurp.Text;
                ad.Rfc = txtRfc.Text;
                ad.Numero_Empleado = int.Parse(txtNEmpleAdmin.Text);
                ad.Fecha_Ingreso = txtFechaInAdmin.Value;
                ad.Area_Trabajo = txtAreaTrabaAdmin.Text;
                if (admin == null)
                {
                    LAdmin.AgregarAdmin(ad);
                }
                else
                {
                    ad.Id = admin.Id;
                    LAdmin.ModificarAdmin(ad);
                }
                this.Close();
            }
        }
        #endregion
        #region Direc
        private bool ValidaDire()
        {
            if (ValiEmple())
            {
                if(txtNEmpleadoDirec.Text!=""&&int.TryParse(txtNEmpleadoDirec.Text,out int num))
                {
                    if (txtProfesionDirec.Text != string.Empty&&txtPuestoDirec.Text!=string.Empty)
                    {
                        if(txtCantidadEmDirec.Text!=""&&int.TryParse(txtCantidadEmDirec.Text,out int num1))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void btnGuardarDirec_Click(object sender, EventArgs e)
        {
            if (ValidaDire())
            {
                Directivo d1 = new Directivo();
                d1.Nombre = txtNombre.Text;
                d1.Apellido_Materno = txtApellidoMa.Text;
                d1.Apellido_Paterno = txtApellidoPa.Text;
                d1.Fecha_Nacimiento = txtFechaNacimiento.Value;
                d1.Curp = txtCurp.Text;
                d1.Rfc = txtRfc.Text;
                d1.Numero_Empleado = int.Parse(txtNEmpleadoDirec.Text);
                d1.Fecha_Ingreso = txtFechaInDirec.Value;
                d1.Profesion = txtProfesionDirec.Text;
                d1.Puesto = txtPuestoDirec.Text;
                d1.Cantidad_Empleados = int.Parse(txtCantidadEmDirec.Text);
                if (direc != null)
                {
                    d1.Id = direc.Id;
                    LDirec.ModificarDirec(d1);
                }
                else
                {
                    LDirec.AgregarDire(d1);
                }
                this.Close();
            }
                   
        }
        #endregion
    }
}
