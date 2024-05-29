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
    /// Lógica de interacción para FinestraModificarRestaurant.xaml
    /// </summary>
    public partial class FinestraModificarRestaurant : Window
    {
        Restaurant restaurant;
        Persona persona;

        /// <summary>
        /// Constructor de la ventana de modificación de restaurante.
        /// </summary>
        /// <param name="nom">Nombre del restaurante a modificar.</param>
        /// <param name="p">Usuario que realiza la modificación.</param>
        public FinestraModificarRestaurant(string nom,Persona p)
        {
            this.persona = p;
            InitializeComponent();
            restaurant = new Restaurant();
            restaurant = restaurant.SelectRestaurant(nom);
            txBoxNomRestaurant.Text = restaurant.Nom;
            txBoxDireccioRestaurant.Text = restaurant.Direccio;
            txBoxTipusCuina.Text = restaurant.TipusCuina;
            txBoxCapacitatRestaurant.Text = restaurant.Capacitat.ToString();
        }

        /// <summary>
        /// Evento de clic para el botón de actualizar restaurante.
        /// Recoge los datos modificados y actualiza la información del restaurante en la base de datos.
        /// </summary>
        private void btnUpdateRestaurant_Click(object sender, RoutedEventArgs e)
        {
            string nomAnterior = restaurant.Nom; // Guarda el nombre anterior del restaurante.
            if ((txBoxNomRestaurant.Text != "" && txBoxDireccioRestaurant.Text != "" && txBoxTipusCuina.Text != "" && txBoxCapacitatRestaurant.Text != "") || (txBoxNomRestaurant.Text != restaurant.Nom && txBoxDireccioRestaurant.Text != restaurant.Direccio && txBoxCapacitatRestaurant.Text != restaurant.Capacitat.ToString() && txBoxTipusCuina.Text != restaurant.TipusCuina))
            {
                // Crea una nueva instancia de Restaurant con los datos modificados.
                Restaurant r = new Restaurant(txBoxNomRestaurant.Text, txBoxDireccioRestaurant.Text, txBoxTipusCuina.Text, Convert.ToInt32(txBoxCapacitatRestaurant.Text));
                restaurant.UpdateRestaurant(r,persona,nomAnterior); // Actualiza la información del restaurante en la base de datos.
                this.Close(); // Cierra la ventana de modificación.
            }
        }
    }
}
