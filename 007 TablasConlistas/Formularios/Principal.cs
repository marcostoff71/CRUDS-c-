using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _007_TablasConlistas.Modelos;
using _007_TablasConlistas.Logica;


namespace _007_TablasConlistas.Formularios
{
    public partial class Principal : Form
    {
        
        int? indiceEditarPasa = null;
        int? indicePasa = null;
        public Principal()
        {
            InitializeComponent();
        }
        #region Pasajero
        private void RefrescarPasa()
        {
            dgDatosPasajeros.DataSource = null;
            dgDatosPasajeros.DataSource = AccesoBd.MostrarPasajeros();
        }
        private bool ValicacionesPa()
        {
            bool valor = false;
            if (txtNombrePasa.Text.Trim()!="")
            {
                if (txtApelliPaPasa.Text.Trim() != "")
                {
                    if (txtApelliMaPasa.Text.Trim() != "")
                    {
                        if (txtEdadPasa.Text != ""&&int.TryParse(txtEdadPasa.Text.Trim(),out int n))
                        {
                            if (txtOcupacionPasa.Text.Trim() != "")
                            {
                                valor = true;
                            }

                        }
                    }

                }
            }
            return valor;
        }
        private void btnAceptarPa_Click(object sender, EventArgs e)
        {
            Pasajero p1 = new Pasajero();
            if (ValicacionesPa())
            {
                p1.NombrePa = txtNombrePasa.Text.Trim();
                p1.ApellidoMaPa = txtApelliPaPasa.Text.Trim();
                p1.ApellidoPatPa = txtApelliMaPasa.Text.Trim();
                p1.EdadPa = byte.Parse(txtEdadPasa.Text.Trim());
                p1.OcupacionPa = txtOcupacionPasa.Text.Trim();
                if (indiceEditarPasa != null)
                {
                    AccesoBd.EditarPasajeros(p1, (int)indiceEditarPasa);
                    indiceEditarPasa = null;
                }
                else
                {
                    AccesoBd.AgregarPasajeros(p1);
                }
                
                
                RefrescarPasa();
                LimpiarPasa();
            }
            else
            {
                MessageBox.Show("Porfavor llena las campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRefrescarpa_Click(object sender, EventArgs e)
        {
            RefrescarPasa();
        }
        private void LimpiarPasa()
        {
            txtNombrePasa.Text = string.Empty;
            txtApelliPaPasa.Text = string.Empty;
            txtApelliMaPasa.Text = string.Empty;
            txtEdadPasa.Text = string.Empty;
            txtOcupacionPasa.Text = string.Empty;
        }
        private void dgDatosPasajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    indiceEditarPasa = dgDatosPasajeros.Rows[e.RowIndex].Index;
                    EditarPasajero((int)indiceEditarPasa);
                    
                }
            }
        }
        private void EditarPasajero(int indice)
        {
            Pasajero p1= AccesoBd.ObterPorIndice(indice);

            txtNombrePasa.Text = p1.NombrePa;
            txtApelliPaPasa.Text = p1.ApellidoPatPa;
            txtApelliMaPasa.Text = p1.ApellidoMaPa;
            txtEdadPasa.Text = p1.EdadPa.ToString();
            txtOcupacionPasa.Text = p1.OcupacionPa;

        }
        private void dgDatosPasajeros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    indiceEditarPasa = dgDatosPasajeros.Rows[e.RowIndex].Index;

                }
            }
        }
        private void BtnEliminarPasa_Click(object sender, EventArgs e)
        {
            if (indicePasa == null)
            {
                MessageBox.Show("Selecciona una fila");

            }
            else
            {
                AccesoBd.EliminarPasajerps((int)indicePasa);
                RefrescarPasa();
                indicePasa = null;
            }
        }
        #endregion

        #region Piloto
        private bool ValicacionesPiloto()
        {
            return true;
        }
        private void btnAgregarPi_Click(object sender, EventArgs e)
        {
            if (ValicacionesPiloto())
            {
                Piloto p1 = new Piloto();
                p1.NombrePi = txtNombrePi.Text.Trim();
                p1.ApellidoPaPi = txtApellidoPaPi.Text.Trim();
                p1.ApellidoMaPi = txtApellidoMaPi.Text.Trim();
                p1.FechaDeNaciPi = tmFechaNaciPi.Value;
                p1.CurpPi = txtCurpPi.Text.Trim();
                p1.RfcPi = txtCurpPi.Text.Trim();
                p1.TiempoVueloPi = long.Parse(txtTiempoVueloPi.Text.Trim());
                p1.TiposNavPiloteadasPi = txtTiNavPiloPi.Text.Trim();

                AccesoBd.AgregarPilotos(p1);
                RefrescarPiloto();
                LimpiarPiloto();
            }
        }
        private void RefrescarPiloto()
        {
            dgDatosPi.DataSource = null;
            dgDatosPi.DataSource = AccesoBd.MostrarPilotos();
        }

        private void LimpiarPiloto()
        {
            txtNombrePi.Text = string.Empty;
            txtApellidoPaPi.Text = string.Empty;
            txtApellidoMaPi.Text = string.Empty;
            tmFechaNaciPi.Value = DateTime.Now;
            txtCurpPi.Text = string.Empty;
            txtRfcPi.Text = string.Empty;
            txtTiempoVueloPi.Text = string.Empty;
            txtTiNavPiloPi.Text = string.Empty;
        }
        #endregion

        #region Admin

        private bool ValidacionesAdmin()
        {
            return true;
        }
        private void btnAgregarAdmin_Click(object sender, EventArgs e)
        {
            if (ValidacionesAdmin())
            {
                Administrativo a1 = new Administrativo();
                //rellenamos los compos del admin

                a1.NombreAdmin = txtNombreAdmi.Text.Trim();
                a1.ApellidoPaAdmin = txtApellidoPaAdmin.Text.Trim();
                a1.ApellidoMaAdmin = txtApellidoMaAdmin.Text.Trim();
                a1.NumeroEmpleAdmin = int.Parse(txtNumEmpleaAdmi.Text.Trim());
                a1.CurpAdmin = txtCurpAdmin.Text.Trim();
                a1.RfcAdmin = txtRfcAdmin.Text.Trim();
                a1.FechaNaciAdmin = dtFechaNaciAdmin.Value;
                a1.FechaIngresoAdmin = tmFechaIngrsoAdmin.Value;
                a1.AreaDeTrabajoAdmin = txtAreaTrabajoAdmin.Text.Trim();

                //agregamos el abojeto a una nueva lista
                AccesoBd.AgregarAdministrativo(a1);
                MessageBox.Show(AccesoBd.MostrarAdministrativos().Count.ToString());
                RefrescarAdmin();
                LimpiarAdmin();

            }
        }
        public void LimpiarAdmin()
        {
            txtNombreAdmi.Text = string.Empty;
            txtApellidoPaAdmin.Text = string.Empty;
            txtApellidoMaAdmin.Text = string.Empty;
            txtNumEmpleaAdmi.Text = string.Empty;
            txtCurpAdmin.Text = string.Empty;
            txtRfcAdmin.Text = string.Empty;
            dtFechaNaciAdmin.Value = DateTime.Now;
            tmFechaIngrsoAdmin.Value = DateTime.Now;
            txtAreaTrabajoAdmin.Text = string.Empty;
        }
        private void RefrescarAdmin()
        {
            dgDatosAdmin.DataSource = null;
            dgDatosAdmin.DataSource = AccesoBd.MostrarAdministrativos();
        }
        #endregion

        #region Directivos
        private bool ValidacionesDirec()
        {
            return true;
        }
        private void btnAgregarDirec_Click(object sender, EventArgs e)
        {
            if (ValidacionesDirec())
            {
                Directivo d1 = new Directivo();
                d1.NombreDi = txtNombreDire.Text.Trim();
                d1.ApellidoPaDi = txtApellidoPaDire.Text.Trim();
                d1.ApellidoMaDi = txtApellidoMaDire.Text.Trim();
                d1.NumeroEmpleDi = int.Parse(txtNumEmpleadoDire.Text.Trim());
                d1.CurpDi = txtCurpDire.Text.Trim();
                d1.RfcDi = txtRfcDire.Text.Trim();
                d1.FechaNaciDi = tmFechaNaciDirec.Value;
                d1.FechaIngresoDi = tmFechaIngresoDirec.Value;
                d1.ProfessionDi = txtPresionDirec.Text.Trim();
                d1.PuestoDi = txtPuestoDirec.Text;
                d1.CanEmpleACaroDi = int.Parse(txtCanEmpleadosDirec.Text.Trim());

                AccesoBd.AgregarDirectivo(d1);
                LimpiarDirec();
                RefrescarDirec();
            }
        }
        private void LimpiarDirec()
        {
            txtNombreDire.Text = string.Empty;
            txtApellidoPaDire.Text = string.Empty;
            txtApellidoMaDire.Text = string.Empty;
            txtNumEmpleadoDire.Text = string.Empty;
            txtCurpDire.Text = string.Empty;
            txtRfcDire.Text = string.Empty;
            tmFechaNaciDirec.Value = DateTime.Now;
            tmFechaIngresoDirec.Value = DateTime.Now;
            txtPresionDirec.Text = string.Empty;
            txtPuestoDirec.Text = string.Empty;
            txtCanEmpleadosDirec.Text = string.Empty;
        }
        private void RefrescarDirec()
        {
            dgDatosDirec.DataSource = null;
            dgDatosDirec.DataSource = AccesoBd.MostrarDirectivos();
            
        }

        #endregion

        
    }
}
