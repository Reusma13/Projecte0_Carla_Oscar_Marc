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
        Reserva reserva = new Reserva();
        Persona persona = new Persona();
        public MainWindowsUsuari(Persona p)
        {
            InitializeComponent();
            ActualitzarReserves();
            persona = p;
            //dgReserves.ItemsSource = reservaBD.ObtenirReserves(); // Cridem al mètode ObtenirReserves() de la instància de ReservaBD
        }

        private void btnNovaReserva_Click(object sender, RoutedEventArgs e)
        {
            // Creem una nova instància de la finestra de reserva
            FinestraMapa finestraMapa = new FinestraMapa(persona);

            finestraMapa.Closed += FinestraMapa_Closed; // Añadimos un manejador de eventos para cuando se cierre la ventana

            // Obrim la finestra de reserva
            finestraMapa.Show();
        }

        private void FinestraMapa_Closed(object sender, EventArgs e)
        {
            // Cuando se cierre la ventana de reserva, actualizamos la lista de reservas
            ActualitzarReserves();
        }

        private void btnEliminarReserva_Click(object sender, RoutedEventArgs e)
        {
            // Obtenir la reserva seleccionada
            var reservaSeleccionada = dgReserves.SelectedItem as Reserva;

            if (reservaSeleccionada != null)
            {
                // Eliminar la reserva seleccionada
                reserva.DeleteReserva(reservaSeleccionada);

                // Actualitzar la vista de dades
                ActualitzarReserves();
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una reserva per eliminar.");
            }
        }

        private void ActualitzarReserves()
        {
            // Actualizamos la lista de reservas
            dgReserves.ItemsSource = null;
            dgReserves.ItemsSource = reserva.ObtenirReservaList(persona.Dni);
        }
    }
}
