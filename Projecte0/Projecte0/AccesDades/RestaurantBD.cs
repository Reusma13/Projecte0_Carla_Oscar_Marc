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
        Connexio connexio = new Connexio();
        PersonaBD personaBD = new PersonaBD();
        FotoBD fotoBD = new FotoBD();

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
        public List<Valoracio> SelectValoracioRestaurant(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            List<Valoracio> valoracios = new List<Valoracio>();
            if (connection != null)
            {
                string sql = $"SELECT v.comentari, v.puntuacio, v.Dni FROM valoracio v JOIN restaurant r ON v.idRestaurant = r.id WHERE r.nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Valoracio valoracio = new Valoracio(reader["comentari"].ToString(), Convert.ToInt32(reader["puntuacio"]), reader["Dni"].ToString());
                    valoracios.Add(valoracio);
                }
                reader.Close();
                connection.Close();
            }
            return valoracios;
        }
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
                    Reserva reserva = new Reserva(Convert.ToInt32(reader["id"]),Convert.ToDateTime(reader["data"]), reader.GetTimeSpan(reader.GetOrdinal("hora")), Convert.ToInt32(reader["numComensales"]), reader["preferencies"].ToString(), reader["nomTaula"].ToString(), reader["Dni"].ToString(), Convert.ToInt32(reader["idRestaurant"]) );
                    reservas.Add(reserva);
                }
                reader.Close();
                connection.Close();
            }
            return reservas;
        }
        public bool CrearRestaurantBD(Restaurant restaurant, Persona p)
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
                    if (personaBD.SelectPersonesBDD(p.Dni,p.Password) is not null)
                    {
                        string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{p.Dni}')";
                        MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                        insertRestaurant = 1 == sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        if(personaBD.InsertPersonaBDD(p))
                        {
                            string sql = $"INSERT INTO restaurant (nom, direccio, tipusCuina, capacitat,Dni) VALUES ('{restaurant.Nom}','{restaurant.Direccio}','{restaurant.TipusCuina}','{restaurant.Capacitat}','{p.Dni}')";
                            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                            insertRestaurant = 1 == sqlCommand.ExecuteNonQuery();
                        }
                        else
                        {
                            Console.WriteLine("Error.");
                        }
                    }
                    if (restaurant.Fotos is not null)
                    {
                        fotoBD.InsertFotoBD(restaurant.Fotos, restaurant);
                    }

                }
            }
            return insertRestaurant;
        }
        public bool DeleteRestaurantBD(string nom)
        {
            bool deleteRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null) 
            {
                fotoBD.DeleteFotoBD(nom);
                string sql = $"DELETE FROM restaurant WHERE nom = '{nom}';";
                MySqlCommand sqlCommand = new MySqlCommand (sql, connection);
                deleteRestaurant = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteRestaurant;
        }
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
