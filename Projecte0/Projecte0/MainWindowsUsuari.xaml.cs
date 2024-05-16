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

namespace Projecte0
{
    /// <summary>
    /// Lógica de interacción para MainWindowsUsuari.xaml
    /// </summary>
    public partial class MainWindowsUsuari : Window
    {
        Connexio connexio = new Connexio();
        public MainWindowsUsuari()
        {
            InitializeComponent();
            dgReserves.ItemsSource = ObtenirReserves();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Creem una nova instància de la finestra de reserva
            FinestraMapa finestraMapa = new FinestraMapa();

            // Obrim la finestra de reserva
            finestraMapa.Show();
        }

        private List<Reserva> ObtenirReserves()
        {
            List<Reserva> reserves = new List<Reserva>();

            // Creem la consulta SQL per obtenir totes les reserves de la base de dades
            string sql = "SELECT * FROM reserves";

            // Executem la consulta SQL
            MySqlConnection mySqlConnection = connexio.ConnexioBDD();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection); 
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            // Llegim les dades de les reserves de la base de dades
            while (reader.Read())
            {
                Reserva reserva = new Reserva()
                {
                    IdReserva = reader.GetInt32("idReserva"),
                    Data = reader.GetDateTime("data"),
                    Hora = reader.GetTimeSpan("hora"),
                    NumComensals = reader.GetInt32("numComensals"),
                    Preferencies = reader.GetString("preferencies")
                };

                reserves.Add(reserva);
            }

            reader.Close();

            return reserves;
        }
    }
}
