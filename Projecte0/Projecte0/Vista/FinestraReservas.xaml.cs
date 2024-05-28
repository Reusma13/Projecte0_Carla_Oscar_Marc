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
using Projecte0.AccesDades;

namespace Projecte0.Vista
{
    /// <summary>
    /// Lógica de interacción para FinestraReserva.xaml
    /// </summary>
    public partial class FinestraReserva : Window
    {
        private string _nomTaula;
        Persona persona;
        string nom;

        /// <summary>
        /// Constructor de la ventana de reserva.
        /// </summary>
        /// <param name="nomTaula">Nombre de la mesa para la reserva.</param>
        /// <param name="p">Usuario que realiza la reserva.</param>
        /// <param name="nom">Nombre del restaurante donde se realiza la reserva.</param>
        public FinestraReserva(string nomTaula, Persona p, string nom)
        {
            InitializeComponent();

            _nomTaula = nomTaula;
            persona = p;
            this.nom = nom;
        }

        /// <summary>
        /// Evento de clic para el botón de reservar.
        /// Recoge los datos de la reserva y los guarda en la base de datos.
        /// </summary>
        private void btnReservar_Click(object sender, RoutedEventArgs e)
        {
            // Recollim les dades de la reserva dels controls
            DateTime data = dpData.SelectedDate.Value;
            TimeSpan hora = TimeSpan.Parse(tbHora.Text);
            int numComensals = Convert.ToInt32(tbNumComensals.Text);
            string preferencies = tbPreferencies.Text;
            string dataFormateada = data.ToString("yyyy-MM-dd"); // data formatejada

            // Creem una nova reserva amb aquestes dades
            Reserva novaReserva = new Reserva()
            {
                Data = DateTime.Parse(dataFormateada),
                Hora = hora,
                NumComensals = numComensals,
                Preferencies = preferencies,
                NomTaula = _nomTaula
            };

            // Guardem la nova reserva a la base de dades
            Reserva reserva = new Reserva();
            reserva.InsertReserva(novaReserva, persona.Dni,nom);

            // Tanquem la finestra de reserva
            this.Close();
        }
    }
}
