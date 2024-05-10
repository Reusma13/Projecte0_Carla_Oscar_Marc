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

namespace Projecte0
{
    /// <summary>
    /// Lógica de interacción para Registrarse.xaml
    /// </summary>
    public partial class Registrarse : Window
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxDniUsuari.Text != "" && txBoxNomUsuari.Text != "" && txBoxCognom.Text != "" && pwdUsuari.Password != "")
            {
                Persona persona = new Persona(txBoxDniUsuari.Text,txBoxNomUsuari.Text,txBoxCognom.Text,pwdUsuari.Password);
                /*if (persona.ComprovarBDD())
                {

                }*/
            }
        }
    }
}
