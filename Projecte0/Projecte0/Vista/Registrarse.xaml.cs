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
                // Intenta seleccionar una persona existente con el DNI y la contraseña proporcionados.
                Persona p = persona.SelectPersona(txBoxDniUsuari.Text, pwdUsuari.Password);
                if (p is not null)
                {
                    MessageBox.Show("Error. Usuari ja existent");
                }
                else
                {
                    // Si la persona no existe, crea una nueva instancia y la inserta en la base de datos.
                    p = new Persona(txBoxDniUsuari.Text,txBoxNomUsuari.Text,txBoxCognom.Text,pwdUsuari.Password); 
                    persona.InsertPersona(p); // Inserta la nueva persona en la base de datos.
                    MainWindow mainWindow = new MainWindow(); // Crea una nueva ventana principal.
                    mainWindow.Show();// Muestra la ventana principal.
                    this.Close(); // Cierra la ventana de registro.
                }
            }
        }
    }
}
