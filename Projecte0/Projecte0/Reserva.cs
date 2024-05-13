using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Reserva
    {
        // Atributs
        protected int idReserva;
        protected DateTime data;
        protected TimeSpan hora;
        protected int numComensals;
        protected string preferencies;

        // Constructors
        public Reserva()
        {
            idReserva = 0;
            data = DateTime.Now;
            hora = TimeSpan.Zero;
            numComensals = 0;
            preferencies = "";
        }
        public Reserva(int idReserva, DateTime data, TimeSpan hora, int numComensals, string preferencies)
        {
            this.idReserva = idReserva;
            this.data = data;
            this.hora = hora;
            this.numComensals = numComensals;
            this.preferencies = preferencies;
        }

        // Propietats
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
    }
}
