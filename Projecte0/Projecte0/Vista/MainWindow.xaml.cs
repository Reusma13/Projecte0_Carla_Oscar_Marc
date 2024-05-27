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
        
        public MainWindow()
        {
            InitializeComponent();
            p = new Persona();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Registrarse ventanaRegistrar = new Registrarse();
            ventanaRegistrar.Show();
            this.Close();
        }

        private void btnIniciarSessio_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxUsuari.Text != "" && pwdBoxUsuari.Password != "")
            {
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
