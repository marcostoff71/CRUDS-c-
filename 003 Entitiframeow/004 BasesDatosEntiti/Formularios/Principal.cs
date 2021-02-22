using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using _004_BasesDatosEntiti.Modelos;
using _004_BasesDatosEntiti.Formularios;

namespace _004_BasesDatosEntiti
{
    public partial class Principal : Form
    {
        
        public Principal()
        {
            InitializeComponent();
        }
        private void Refrescar()
        {
            
            using (EstuEntities db = new EstuEntities())
            {
                List<Persona> i = db.Persona.ToList();
                IQueryable<Persona> l = from d in db.Persona
                                        select d;
                        
                Tabla.DataSource = l.ToList();
                
                
            }
            
            
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            Refrescar();
            


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Registro re = new Registro();
            re.ShowDialog();
            Refrescar();
        }
        private void Eliminar(int id)
        {
            
            if (MessageBox.Show("Seguro de borrar el registro","Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                using(EstuEntities db = new EstuEntities())
                {
                    Persona borar = db.Persona.FirstOrDefault(d => d.Id == id);
                    db.Persona.Remove(borar);
                    db.SaveChanges();
                }
                Refrescar();
            }
        }
        public void Editar(int id)
        {
            Persona p1;
            using(EstuEntities db = new EstuEntities())
            {
                p1 = db.Persona.Where(i => i.Id == id).First();
                
            }
            Registro registro = new Registro();
            registro.cargarCompos(p1);
            registro.ShowDialog();
            Refrescar();
        }
        private void Tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex >= 0)
                {
                    if (Tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Editar")//editar
                    {
                        int id = int.Parse(Tabla.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Editar(id);
                    }else if(Tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
                    {
                        int id = int.Parse(Tabla.Rows[e.RowIndex].Cells[2].Value.ToString());
                        Eliminar(id);
                    }
                    

                    
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = txtBuscar.Text.Trim();
            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text;
                using(EstuEntities db = new EstuEntities())
                {
                    IQueryable<Persona> bus = from i in db.Persona
                                              where i.Apellido_Materno == busqueda ||
                                              i.Apellido_Paterno == busqueda ||
                                              i.Nombre == busqueda
                                              select i;
                    //List<Persona> bus1 = bus.ToList();
                    List<Persona> bus1 = db.Persona.Where(i => i.Apellido_Materno == busqueda || i.Apellido_Paterno == busqueda || i.Nombre == busqueda).ToList();
                    
                    

                    if (bus1.Count > 0)
                    {
                        if (bus1.Count == 1)
                        {
                            MessageBox.Show(busqueda + " se ha encontrado 1 vez");
                        }
                        else
                        {
                            MessageBox.Show(busqueda + " se ha encontrado "+bus1.Count.ToString()+" veces");
                        }
                        Tabla.DataSource = bus1;
                    }
                    else
                    {
                        MessageBox.Show(busqueda + " no encontrada");
                    }
                    txtBuscar.Text = string.Empty;
                }
            }
            else
            {
                Refrescar();
            }
        }
    }
}
