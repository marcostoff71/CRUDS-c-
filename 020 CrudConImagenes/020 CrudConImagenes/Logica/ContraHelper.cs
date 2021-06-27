using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace _020_CrudConImagenes.Logica
{
    public static class ContraHelper
    {
        public static string GetSha226Ascii(string texto)
        {
            string sha="";
            var d = SHA256Managed.Create();
            byte[] ascii=d.ComputeHash(ASCIIEncoding.ASCII.GetBytes(texto));

            for (int i = 0; i < ascii.Length; i++)
            {
                sha += i.ToString("X2");
            }

            return sha;

        }
        public static string GetSha226Utf8(string texto)
        {
            string sha = "";
            var d = SHA256Managed.Create();
            byte[] ascii = d.ComputeHash(ASCIIEncoding.UTF8.GetBytes(texto));

            for (int i = 0; i < ascii.Length; i++)
            {
                sha += i.ToString("X2");
            }

            return sha;
        }
        public static void QuitaEspacios(this TextBox textBox) => textBox.Text = textBox.Text.Trim();
    }
}
