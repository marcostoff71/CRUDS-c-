using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _001_Proyexto001
{
    public partial class Form1 : Form
    {
        private CapaDeNegocios nego1;
        public Form1()
        {
            nego1 = new CapaDeNegocios();
            InitializeComponent();
        }
        #region eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirContactosDiaglog();
            CargarContacot();
        }
        #endregion
        #region Metodos privados
        private void AbrirContactosDiaglog()
        {
            Form2 AgregarContactos = new Form2();
            AgregarContactos.ShowDialog(this);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarContacot();
        }
        public void CargarContacot()
        {
            List<Contac> contactos = nego1.ObtenerContactos();
            gridContactos.DataSource = contactos;
        }
        public void CargarContacot(string buscar)
        {
            List<Contac> contactos = nego1.ObtenerContactos();
            gridContactos.DataSource = contactos;
        }

        private void gridContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (gridContactos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == gridContactos.Rows[e.RowIndex].Cells[6].Value)
                {
                    DataGridViewLinkCell cell = (DataGridViewLinkCell)gridContactos.Rows[e.RowIndex].Cells[e.ColumnIndex];


                    if (cell.Value.ToString() == "Editar")
                    {
                        Form2 f2 = new Form2();
                        f2.CargarContacto(new Contac
                        {
                            Id = int.Parse(gridContactos.Rows[e.RowIndex].Cells[0].Value.ToString()),
                            Nombre=gridContactos.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            ApellidoMa=gridContactos.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            ApellidoPa=gridContactos.Rows[e.RowIndex].Cells[3].Value.ToString(),
                            Telefono=gridContactos.Rows[e.RowIndex].Cells[4].Value.ToString(),
                            Direcion=gridContactos.Rows[e.RowIndex].Cells[5].Value.ToString(),
                            
                        });
                        
                        f2.ShowDialog(this);
                    }
                }
                if (gridContactos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == gridContactos.Rows[e.RowIndex].Cells[7].Value)
                {
                    DataGridViewLinkCell cell = (DataGridViewLinkCell)gridContactos.Rows[e.RowIndex].Cells[e.ColumnIndex];


                    if (cell.Value.ToString() == "Borrar")
                    {

                        int id=int.Parse(gridContactos.Rows[e.RowIndex].Cells[0].Value.ToString());
                        EliminarContactos(id);
                        CargarContacot();
                    }
                }
            }

        }
        private void EliminarContactos(int id)
        {
            nego1.EliminarContacto(id);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "")
            {

                List<Contac> bus = nego1.ObtenerContactos(txtBuscar.Text);
                if (bus.Count > 0)
                {
                    gridContactos.DataSource = bus;
                }else
                {
                    MessageBox.Show(txtBuscar.Text+" No encontrado ", "Busqueda");
                }
                txtBuscar.Text = string.Empty;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarContacot();
        }
    }
}
