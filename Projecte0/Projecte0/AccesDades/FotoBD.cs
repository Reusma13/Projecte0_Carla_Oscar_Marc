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
        /// <summary>
        /// Fem el select de fotos desde la base de dades 
        /// </summary>
        /// <param name="r">Ens pasa un restaurant</param>
        /// <returns>Ens retorna una llista de string amb totes les url de les fotos de aquell restaurant</returns>
        public List<string> SelectFotosBDD(Restaurant r)
        {
            List<string> fotosSeleccionades = new List<string>(); // Creem el list de string per les url's
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Comanda sql per agafar la url de les fotos fent un join de f.idRestaurant y r.id (taula restaurant) quan el r.nom (nom restaurant) sigui igual al nom del restaurant que ens ha pasat l'usuari
                string sql = $"SELECT f.url FROM fotos f JOIN restaurant r ON f.idRestaurant = r.id WHERE r.nom = '{r.Nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executem la comanda
                while (reader.Read()) // Llegim totes les url's
                {
                    fotosSeleccionades.Add(reader["url"].ToString());
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }
            return fotosSeleccionades; // retornem les fotos
        }
        /// <summary>
        /// Serveix per inserir fotos a la base de dades
        /// </summary>
        /// <param name="fotos">Ens pasa com a parametres un list de strings amb les url's de les fotos</param>
        /// <param name="r">Ens pasa el restaurant que vol inserir les fotos</param>
        /// <returns>Retorna true si a afegit totes les fotos, sino retorna false</returns>
        public bool InsertFotoBD(List<string> fotos, Restaurant r)
        {
            bool inseritFotos = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD i l'inserim a connection per poder-lo utilizar
            int cont = 0;
            while (connection != null && cont < fotos.Count) // Mentres la conexio no sea nula i el contador creat sigui menor al total de fotos entrem per el bucle
            {
                // Comanda sql per inserir fotos mijançant el contador per cambiar de url y el nom del restaurant 
                string sql = $"INSERT INTO fotos (url, idRestaurant) SELECT '{fotos[cont]}', id FROM restaurant  WHERE nom = '{r.Nom}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritFotos = 1 == sqlCommand.ExecuteNonQuery(); // Si cambia el registre de la base de dades significa que a afegit la foto
                cont++;
            }
            return inseritFotos;
        }
        /// <summary>
        /// Serveix per eliminar totes les fotos de la base de dades
        /// </summary>
        /// <param name="nom">Li pasem el nom del restaurant</param>
        /// <returns>Retorna true si a eliminat les fotos, sino retorna false</returns>
        public bool DeleteFotoBD(string nom)
        {
            bool deleteFotos = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"DELETE FROM fotos WHERE idRestaurant = (SELECT id FROM restaurant WHERE nom = '{nom}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql,connection);
                deleteFotos = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deleteFotos;
        }
    }
}
