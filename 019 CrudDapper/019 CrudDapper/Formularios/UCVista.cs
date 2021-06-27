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
    public partial class UCVista : UserControl
    {
        private readonly IServicesPersona acceso;
        public UCVista()
        {

            InitializeComponent();
            acceso = new ServicesPersona();
            //IniciarlizarDataGridPersona();
        }

        private void IniciarlizarDataGridPersona()
        {
            DataGridViewColumn columnId = new DataGridViewColumn();
            columnId.HeaderText = "Id";
            columnId.DataPropertyName = "Id";
            columnId.DisplayIndex = 0;
            columnId.Name = "Id";

            DataGridViewColumn columnNom = new DataGridViewColumn();
            columnNom.HeaderText = "Nombre";
            columnNom.DataPropertyName = "Nombre";
            columnNom.DisplayIndex = 1;
            columnNom.Name = "Nombre";


            DataGridViewColumn columnApPa = new DataGridViewColumn();
            columnApPa.HeaderText = "Apellido Paterno";
            columnApPa.DataPropertyName = "ApPaterno";
            columnApPa.DisplayIndex = 2;
            columnApPa.Name = "ApPaterno";
            
            DataGridViewColumn columnApMa = new DataGridViewColumn();
            columnApMa.HeaderText = "Apellido Materno";
            columnApMa.DataPropertyName = "ApMaterno";
            columnApMa.DisplayIndex = 3;
            columnApMa.Name = "ApMaterno";

            dgvDatosPersona.Columns.Add(columnId);
            dgvDatosPersona.Columns.Add(columnNom);
            dgvDatosPersona.Columns.Add(columnApPa);
            dgvDatosPersona.Columns.Add(columnApMa);
           
            
        }


        #region Util
        private void QuitaEspaciosText(TextBox t)
        {
            t.Text = t.Text.Trim();
        }
        private async Task Refrescar()
        {
            List<PersonaViewModel> lst = new List<PersonaViewModel>();
            lst = (await this.acceso.Obtener()).Select(item => new PersonaViewModel()
            {
                Id = item.Id,
                Nombre = item.Nombre,
                ApMaterno = item.ApMaterno,
                ApPaterno = item.ApPaterno
            }).ToList();

            dgvDatosPersona.DataSource = lst;
        }
        private int? GetId()
        {
            if (dgvDatosPersona == null || dgvDatosPersona.Rows == null || dgvDatosPersona.CurrentRow == null)
            {
                return null;
            }
            else
            {
                return int.Parse(dgvDatosPersona.CurrentRow.Cells[0].Value.ToString());
            }
        }
        private async Task EliminarDatos(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                await this.acceso.Eliminar(id);
            }
        }
        #endregion

        private async void UCVista_Load(object sender, EventArgs e)
        {
            await Refrescar();
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRegistro re = new FrmRegistro();
            re.ShowDialog();
            await Refrescar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (GetId() != null)
            {
                int id = (int)GetId();
                await EliminarDatos(id);
                await Refrescar();
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (GetId() != null)
            {
                FrmRegistro re = new FrmRegistro((int)GetId());
                re.ShowDialog();
                await Refrescar();
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await Refrescar();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            QuitaEspaciosText(textBox1);
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string busqueda = textBox1.Text;
                List<PersonaViewModel> lst = new List<PersonaViewModel>();

                lst = (from d in await acceso.Obtener()
                      where d.ApMaterno.Contains(busqueda) ||
                      d.ApPaterno.Contains(busqueda) ||
                      d.Nombre.Contains(busqueda)
                      select new PersonaViewModel()
                      {
                          Id = d.Id,
                          Nombre = d.Nombre,
                          ApMaterno = d.ApMaterno,
                          ApPaterno = d.ApPaterno
                      }).ToList();

                dgvDatosPersona.DataSource = lst;
            }
        }
    }
}
