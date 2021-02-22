using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _003_Entitiframeow
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarTabla();
        }
        public void MostrarTabla()
        {
            using (DataCumpleEntities db = new DataCumpleEntities())
            {
                var lista = from d in db.FechaCum
                            select d;
                dataGridView1.DataSource = lista.ToList();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro r1 = new Registro();
            r1.ShowDialog();
            MostrarTabla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Editar")
                    {
                        
                        int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        
                        Registro r1 = new Registro();
                        r1.CargarContactos(id);
                        r1.ShowDialog();
                        MostrarTabla();
                    }
                }else if (e.ColumnIndex == 1)
                {
                    
                    int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    using(DataCumpleEntities db = new DataCumpleEntities())
                    {
                        var n = from i in db.FechaCum
                                      where i.Id == id select i;
                        FechaCum f1 = n.First();

                        db.FechaCum.Remove(f1);
                        db.SaveChanges();
                    }
                    MostrarTabla();
                }

            }
        }
        #region editarBorrar

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txt.Text.Trim() != "")
            {
                string bus = txt.Text.Trim();
                
                using (DataCumpleEntities db = new DataCumpleEntities())
                {
                    var bus1 = db.FechaCum.Where(i => i.Apellidos == bus || i.Nombre == bus);
                    var bu = from i in db.FechaCum
                             where i.Apellidos == bus || i.Nombre == bus
                             select i;
                    if (bu.Count() > 0)
                    {
                        dataGridView1.DataSource = bu.ToList();
                        if (bu.Count() == 1)
                        {
                            MessageBox.Show(bus + " encontrado " + bu.Count().ToString()+" vez");
                        }else
                        {
                            MessageBox.Show(bus + " encontrado " + bu.Count().ToString() + " veces");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(bus + " no encontrado");
                    }
                    
                }
                txt.Text = string.Empty;
            }
            else
            {
                MostrarTabla();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarTabla();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
