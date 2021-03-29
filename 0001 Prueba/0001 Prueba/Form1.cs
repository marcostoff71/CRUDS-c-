using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0001_Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserControl1 u1 = new UserControl1();
            u1.Show();
            panelconte.Controls.Clear();
            u1.Dock = DockStyle.Fill;
            panelconte.Controls.Add(u1);
        }
    }
}
