using Projecte0.AccesDades;
using Projecte0.Domini;
using System;
using Projecte0.Domini;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Projecte0.Domini
{
    public class Restaurant
    {
        RestaurantBD restaurantBD;
        FotoBD fotoBD;
        // -------- Atributs --------
        protected string nom;
        protected string direccio;
        protected string tipusCuina;
        protected int capacitat;
        protected List<string> fotos;
        protected List<Valoracio> valoracio;
        protected List<Reserva> reserves;


        // -------- Constructors --------
        /// <summary>
        /// Constructor buit de Restaurant
        /// </summary>
        public Restaurant()
        {
            nom = "";
            direccio = "";
            tipusCuina = "";
            capacitat = 0;
            fotos = new List<string>();
            valoracio = new List<Valoracio>();
            reserves = new List<Reserva>();
            restaurantBD = new RestaurantBD();
            fotoBD = new FotoBD();
        }
        public Restaurant(string nom, string direccio, string tipusCuina, int capacitat) : this()

        {
            this.nom = nom;
            this.direccio = direccio;
            this.tipusCuina = tipusCuina;
            this.capacitat = capacitat;
        }

        /// <summary>
        /// Constructor amb tots els atributs de la clase Restaurant
        /// </summary>
        /// <param name="nom">Nom del restaurant</param>
        /// <param name="direccio">Direccio del restaurant</param>
        /// <param name="tipusCuina">Tipus de cuina del restaurant</param>
        /// <param name="capacitat">Capacitat del restaurant</param>
        /// <param name="fotos">Llista de fotos del restaurant</param>
        /// <param name="valoracio">Llista de valoracions del restaurant</param>
        /// <param name="reserves">Llista de reserves del restaurant</param>
        public Restaurant(string nom, string direccio, string tipusCuina, int capacitat, List<string> fotos, List<Valoracio> valoracio, List<Reserva> reserves)

        {
            this.nom = nom;
            this.direccio = direccio;
            this.tipusCuina = tipusCuina;
            this.capacitat = capacitat;
            this.fotos = fotos;
            this.valoracio = valoracio;
            this.reserves = reserves;
        }

        // -------- Propietats --------
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Direccio
        {
            get { return direccio; }
            set { direccio = value; }
        }
        public string TipusCuina
        {
            get { return tipusCuina; }
            set { tipusCuina = value; }
        }
        public int Capacitat
        {
            get { return capacitat; }
            set { capacitat = value; }
        }
        public List<string> Fotos
        {
            get { return fotos; }
            set { fotos = value; }
        }
        public List<Valoracio> Valoracio
        {
            get { return valoracio; }
            set { valoracio = value; }
        }
        public List<Reserva> Reserves
        {
            get { return reserves; }
            set { reserves = value; }
        } 

        // -------- Metodes --------
        public Restaurant SelectRestaurant(string nom)
        {
            return restaurantBD.SelectRestaurantBD(nom);
        }
        public List<Restaurant> SelectRestaurantList(string dni)
        {
            return restaurantBD.SelectRestaurantListBD(dni);
        }
        public bool InsertRestaurant(Restaurant restaurant, Persona p)
        {
            return restaurantBD.CrearRestaurantBD(restaurant, p);
        }
        public bool DeleteRestaurant(string nom)
        {
            return restaurantBD.DeleteRestaurantBD(nom);
        }
        public bool UpdateRestaurant(Restaurant restaurant,Persona p,string nom)
        {
            return restaurantBD.UpdateRestaurantBD(restaurant,p,nom);
        }
        public List<string> SelectFotos(Restaurant r)
        {
            return fotoBD.SelectFotosBDD(r);
        }
        public bool InsertFotos(List<string> fotos, Restaurant r)
        {
            return fotoBD.InsertFotoBD(fotos,r);
        }
        public override string ToString()
        {
            return nom;
        }
    }
}
