using MySql.Data.MySqlClient;
using Projecte0;
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
        /// <summary>
        /// Busca a la base de dades quina Reserva correspon al idReserva
        /// </summary>
        /// <param name="idReserva">id de la Reserva que vols seleccionar</param>
        /// <returns>El objecte Reserva de la reserva seleccionada, o null si no es troba</returns>
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



        /// <summary>
        /// Insereix una nova reserva a la base de dades
        /// </summary>
        /// <param name="reserva">Reserva la qual es vol insertar</param>
        /// <returns>True si la reserva s'ha afegit correctament, si no, false</returns>
        public bool InsertReservaBDD(Reserva reserva)
        {
            bool inseritReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"INSERT INTO Reserva (idReserva, data, hora, numComensals, preferencies) " +
                            $"VALUES('{reserva.IdReserva}','{reserva.Data}','{reserva.Hora}','{reserva.NumComensals}','{reserva.Preferencies}'), '{reserva.NomTaula}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritReserva = 1 == sqlCommand.ExecuteNonQuery();
            }
            return inseritReserva;
        }

        /// <summary>
        /// Actualitza una nova reserva a la base de dades
        /// </summary>
        /// <param name="reserva">Reserva la qual es vol actualitzar</param>
        /// <returns>True si la reserva s'ha actualitzat correctament, si no, false</returns>
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

        /// <summary>
        /// Eliminar una reserva a la base de dades
        /// </summary>
        /// <param name="reserva">Reserva la qual es vol eliminar</param>
        /// <returns>True si la reserva s'ha eliminat correctament, si no, false</returns>
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


