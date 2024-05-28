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
        /// <summary>
        /// Retorna un restaurant específic de la base de dades.
        /// </summary>
        /// <param name="nom">El nom del restaurant a retornar.</param>
        /// <returns>Retorna l'objecte Restaurant.</returns>
        public Restaurant SelectRestaurant(string nom)
        {
            return restaurantBD.SelectRestaurantBD(nom);
        }

        /// <summary>
        /// Retorna una llista de restaurants d'un client específic.
        /// </summary>
        /// <param name="dni">El DNI del client per al qual es volen obtenir els restaurants.</param>
        /// <returns>Retorna una llista de restaurants.</returns>
        public List<Restaurant> SelectRestaurantList(string dni)
        {
            return restaurantBD.SelectRestaurantListBD(dni);
        }

        /// <summary>
        /// Inserta un nou restaurant a la base de dades.
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant a inserir.</param>
        /// <param name="p">L'objecte Persona associat al restaurant.</param>
        /// <returns>Retorna true si la inserció és exitosa.</returns>
        public bool InsertRestaurant(Restaurant restaurant, Persona p)
        {
            return restaurantBD.CrearRestaurantBD(restaurant, p);
        }

        /// <summary>
        /// Elimina un restaurant de la base de dades.
        /// </summary>
        /// <param name="nom">El nom del restaurant a eliminar.</param>
        /// <returns>Retorna true si l'eliminació és exitosa.</returns>
        public bool DeleteRestaurant(string nom)
        {
            return restaurantBD.DeleteRestaurantBD(nom);
        }

        /// <summary>
        /// Actualitza un restaurant existent a la base de dades.
        /// </summary>
        /// <param name="restaurant">L'objecte Restaurant a actualitzar.</param>
        /// <param name="p">L'objecte Persona associat al restaurant.</param>
        /// <param name="nom">El nom del restaurant a actualitzar.</param>
        /// <returns>Retorna true si l'actualització és exitosa.</returns>
        public bool UpdateRestaurant(Restaurant restaurant, Persona p, string nom)
        {
            return restaurantBD.UpdateRestaurantBD(restaurant, p, nom);
        }

        /// <summary>
        /// Retorna una llista de fotos d'un restaurant específic.
        /// </summary>
        /// <param name="r">L'objecte Restaurant del qual es volen obtenir les fotos.</param>
        /// <returns>Retorna una llista de cadenes de text que representen les fotos.</returns>
        public List<string> SelectFotos(Restaurant r)
        {
            return fotoBD.SelectFotosBDD(r);
        }

        /// <summary>
        /// Inserta noves fotos a la base de dades per a un restaurant específic.
        /// </summary>
        /// <param name="fotos">Una llista de cadenes de text que representen les fotos a inserir.</param>
        /// <param name="r">L'objecte Restaurant associat a les fotos.</param>
        /// <returns>Retorna true si la inserció de les fotos és exitosa.</returns>
        public bool InsertFotos(List<string> fotos, Restaurant r)
        {
            return fotoBD.InsertFotoBD(fotos, r);
        }

        /// <summary>
        /// Retorna el nom del restaurant.
        /// </summary>
        /// <returns>Retorna una cadena de text que representa el nom del restaurant.</returns>
        public override string ToString()
        {
            return nom;
        }

    }
}
