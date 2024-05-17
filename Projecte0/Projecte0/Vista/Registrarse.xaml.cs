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
using System.Windows.Shapes;
using Projecte0.Domini;

namespace Projecte0
{
    /// <summary>
    /// Lógica de interacción para Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Window
    {
        Persona persona;
        public Registrarse()
        {
            persona = new Persona();
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxDniUsuari.Text != "" && txBoxNomUsuari.Text != "" && txBoxCognom.Text != "" && pwdUsuari.Password != "")
            {
                Persona p = persona.SelectPersona(txBoxDniUsuari.Text, pwdUsuari.Password);
                if (p is not null)
                {
                    MessageBox.Show("Error. Usuari ja existent");
                }
                else
                {
                    p = new Persona(txBoxDniUsuari.Text,txBoxNomUsuari.Text,txBoxCognom.Text,pwdUsuari.Password);
                    persona.InsertPersona(p);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
