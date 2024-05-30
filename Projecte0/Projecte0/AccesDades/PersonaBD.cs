using MySql.Data.MySqlClient;
using Projecte0;
using Projecte0.Domini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.AccesDades
{
    public class PersonaBD
    {
        // -------- Atribut --------
        Connexio connexio = new Connexio(); // Creem la conexio

        // -------- Mètodes --------
        /// <summary>
        /// Busca a la base de dades quina Persona correspon al dni i password
        /// </summary>
        /// <param name="dni">Dni de la persona que vols seleccionar</param>
        /// <param name="password">Contrasenya de la persona que vols seleccionar</param>
        /// <returns>El objecte Persona de la persona seleccionada, o null si no es troba</returns>
        public Persona SelectPersonesBDD(string dni, string password)
        {
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD y l'inserim a connection per poder-lo utilizar
            Persona persona = null;
            if (connection != null)
            {
                string sql = $"SELECT * FROM persona WHERE Dni = '{dni}' AND password = '{password}'";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader(); // Executa la comanda sql
                // Y busca a la persona si hi existeix
                if (reader.Read())
                {
                    // Creem la persona amb els parametres que ens a donat la Base de dades
                    persona = new Persona(reader["Dni"].ToString(), reader["nom"].ToString(), reader["cognom"].ToString(), reader["password"].ToString(), reader["esAdmin"].ToString()); 
                }
                reader.Close(); // Tanquem el reader
                connection.Close(); // Tanquem conexio
            }
            return persona; // Retornem a la persona
        }

        /// <summary>
        /// Insereix una nova persona a la base de dades
        /// </summary>
        /// <param name="persona">L'objecte Persona que es vol afegir</param>
        /// <returns>True si la persona s'ha afegit correctament, si no, false</returns>
        public bool InsertPersonaBDD(Persona persona)
        {
            bool inseritPersona = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD y l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Fem l'insert a la base de dades
                string sql = $"INSERT INTO Persona (Dni, nom, cognom,password,esAdmin) VALUES('{persona.Dni}','{persona.Nom}','{persona.Cognom}','{persona.Password}','{persona.EsAdmin}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritPersona = 1 == sqlCommand.ExecuteNonQuery(); // Si el ExecuteNonQuery es igual a 1 significa que es true y a modificat la base de dades
            }
            return inseritPersona;
        }

        /// <summary>
        /// Eliminar una persona a la base de dades
        /// </summary>
        /// <param name="dni">dni de la persona la qual es vol eliminar</param>
        /// <returns>True si la persona s'ha eliminat correctament, si no, false</returns>
        public bool DeletePersonaBDD(string dni)
        {
            bool deletePersona = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"DELETE FROM persona WHERE Dni = '{dni}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                deletePersona = 1 == sqlCommand.ExecuteNonQuery();
            }
            return deletePersona;
        }

        /// <summary>
        /// Actualitza una persona a la base de dades
        /// </summary>
        /// <param name="persona">Persona la qual es vol actualitzar</param>
        /// <returns>True si la persona s'ha actualitzat correctament, si no, false</returns>>
        public bool UpdatePersonaBDD(Persona persona)
        {
            bool updatePersona = false;
            MySqlConnection connection = connexio.ConnexioBDD(); // Utilizem el metode conexioBDD y l'inserim a connection per poder-lo utilizar
            if (connection != null)
            {
                // Fer update de persona quan el dni es igual al dni que ens a pasat l'usuari
                string sql = $"UPDATE persona SET nom = '{persona.Nom}', cognom = '{persona.Cognom}', password = '{persona.Password}', esAdmin = '{persona.EsAdmin}' WHERE Dni = '{persona.Dni}';";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                updatePersona = 1 == sqlCommand.ExecuteNonQuery(); // Executem la comanda si es igual a 1 retorna true
            }
            return updatePersona;
        }
    }
}
