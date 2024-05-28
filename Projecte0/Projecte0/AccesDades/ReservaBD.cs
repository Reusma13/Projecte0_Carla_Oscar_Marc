using MySql.Data.MySqlClient;
using Projecte0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Projecte0.Domini;
using Projecte0.Vista;
using System.Reflection.PortableExecutable;

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
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            Reserva reserva = null;
            if (connection != null)
            {
                // Comanda sql per seleccionar la reserva
                string sql = $"SELECT * FROM reserva WHERE IdReserva = '{idReserva}'";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                if (reader.Read()) // Mira si existeix la reserva
                {
                    // Creem la reserva
                    reserva = new Reserva(Convert.ToInt32(reader["id"]), Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(),  reader["nomTaula"].ToString(), reader["Dni"].ToString(), Convert.ToInt32(reader["idRestaurant"]));
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return reserva;
        }
      
        /// <summary>
        /// Serveix per inserir una reserva a la base de dades
        /// </summary>
        /// <param name="reserva">Li pasem la reserva</param>
        /// <param name="dni">Li pasem el dni del usuari</param>
        /// <param name="nomRestaurant">Li pasem el nom del restaurant on vol fer la reserva</param>
        /// <returns>Si inseriex la reserva retorna true, sino retorna false</returns>
        public bool InsertReservaBDD(Reserva reserva, string dni, string nomRestaurant)
        {
            bool inseritReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Formateja la data al format 'YYYY-MM-DD'
                string dataFormateada = reserva.Data.ToString("yyyy-MM-dd");
                // Comanda sql per fer l'insert de la reserva
                string sql = $"INSERT INTO Reserva (data, hora, numComensales, preferencies, Dni, idRestaurant,nomTaula) " +
                            $"VALUES('{dataFormateada}','{reserva.Hora}','{reserva.NumComensals}','{reserva.Preferencies}','{dni}',(SELECT id FROM Restaurant WHERE nom = '{nomRestaurant}'),'{reserva.NomTaula}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritReserva = 1 == sqlCommand.ExecuteNonQuery(); // Executa y comprova que s'ha fet l'insert correctament
            }
            connection.Close(); // Tanquem la conexio
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
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Comanda sql per fer l'update de la reserva
                string sql = $"UPDATE reserva " +
                    $"SET data = {reserva.Data}, hora = {reserva.Hora}, numComensals = {reserva.NumComensals}, preferencies = {reserva.Preferencies}, nomTaula = {reserva.NomTaula} WHERE IdReserva = {reserva.IdReserva}";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                updateReserva = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda y mirem si s'ha afegit a la base de dades
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
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Comanda sql per fer delete quan l'id sigui igual a l'id d'usuari
                string sql = $"DELETE FROM reserva WHERE idReserva = {reserva.IdReserva}";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deleteReserva = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si s'ha eliminat correctament
            }
            connection.Close(); // Tanquem la conexio
            return deleteReserva;
        }
        /// <summary>
        /// Serveix per eliminar totes les reserves del X restaurant
        /// </summary>
        /// <param name="nom">Pasem el nom del restaurant</param>
        /// <returns>Ens retorna true si l'ha eliminat, retorna false si no les a eliminat</returns>
        public bool DeleteReservaBDD(string nom)
        {
            bool deleteReserva = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Comanda sql per eliminar totes les reserves quan l'idRestaurant sigui igual al id de la taula restaurant quan el nom sigui igual al nom que ens a pasat l'usuari
                string sql = $"DELETE FROM reserva WHERE idRestaurant = (SELECT id FROM restaurant WHERE nom = '{nom}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deleteReserva = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i mirem si s'ha eliminat correctament
            }
            connection.Close(); // Tanquem la conexio
            return deleteReserva;
        }
        /// <summary>
        /// Serveix per obtenir totes les reserves de X usuari
        /// </summary>
        /// <param name="dni">Dni del usuari que vol agafar totes les reserves</param>
        /// <returns>Retorna un list de reserva</returns>
        public List<Reserva> ObtenirReserves(string dni)
        {
            List<Reserva> reserves = new List<Reserva>();

            // Creem la consulta SQL per obtenir totes les reserves de la base de dades quan el dni que li pasem sigui igual al dni que existeix a la base de dades
            string sql = $"SELECT * FROM reserva WHERE dni = '{dni}';";

            // Executem la consulta SQL
            MySqlConnection mySqlConnection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader(); // Executem la comanda

            // Llegim les dades de les reserves de la base de dades
            while (reader.Read())
            {
                Reserva reserva = new Reserva()
                {
                    // Posem tots els parametres de la reserva
                    IdReserva = reader.GetInt32("idReserva"),
                    Data = reader.GetDateTime("data"),
                    Hora = reader.GetTimeSpan("hora"),
                    NumComensals = reader.GetInt32("numComensales"),
                    Preferencies = reader.GetString("preferencies"),
                    Dni = reader.GetString("Dni"),
                    IdRestaurant = reader.GetInt32("idRestaurant"),
                    NomTaula = reader.GetString("nomTaula")
                };

                reserves.Add(reserva); // Afegim la reserva a la llista
            }
            reader.Close(); // Tanquem el reader
            mySqlConnection.Close(); // Tanquem la conexio
            return reserves;
        }
        /// <summary>
        /// Metode per veure si la taula ja esta reservada
        /// </summary>
        /// <param name="nomTaula">Nom de la taula que volem saber si esta reservada</param>
        /// <returns>Retorna true si esta reservada retorna true, sino retorna false</returns>
        public bool EstaReservada(string nomTaula)
        {
            using (MySqlConnection mySqlConnection = connexio.ConnexioBDD()) // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            {
                // Comanda sql per saber si esta reservada aquella taula
                string query = "SELECT COUNT(*) FROM Reserva WHERE nomTaula = @nomTaula"; 

                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                cmd.Parameters.AddWithValue("@nomTaula", nomTaula); // Afegim el valor a @nomTaula

                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Executem la comanda i el resultat el convertim en int

                return count > 0; // Mirem si el valor es major a 0
            }
        }
    }
}


