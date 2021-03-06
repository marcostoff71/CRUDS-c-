﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _014_CRUDSQLControl.Logica.Acceso;
using _014_CRUDSQLControl.Modelos;

namespace _014_CRUDSQLControl.Formularios
{
    public partial class Registro : Form
    {
        int? id = null;
        public Registro(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                Cargardatos((int)id);
            }
        }

        public void Cargardatos(int id)
        {
            Persona p1 = AccesoBdPersonas.ObtenerPorId(id);
            txtNombre.Text = p1.Nombre;
            txtApellido.Text = p1.Apellido;
            txtEdad.Text = p1.Edad.ToString();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                Persona p1 = new Persona();
                p1.Nombre = txtNombre.Text;
                p1.Apellido = txtApellido.Text;
                p1.Edad = int.Parse(txtEdad.Text);
                if (id == null)
                {
                    AccesoBdPersonas.AgregarPersona(p1);
                }
                else
                {
                    p1.Id = (int)id;
                    AccesoBdPersonas.ModificarPersona(p1);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Completa los compos correctamente","Validaciones",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private bool Validaciones()
        {
            TrimTextBox(ref txtNombre);
            TrimTextBox(ref txtApellido);
            TrimTextBox(ref txtEdad);
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtEdad.Text != "")
            {
                return true;
            }
            return false;
        }
        private void TrimTextBox(ref TextBox text)
        {
            text.Text = text.Text.Trim();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logica.ValiTextbox.SoloNumerosF(txtEdad,e);
        }
    }
}
