using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _015_EscuelaFramekork.Logica;
using _015_EscuelaFramekork.Formularios;

namespace _015_EscuelaFramekork.Formularios
{
    public partial class Vista : UserControl
    {
        int op;
        public Vista(int op)
        {
            InitializeComponent();
            this.op = op;
            Refrescar(op);
        }
        #region Util
        public int? Getid()
        {

            if (dgDatos == null)
            {
                return null;
            }else if (dgDatos.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return int.Parse(dgDatos.Rows[dgDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }
        }
        public void Refrescar(int op)
        {
            switch (op)
            {
                case 0:
                    RefrescarPasa();
                    break;
                case 1:
                    RefrescarPilo();
                    break;
                case 2:
                    RefrescarAdmin();
                    break;
                case 3:
                    RefrescarDirec();
                    break;
            }
        }
        #endregion
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case 0:
                    AgregarPasa();
                    break;
                case 1:
                    AgregarPilo();
                    break;
                case 2:
                    AgregarAdmin();
                    break;
                case 3:
                    AgregarDirec();
                    break;
            }
        }

        #region Pasajero
        private void BuscarPasa(string bus)
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LPasajero.BuscarPasa(bus);
        }
        private void RefrescarPasa()
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LPasajero.ObtenerPasajeros();
        }
        private void AgregarPasa()
        {
            Registro r1 = new Registro();
            r1.CamposPasa();
            r1.ShowDialog();
            RefrescarPasa();
        }
        private void ModificarPasa(int id)
        {
            Registro r1 = new Registro();
            r1.CargarPasa(LPasajero.ObtenerPorid(id));
            r1.ShowDialog();
            RefrescarPasa();
        }
        private void EliminarPasa(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPasajero.EliminarPasajero(id);
            }
            RefrescarPasa();
        }
        #endregion
        #region Piloto
        private void BuscarPilo(string bus)
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LPiloto.BuscarPilo(bus);
        }
        private void RefrescarPilo()
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LPiloto.ObtenerPilotos();
        }
        private void AgregarPilo()
        {
            Registro r1 = new Registro();
            r1.CamposPilo();
            r1.ShowDialog();
            RefrescarPilo();
        }
        private void ModificarPilo(int id)
        {
            Registro r1 = new Registro();
            r1.CargarPilo(LPiloto.ObtenerPorId(id));
            r1.ShowDialog();
            RefrescarPilo();
        }
        private void EliminarPilo(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPiloto.EliminarPiloto(id);
            }
            RefrescarPilo();
        }
        #endregion
        #region Admin
        private void BuscarAdmin(string bus)
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LAdmin.BuscarAdmin(bus);
        }
        private void RefrescarAdmin()
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LAdmin.ObtenerAdmin();
        }
        private void AgregarAdmin()
        {
            Registro r1 = new Registro();
            r1.CamposAdmin();
            r1.ShowDialog();
            RefrescarAdmin();
        }
        private void ModificarAdmin(int id)
        {
            Registro r1 = new Registro();
            r1.CargarAdmin(LAdmin.ObterPodId(id));
            r1.ShowDialog();
            RefrescarAdmin();
        }
        private void EliminarAdmin(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LAdmin.EiliminarAdmin(id);
            }
            RefrescarAdmin();
        }
        #endregion
        #region Direc
        private void BuscarDirec(string bus)
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LDirec.BuscarDirec(bus);
        }
        private void RefrescarDirec()
        {
            dgDatos.DataSource = null;
            dgDatos.DataSource = LDirec.ObterDirec();
        }
        private void AgregarDirec()
        {
            Registro r1 = new Registro();
            r1.CamposDirec();
            r1.ShowDialog();
            RefrescarDirec();
        }
        private void ModificarDirec(int id)
        {
            Registro r1 = new Registro();
            r1.CargarDirec(LDirec.ObterPodId(id));
            r1.ShowDialog();
            RefrescarDirec();
        }
        private void EliminarDirec(int id)
        {
            if (MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LDirec.EiliminarDirec(id);
            }
            RefrescarDirec();
        }
        #endregion

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case 0:
                    RefrescarPasa();
                    break;
                case 1:
                    RefrescarPilo();
                    break;
                case 2:
                    RefrescarAdmin();
                    break;
                case 3:
                    RefrescarDirec();
                    break;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Getid() == null)
            {
                MessageBox.Show("Seleciona una fila");
            }
            else
            {
                int id =(int)Getid();
                switch (op)
                {
                    case 0:
                        ModificarPasa(id);
                        break;
                    case 1:
                        ModificarPilo(id);
                        break;
                    case 2:
                        ModificarAdmin(id);
                        break;
                    case 3:
                        ModificarDirec(id);
                        break;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Getid() == null)
            {
                MessageBox.Show("Seleciona una fila");
            }
            else
            {
                int id = (int)Getid();
                switch (op)
                {
                    case 0:
                        EliminarPasa(id);
                        break;
                    case 1:
                        EliminarPilo(id);
                        break;
                    case 2:
                        EliminarAdmin(id);
                        break;
                    case 3:
                        EliminarDirec(id);
                        break;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "")
            {
                switch (op)
                {
                    case 0:
                        RefrescarPasa();
                        break;
                    case 1:
                        RefrescarPilo();
                        break;
                    case 2:
                        RefrescarAdmin();
                        break;
                    case 3:
                        RefrescarDirec();
                        break;
                }
            }
            else
            {
                switch (op)
                {
                    case 0:
                        BuscarPasa(textBox1.Text.Trim());
                        break;
                    case 1:
                        BuscarPilo(textBox1.Text.Trim());
                        break;
                    case 2:
                        BuscarAdmin(textBox1.Text.Trim());
                        break;
                    case 3:
                        BuscarDirec(textBox1.Text.Trim());
                        break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
