using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projecte0.Domini;

namespace Projecte0.AccesDades
{
    internal class ValoracioBD
    {
        // -------- Atribut --------
        Connexio connexio = new Connexio();

        // -------- Mètodes --------
        /// <summary>
        /// Serveix per agafar totes les valoracions
        /// </summary>
        /// <returns>Retorna un list de valoracions</returns>
        public List<Valoracio> SelectValoracioBDD()
        {
            List<Valoracio> valoracions = new List<Valoracio>();
            MySqlConnection connection = connexio.ConnexioBDD(); // Creem la conexio
            if (connection != null)
            {
                // Comanda sql per agafar les valoracions
                string sql = "SELECT * FROM valoracio"; 
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executa la comanda

                while (reader.Read()) // Mentres hi hagi valoracions continua llegim
                {
                    // Creem la valoracio amb els paramentres del reader que ens a donat la base de dades
                    Valoracio valoracio = new Valoracio(
                        Convert.ToInt32(reader["id"]),
                        reader["comentari"].ToString(),
                        Convert.ToInt32(reader["puntuacio"]),
                        reader["dni"].ToString()
                    ) ;
                    valoracions.Add(valoracio); // Afegim la valoracio a la list
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem la conexio
            }

            return valoracions;
        }
        /// <summary>
        /// Serveix per inserir una valoracio a la base de dades
        /// </summary>
        /// <param name="valoracio">Valoracio creada per l'usuari</param>
        /// <param name="nomRestaurant">Nom restaurant per afegir la valoracio</param>
        /// <returns>Retorna true si la a afegit, retorna false si no la ha afegit</returns>
        public bool InsertValoracioBDD(Valoracio valoracio, string nomRestaurant)
        {
            bool insertadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null)
            {
                // Comanda sql per fer l'insert amb els parametres pasats a la valoracio
                string sql = $"INSERT INTO valoracio (comentari, puntuacio, dni, idRestaurant) " +
                             $"VALUES('{valoracio.Comentari}', '{valoracio.Puntuacio}', '{valoracio.Dni}', (SELECT id FROM restaurant WHERE nom = '{nomRestaurant}'));";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                insertadaValoracio = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si el resultat es 1 posa la variable a true, sino posa la variable a false

                connection.Close(); // Tanquem la conexio
            }
            return insertadaValoracio;
        }
        /// <summary>
        /// Serviex per fer un update de una valoracio
        /// </summary>
        /// <param name="valoracio">Li psaem la nova valoracio</param>
        /// <returns>Retorna true si la valoracio s'ha actualizat, sino retorna false</returns>
        public bool UpdateValoracioBDD(Valoracio valoracio)
        {
            bool actualizadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null)
            {
                // Comanda sql per fer l'update de valoracio quan el dni sigui igual al dni de la valoracio
                string sql = $"UPDATE valoracio " +
                             $"SET comentari = '{valoracio.Comentari}', puntuacio = {valoracio.Puntuacio} WHERE dni = '{valoracio.Dni}' ";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                actualizadaValoracio = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si es 1, si es 1 posa la variable a true si es 0 posa la variable a false

                connection.Close(); // Tanquem la conexio
            }
            return actualizadaValoracio;
        }
        /// <summary>
        /// Elimina totes les valoracions de X usuari
        /// </summary>
        /// <param name="dni">Li pasem el dni del usuari</param>
        /// <returns>Retorna true si ha eliminat la valoracio sino retorna false</returns>
        public bool DeleteValoracioBDD(string dni)
        {
            bool eliminadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null)
            {
                // Comanda sql per eliminar totes les valoracions segons el dni
                string sql = $"DELETE FROM valoracio WHERE dni = '{dni}'";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                eliminadaValoracio = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si es 1, si es 1 posa la variable a true, sino posa la variable a false

                connection.Close(); // Tanquem la conexio
            }
            return eliminadaValoracio;
        }
        /// <summary>
        /// Aquest metode l'utilizem per poder eliminar una reserva desde el datagrid
        /// </summary>
        /// <param name="valoracio">Li pasem una valoracio seleccionada del datagrid</param>
        /// <returns>Ens retorna true si l'ha eliminat o false si no la eliminat</returns>
        public bool DeleteValoracioBDD(Valoracio valoracio)
        {
            bool eliminadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            if (connection != null)
            {
                // Comanda sql per eliminar una valoracio segons la id de la valoracio
                string sql = $"DELETE FROM valoracio WHERE id = '{valoracio.Id}'";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                eliminadaValoracio = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem si es 1, si es 1 posa la variable a true, sino posa la variable a false

                connection.Close(); // Tanquem la conexio
            }
            return eliminadaValoracio;
        }
        /// <summary>
        /// Serveix per obtenir totes les valoracions de X restaurant
        /// </summary>
        /// <param name="nom">Li pasem el nom del restaurant que volem agafar les valoracions</param>
        /// <returns>Retorna un list de valoracions</returns>
        public List<Valoracio> ObtenirValoracionsBDD(string nom)
        {
            List<Valoracio> valoracions = new List<Valoracio>();

            // Comanda sql per seleccionar totes les valoracions del restaurant segons el nom
            string sql = $"SELECT * FROM valoracio v JOIN restaurant r ON v.idRestaurant = r.id WHERE r.nom = '{nom}';";

            MySqlConnection mySqlConnection = connexio.ConnexioBDD(); // Fem la conexio
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader(); // Executem la comanda i comprovem si es 1 per posar la variable a true

            while (reader.Read()) // Llegim totes les valoracions que hi hagin
            {
                // Creem la valoracio
                Valoracio valoracio = new Valoracio()
                {
                    Id = reader.GetInt32("id"),
                    Comentari = reader.GetString("comentari"),
                    Puntuacio = reader.GetInt32("puntuacio"),
                    Dni = reader.GetString("dni")
                };

                valoracions.Add(valoracio); // Afegim la valoracio a el list de valoracions
            }

            reader.Close(); // Taquem reader
            mySqlConnection.Close(); // Tanquem conexio

            return valoracions;
        }

        /// <summary>
        /// Serveix per eliminar totes les valoracions de X restaurant
        /// </summary>
        /// <param name="nom">Li pasem el nom del restaurant que volem eliminar les valoracions</param>
        /// <returns>Ens retorna true si l'ha eliminat, sino retorna false</returns>
        public bool EliminarValoracionsPorRestauranteBDD(string nom)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Fem la conexio
            bool deleteValoracio = false; // Creem un bool per despres retornar-lo
            if (connection != null)
            {
                // Comanda per eliminar totes les valoracions del restaurant segons el nom
                string sql = $"DELETE FROM valoracio WHERE idRestaurant IN (SELECT id FROM restaurant WHERE nom = '{nom}')";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deleteValoracio = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda i comprovem que es 1


                connection.Close(); // Tanquem conexio
            }
            return deleteValoracio;
        }
        public List<Valoracio> ObtenirValoracioClient(string dni)
        {
            List<Valoracio> valoracions = new List<Valoracio>();

            // Comanda sql per seleccionar totes les valoracions de un usuari amb el dni
            string sql = $"SELECT * FROM valoracio WHERE Dni = '{dni}';";

            MySqlConnection mySqlConnection = connexio.ConnexioBDD(); // Fem la conexio
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader(); // Executem la comanda i comprovem si es 1 per posar la variable a true

            while (reader.Read()) // Llegim totes les valoracions que hi hagin
            {
                // Creem la valoracio
                Valoracio valoracio = new Valoracio()
                {
                    Id = reader.GetInt32("id"),
                    Comentari = reader.GetString("comentari"),
                    Puntuacio = reader.GetInt32("puntuacio"),
                    Dni = reader.GetString("dni")
                };

                valoracions.Add(valoracio); // Afegim la valoracio a el list de valoracions
            }

            reader.Close(); // Taquem reader
            mySqlConnection.Close(); // Tanquem conexio

            return valoracions;
        }
    }
}
