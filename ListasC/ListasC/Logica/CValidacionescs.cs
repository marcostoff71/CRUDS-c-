using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ListasC.Logica
{
    class CValidacionescs
    {
        public static bool esNumEn(string text)
        {
            int num;
            bool valor;
            try
            {
                num = int.Parse(text);
                valor = true;
            }
            catch (Exception e)
            {
                valor = false;
               
            }
            return valor;
        }
        public static bool esNumDe(string text)
        {
            return double.TryParse(text, out double num);
        }
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false ;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
            }
        }
    }
}
