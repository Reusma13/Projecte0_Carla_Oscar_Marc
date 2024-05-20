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
    /// Lógica de interacción para MainWindowAdministrador.xaml
    /// </summary>
    public partial class MainWindowAdministrador : Window
    {
        Restaurant restaurant;
        public MainWindowAdministrador(Persona p)
        {
            InitializeComponent();
            restaurant = new Restaurant();
            List<Restaurant> restaurants = restaurant.SelectRestaurantList(p.Dni);
            cBoxRestaurant.ItemsSource = restaurants;
        }
    }
}
