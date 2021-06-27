using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _021_SubirImagenesADatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            open.Filter = "Arhivos de img(*.jpg)|*.jpg";
            DialogResult re = open.ShowDialog();
            if (re == DialogResult.OK)
            {
                txtRuta.Text = open.FileName;
                byte[] bytes = File.ReadAllBytes(open.FileName);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    picImgUsuario.Image = Image.FromStream(ms);
                }
                
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (File.Exists(open.FileName))
            //{
            //    using (Stream stream = open.OpenFile())
            //    {
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            stream.CopyTo(ms);

            //            byte[] arr = ms.ToArray();

            //            using (Modelos.PrubaContraEntities db = new Modelos.PrubaContraEntities())
            //            {
            //                db.Imagenes.Add(
            //                    new Modelos.Imagenes()
            //                    {
            //                        Imagen = arr,
            //                        Nombre = txtNombre.Text.Trim()

            //                    });
            //                db.SaveChanges();
            //                MessageBox.Show("guardado");
            //            }

            //        }
            //    }

            //}


            //if (File.Exists(open.FileName))
            //{
            //    byte[] byts=File.ReadAllBytes(open.FileName);

            //    using (MemoryStream ms = new MemoryStream(byts))
            //    {


            //        byte[] arr = ms.ToArray();

            //        using (Modelos.PrubaContraEntities db = new Modelos.PrubaContraEntities())
            //        {
            //            db.Imagenes.Add(
            //                new Modelos.Imagenes()
            //                {
            //                    Imagen = arr,
            //                    Nombre = txtNombre.Text.Trim()

            //                });
            //            db.SaveChanges();
            //            MessageBox.Show("guardado");
            //        }

            //    }
            //}
            using (MemoryStream ms = new MemoryStream())
            {

                
                Bitmap img = (Bitmap)picImgUsuario.Image;
                img.Save(ms, img.RawFormat);
                byte[] arr = ms.ToArray();

                using (Modelos.PrubaContraEntities db = new Modelos.PrubaContraEntities())
                {
                    db.Imagenes.Add(
                        new Modelos.Imagenes()
                        {
                            Imagen = arr,
                            Nombre = txtNombre.Text.Trim()

                        });
                    db.SaveChanges();
                    MessageBox.Show("guardado");
                }

            }

        }
    }
}
