using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _013_CRUDDAPPERTASKT.Logica;

namespace _013_CRUDDAPPERTASKT.Formularios
{
    public partial class VistaDatos : UserControl
    {
        private Acceso acceso;
        public  VistaDatos()
        {
            InitializeComponent();

            this.acceso = new Acceso();
            
        }
        private async Task Refrescar()
        {
            dgDatos.DataSource = await acceso.ObtenerPersonas();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await Refrescar();
        }
    }
}
