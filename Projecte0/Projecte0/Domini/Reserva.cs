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

        // M�todes per interactuar amb la base de dades.
        public Reserva SelectReserva(int idReserva) // Retorna una reserva espec�fica de la base de dades.
        {
            return reservaBD.SelectReservaBDD(idReserva);
        }

        public bool InsertReserva(Reserva reserva, string dni) // Insereix una nova reserva a la base de dades.
        {
            return reservaBD.InsertReservaBDD(reserva, dni);
        }

        public bool UpdateReserva(Reserva reserva) // Actualitza una reserva existent a la base de dades.
        {
            return reservaBD.UpdateReservaBDD(reserva);
        }

        public bool DeleteReserva(Reserva reserva) // Elimina una reserva de la base de dades.
        {
            return reservaBD.DeleteReservaBDD(reserva);
        }
        public List<Reserva> ObtenirReservaList(string dni) // Retorna una llista de reserves d'un client espec�fic.
        {
            return reservaBD.ObtenirReserves(dni);
        }
    }
}
