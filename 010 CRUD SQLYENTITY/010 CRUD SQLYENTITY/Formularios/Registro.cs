using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _010_CRUD_SQLYENTITY.Logica.AccesoBD;
using _010_CRUD_SQLYENTITY.Modelos;

namespace _010_CRUD_SQLYENTITY.Formularios
{
    public partial class Registro : Form
    {
        private int? id;
        public Registro(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                CargarCampos((int)id);
            }
        }

        #region MyRegion

        private void Limpiar()
        {
            txtSexo.SelectedIndex = -1;
        }
        private void CargarCampos(int id)
        {
            Persona p = AccesoSql.ObtenerPorId(id);
            txtNombre.Text = p.Nombre;
            txtApellidoPa.Text = p.Apellido_Paterno;
            txtApellidoMa.Text = p.Apellido_Materno;
            txtEdad.Text = p.Edad.ToString();
            if (p.Sexo == "Hombre")
            {
                txtSexo.SelectedIndex = 0;
            }else if (p.Sexo == "Mujer")
            {
                txtSexo.SelectedIndex = 1;
            }else if (p.Sexo == "Otro")
            {
                txtSexo.SelectedIndex = 2;
            }
            dtCumple.Value = p.Cumple;
        }
        private bool Validaciones()
        {
            bool valor=false;
            if (txtNombre.Text.Trim() != string.Empty)
            {
                if (txtApellidoPa.Text.Trim() != string.Empty)
                {
                    if (txtApellidoMa.Text.Trim() != string.Empty)
                    {
                        if (txtEdad.Text.Trim() != string.Empty&&esNum(txtEdad.Text.Trim()))
                        {
                            if (txtSexo.SelectedIndex >= 0)
                            {
                                valor = true;
                            }
                        }
                    }
                }
            }

            return valor;
        }
        private bool esNum(string txtNumber)
        {
            bool valor;
            int num;
            valor = int.TryParse(txtNumber, out num);
            //return int.TryParse(txtNumber, out int num);
            return valor;
        }

        #endregion

        private void btnAceptar_Click(object sender,
            EventArgs e)
        {
            if (Validaciones())
            {
                Persona p1 = new Persona();
                p1.Nombre = txtNombre.Text.Trim();
                p1.Apellido_Paterno = txtApellidoPa.Text.Trim();
                p1.Apellido_Materno = txtApellidoMa.Text.Trim();
                p1.Edad = int.Parse(txtEdad.Text.Trim());
                p1.Cumple = dtCumple.Value;
                p1.Sexo = txtSexo.Text.Trim();
                if (id == null)
                {
                    AccesoSql.AgregarPersona(p1);
                }
                else
                {
                    p1.Id = (int) id;
                    AccesoSql.ModificarPersona(p1);
                    this.Close();
                }

                Limpiar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
