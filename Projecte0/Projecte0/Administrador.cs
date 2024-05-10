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
    }
}
