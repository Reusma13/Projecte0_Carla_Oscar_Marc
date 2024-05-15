using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Administrador : Persona
    {
        // -------- Atributs --------
        private List<Restaurant> restaurants;

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
        /// <param name="restaurants">Llista de restaurants que pot administrar l'administrador</param>
        public Administrador(string dni, string nom, string cognom,string password,List<Restaurant> restaurants) : base(dni, nom, cognom, password)
        {
            this.restaurants = restaurants;
        }

        // -------- Propietats --------
        public List<Restaurant> Restaurants
        { 
            get { return restaurants; }
            set { restaurants = value; }
        }

        // -------- Mètodes --------
        public void CrearRestaurant(string nom, string direccio, string tipusCuina, int capacitat)
        {
            //Mirar bien como hacer lo de las fotos

            Restaurant nouRestaurant = new Restaurant(nom, direccio, tipusCuina, capacitat);
            restaurants.Add(nouRestaurant);
        }

        /// <summary>
        /// Elimina un restaurant
        /// </summary>
        /// <param name="nomRestaurantEliminar">El nom del restaurant que es vol eliminar</param>
        /// <returns>Retorna true si el restaurant s'ha eliminat correctament, si no, retorna false</returns>
        public bool EliminarRestaurant(string nomRestaurantEliminar)
        {
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
        /// <param name="direccio">Direccio del restaurant</param>
        /// <param name="tipusCuina">Tipus de cuina del restaurant</param>
        /// <param name="capacitat">Capacitat del restaurant</param>
        /// <returns>Retorna true si el restaurant s'ha actualitzat correctament, si no, retorna false</returns>
        public bool ActualitzarPerfilRestaurant(string nom, string nouNom, string direccio, string tipusCuina, int capacitat)
        {
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
