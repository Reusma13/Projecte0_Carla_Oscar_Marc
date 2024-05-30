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
        Reserva reserva = new Reserva();
        Valoracio valoracio = new Valoracio();
        Persona persona = new Persona();

        /// <summary>
        /// Constructor de la ventana principal del usuario.
        /// </summary>
        /// <param name="p">Objeto Persona que representa al usuario actual.</param>
        public MainWindowsUsuari(Persona p)
        {
            InitializeComponent();
            ActualitzarReserves();
            persona = p;
            dgReserves.ItemsSource = reserva.ObtenirReservaList(persona.Dni); // Cridem al mètode ObtenirReserves() de la instància de ReservaBD
            dgValoracions.ItemsSource = valoracio.ObtenirValoracioClient(persona.Dni);
        }

        /// <summary>
        /// Evento de clic para crear una nueva reserva.
        /// </summary>
        private void btnNovaReserva_Click(object sender, RoutedEventArgs e)
        {
            // Creem una nova instància de la finestra de reserva
            FinestraMapa finestraMapa = new FinestraMapa(persona);
            finestraMapa.Show();
            finestraMapa.Closed += FinestraMapa_Closed; // Suscribe el evento de cierre para actualizar las reservas.
        }

        /// <summary>
        /// Evento que se dispara cuando la ventana de mapa se cierra.
        /// </summary>
        private void FinestraMapa_Closed(object sender, EventArgs e)
        {
            // Cuando se cierre la ventana de reserva, actualizamos la lista de reservas
            ActualitzarReserves();
        }

        /// <summary>
        /// Evento de clic para eliminar una reserva seleccionada.
        /// </summary>
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

        /// <summary>
        /// Actualiza la lista de reservas del usuario.
        /// </summary>
        private void ActualitzarReserves()
        {
            // Actualizamos la lista de reservas
            dgReserves.ItemsSource = null; // Limpia la lista actual.
            dgReserves.ItemsSource = reserva.ObtenirReservaList(persona.Dni); // Obtiene y muestra la lista actualizada de reservas.
        }

        /// <summary>
        /// Evento de clic para crear una nueva valoración.
        /// </summary>
        private void btnNovaValoracio_Click(object sender, RoutedEventArgs e)
        {
            FerValoracio ferValoracio = new FerValoracio(persona);
            ferValoracio.Show();
            ferValoracio.Closed += FinestraValoracio_Closed; // Suscribe el evento de cierre para actualizar las valoraciones.

        }

        /// <summary>
        /// Evento que se dispara cuando la ventana de valoración se cierra.
        /// </summary>
        private void FinestraValoracio_Closed(object sender, EventArgs e) 
        {
            ActualizarValoracions();
        }

        /// <summary>
        /// Actualiza la lista de valoraciones del usuario.
        /// </summary>
        private void ActualizarValoracions()
        {
            dgValoracions.ItemsSource = null;
            dgValoracions.ItemsSource = valoracio.ObtenirValoracioClient(persona.Dni); // Obtiene y muestra la lista actualizada de valoraciones.
        }

        /// <summary>
        /// Evento de clic para eliminar una valoración seleccionada.
        /// </summary>
        private void btnEliminarValoracio_Click(object sender, RoutedEventArgs e)
        {
            // Obtenir la valoracio seleccionada
            var valoracioSeleccionada = dgValoracions.SelectedItem as Valoracio; // Obtiene la valoración seleccionada.

            if (valoracioSeleccionada != null)
            {
                // Eliminar la valoracio seleccionada
                valoracio.DeleteValoracio(valoracioSeleccionada);

                // Actualitzar la vista de dades
                ActualizarValoracions();
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una valoracio per eliminar.");
            }
        }
    }
}
