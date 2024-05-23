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
using Projecte0.AccesDades;
using Projecte0.Domini;

namespace Projecte0.Vista
{
    /// <summary>
    /// Lógica de interacción para FinestraMapa.xaml
    /// </summary>
    public partial class FinestraMapa : Window
    {
        ReservaBD reservaBD = new ReservaBD();
        public FinestraMapa()
        {
            InitializeComponent();
            ActualizarEstadoMesas();
        }

        private void ButtonTaula1_Click(object sender, RoutedEventArgs e)
        {
            ManejarClicMesa(ButtonTaula1);
        }

        private void ButtonTaula2_Click(object sender, RoutedEventArgs e)
        {
            ManejarClicMesa(ButtonTaula2);
        }

        private void ButtonTaula3_Click(object sender, RoutedEventArgs e)
        {
            ManejarClicMesa(ButtonTaula3);
        }

        private void ButtonTaula4_Click(object sender, RoutedEventArgs e)
        {
            ManejarClicMesa(ButtonTaula4);
        }

        private void ManejarClicMesa(Button botonMesa) // He creat el ManejarClicMesa ja que els 4 botons tenien parts de codi repetides
        {
            string nomTaula = botonMesa.Content.ToString();

            if (reservaBD.EstaReservada(nomTaula))
            {
                MessageBox.Show("La mesa ya está reservada.");
                botonMesa.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                FinestraReserva finestraReserva = new FinestraReserva(nomTaula);
                finestraReserva.Show();
            }
        }

        private void ActualizarEstadoMesas()
        {
            ActualizarEstadoMesa(ButtonTaula1);
            ActualizarEstadoMesa(ButtonTaula2);
            ActualizarEstadoMesa(ButtonTaula3);
            ActualizarEstadoMesa(ButtonTaula4);
        }

        private void ActualizarEstadoMesa(Button botonMesa) // He creat aquest mètode per canviar el color del text del botó quan la taula ja esta reservada
        {
            string nomTaula = botonMesa.Content.ToString();

            if (reservaBD.EstaReservada(nomTaula))
            {
                botonMesa.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                botonMesa.Foreground = new SolidColorBrush(Colors.White);
            }
        }
    }
}
