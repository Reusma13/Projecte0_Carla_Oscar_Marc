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
        public FerValoracio(Persona p)
        {
            InitializeComponent();
            persona = p;
            v = new Valoracio();
            restaurant = new Restaurant();
            List<Restaurant> restaurants = restaurant.SelectRstaurantList();
            cboxRestaurant.ItemsSource = restaurants;
            cboxRestaurant.DisplayMemberPath = "Nom";
        }

        private void btnRealizarValoracio_Click(object sender, RoutedEventArgs e)
        {
            if(cboxRestaurant != null && txBoxComentari.Text != "" && txBoxPuntacio.Text != "")
            {
                Valoracio valoracio = new Valoracio(txBoxComentari.Text,Convert.ToInt32(txBoxPuntacio.Text),persona.Dni);
                v.InsertValoracio(valoracio,cboxRestaurant.SelectedItem.ToString());
            }
        }
    }
}
