using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace _020_CrudConImagenes.Logica
{
    public static class ImageHelper
    {
        public static byte[] RutaABytes(string ruta)
        {
            byte[] arrImg = null;
            try
            {
                byte[] bytes=File.ReadAllBytes(ruta);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    arrImg = ms.ToArray();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Imagen no compatible se seleciona una imagen por defecto");
                MessageBox.Show(e.Message);
                using (MemoryStream ms = new MemoryStream())
                {

                    global::_020_CrudConImagenes.Properties.Resources.usuarioDefe.Save(ms, global::_020_CrudConImagenes.Properties.Resources.usuarioDefe.RawFormat);
                    arrImg = ms.ToArray();
                }
                
            }

            return arrImg;
        }
        public static byte[] ImageABytes(Image img)
        {
            byte[] arrImg = null;
            try
            {
                
                MemoryStream ms = new MemoryStream();
                
                img.Save(ms, img.RawFormat);
                arrImg = ms.ToArray();
                ms.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Imagen no compatible se seleciona una imagen por defecto");
                MessageBox.Show(e.Message);
                using (MemoryStream ms = new MemoryStream())
                {

                    global::_020_CrudConImagenes.Properties.Resources.usuarioDefe.Save(ms, global::_020_CrudConImagenes.Properties.Resources.usuarioDefe.RawFormat);
                    arrImg = ms.ToArray();
                }

            }

            return arrImg;
        }
        public static Image ByteAImagen(byte[] arr)
        {
            Image img = null;
            using(MemoryStream ms = new MemoryStream(arr))
            {
                img=Image.FromStream(ms);
            }

            return img;
        }
    }
}
