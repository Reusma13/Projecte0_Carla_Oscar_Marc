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

        public MySqlConnection ConnexioBDD()
        {
            string connexio = $"server={server};user={user};database={database};port={port};password={password}";
            MySqlConnection connection = new MySqlConnection(connexio);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                connection = null;
            }
            return connection;
        }
    }
}
