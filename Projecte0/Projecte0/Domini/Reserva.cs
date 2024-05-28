using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projecte0.AccesDades;

namespace Projecte0.Domini
{

    public class Reserva
    {
        ReservaBD reservaBD;
        // -------- Atributs --------
        protected int idReserva;
        protected DateTime data;
        protected TimeSpan hora;
        protected int numComensals;
        protected string preferencies;
        protected string dni;
        protected int idRestaurant;
        protected string nomTaula;

        // -------- Constructors --------

        /// <summary>
        /// Constructor buit de Reserva
        /// </summary>
        public Reserva()
        {
            idReserva = 0;
            data = DateTime.Now;
            hora = TimeSpan.Zero;
            numComensals = 0;
            preferencies = "";
            dni = "";
            reservaBD = new ReservaBD();
            idRestaurant = 0;
            nomTaula = "";
        }

        /// <summary>
        /// Constructor amb tots els atributs de la clase Reserva
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva</param>
        /// <param name="data">Data de la reserva</param>
        /// <param name="hora">Hora de la reserva</param>
        /// <param name="numComensals">Numero de comensals de la reserva</param>
        /// <param name="preferencies">Preferencies de la reserva</param>
        /// <param name="nomTaula">El nom de la taula reservada</param>
        public Reserva(int idReserva, DateTime data, TimeSpan hora, int numComensals, string preferencies, string nomTaula, string dni, int idRestaurant): this()
        {
            this.idReserva = idReserva;
            this.data = data;
            this.hora = hora;
            this.numComensals = numComensals;
            this.preferencies = preferencies;
            this.dni = dni;
            this.idRestaurant= idRestaurant;
            this.nomTaula = nomTaula;
        }

        // -------- Propietats --------
        public int IdReserva
        {
            get { return idReserva; }
            set { idReserva = value; }
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        public TimeSpan Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public int NumComensals
        {
            get { return numComensals; }
            set { numComensals = value; }
        }
        public string Preferencies
        {
            get { return preferencies; }
            set { preferencies = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string NomTaula
        {
            get { return nomTaula; }
            set { nomTaula = value; }
        }
        public int IdRestaurant
        {
            get { return idRestaurant; }
            set { idRestaurant = value;}
        }

        // -------- Metodes --------

        /// <summary>
        /// Mostra una reserva especifica de la base de dades
        /// </summary>
        /// <param name="idReserva">Li passem el id de la reserva que volem veure</param>
        /// <returns>Ens retorna la reserva</returns>
        public Reserva SelectReserva(int idReserva) 
        {
            return reservaBD.SelectReservaBDD(idReserva);
        }
      
        /// <summary>
        /// Serveix per inserir una reserva a la base de dades
        /// </summary>
        /// <param name="reserva">Li passem la nova reserva</param>
        /// <param name="dni">Li passem el dni de la persona que la insereix</param>
        /// <param name="nom">Li passem el nom del restaurant</param>
        /// <returns>Retorna true si s'ha pogut inserir la reserva, sino retorna false.</returns>
        public bool InsertReserva(Reserva reserva, string dni,string nom)

        {
            return reservaBD.InsertReservaBDD(reserva, dni,nom);
        }

        /// <summary>
        /// Serveix per actualitzar una reserva existent a la base de dades.
        /// </summary>
        /// <param name="reserva">Li passem una nova reserva.</param>
        /// <returns>Retorna true si es pot actualitzar la reserva, sino retorna false</returns>
        public bool UpdateReserva(Reserva reserva) 
        {
            return reservaBD.UpdateReservaBDD(reserva);
        }

        /// <summary>
        /// Serveix per eliminar una reserva de la base de dades.
        /// </summary>
        /// <param name="reserva">Li passem una reserva</param>
        /// <returns>Retorna true si pot eliminar la reserva, sino retorna false.</returns>
        public bool DeleteReserva(Reserva reserva) 
        {
            return reservaBD.DeleteReservaBDD(reserva);
        }

        /// <summary>
        /// Serveix per mostrar una llista de reserves d'un client específic.
        /// </summary>
        /// <param name="dni">Li passem el dni de la persona que volem veure les reserves</param>
        /// <returns>Retorna una List<> de les reserves de un client.</returns>
        public List<Reserva> ObtenirReservaList(string dni) 
        {
            return reservaBD.ObtenirReserves(dni);
        }
    }
}
