using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _020_CrudConImagenes.Modelos;
using _020_CrudConImagenes.Logica;

namespace _020_CrudConImagenes.Formularios
{
    public partial class CtrRegistro : UserControl
    {
        private BdPersona oDbPersona;
        private string ruta = "";
        private int id;
        Persona auxPersona;
        public CtrRegistro()
        {

            InitializeComponent();
            oDbPersona = new BdPersona();
            Refrescar();
            id = 0;

        }
        #region Helpers

            private void Refrescar()
            {
                List<Persona> lstPersona = this.oDbPersona.Obtener().ToList();
                dgvDatosPersona.DataSource = lstPersona;
            }
            private bool CamposCorrectos()
            {
                txtNombre.QuitaEspacios();
                txtApematerno.QuitaEspacios();
                txtApePaterno.QuitaEspacios();
                if (!string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(txtApematerno.Text)
                    && !string.IsNullOrEmpty(txtApePaterno.Text))
                {
                    return true;
                }

                return false;
            }
            private int CalculaEdad(DateTime tiempo)
            {
                int edad = DateTime.Now.Subtract(tiempo).Days / 365;
                return edad;
            }
            private int? GetId()
        {
            if (dgvDatosPersona == null || dgvDatosPersona.Rows == null||dgvDatosPersona.Columns==null)
            {
                return null;
            }
            else
            {
                
                return int.Parse(dgvDatosPersona.Rows[dgvDatosPersona.CurrentRow.Index].Cells[0].Value.ToString());
            }
        }
            private void LimpiaCampos()
        {
            txtNombre.Clear();
            txtApePaterno.Clear();
            txtApematerno.Clear();
            SelecionaImagen();

        }

        #endregion
        private void SelecionaImagen(string ruta="")
        {
            
            Image defe = global::_020_CrudConImagenes.Properties.Resources.usuarioDefe;
            if (ruta == "")
            {
                picImgPersona.Image = defe;
            }
            try
            {

                byte[] arrimg = File.ReadAllBytes(ruta);
                using (MemoryStream ms = new MemoryStream(arrimg))
                {
                    Image img = Image.FromStream(ms);
                    picImgPersona.Image = img;
                    this.ruta = ruta;
                }
            }
            catch (Exception e)
            {

                picImgPersona.Image = defe;
            }
        }
        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            open.Filter = "Images(*.jpg) | *.jpg";


            if (open.ShowDialog() == DialogResult.OK)
            {
                SelecionaImagen(open.FileName);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CamposCorrectos())
            {
                
                    Persona per = new Persona();
                    per.Nombre = txtNombre.Text;
                    per.ApellidoPaterno = txtApePaterno.Text;
                    per.ApellidoMaterno = txtApematerno.Text;
                    per.FechaNaci = dtpFechaNaci.Value;
                    per.Edad = CalculaEdad(per.FechaNaci);
                    
                    if (id == 0)
                    {
                    if (File.Exists(this.ruta))
                    {

                        per.Foto = ImageHelper.RutaABytes(this.ruta);
                        this.oDbPersona.Agregar(per);
                    }
                    else
                    {
                        per.Foto = ImageHelper.ImageABytes(_020_CrudConImagenes.Properties.Resources.usuarioDefe);
                    }
                    }
                    else
                    {
                        per.Id = this.id;
                        if (this.ruta == "")
                        {
                            per.Foto = this.auxPersona.Foto;
                        }
                        else
                        {
                            per.Foto = ImageHelper.RutaABytes(this.ruta);
                        }
                        this.oDbPersona.Modificar(per);
                        this.id = 0;
                    }


                    this.ruta = "";
                    LimpiaCampos();
                    Refrescar();
                
            }
        }
        
        private void CargaDatos(int id)
        {
            auxPersona = this.oDbPersona.ObtenerPorId(id);
            this.id = auxPersona.Id;
            txtNombre.Text = auxPersona.Nombre;
            txtApePaterno.Text = auxPersona.ApellidoPaterno;
            txtApematerno.Text = auxPersona.ApellidoMaterno;
            dtpFechaNaci.Value = auxPersona.FechaNaci;
            picImgPersona.Image = ImageHelper.ByteAImagen(auxPersona.Foto);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                CargaDatos((int)id);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            int? id = GetId();
            if (id != null)
            {
                this.oDbPersona.Eliminar((int)id);
                Refrescar();
            }
        }
    }
}
