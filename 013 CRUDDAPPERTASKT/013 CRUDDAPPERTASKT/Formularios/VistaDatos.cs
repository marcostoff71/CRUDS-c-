using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _013_CRUDDAPPERTASKT.Logica;
using _013_CRUDDAPPERTASKT.Formularios;


namespace _013_CRUDDAPPERTASKT.Formularios
{
    public partial class VistaDatos : UserControl
    {
        private CapaNegocios acceso;
        
        public  VistaDatos()
        {
            InitializeComponent();

            this.acceso = new CapaNegocios();

        }
        private async Task Refrescar()
        {
            dgDatos.DataSource = await acceso.ObtenerPersonas();
        }
        private int? ObtenerId()
        {
            if (dgDatos.Rows.Count > 0)
            {

                return int.Parse(dgDatos.Rows[dgDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            else
            {
                return null;
            }
            
        }
        
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await Refrescar();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            await Refrescar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();
            if (id != null)
            {
                Modificar((int)id);
            }
            
           
        }
        private async void Modificar(int id)
        {
            Registro r1 = new Registro(id);
            r1.ShowDialog();
            await Refrescar();
        }
       

        
        private async Task Eliminar(int id)
        {
            DialogResult res = MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                await acceso.EliminarPersona(id);
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null) { 
                await Eliminar((int)id);
                await Refrescar();
            }
        }

        private async void VistaDatos_Load(object sender, EventArgs e)
        {
            await Refrescar();
        }
        private async Task Buscar(string bus)
        {
            dgDatos.DataSource = await acceso.BuscarPersona(bus);
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                await Refrescar();
            }
            else
            {
                string busqueda;
                busqueda = txtBuscar.Text.Trim();
                await Buscar(busqueda);
            }
        }
    }
}
