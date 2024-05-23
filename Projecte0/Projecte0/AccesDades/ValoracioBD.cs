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
        public List<Valoracio> SelectValoracioBDD()
        {
            List<Valoracio> valoracions = new List<Valoracio>();
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = "SELECT * FROM valoracio"; 
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Valoracio valoracio = new Valoracio(
                        reader["comentari"].ToString(),
                        Convert.ToInt32(reader["puntuacio"]),
                        reader["dni"].ToString()
                    );
                    valoracions.Add(valoracio);
                }

                reader.Close();
                connection.Close();
            }

            return valoracions;
        }

        public bool InsertValoracioBDD(Valoracio valoracio)
        {
            bool insertadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"INSERT INTO valoracio (comentari, puntuacio, dni) " +
                             $"VALUES('{valoracio.Comentari}', '{valoracio.Puntuacio}', '{valoracio.Dni}');";
                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                insertadaValoracio = 1 == sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
            return insertadaValoracio;
        }

        public bool UpdateValoracioBDD(Valoracio valoracio)
        {
            bool actualizadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"UPDATE valoracio " +
                             $"SET comentari = '{valoracio.Comentari}', puntuacio = {valoracio.Puntuacio}, dni = '{valoracio.Dni}' ";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                actualizadaValoracio = 1 == sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
            return actualizadaValoracio;
        }

        public bool DeleteValoracioBDD(string dni)
        {
            bool eliminadaValoracio = false;
            MySqlConnection connection = connexio.ConnexioBDD();
            if (connection != null)
            {
                string sql = $"DELETE FROM valoracio WHERE dni = '{dni}'";

                MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                eliminadaValoracio = 1 == sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
            return eliminadaValoracio;
        }

        public List<Valoracio> ObtenirValoracionsBDD()
        {
            List<Valoracio> valoracions = new List<Valoracio>();

            string sql = "SELECT * FROM valoracio";

            MySqlConnection mySqlConnection = connexio.ConnexioBDD();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Valoracio valoracio = new Valoracio()
                {
                    Comentari = reader.GetString("comentari"),
                    Puntuacio = reader.GetInt32("puntuacio"),
                    Dni = reader.GetString("dni")
                };

                valoracions.Add(valoracio);
            }

            reader.Close();
            mySqlConnection.Close();

            return valoracions;
        }
    }
}
