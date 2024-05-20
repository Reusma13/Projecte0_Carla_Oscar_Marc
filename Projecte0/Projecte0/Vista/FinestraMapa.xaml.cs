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
    /// Lógica de interacción para FinestraMapa.xaml
    /// </summary>
    public partial class FinestraMapa : Window
    {
        public FinestraMapa()
        {
            InitializeComponent();
        }

        private void ButtonTaula1_Click(object sender, RoutedEventArgs e)
        {
            // Obtenim el nom de la taula del botó
            string nomTaula = ButtonTaula1.Content.ToString();

            // Ara pots obrir la finestra de reserva amb la taula seleccionada
            FinestraReservas finestraReserva = new FinestraReservas(nomTaula);
            finestraReserva.Show();
        }

        private void ButtonTaula2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTaula3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTaula4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
