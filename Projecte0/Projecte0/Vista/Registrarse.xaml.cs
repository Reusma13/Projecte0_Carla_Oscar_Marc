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

        /// <summary>
        /// Manejador del evento de clic en el botón de registrar.
        /// Si el usuario y la contraseña son correctos, crea una nueva persona, la inserta en la base de datos, abre la ventana principal y cierra la ventana actual.
        /// </summary>
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
