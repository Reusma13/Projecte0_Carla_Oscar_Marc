using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Restaurant
    {
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
            this.reserves = reserves();
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
          
        public List<Reserva> Reserves
        {
            get { return reserves; }
            set { reserves = value; }
        } 

        // -------- Metodes --------
        /// <summary>
        /// Actualiza les reserves
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva</param>
        /// <param name="novaData">Nova data de la reserva</param>
        /// <param name="novaHora">Nova hora de la reserva</param>
        /// <param name="numComensals">Nou numero de comensals de la reserva</param>
        /// <param name="preferencies">Noves preferencies de la reserva</param>
        /// <returns>Retorna true si la reserva s'ha actualitzat correctament, si no, retorna false</returns>
        public bool ActualitzarReserva(int idReserva, DateTime novaData, TimeSpan novaHora, int numComensals, string preferencies)
         {
            Reserva reservaActualitzar = reserves.Find(r => r.IdReserva == idReserva);
            bool reservaActualitzada = false;
            if (reservaActualitzar != null)
            {
                reservaActualitzar.Data = novaData;
                reservaActualitzar.Hora = novaHora;
                reservaActualitzar.NumComensals = numComensals;
                reservaActualitzar.Preferencies = preferencies;
                reservaActualitzada = true;
            }
            return reservaActualitzada;
        }
      
      
        /// <summary>
        /// Modifica les reserves
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva</param>
        /// <param name="novaData">Nova data de la reserva</param>
        /// <param name="novaHora">Nova hora de la reserva</param>
        /// <param name="numComensals">Nou numero de comensals de la reserva</param>
        /// <param name="preferencies">Noves preferencies de la reserva</param>
        /// <returns>Retorna true si la reserva s'ha modificat correctament, si no, retorna false</returns>
        public bool ModificarReserva(int idReserva, DateTime novaData, TimeSpan novaHora, int numComensals, string preferencies)
        {
            Reserva reservaAModificar = reserves.Find(r => r.IdReserva == idReserva);
            bool reservaModificada = false;
            if (reservaAModificar != null)
            {
                reservaAModificar.Data = novaData;
                reservaAModificar.Hora = novaHora;
                reservaAModificar.NumComensals = numComensals;
                reservaAModificar.Preferencies = preferencies;
                reservaModificada = true;
            }
            return reservaModificada;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Reserva> VisualitzarReserves()
        {
            return reserves;
        }

        public void AfegirReserva(Reserva reserva)
        {
            reserves.Add(reserva);
        }
    }
}
