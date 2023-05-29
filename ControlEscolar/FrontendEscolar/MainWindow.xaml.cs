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

namespace FrontendEscolar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pbPassword.Password;
            if(!validarCamposVacios (username, password))
            {
                //Iniciar sesion
            }
        }

        private bool validarCamposVacios(string username, string password)
        {
            bool camposVacios = false;
            if (string.IsNullOrEmpty(username))
            {
                lbErrorUsername.Content = "Nombre de usuario requerido";
                camposVacios = true;
            }
            else
            {
                lbErrorUsername.Content = "";
            }
            if (string.IsNullOrEmpty(password))
            {
                lbErrorPassword.Content = "Contraseña requerida";
                camposVacios = true;
            }
            else
            {
                lbErrorPassword.Content = "";
            }
            return camposVacios;
        }
    }
}
