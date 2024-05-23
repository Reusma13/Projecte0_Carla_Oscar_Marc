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
        public FinestraModificarRestaurant(string nom)
        {
            InitializeComponent();
            restaurant = new Restaurant();
            restaurant = restaurant.SelectRestaurant(nom);
            txBoxNomRestaurant.Text = restaurant.Nom;

        }
    }
}
