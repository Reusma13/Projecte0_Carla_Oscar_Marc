using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;
using System.Windows.Media;

namespace Projecte0.Domini
{
    class Administrador : Persona
    {
        // -------- Atributs --------
        private List<Restaurant> restaurants;
        protected Connexio connexio;

        // -------- Constructors --------
        /// <summary>
        /// Constructor buit amb la base de la clase pare
        /// </summary>
        public Administrador() : base()
        {
            restaurants = new List<Restaurant>();
            password = "admin";

        }

        /// <summary>
        /// Contructor amb tots els atributs de Persona i de Administrador
        /// </summary>
        /// <param name="dni">El DNI de l'administrador</param>
        /// <param name="nom">El nom de l'administrador</param>
        /// <param name="cognom">El cognom de l'administrador</param>
        /// <param name="password">La contrasenya de l'administrador</param>
        /// <param name="esAdmin"></param>
        /// <param name="restaurants">Llista de restaurants que pot administrar l'administrador</param>
        public Administrador(string dni, string nom, string cognom,string password,string esAdmin,List<Restaurant> restaurants) : base(dni, nom, cognom, password,esAdmin)
        {
            this.restaurants = restaurants;
            connexio = new Connexio();
        }

        // -------- Propietats --------
        public List<Restaurant> Restaurants
        { 
            get { return restaurants; }
            set { restaurants = value; }
        }


        // -------- Mètodes --------
        /// <summary>
        /// Crea un restaurant
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="direccio"></param>
        /// <param name="tipusCuina"></param>
        /// <param name="capacitat"></param>
        /// <param name="fotos"></param>
        /// <param name="reserves"></param>
        public void CrearRestaurant(string nom, string direccio, string tipusCuina, int capacitat, List<string> fotos, List<Reserva> reserves)
        {
            Restaurant nouRestaurante = new Restaurant(nom, direccio, tipusCuina, capacitat, fotos, reserves);
            string sql = $"INSERT INTO restaurants (nom, direccio, tipusCuina, capacitat) VALUES ('{nouRestaurante.Nom}', '{nouRestaurante.Direccio}', '{nouRestaurante.TipusCuina}', {nouRestaurante.Capacitat})";
            connexio.ConnexioBDD(sql);
        }

        /// <summary>
        /// Elimina un restaurant
        /// </summary>
        /// <param name="nomRestaurantEliminar">El nom del restaurant que es vol eliminar</param>
        /// <returns>Retorna true si el restaurant s'ha eliminat correctament, si no, retorna false</returns>
        public bool EliminarRestaurant(string nomRestaurantEliminar)
        {
            string sql = $"DELETE FROM restaurants WHERE nom = '{nomRestaurantEliminar}'";
            connexio.ConnexioBDD(sql);
          
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Nom == nom);
            bool restaurantEliminat = false;

            if (restaurant != null)
            {
                restaurant.Remove(restaurant);
                restaurantEliminat = true;
            }

            return restaurantEliminat;
        }

        /// <summary>
        /// Actualitza un perfil de restaurant
        /// </summary>
        /// <param name="nom">Nom del restaurant</param>
        /// <param name="nouNom">Nou nom que es vol posar al restaurant</param>
        /// <param name="direccio">Direccio del restaurant</param>
        /// <param name="tipusCuina">Tipus de cuina del restaurant</param>
        /// <param name="capacitat">Capacitat del restaurant</param>
        /// <returns>Retorna true si el restaurant s'ha actualitzat correctament, si no, retorna false</returns>
        public bool ActualitzarPerfilRestaurant(string nom, string nouNom, string direccio, string tipusCuina, int capacitat)
        {
            string sql = $"UPDATE restaurants SET direccio = '{novaDireccio}', tipusCuina = '{nouTipusCuina}', capacitat = {novaCapacitat} WHERE nom = '{nom}'";
            connexio.ConnexioBDD(sql);
          
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Nom == nom);
            bool canviatCorrectament = false;

            if (restaurant != null)
            {
                restaurant.Nom = nouNom;
                restaurant.Direccio = direccio;
                restaurant.TipusCuina = tipusCuina;
                restaurant.Capacitat = capacitat;

                canviatCorrectament = true;
            }
            return canviatCorrectament;
        }

        //Visualizar la Valoracion de un Restaurante en concreto

        public List<Valoracio> VisualitzarEstadistica(string nomRestaurant)
        {
            if (restaurants != null)
            {
                return restaurants.Valoracio;
            }
        }
    }
}
