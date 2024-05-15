using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Administrador : Persona
    {
        // Atributs
        private List<Restaurant> restaurants;

        // Constructors
        public Administrador() : base()
        {
            restaurants = new List<Restaurant>();
            password = "admin";
        }
        public Administrador(string dni, string nom, string cognom,string password,List<Restaurant> restaurants) : base(dni, nom, cognom, password)
        {
            this.restaurants = restaurants;
        }
        
        // Propietats
        public List<Restaurant> Restaurants
        { 
            get { return restaurants; }
            set { restaurants = value; }
        }

        // Mètodes 
        public void CrearRestaurant(string nom, string direccio, string tipusCuina, int capacitat)
        {
            //Mirar bien como hacer lo de las fotos

            Restaurant nouRestaurant = new Restaurant(nom, direccio, tipusCuina, capacitat);
            restaurants.Add(nouRestaurant);
        }

        public void EliminarRestaurant(string nomRestaurantEliminar)
        {
            bool restaurantEliminat = false;
            for(int i; i < restaurants.Count && !restaurantEliminat; i++)
            {
                if (restaurants[i].Nom == nomRestaurantEliminar)
                {
                    restaurants.RemoveAt(i);
                    restaurantEliminat = true;
                }
            }

            if (restaurantEliminat = true)
            {
                //Enseñar que se elimino correctamente
            }
            else if (restaurantEliminat = false)
            {
                //Poner que no se encontro el restaurante
            }
            else
            {
                //Decir que hubo algun error
            }

            return;
        }

        public void ActualitzarPerfilRestaurant(int posicio, string nom, string direccio, string tipusCuina, int capacitat)
        {
            bool restaurantEliminat = false;
            restaurants[posicio].Nom = nom;
            restaurants[posicio].Direccio = direccio;
            restaurants[posicio].TipusCuina = tipusCuina;
            restaurants[posicio].Capacitat = capacitat;

        }

        public void VisualitzarEstadistica()
        {
            // Falta Codi
        }
    }
}
