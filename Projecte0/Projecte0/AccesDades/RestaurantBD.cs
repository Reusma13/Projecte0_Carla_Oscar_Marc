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

        public Restaurant SelectResurantBD(string nom)
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
                }
                reader.Close();
                connection.Close();
            }
            return restaurant;
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
                if(reader.Read())
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
                string sql = $"SELECT r.`data` ,r.hora ,r.numComensales ,r.preferencies ,r.Dni FROM reserva r JOIN restaurant r2 ON r.idRestaurant = r2.id WHERE r2.nom = '{nom}';"; 
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Reserva reserva = new Reserva(Convert.ToDateTime(reader["data"]),);
                    reservas.Add();
                }
                reader.Close();
                connection.Close();
            }
        }
        public bool CrearRestaurantBD(Restaurant restaurant, Administrador admin)
        {
            bool insertRestaurant = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"INSERT INTO restaurants (nom, direccio, tipusCuina, capacitat) VALUES ('{restaurant.Nom}', '{restaurant.Direccio}', '{restaurant.TipusCuina}', '{restaurant.Capacitat}'.{admin.Dni})";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                insertRestaurant = 1 == sqlCommand.ExecuteNonQuery();
            }
            return insertRestaurant;
        }
    }
}
