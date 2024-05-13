using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    public class Connexio
    {
        private static string server = "localhost";
        private static string user = "root";
        private static string password = "";
        private static string database = "projecte0";
        private static string port = "3306";

        public void ConnexioBDD()
        {
            string connexio = $"server={server};user={user};database={database};port{port};password={password}";
            MySqlConnection connection = new MySqlConnection(connexio);
            try
            {
                Console.WriteLine("Intentant obrir Base De Dades...");
                connection.Open();
                // REUBICAR CUANDO LO EXPLIQUE
                /*string sql = "SELECT * FROM persona";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader["Dni"], reader["nom"], reader["cognom"]);
                }
                reader.Close();*/

                // Hem de fer un mètode per Obrir i un altre mètode per Tancar tal com ho han fet els companys en el exemple
                // El command es fa quan tenim el text i la connexió on volem connectar
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally 
            { 
                connection.Close();
                Console.WriteLine("Connexio tancada.");
            }
        }

    }
}
