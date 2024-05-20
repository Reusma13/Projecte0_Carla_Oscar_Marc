using MySql.Data.MySqlClient;
using Projecte0.Domini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    public class PersonaBD
    {
        // -------- Atribut --------
        Connexio connexio = new Connexio();

        // -------- Mètodes --------
        /// <summary>
        /// Busca a la base de dades quina Persona correspon al dni i password
        /// </summary>
        /// <param name="dni">Dni de la persona que vols seleccionar</param>
        /// <param name="password">Contrasenya de la persona que vols seleccionar</param>
        /// <returns>El objecte Persona de la persona seleccionada, o null si no es troba</returns>
        public Persona SelectPersonesBDD(string dni, string password)
        {
            MySqlConnection connection = connexio.ConnexioBDD();
            Persona persona = null;
            if (connection != null)
            {
                string sql = $"SELECT * FROM persona WHERE Dni = '{dni}' AND password = '{password}'";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    persona = new Persona(reader["Dni"].ToString(), reader["nom"].ToString(), reader["cognom"].ToString(), reader["password"].ToString(), reader["esAdmin"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return persona;
        }

        /// <summary>
        /// Insereix una nova persona a la base de dades
        /// </summary>
        /// <param name="persona">L'objecte Persona que es vol afegir</param>
        /// <returns>True si la persona s'ha afegit correctament, si no, false</returns>
        public bool InsertPersonaBDD(Persona persona)
        {
            bool inseritPersona = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"INSERT INTO Persona (Dni, nom, cognom,password,esAdmin) VALUES('{persona.Dni}','{persona.Nom}','{persona.Cognom}','{persona.Password}','{persona.EsAdmin}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                inseritPersona = 1 == sqlCommand.ExecuteNonQuery();
            }
            return inseritPersona;
        }
    }
}
