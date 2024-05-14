using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;
using System.Windows.Media;

namespace Projecte0
{
    class Administrador : Persona
    {
        // Atributs
        private List<Restaurant> restaurants;
        protected Connexio connexio;

        // Constructors
        public Administrador() : base()
        {
            restaurants = new List<Restaurant>();
            password = "admin";
            connexio = new Connexio();
        }
        public Administrador(string dni, string nom, string cognom,string password,List<Restaurant> restaurants) : base(dni, nom, cognom, password)
        {
            this.restaurants = restaurants;
            connexio = new Connexio();
        }
        
        // Propietats
        public List<Restaurant> Restaurants
        { 
            get { return restaurants; }
            set { restaurants = value; }
        }

        // Mètodes 
        public void CrearRestaurant(string nom, string direccio, string tipusCuina, int capacitat, List<string> fotos, List<Reserva> reserves)
        {
            Restaurant nouRestaurante = new Restaurant(nom, direccio, tipusCuina, capacitat, fotos, reserves);
            string sql = $"INSERT INTO restaurants (nom, direccio, tipusCuina, capacitat) VALUES ('{nouRestaurante.Nom}', '{nouRestaurante.Direccio}', '{nouRestaurante.TipusCuina}', {nouRestaurante.Capacitat})";
            connexio.ConnexioBDD(sql);
        }

        public void EliminarRestaurant(string nom)
        {
            string sql = $"DELETE FROM restaurants WHERE nom = '{nom}'";
            connexio.ConnexioBDD(sql);
        }

        public void ActualizarPerfilRestaurante(string nom, string novaDireccio, string nouTipusCuina, int novaCapacitat, List<string> novesFotos, List<Reserva> novesReserves)
        {
            string sql = $"UPDATE restaurants SET direccio = '{novaDireccio}', tipusCuina = '{nouTipusCuina}', capacitat = {novaCapacitat} WHERE nom = '{nom}'";
            connexio.ConnexioBDD(sql);
        }


        public void VisualitzarEstadistica()
        {
            // Aquí podríes implementar la lògica per visualitzar les estadístiques que necessitis.
            // Per exemple, podríes mostrar el nombre total de restaurants, la mitjana de capacitat, etc.
        }
    }
}
