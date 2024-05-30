using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
using Microsoft.Win32;
using Projecte0.Domini;
using Projecte0.Vista;

namespace Projecte0
{
    /// <summary>
    /// Lógica de interacción para MainWindowAdministrador.xaml
    /// </summary>
    public partial class MainWindowAdministrador : Window
    {
        private List<Restaurant> restaurants;
        private Valoracio valoracio;
        Restaurant restaurant;
        Persona p;
        List<string> lineas; // Lista para almacenar las líneas de un archivo, como las URLs de las fotos de los restaurantes.
        string[] lineas2;  // Array para almacenar temporalmente las líneas leídas de un archivo.

        /// <summary>
        /// Constructor de la ventana de administrador.
        /// </summary>
        /// <param name="p">Objeto Persona que representa al administrador.</param>
        public MainWindowAdministrador(Persona p)
        {
            this.p = p;
            InitializeComponent();
            restaurant = new Restaurant();
            List<Restaurant> restaurants = restaurant.SelectRestaurantList(p.Dni);
            cBoxRestaurant.ItemsSource = restaurants;
            cBoxRestaurant.DisplayMemberPath = "Nom";
            valoracio = new Valoracio();
            cBoxRestaurants.ItemsSource = restaurants;
            cBoxRestaurants.DisplayMemberPath = "Nom";
        }

        /// <summary>
        /// Actualiza la lista de valoraciones mostradas en la interfaz.
        /// </summary>
        private void UpdateValoracions()
        {
            if (cBoxRestaurants.SelectedItem != null)
            {
                string nomRestaurant = cBoxRestaurants.SelectedItem.ToString();
                List<Valoracio> valoracions = valoracio.ObtenirValoracions(nomRestaurant);
                dgValoracions.ItemsSource = valoracions;
            }
        }

        /// <summary>
        /// Actualiza la lista de valoraciones del restaurante seleccionado.
        /// </summary>
        private void btnActualizarValoracions_Click(object sender, RoutedEventArgs e)
        {
            UpdateValoracions();
        }

        /// <summary>
        /// Maneja el cambio de selección en el ComboBox de restaurantes, actualizando las valoraciones correspondientes.
        /// </summary>
        private void cBoxRestaurant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cBoxRestaurant.SelectedItem != null)
            {
                UpdateValoracions();
            }
        }

        /// <summary>
        /// Abre un cuadro de diálogo para cargar fotos desde un archivo.
        /// </summary>
        private void btnCargarFotos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Creamos la ventana para seleccionar un fichero
            if (openFileDialog.ShowDialog() == true) // Si selecciona un fichero entra por el if
            {
                lineas2 = File.ReadAllLines(openFileDialog.FileName); // Lee todas las lineas del fichero y las pone en un array
                lineas = new List<string>();
                for (int i = 0; i < lineas2.Length; i++)
                {
                    lineas.Add(lineas2[i]);
                }
            }
        }

        /// <summary>
        /// Crea un nuevo restaurante con la información proporcionada y lo añade a la base de datos si no existe previamente.
        /// </summary>
        private void btnCrearRestaurant_Click(object sender, RoutedEventArgs e)
        {
            Restaurant r;
            if (txBoxNomRestaurant.Text != "" && txBoxDireccioRestaurant.Text != "" && txBoxTipusCuina.Text != "" && txBoxCapacitatRestaurant.Text != "" && (txBoxURLFotoRestaurant.Text != "" || lineas != null))
            {
                if (restaurant.SelectRestaurant(txBoxNomRestaurant.Text) == null)
                {
                    if (lineas != null)
                    {
                        r = new Restaurant(txBoxNomRestaurant.Text, txBoxDireccioRestaurant.Text, txBoxTipusCuina.Text, Convert.ToInt32(txBoxCapacitatRestaurant.Text), lineas, null, null);
                    }
                    else
                    {
                        lineas = new List<string>();
                        lineas.Add(txBoxURLFotoRestaurant.Text);
                        r = new Restaurant(txBoxNomRestaurant.Text, txBoxDireccioRestaurant.Text,txBoxTipusCuina.Text,Convert.ToInt32(txBoxCapacitatRestaurant.Text),lineas,null,null);
                    }
                    restaurant.InsertRestaurant(r, p);
                }
                else
                {
                    MessageBox.Show("Restaurant ja existent.");
                }
            }
        }

        /// <summary>
        /// Abre la ventana para modificar la información del restaurante seleccionado.
        /// </summary>
        private void btnModificarRestaurant_Click(object sender, RoutedEventArgs e)
        {
            string nom = cBoxRestaurant.SelectedItem.ToString();
            FinestraModificarRestaurant finestraModificarRestaurant = new FinestraModificarRestaurant(nom, p);
            finestraModificarRestaurant.Show();
        }

        /// <summary>
        /// Actualiza la lista de restaurantes mostrada en el ComboBox.
        /// </summary>
        private void btnActualizarRestaurant_Click(object sender, RoutedEventArgs e)
        {
            restaurants = restaurant.SelectRestaurantList(p.Dni);
            cBoxRestaurant.ItemsSource = restaurants;
            cBoxRestaurant.DisplayMemberPath = "Nom";
        }

        /// <summary>
        /// Elimina el restaurante seleccionado de la base de datos.
        /// </summary>
        private void btnEliminarRestaurant_Click_1(object sender, RoutedEventArgs e)
        {
            string nom = cBoxRestaurant.SelectedItem.ToString();
            restaurant.DeleteRestaurant(nom);
        }
    }
}
