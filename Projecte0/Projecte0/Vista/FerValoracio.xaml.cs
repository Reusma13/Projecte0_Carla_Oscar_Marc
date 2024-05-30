using Projecte0.Domini;
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

namespace Projecte0.Vista
{
    /// <summary>
    /// Lógica de interacción para FerValoracio.xaml
    /// </summary>
    public partial class FerValoracio : Window
    {
        Persona persona;
        Valoracio v;
        Restaurant restaurant;

        /// <summary>
        /// Constructor de la ventana FerValoracio.
        /// </summary>
        /// <param name="p">Objeto Persona que representa al usuario que realiza la valoración.</param>
        public FerValoracio(Persona p)
        {
            InitializeComponent();
            persona = p;
            v = new Valoracio();
            restaurant = new Restaurant();
            List<Restaurant> restaurants = restaurant.SelectRestaurantList();
            cboxRestaurant.ItemsSource = restaurants;
            cboxRestaurant.DisplayMemberPath = "Nom"; // Indica qué propiedad de los objetos Restaurant se mostrará en el ComboBox.
        }

        /// <summary>
        /// Evento de clic para el botón de realizar valoración.
        /// </summary>
        /// <param name="sender">El objeto que originó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnRealizarValoracio_Click(object sender, RoutedEventArgs e)
        {
            if(cboxRestaurant != null && txBoxComentari.Text != "" && txBoxPuntacio.Text != "")
            {
                // Creamos una nueva valoración con los datos ingresados y el DNI de la persona.
                Valoracio valoracio = new Valoracio(txBoxComentari.Text,Convert.ToInt32(txBoxPuntacio.Text),persona.Dni);
                // Insertamos la nueva valoración en la base de datos.
                v.InsertValoracio(valoracio,cboxRestaurant.SelectedItem.ToString());
            }
        }
    }
}
