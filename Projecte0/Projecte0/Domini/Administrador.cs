using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
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
        public Administrador(string dni, string nom, string cognom, string password, string esAdmin, List<Restaurant> restaurants) : base(dni, nom, cognom, password, esAdmin)
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
        public void CrearRestaurant()
        {
            //lògica aquí
        }

        public void EliminarRestaurant()
        {
            //lògica aquí
        }

        public void ActualitzarPerfilRestaurant()
        {
            //lògica aquí
        }

        public void VisualitzarEstadistica()
        {
            //lògica aquí
        }
    }
}
