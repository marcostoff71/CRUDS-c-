using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _014_CRUDSQLControl.Logica
{
    class ValiTextbox
    {
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }
        public static void SoloNumerosF(TextBox text,KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else if (e.KeyChar=='.'&&text.Text.Contains(".")==false)
            {
                e.Handled = false;
            }else if (e.KeyChar == ',' && text.Text.Contains(".") == false)
            {
                e.KeyChar = '.';
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
