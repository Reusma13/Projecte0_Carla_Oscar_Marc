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
using MySql.Data.MySqlClient;
using Projecte0.AccesDades;
using Projecte0.Domini;
using Projecte0.Vista;

namespace Projecte0
{
    /// <summary>
    /// Lógica de interacción para MainWindowsUsuari.xaml
    /// </summary>
    public partial class MainWindowsUsuari : Window
    {
        Connexio connexio = new Connexio();
        ReservaBD reservaBD = new ReservaBD(); // Creem una instància de ReservaBD
        public MainWindowsUsuari()
        {
            InitializeComponent();
            dgReserves.ItemsSource = reservaBD.ObtenirReserves(); // Cridem al mètode ObtenirReserves() de la instància de ReservaBD
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Creem una nova instància de la finestra de reserva
            FinestraMapa finestraMapa = new FinestraMapa();

            // Obrim la finestra de reserva
            finestraMapa.Show();
        }
    }
}
