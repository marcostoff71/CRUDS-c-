using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _004_BasesDatosEntiti.Modelos;

namespace _004_BasesDatosEntiti.Formularios
{
    public partial class Registro : Form
    {
        Persona persona = new Persona();
        public Registro()
        {
            InitializeComponent();
        }
        private bool valiCampos()
        {
            bool vali = false;
            
            if (txtNombre.Text.Trim()!="")
            {
                if (txtApellidoMa.Text.Trim() != "")
                {
                    if (txtApellidoPa.Text.Trim() != "")
                    {
                        if(int.TryParse(txtEdad.Text.Trim(),out int n))
                        {
                            if (int.Parse(txtEdad.Text) > 0)
                            {
                                vali = true;
                            }
                            
                        }
                        
                    }
                }
               
            }
            return vali;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (valiCampos())
            {
                if (persona.Id == 0)
                {

                    using (EstuEntities db = new EstuEntities())
                    {
                        Persona p1 = new Persona();
                        p1.Nombre = txtNombre.Text.Trim();
                        p1.Apellido_Paterno = txtApellidoPa.Text.Trim();
                        p1.Apellido_Materno = txtApellidoMa.Text.Trim();
                        p1.Edad = int.Parse(txtEdad.Text.Trim());
                        p1.Cumpleaños = datatimeCumple.Value;
                        db.Persona.Add(p1);
                        db.SaveChanges();
                    }
                    this.Close();
                }
                else
                {
                    persona.Nombre = txtNombre.Text.Trim();
                    persona.Apellido_Paterno = txtApellidoPa.Text.Trim();
                    persona.Apellido_Materno = txtApellidoMa.Text.Trim();
                    persona.Edad = int.Parse(txtEdad.Text.Trim());
                    persona.Cumpleaños = datatimeCumple.Value;

                    using(EstuEntities db = new EstuEntities())
                    {
                        db.Entry(persona).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    this.Close();
                }
            }
        }
        public void cargarCompos(Persona p1)
        {
            persona = p1;
            txtNombre.Text = p1.Nombre.Trim();
            txtApellidoPa.Text = p1.Apellido_Paterno.Trim();
            txtApellidoMa.Text = p1.Apellido_Materno.Trim();
            txtEdad.Text = p1.Edad.ToString().Trim();
            datatimeCumple.Value = p1.Cumpleaños.Value;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
