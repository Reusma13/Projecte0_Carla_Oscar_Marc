using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projecte0.Domini;


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
                    reserva = new Reserva(Convert.ToInt32(reader["id"]), Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(), reader["Dni"].ToString(), reader["nomTaula"].ToString());
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
                string sql = $"INSERT INTO Reserva (idReserva, data, hora, numComensals, preferencies) " +
                            $"VALUES('{reserva.IdReserva}','{reserva.Data}','{reserva.Hora}','{reserva.NumComensals}','{reserva.Preferencies}');";
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
                    $"SET data = {reserva.Data}, hora = {reserva.Hora}, numComensals = {reserva.NumComensals}, preferencies = {reserva.Preferencies} WHERE IdReserva = {reserva.IdReserva}";

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
                string sql = $"DELETE * FROM reserva WHERE idReserva = {reserva.IdReserva}";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deleteReserva = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteReserva;
        }
    }
}


