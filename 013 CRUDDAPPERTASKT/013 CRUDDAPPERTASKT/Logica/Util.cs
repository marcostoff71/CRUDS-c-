using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _013_CRUDDAPPERTASKT.Logica
{
    public static class Util
    {
        public static void BorrarEspacios(ref TextBox e)
        {
            e.Text = e.Text.Trim();
        }
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static bool EsNumInt(string texto)
        {
            return int.TryParse(texto, out int num);
        }
    }
}
