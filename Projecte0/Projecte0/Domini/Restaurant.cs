using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    class Restaurant
    {
        // Atributs
        protected string nom;
        protected string direccio;
        protected string tipusCuina;
        protected int capacitat;
        protected List<string> fotos;
        protected List<Reserva> reserves;

        // Constructors
        public Restaurant()
        {
            nom = "";
            direccio = "";
            tipusCuina = "";
            capacitat = 0;
            fotos = new List<string>();
        }
        public Restaurant(string nom, string direccio, string tipusCuina, int capacitat, List<string> fotos)
        {
            this.nom = nom;
            this.direccio = direccio;
            this.tipusCuina = tipusCuina;
            this.capacitat = capacitat;
            this.fotos = fotos;
        }

        // Propietats
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

        // Metodes
        public void ActualitzarReserva(int idReserva, DateTime novaData, TimeSpan novaHora, int numComensals, string preferencies)
        {
            Reserva reservaAActualitzar = reserves.Find(r => r.IdReserva == idReserva);
            if (reservaAActualitzar != null)
            {
                reservaAActualitzar.Data = novaData;
                reservaAActualitzar.Hora = novaHora;
                reservaAActualitzar.NumComensals = numComensals;
                reservaAActualitzar.Preferencies = preferencies;
            }
        }

        public void ModificarReserva(int idReserva, DateTime novaData, TimeSpan novaHora, int numComensals, string preferencies)
        {
            Reserva reservaAModificar = reserves.Find(r => r.IdReserva == idReserva);
            if (reservaAModificar != null)
            {
                reservaAModificar.Data = novaData;
                reservaAModificar.Hora = novaHora;
                reservaAModificar.NumComensals = numComensals;
                reservaAModificar.Preferencies = preferencies;
            }
        }

        public List<Reserva> VisualitzarReserves()
        {
            return reserves;
        }
    }
}
