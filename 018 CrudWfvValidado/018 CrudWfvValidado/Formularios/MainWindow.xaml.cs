using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _018_CrudWfvValidado.Logica;
using _018_CrudWfvValidado.Formularios;

namespace _018_CrudWfvValidado.Formularios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiciosPersona acceso;
        public MainWindow()
        {
            InitializeComponent();
            acceso = new ServiciosPersona();
            
            
        }
        private async Task ListarPersonas()
        {
            dgDatosPersona.ItemsSource = await this.acceso.Obtener();
        }

        private async Task Eliminar(int pId)
        {
            MessageBoxResult re = MessageBox.Show("Seguro de eliminar", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (re == MessageBoxResult.Yes)
            {
                bool valor = await this.acceso.Eliminar(pId);
                if (!valor)
                {
                    MessageBox.Show("El registro ya ha sido eliminado o uno huno un error");
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ListarPersonas();
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            await Eliminar(id);
            await ListarPersonas();
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            Registro oRegistro = new Registro(id);
            oRegistro.ShowDialog();
            await ListarPersonas();
        }

        private async void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            await ListarPersonas();
        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Registro oRegistro = new Registro();
            oRegistro.ShowDialog();
            await ListarPersonas();
        }

        private async void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBuscar.Text = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                await ListarPersonas();
            }
            else
            {
                dgDatosPersona.ItemsSource = await this.acceso.BuscarPer(txtBuscar.Text);
            }
        }

        
    }
}
