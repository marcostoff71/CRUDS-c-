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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        private FechaCum f1 = new FechaCum();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validaciones())
            {
                if (f1.Id!=0)
                {
                    f1.Apellidos = txtApellidos.Text.Trim();
                    f1.Cumpleños = txtCumple.Value;
                    f1.Nombre = txtNombre.Text.Trim();

                    using (DataCumpleEntities db = new DataCumpleEntities())
                    {
                        db.Entry(f1).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    this.Close();
                }
                else
                {
                    FechaCum cum1 = new FechaCum();
                    cum1.Apellidos = txtApellidos.Text.Trim();
                    cum1.Nombre = txtNombre.Text.Trim();
                    cum1.Cumpleños = txtCumple.Value;

                    using (DataCumpleEntities db = new DataCumpleEntities())
                    {
                        db.FechaCum.Add(cum1);
                        db.SaveChanges();
                    }
                    this.Close();
                }
            }
        }
        public bool validaciones()
        {
            bool valor = false;
            if (1 == 1)
            {
                valor = true;
            }
            return valor;
        }
        public void CargarContactos(int id)
        {
            using (DataCumpleEntities db = new DataCumpleEntities())
            {
                f1 = db.FechaCum.Where(a => a.Id == id).First();
                txtApellidos.Text = f1.Apellidos.Trim();
                txtNombre.Text = f1.Nombre.Trim();
                txtCumple.Value = f1.Cumpleños.Value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
