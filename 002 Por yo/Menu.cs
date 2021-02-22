using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _002_Por_yo.Mdelos;

namespace _002_Por_yo
{
    public partial class Menu : Form
    {
        CMnu Cmenu = new CMnu();
        
        public Menu()
        {
            
           
            InitializeComponent();
        }
        #region Tabla
        private void ObtenerDatosTabl()
        {
            List<Persona> tab = Cmenu.Obtener();
           
                dataGridView1.DataSource = Cmenu.Obtener();
            
            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
            ObtenerDatosTabl();
        }
        #endregion
        private void Menu_Load(object sender, EventArgs e)
        {
            ObtenerDatosTabl();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ObtenerIDTabla() != null && ObtenerIDTabla() >= 0)
            {
                int? c = ObtenerIDTabla();
                Registro r1 = new Registro();
                r1.ObtenerPersona(new Persona
                {
                    Id = int.Parse(dataGridView1.Rows[(int)c].Cells[0].Value.ToString()),
                    Nombre = dataGridView1.Rows[(int)c].Cells[1].Value.ToString(),
                    Edad = int.Parse(dataGridView1.Rows[(int)c].Cells[2].Value.ToString())

                });
                r1.ShowDialog();
                ObtenerDatosTabl();
            }
        }
        private int? ObtenerIDTabla()
        {
            int? n;
            try
            {
            n = dataGridView1.CurrentCell.RowIndex;
            }
            catch { n = null; }
            return n;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ObtenerIDTabla() != null && ObtenerIDTabla() >= 0)
            {
                int? c = ObtenerIDTabla();
                int id = int.Parse(dataGridView1.Rows[(int)c].Cells[0].Value.ToString());
                Cmenu.Eliminar(id);
                ObtenerDatosTabl();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "")
            {
                List<Persona> a = Cmenu.Buscar(txtBuscar.Text.Trim());
                if (a.Count > 0)
                {
                    dataGridView1.DataSource = a;
                }
                else
                {
                    MessageBox.Show(txtBuscar.Text.Trim() + " no se encontro");
                }

            }
            else
            {
                ObtenerDatosTabl();
            }
           
        }
    }
}
