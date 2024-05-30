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
using Projecte0.AccesDades;
using Projecte0.Domini;

namespace Projecte0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona p;

        /// <summary>
        /// Constructor de la ventana principal.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            p = new Persona();
        }

        /// <summary>
        /// Evento de clic para el botón de registro.
        /// Abre la ventana de registro y cierra la ventana actual.
        /// </summary>
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Registrarse ventanaRegistrar = new Registrarse(); // Crea una nueva ventana de registro
            ventanaRegistrar.Show(); // Muestra la ventana de registro
            this.Close(); // Cierra la ventana principal
        }

        /// <summary>
        /// Evento de clic para el botón de inicio de sesión.
        /// Verifica las credenciales y abre la ventana correspondiente al tipo de usuario.
        /// </summary>
        private void btnIniciarSessio_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxUsuari.Text != "" && pwdBoxUsuari.Password != "")
            {
                // Selecciona la persona de la base de datos con las credenciales proporcionadas.
                p = p.SelectPersona(txBoxUsuari.Text, pwdBoxUsuari.Password);
                if(p.EsAdmin.ToLower() == "si")
                {
                    MainWindowAdministrador mainWindowAdministrador = new MainWindowAdministrador(p);
                    mainWindowAdministrador.Show();
                    this.Close();
                }
                else
                {
                    MainWindowsUsuari mainWindowsUsuari = new MainWindowsUsuari(p);
                    mainWindowsUsuari.Show();
                    this.Close();
                }
            }
        }
    }
}
