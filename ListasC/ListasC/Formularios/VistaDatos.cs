using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListasC.Logica;
using ListasC.Formularios;
using ListasC.Modelos;

namespace ListasC.Formularios
{
    public partial class VistaDatos : UserControl
    {
        private string NomObjeto;
        DataGridViewLinkColumn EditarData;
        DataGridViewLinkColumn EliminarData;
        
        private void InicarEditarEliminar()
        {
            EditarData = new DataGridViewLinkColumn();
            EditarData.DataPropertyName = "Editar";
            EditarData.Text = "Editar";
            EditarData.HeaderText = "Editar";
            EditarData.UseColumnTextForLinkValue = true;

            EliminarData = new DataGridViewLinkColumn();
            EliminarData.DataPropertyName = "Eliminar";
            EliminarData.Text = "Eliminar";
            EliminarData.HeaderText = "Eliminar";
            EliminarData.UseColumnTextForLinkValue = true;
        }
        public VistaDatos(string datos)
        {
            InitializeComponent();
            InicarEditarEliminar();
            this.NomObjeto = datos;
        }

        public void CargarDatos(string datos)
        {
            NomObjeto = datos;
            if (datos == "Pasajero")
            {
                CargarPasajeros();
            }
            else if (datos == "Empleado")
            {
                CargarEmpleado();
            }
            else if (datos == "Piloto")
            {
                CargarPilotos();
            }
            else if (datos == "Administrativo")
            {
                CargarAdimistrativos();
            }
            else if (datos == "Directivo")
            {
                CargarDirectivo();
            }
            
        }

        #region Pasajero
        public void CargarPasajeros()
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            nombre.DataPropertyName = "Nombre";
            nombre.Name = "NombreData";

            DataGridViewTextBoxColumn apellidoPa = new DataGridViewTextBoxColumn();
            apellidoPa.HeaderText = "Apellido Paterno";
            apellidoPa.DataPropertyName = "ApellidoPa";
            apellidoPa.Name = "ApellidoPaData";

            DataGridViewTextBoxColumn apellidoMa = new DataGridViewTextBoxColumn();
            apellidoMa.HeaderText = "Apellido Materno";
            apellidoMa.DataPropertyName = "ApellidoMa";
            apellidoMa.Name = "ApellidoMaData";
            apellidoMa.ReadOnly = true;

            DataGridViewTextBoxColumn edad = new DataGridViewTextBoxColumn();
            edad.DataPropertyName = "Edad";
            edad.HeaderText = "Edad";
            edad.Name = "EdadData";

            DataGridViewTextBoxColumn ocupacion = new DataGridViewTextBoxColumn();
            ocupacion.DataPropertyName = "Ocupacion";
            ocupacion.HeaderText = "Ocupacion";
            ocupacion.Name = "OcupacionData";


            dgDatosPersonas.Columns.Clear();
            dgDatosPersonas.Columns.AddRange(new DataGridViewColumn[] { nombre, apellidoPa, apellidoMa, edad, ocupacion, EditarData, EliminarData });


        }
        private void RefrescarPasajeros()
        {
            if (LPasajero.obtenerPasajeros().Count > 0)
            {
                dgDatosPersonas.DataSource = null;
                dgDatosPersonas.DataSource = LPasajero.obtenerPasajeros();
            }

        }
        private void AgregarPasajero()
        {
            RegistroPasa p1 = new RegistroPasa();
            p1.ShowDialog();
            RefrescarPasajeros();
        }
        #endregion
        #region Empleado
        public void CargarEmpleado()
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            nombre.DataPropertyName = "Nombre";
            nombre.Name = "NombreData";
            DataGridViewTextBoxColumn apellidoPa = new DataGridViewTextBoxColumn();
            apellidoPa.HeaderText = "Apellido Paterno";
            apellidoPa.DataPropertyName = "ApellidoPa";
            apellidoPa.Name = "ApellidoPaData";
            DataGridViewTextBoxColumn apellidoMa = new DataGridViewTextBoxColumn();
            apellidoMa.HeaderText = "Apellido Materno";
            apellidoMa.DataPropertyName = "ApellidoMa";
            apellidoMa.Name = "ApellidoMaData";
            DataGridViewTextBoxColumn fechaNacimineto = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha de nacimiento";
            fechaNacimineto.Name = "FechaNacimientoData";
            fechaNacimineto.DataPropertyName = "FechaNacimiento";
            DataGridViewTextBoxColumn curp = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Curp";
            fechaNacimineto.Name = "curpData";
            fechaNacimineto.DataPropertyName = "Curp";
            DataGridViewTextBoxColumn rfc = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Rfc";
            fechaNacimineto.Name = "RfcData";
            fechaNacimineto.DataPropertyName = "Rfc";

            dgDatosPersonas.Columns.AddRange(nombre, apellidoPa, apellidoMa, fechaNacimineto, curp, rfc, EditarData, EliminarData);

            RefrescarEmpleados();
        }
        private void RefrescarEmpleados()
        {
            dgDatosPersonas.DataSource = null;
            dgDatosPersonas.DataSource = LEmpleado.obtenerEmpleados();
        }
        #endregion
        #region Piloto
        public void CargarPilotos()
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            nombre.DataPropertyName = "Nombre";
            nombre.Name = "NombreData";
            DataGridViewTextBoxColumn apellidoPa = new DataGridViewTextBoxColumn();
            apellidoPa.HeaderText = "Apellido Paterno";
            apellidoPa.DataPropertyName = "ApellidoPa";
            apellidoPa.Name = "ApellidoPaData";
            DataGridViewTextBoxColumn apellidoMa = new DataGridViewTextBoxColumn();
            apellidoMa.HeaderText = "Apellido Materno";
            apellidoMa.DataPropertyName = "ApellidoMa";
            apellidoMa.Name = "ApellidoMaData";
            DataGridViewTextBoxColumn fechaNacimineto = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha de nacimiento";
            fechaNacimineto.Name = "FechaNacimientoData";
            fechaNacimineto.DataPropertyName = "FechaNacimiento";
            DataGridViewTextBoxColumn curp = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Curp";
            fechaNacimineto.Name = "curpData";
            fechaNacimineto.DataPropertyName = "Curp";
            DataGridViewTextBoxColumn rfc = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Rfc";
            fechaNacimineto.Name = "RfcData";
            fechaNacimineto.DataPropertyName = "Rfc";
            DataGridViewTextBoxColumn tiempoDeVuelo = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Tiempo de vuelo";
            fechaNacimineto.Name = "TiempoDeVueloData";
            fechaNacimineto.DataPropertyName = "TiempoDeVuelo";
            DataGridViewTextBoxColumn tipoDeNave = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Tipo de nave";
            fechaNacimineto.Name = "TipoDeNave";
            fechaNacimineto.DataPropertyName = "TipoDeNave";

            dgDatosPersonas.Columns.AddRange(nombre, apellidoPa, apellidoMa, fechaNacimineto, curp, rfc, tiempoDeVuelo, tipoDeNave);
            RefrescarPilotos();

        }
        public void RefrescarPilotos()
        {
            dgDatosPersonas.DataSource = null;
            dgDatosPersonas.DataSource = LPiloto.obtenerPilotos();
        }
        #endregion
        #region Administrativo
        public void CargarAdimistrativos()
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            nombre.DataPropertyName = "Nombre";
            nombre.Name = "NombreData";
            DataGridViewTextBoxColumn apellidoPa = new DataGridViewTextBoxColumn();
            apellidoPa.HeaderText = "Apellido Paterno";
            apellidoPa.DataPropertyName = "ApellidoPa";
            apellidoPa.Name = "ApellidoPaData";
            DataGridViewTextBoxColumn apellidoMa = new DataGridViewTextBoxColumn();
            apellidoMa.HeaderText = "Apellido Materno";
            apellidoMa.DataPropertyName = "ApellidoMa";
            apellidoMa.Name = "ApellidoMaData";
            DataGridViewTextBoxColumn fechaNacimineto = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha de nacimiento";
            fechaNacimineto.Name = "FechaNacimientoData";
            fechaNacimineto.DataPropertyName = "FechaNacimiento";
            DataGridViewTextBoxColumn curp = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Curp";
            fechaNacimineto.Name = "curpData";
            fechaNacimineto.DataPropertyName = "Curp";
            DataGridViewTextBoxColumn rfc = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Rfc";
            fechaNacimineto.Name = "RfcData";
            fechaNacimineto.DataPropertyName = "Rfc";
            DataGridViewTextBoxColumn numeroDeEmpleado = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Numero de empleado";
            fechaNacimineto.Name = "NumeroDeEmpleadoData";
            fechaNacimineto.DataPropertyName = "NumeroDeEmpleado";
            DataGridViewTextBoxColumn fechaDeIngreso = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha De Ingreso";
            fechaNacimineto.Name = "FechaDeIngresoData";
            fechaNacimineto.DataPropertyName = "FechaDeIngreso";
            DataGridViewTextBoxColumn areaDeTrabajo = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Area de trabajo";
            fechaNacimineto.Name = "AreaDeTrabajoData";
            fechaNacimineto.DataPropertyName = "AreaDeTrabajoData";
            dgDatosPersonas.Columns.AddRange(nombre, apellidoPa, apellidoMa, fechaNacimineto, curp, rfc, numeroDeEmpleado, fechaDeIngreso, areaDeTrabajo);
            RefrescarAdministrativo();
        }
        public void RefrescarAdministrativo()
        {
            dgDatosPersonas.DataSource = null;
            dgDatosPersonas.DataSource = LAdministrativo.obtenerAdministrativos();
        }
        #endregion
        #region Directivo
        public void CargarDirectivo()
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            nombre.DataPropertyName = "Nombre";
            nombre.Name = "NombreData";
            DataGridViewTextBoxColumn apellidoPa = new DataGridViewTextBoxColumn();
            apellidoPa.HeaderText = "Apellido Paterno";
            apellidoPa.DataPropertyName = "ApellidoPa";
            apellidoPa.Name = "ApellidoPaData";
            DataGridViewTextBoxColumn apellidoMa = new DataGridViewTextBoxColumn();
            apellidoMa.HeaderText = "Apellido Materno";
            apellidoMa.DataPropertyName = "ApellidoMa";
            apellidoMa.Name = "ApellidoMaData";
            DataGridViewTextBoxColumn fechaNacimineto = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha de nacimiento";
            fechaNacimineto.Name = "FechaNacimientoData";
            fechaNacimineto.DataPropertyName = "FechaNacimiento";
            DataGridViewTextBoxColumn curp = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Curp";
            fechaNacimineto.Name = "curpData";
            fechaNacimineto.DataPropertyName = "Curp";
            DataGridViewTextBoxColumn rfc = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Rfc";
            fechaNacimineto.Name = "RfcData";
            fechaNacimineto.DataPropertyName = "Rfc";
            DataGridViewTextBoxColumn numeroDeEmpleado = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Numero de empleado";
            fechaNacimineto.Name = "NumeroDeEmpleadoData";
            fechaNacimineto.DataPropertyName = "NumeroDeEmpleado";
            DataGridViewTextBoxColumn fechaDeIngreso = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Fecha De Ingreso";
            fechaNacimineto.Name = "FechaDeIngresoData";
            fechaNacimineto.DataPropertyName = "FechaDeIngreso";
            DataGridViewTextBoxColumn profesion = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Profesion";
            fechaNacimineto.Name = "ProfesionData";
            fechaNacimineto.DataPropertyName = "Profesion";
            DataGridViewTextBoxColumn puesto = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Puesto";
            fechaNacimineto.Name = "PuestoData";
            fechaNacimineto.DataPropertyName = "Puesto";
            DataGridViewTextBoxColumn cantidadDeEmpleados = new DataGridViewTextBoxColumn();
            fechaNacimineto.HeaderText = "Cantidad de empleados";
            fechaNacimineto.Name = "CantidadDeEmpleadosData";
            fechaNacimineto.DataPropertyName = "CantidadDeEmpleados";
            dgDatosPersonas.Columns.AddRange(nombre, apellidoPa, apellidoMa, fechaNacimineto, curp, rfc, numeroDeEmpleado, fechaDeIngreso, profesion, puesto, cantidadDeEmpleados, EditarData, EliminarData);
            // RefrescarDirectivos();

        }
        public void RefrescarDirectivos()
        {
            dgDatosPersonas.DataSource = null;
            dgDatosPersonas.DataSource = LDirectivo.ObtenerDirectivos();
        }
        #endregion
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPasajero();
            RefrescarPasajeros();
        }

        private void VistaDatos_Load(object sender, EventArgs e)
        {
            switch (NomObjeto)
            {
                case "Pasajero":
                    CargarPasajeros();
                    break;
                case "Empleado":
                    CargarEmpleado();
                    break;
                case "Piloto":
                    CargarPilotos();
                    break;
                case "Administrativo":
                    CargarAdimistrativos();
                    break;
                case "Directivo":
                    CargarDirectivo();
                    break;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            switch (NomObjeto)
            {
                case "Pasajero":
                    RefrescarPasajeros();
                    break;
                case "Empleado":
                    RefrescarEmpleados();
                    break;
                case "Piloto":
                    RefrescarPilotos();
                    break;
                case "Administrativo":
                    RefrescarAdministrativo();
                    break;
                case "Directivo":
                    RefrescarDirectivos();
                    break;
            }
        }
    }
}
