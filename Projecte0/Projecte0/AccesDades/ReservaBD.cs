using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Projecte0.Domini;
using Projecte0.Vista;


namespace Projecte0.AccesDades
{
    public class ReservaBD
	  {
        // -------- Atribut --------
        Connexio connexio = new Connexio();

        // -------- Mètodes --------
        public Reserva SelectReservaBDD(int idReserva)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            Reserva reserva = null;
            if (connection != null)
            {
                string sql = $"SELECT * FROM reserva WHERE IdReserva = '{idReserva}'";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    reserva = new Reserva(Convert.ToInt32(reader["id"]), Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(),  reader["nomTaula"].ToString(), reader["Dni"].ToString(), Convert.ToInt32(reader["idRestaurant"]));
                }
                reader.Close();
                connection.Close();
            }
            return reserva;
        }

        public bool InsertReservaBDD(Reserva reserva)
        {
            bool inseritReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                // Formateja la data al format 'YYYY-MM-DD'
                string dataFormateada = reserva.Data.ToString("yyyy-MM-dd");

                string sql = $"INSERT INTO Reserva (idReserva, data, hora, numComensales, preferencies, Dni, idRestaurant,nomTaula) " +
                            $"VALUES('{reserva.IdReserva}','{dataFormateada}','{reserva.Hora}','{reserva.NumComensals}','{reserva.Preferencies}', '12345678A',1,'{reserva.NomTaula}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritReserva = 1 == sqlCommand.ExecuteNonQuery();
            }
            return inseritReserva;
        }

        public bool UpdateReservaBDD(Reserva reserva)
        {
            bool updateReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"UPDATE reserva " +
                    $"SET data = {reserva.Data}, hora = {reserva.Hora}, numComensals = {reserva.NumComensals}, preferencies = {reserva.Preferencies}, nomTaula = {reserva.NomTaula} WHERE IdReserva = {reserva.IdReserva}";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                updateReserva = 1 == sqlCommand.ExecuteNonQuery();
            }
            return updateReserva;
        }

        public bool DeleteReservaBDD(Reserva reserva)
        {
            bool deleteReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"DELETE FROM reserva WHERE idReserva = {reserva.IdReserva}";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deleteReserva = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteReserva;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Creem una nova instància de la finestra de reserva
            FinestraMapa finestraMapa = new FinestraMapa();

            // Obrim la finestra de reserva
            finestraMapa.Show();
        }

        public List<Reserva> ObtenirReserves()
        {
            List<Reserva> reserves = new List<Reserva>();

            // Creem la consulta SQL per obtenir totes les reserves de la base de dades
            string sql = "SELECT * FROM Reserva";

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
                    NumComensals = reader.GetInt32("numComensales"),
                    Preferencies = reader.GetString("preferencies"),
                    Dni = reader.GetString("Dni"),
                    IdRestaurant = reader.GetInt32("idRestaurant"),
                    NomTaula = reader.GetString("nomTaula")
                };

                reserves.Add(reserva);
            }

            reader.Close();

            return reserves;
        }
    }
}


