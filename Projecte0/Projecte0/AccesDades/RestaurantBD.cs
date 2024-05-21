using MySql.Data.MySqlClient;
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

        // -------- Mètodes --------
        /// <summary>
        /// Busca a la base de dades quins Restaurants corresponen al dni
        /// </summary>
        /// <param name="dni">El DNI de l'usuari els restaurants del qual es volen obtenir</param>
        /// <returns>Una llista d'objectes Restaurant associats al DNI especificat</returns>
        public List<Restaurant> SelectRestaurantListBD(string dni)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            Restaurant restaurant = null;
            List<Restaurant> restaurants = new List<Restaurant>();
            if (connection != null)
            {
                string sql = $"SELECT * FROM restaurant WHERE dni = '{dni}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    restaurant = new Restaurant(reader["nom"].ToString(), reader["direccio"].ToString(), reader["tipusCuina"].ToString(), Convert.ToInt32(reader["capacitat"]));
                    restaurant.Fotos = SelectFotosRestaurant(restaurant.Nom);
                    restaurant.Reserves = SelectReservasRestaurant(restaurant.Nom);
                    restaurant.Valoracio = SelectValoracioRestaurant(restaurant.Nom);
                    restaurants.Add(restaurant);
                }
                reader.Close();
                connection.Close();
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
            MySqlConnection connection = connexio.ConnexioBDD();
            Restaurant restaurant = null;
            if (connection != null)
            {
                string sql = $"SELECT * FROM restaurant WHERE nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    restaurant = new Restaurant(reader["nom"].ToString(), reader["direccio"].ToString(), reader["tipusCuina"].ToString(), Convert.ToInt32(reader["capacitat"]));
                    restaurant.Fotos = SelectFotosRestaurant(restaurant.Nom);
                    restaurant.Reserves = SelectReservasRestaurant(restaurant.Nom);
                    restaurant.Valoracio = SelectValoracioRestaurant(restaurant.Nom);
                }
                reader.Close();
                connection.Close();
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
            MySqlConnection connection = connexio.ConnexioBDD();
            List<Valoracio> valoracions = new List<Valoracio>();
            if (connection != null)
            {
                string sql = $"SELECT v.comentari, v.puntuacio, v.Dni FROM valoracio v JOIN restaurant r ON v.idRestaurant = r.id WHERE r.nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Valoracio valoracio = new Valoracio(reader["comentari"].ToString(), Convert.ToInt32(reader["puntuacio"]), reader["Dni"].ToString());
                    valoracions.Add(valoracio);
                }
                reader.Close();
                connection.Close();
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
            MySqlConnection connection = connexio.ConnexioBDD();
            List<string> list = new List<string>();
            if(connection != null)
            {
                string sql = $"SELECT f.url FROM fotos f JOIN restaurant r ON f.idRestaurant = r.id WHERE r.nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(reader["url"].ToString());
                }
                reader.Close();
                connection.Close();
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
            MySqlConnection connection = connexio.ConnexioBDD();
            List<Reserva> reservas = new List<Reserva>();
            if(connection != null)
            {
                string sql = $"SELECT id, r.`data` ,r.hora ,r.numComensales ,r.preferencies ,r.Dni FROM reserva r JOIN restaurant r2 ON r.idRestaurant = r2.id WHERE r2.nom = '{nom}';"; 
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Reserva reserva = new Reserva(Convert.ToInt32(reader["id"]),Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(), reader["Dni"].ToString());
                    reservas.Add(reserva);
                }
                reader.Close();
                connection.Close();
            }
            return reservas;
        }

        /// <summary>
        /// Crea un nou restaurant a la base de dades associat a un administrador específic
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant que voleu inserir a la base de dades</param>
        /// <param name="admin">L'objecte Administrador al qual s'associarà el restaurant</param>
        /// <returns>True si el restaurant s'ha afegit correctament, si no, false</returns>
        public bool CrearRestaurantBD(Restaurant restaurant, Administrador admin)
        {
            bool insertRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                if (SelectRestaurantBD(restaurant.Nom) != null)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    if (personaBD.SelectPersonesBDD(admin.Dni,admin.Password) != null)
                    {
                        string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{admin.Dni}')";
                        MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                        insertRestaurant = 1 == sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        if(personaBD.InsertPersonaBDD(admin))
                        {
                            string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{admin.Dni}')";
                            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                            insertRestaurant = 1 == sqlCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            Console.WriteLine("Error.");
                        }
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
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null) 
            {
                string sql = $"DELETE FROM restaurant WHERE nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                deleteRestaurant = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteRestaurant;
        }

        /// <summary>
        /// Actualitza la informació d'un restaurant a la base de dades
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant amb la informació actualitzada</param>
        /// <param name="admin">L'objecte Administrador associat al restaurant</param>
        /// <returns>True si el restaurant s'ha actualitzat correctament, si no, false</returns>
        public bool UpdateRestaurantBD(Restaurant restaurant, Administrador admin)
        {
            bool updateRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null) 
            {
                string sql = $"UPDATE restaurant SET direccio = '{restaurant.Direccio}', tipusCuina = '{restaurant.TipusCuina}', capacitat = '{restaurant.Capacitat}', Dni = '{admin.Dni}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                updateRestaurant = 1 == sqlCommand.ExecuteNonQuery();
            }
            return updateRestaurant;
        }
    }
}
