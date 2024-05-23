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

        private void btnUpdateRestaurant_Click(object sender, RoutedEventArgs e)
        {
            string nomAnterior = restaurant.Nom;
            if((txBoxNomRestaurant.Text != "" && txBoxDireccioRestaurant.Text != "" && txBoxTipusCuina.Text != "" && txBoxCapacitatRestaurant.Text != "") || (txBoxNomRestaurant.Text != restaurant.Nom && txBoxDireccioRestaurant.Text != restaurant.Direccio && txBoxCapacitatRestaurant.Text != restaurant.Capacitat.ToString() && txBoxTipusCuina.Text != restaurant.TipusCuina))
            {
                Restaurant r = new Restaurant(txBoxNomRestaurant.Text, txBoxDireccioRestaurant.Text, txBoxTipusCuina.Text, Convert.ToInt32(txBoxCapacitatRestaurant.Text));
                restaurant.UpdateRestaurant(r,persona,nomAnterior);
            }
        }
    }
}
