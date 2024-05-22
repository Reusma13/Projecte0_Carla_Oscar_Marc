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
using Projecte0.AccesDades;
using Projecte0.Domini;

namespace Projecte0.Vista
{
    /// <summary>
    /// Lógica de interacción para FinestraMapa.xaml
    /// </summary>
    public partial class FinestraMapa : Window
    {
        Restaurant restaurant;
        List<Restaurant> restaurants;
        Restaurant restaurantSeleccionat;

        public FinestraMapa(Persona p)
        {
            InitializeComponent();
            restaurant = new Restaurant();
            restaurants = restaurant.SelectRestaurantList(p.Dni);
            cBoxRestaurantMapa.ItemsSource = restaurants;
            cBoxRestaurantMapa.DisplayMemberPath = "Nom";
        }

        private void ButtonTaula1_Click(object sender, RoutedEventArgs e)
        {
            //Llegeix el restaurant
            restaurantSeleccionat = cBoxRestaurantMapa.SelectedItem as Restaurant;

            // Obtenim el nom de la taula del botó
            string nomTaula = ButtonTaula1.Content.ToString();

            // Ara pots obrir la finestra de reserva amb la taula seleccionada
            FinestraReserva finestraReserva = new FinestraReserva(nomTaula);
            finestraReserva.Show();
        }

        private void ButtonTaula2_Click(object sender, RoutedEventArgs e)
        {
            restaurantSeleccionat = cBoxRestaurantMapa.SelectedItem as Restaurant;
            string nomTaula = ButtonTaula2.Content.ToString();
            FinestraReserva finestraReserva = new FinestraReserva(nomTaula);
            finestraReserva.Show();
        }

        private void ButtonTaula3_Click(object sender, RoutedEventArgs e)
        {
            restaurantSeleccionat = cBoxRestaurantMapa.SelectedItem as Restaurant;
            string nomTaula = ButtonTaula3.Content.ToString();
            FinestraReserva finestraReserva = new FinestraReserva(nomTaula);
            finestraReserva.Show();
        }

        private void ButtonTaula4_Click(object sender, RoutedEventArgs e)
        {
            restaurantSeleccionat = cBoxRestaurantMapa.SelectedItem as Restaurant;
            string nomTaula = ButtonTaula4.Content.ToString();
            FinestraReserva finestraReserva = new FinestraReserva(nomTaula);
            finestraReserva.Show();
        }
    }
}
