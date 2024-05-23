using MySql.Data.MySqlClient;
using Projecte0.Domini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.AccesDades
{
    public class FotoBD
    {
        Connexio connexio = new Connexio();
        public List<string> SelectFotosBDD(Restaurant r)
        {
            List<string> fotosSeleccionades = new List<string>();
            MySqlConnection connection = connexio.ConnexioBDD();
            Persona persona = null;
            if (connection != null)
            {
                string sql = $"SELECT f.url FROM fotos f JOIN restaurant r ON f.idRestaurant = r.id WHERE r.nom = '{r.Nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    fotosSeleccionades.Add(reader["url"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return fotosSeleccionades;
        }
        public bool InsertFotoBD(List<string> fotos, Restaurant r)
        {
            bool inseritFotos = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            int cont = 0;
            while (connection != null && cont < fotos.Count)
            {
                string sql = $"INSERT INTO fotos (url, idRestaurant) SELECT '{fotos[cont]}', id FROM restaurant  WHERE nom = '{r.Nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritFotos = 1 == sqlCommand.ExecuteNonQuery();
                cont++;
            }
            return inseritFotos;
        }
        public bool DeleteFotoBD(string nom)
        {
            bool deleteFotos = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"DELETE FROM fotos WHERE idRestaurnat = (SELECT id FROM restaurant WHERE nom = '{nom}';)";
                MySqlCommand sqlCommand = new MySqlCommand(sql,connection);
                deleteFotos = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteFotos;
        }
    }
}
