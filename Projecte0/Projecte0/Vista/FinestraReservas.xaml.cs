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
        public FinestraReserva(string nomTaula, Persona p)
        {
            InitializeComponent();

            _nomTaula = nomTaula;
            persona = p;
        }

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
            ReservaBD reservaBD = new ReservaBD();
            reservaBD.InsertReservaBDD(novaReserva, persona.Dni);

            // Tanquem la finestra de reserva
            this.Close();
        }
    }
}
