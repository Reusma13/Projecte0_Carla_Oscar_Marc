﻿using MySql.Data.MySqlClient;
using Projecte0.Domini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Projecte0.AccesDades
{
    public class RestaurantBD
    {
        // -------- Atribut --------
        Connexio connexio = new Connexio();
        PersonaBD personaBD = new PersonaBD();
        FotoBD fotoBD = new FotoBD();
        ReservaBD reservaBD = new ReservaBD();
        ValoracioBD valoracioBD = new ValoracioBD();


        // -------- Mètodes --------
        /// <summary>
        /// Busca a la base de dades quins Restaurants corresponen al dni
        /// </summary>
        /// <param name="dni">El DNI de l'usuari els restaurants del qual es volen obtenir</param>
        /// <returns>Una llista d'objectes Restaurant associats al DNI especificat</returns>
        public List<Restaurant> SelectRestaurantListBD(string dni)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            Restaurant restaurant = null;
            List<Restaurant> restaurants = new List<Restaurant>(); // Creem la llista de restaurant
            if (connection != null)
            {
                // Comanda sql per fer el select de tots els restaurants quan el dni es igual al dni que le hem pasat
                string sql = $"SELECT * FROM restaurant WHERE dni = '{dni}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                while (reader.Read()) // Llegim els restaurants
                {
                    // Creem el restaurant
                    restaurant = new Restaurant(reader["nom"].ToString(), reader["direccio"].ToString(), reader["tipusCuina"].ToString(), Convert.ToInt32(reader["capacitat"]));
                    restaurant.Fotos = SelectFotosRestaurant(restaurant.Nom); // Fem el select de les fotos
                    restaurant.Reserves = SelectReservasRestaurant(restaurant.Nom); // Fem el select de reserves
                    restaurant.Valoracio = SelectValoracioRestaurant(restaurant.Nom); // Fem el select de valoracio
                    restaurants.Add(restaurant); // Afegim el restaurant a la llista
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return restaurants;
        }
        /// <summary>
        /// Fa el mateix que l'anterior per directament agafa tots els restaurants, necessitem aquest metode per utilizar-lo a l'apartat d'usuari
        /// </summary>
        /// <returns>Retorna un list de restaurant</returns>
        public List<Restaurant> SelectRestaurantListBD()
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            Restaurant restaurant = null;
            List<Restaurant> restaurants = new List<Restaurant>(); 
            if (connection != null)
            {
                // Comanda sql per fer el select de tots els restaurants
                string sql = $"SELECT * FROM restaurant;";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();  // Executem la comanda
                while (reader.Read()) // Llegim els restaurants
                {
                    // Creem el restaurant
                    restaurant = new Restaurant(reader["nom"].ToString(), reader["direccio"].ToString(), reader["tipusCuina"].ToString(), Convert.ToInt32(reader["capacitat"]));
                    restaurant.Fotos = SelectFotosRestaurant(restaurant.Nom); // Fem el select de les fotos
                    restaurant.Reserves = SelectReservasRestaurant(restaurant.Nom); // Fem el select de reserves
                    restaurant.Valoracio = SelectValoracioRestaurant(restaurant.Nom); // Fem el select de valoracio
                    restaurants.Add(restaurant); // Afegim el restaurant a la llista
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return restaurants;
        }

        /// <summary>
        /// Busca a la base de dades quins Restaurant correspon al nom
        /// </summary>
        /// <param name="nom">Nom del restaurant que es vol obtenir</param>
        /// <returns>L'objecte Restaurant corresponent al nom especificat, o null si no es troba</returns>
        public Restaurant SelectRestaurantBD(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            Restaurant restaurant = null;
            if (connection != null)
            {
                // Comanda sql per fer el select de restaurant quan el nom sigui igual al nom que l'ha pasat l'usuari
                string sql = $"SELECT * FROM restaurant WHERE nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem comanda
                if (reader.Read()) // Mirem el resultat
                {
                    // Creem el restaurant + afegir fotos, reserves i valoracions
                    restaurant = new Restaurant(reader["nom"].ToString(), reader["direccio"].ToString(), reader["tipusCuina"].ToString(), Convert.ToInt32(reader["capacitat"]));
                    restaurant.Fotos = SelectFotosRestaurant(restaurant.Nom);
                    restaurant.Reserves = SelectReservasRestaurant(restaurant.Nom);
                    restaurant.Valoracio = SelectValoracioRestaurant(restaurant.Nom);
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return restaurant;
        }

        /// <summary>
        /// Busca a la base de dades quines Valoracions corresponen al nom del restaurant
        /// </summary>
        /// <param name="nom">Nom del restaurant que es volen obtenir les valoracions</param>
        /// <returns>Una llista de valoracions que correspon al restaurant</returns>
        public List<Valoracio> SelectValoracioRestaurant(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            List<Valoracio> valoracions = new List<Valoracio>();
            if (connection != null)
            {
                // Comanda sql per agafar totes les valoracions de un restaurant
                string sql = $"SELECT v.comentari, v.puntuacio, v.Dni FROM valoracio v JOIN restaurant r ON v.idRestaurant = r.id WHERE r.nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                while (reader.Read()) // Mentres hi hagi alguna cosa per llegir continuara per el bucle
                {
                    // Creem la valoracio
                    Valoracio valoracio = new Valoracio(reader["comentari"].ToString(), Convert.ToInt32(reader["puntuacio"]), reader["Dni"].ToString());
                    valoracions.Add(valoracio); // La afegim a la list de valoracions
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return valoracions;
        }

        /// <summary>
        /// Busca a la base de dades quines Fotos corresponen al nom del restaurant
        /// </summary>
        /// <param name="nom">El nom del restaurant que es vol obtenir les fotos</param>
        /// <returns>Una llista de fotos del restaurant especificat</returns>
        public List<string> SelectFotosRestaurant(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            List<string> list = new List<string>();
            if(connection != null)
            {
                // Comanda sql per agafar la url de les fotos quan el nom del restaurant coincideix i la id es igual
                string sql = $"SELECT f.url FROM fotos f JOIN restaurant r ON f.idRestaurant = r.id WHERE r.nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                while(reader.Read()) // Va llegin totes les lineas que tingui el resultat
                {
                    list.Add(reader["url"].ToString()); // Afegim a la llista
                }
                reader.Close(); // Tanquem reader
                connection.Close(); // Tanquem conexio
            }
            return list;
        }

        /// <summary>
        /// Busca a la base de dades quines Reserves corresponen al nom del restaurant
        /// </summary>
        /// <param name="nom">El nom del restaurant que es vol obtenir les reserves</param>
        /// <returns>Una llista de reserves del restaurant especificat</returns>
        public List<Reserva> SelectReservasRestaurant(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            List<Reserva> reservas = new List<Reserva>();
            if(connection != null)
            {
                // Comanda sql per agafar les reserves de un restaurant segons el nom
                string sql = $"SELECT id, r.`data` ,r.hora ,r.numComensales ,r.preferencies ,r.Dni, r.nomTaula, r.idRestaurant FROM reserva r JOIN restaurant r2 ON r.idRestaurant = r2.id WHERE r2.nom = '{nom}';"; 
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                while (reader.Read()) // Llegim les reserves
                {
                    // Creem la reserva
                    Reserva reserva = new Reserva(Convert.ToInt32(reader["id"]),Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(), reader["nomTaula"].ToString(), reader["Dni"].ToString(), Convert.ToInt32(reader["idRestaurant"]) );
                    reservas.Add(reserva); // La afegim a la llista
                }
                reader.Close(); // Tanquem reader
                connection.Close(); // Tanquem conexio
            }
            return reservas;
        }


        /// <summary>
        /// Crea un nou restaurant a la base de dades associat a un administrador específic
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant que voleu inserir a la base de dades</param>
        /// <param name="p">L'objecte Persona al qual s'associarà el restaurant</param>
        /// <returns>True si el restaurant s'ha afegit correctament, si no, false</returns>
        public bool CrearRestaurantBD(Restaurant restaurant, Persona p)
        {
            bool insertRestaurant = false; // Iniciem un bool per retornar-lo despres
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null)
            {
                if (SelectRestaurantBD(restaurant.Nom) != null) // Comprovem que el restaurant existeix
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    if (personaBD.SelectPersonesBDD(p.Dni,p.Password) is not null) // Comprovem que la persona existeix 
                    {
                        // Comanda sql per inserir el restaurant amb els seus parametres
                        string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{p.Dni}')";
                        MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                        insertRestaurant = 1 == sqlCommand.ExecuteNonQuery(); // Si la comanda ExecuteNonQuery es igual a 1 significa que l'ha inserit y es true
                    }
                    else
                    {
                        if(personaBD.InsertPersonaBDD(p)) // Si no existeix inserim la persona
                        {
                            // Comanda sql per inserir el restaurant amb els seus parametres
                            string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{p.Dni}')";
                            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                            insertRestaurant = 1 == sqlCommand.ExecuteNonQuery(); // Si la comanda ExecuteNonQuery es igual a 1 significa que l'ha inserit y es true
                        }
                        else
                        {
                            Console.WriteLine("Error.");
                        }
                    }
                    if (restaurant.Fotos is not null) // Comprovem si les fotos del restaurant que hem inserit son diferents a null
                    {
                        fotoBD.InsertFotoBD(restaurant.Fotos, restaurant); // Cridem al metode InsertFotoBD per inserir les fotos amb el restaurant pertinent
                    }

                }
            }
            return insertRestaurant;
        }

        /// <summary>
        /// Elimina un restaurant de la base de dades
        /// </summary>
        /// <param name="nom">El nom del restaurant que es vol eliminar</param>
        /// <returns>True si el restaurant s'ha eliminat correctament, si no, false</returns>
        public bool DeleteRestaurantBD(string nom)
        {
            bool deleteRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null) 
            {
                // Primer eliminem tot el que tingui una clau forana de restaurant per aixi no ens doni cap error
                fotoBD.DeleteFotoBD(nom);
                reservaBD.DeleteReservaBDD(nom);
                valoracioBD.DeleteValoracioBDD(nom);

                // Seguidament eliminem el restaurant quan el nom coincideixi amb el nom que ens a pasat l'usuari
                string sql = $"DELETE FROM restaurant WHERE nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                deleteRestaurant = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si dona 1 per aixi saber si la modificat o no
            }
            return deleteRestaurant;
        }

        /// <summary>
        /// Actualitza la informació d'un restaurant a la base de dades
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant amb la informació actualitzada</param>
        /// <param name="p">L'objecte Persona associat al restaurant</param>
        /// <param name="nomAnterior">Nom anterior que tenia el restaurant per poder fer el update segons el nom</param>
        /// <returns>True si el restaurant s'ha actualitzat correctament, si no, false</returns>
        public bool UpdateRestaurantBD(Restaurant restaurant, Persona p, string nomAnterior)
        {
            bool updateRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null) 
            {
                // Comanda sql per fer el update de restaurant segons el nomAnterior que tenia i assignar-li els nous parametres
                string sql = $"UPDATE restaurant SET nom = '{restaurant.Nom}',direccio = '{restaurant.Direccio}', tipusCuina = '{restaurant.TipusCuina}', capacitat = '{restaurant.Capacitat}', Dni = '{p.Dni}' WHERE nom = '{nomAnterior}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                updateRestaurant = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda sql i comprovem si a donat 1 per posar la variable a true o false
            }
            return updateRestaurant;
        }
    }
}
