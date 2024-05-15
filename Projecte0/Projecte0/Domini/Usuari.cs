using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    class Usuari : Persona
    {
        // Atributs
        protected Valoracio puntuacio;

        // Constructors
        public Usuari() : base()
        {
            puntuacio = new Valoracio();
        }
        public Usuari(string dni, string nom, string cognom, string password, string esAdmin, Valoracio puntuacio) : base(dni, nom, cognom, password, esAdmin)
        {
            this.puntuacio = puntuacio;
        }

        // Propietats
        public Valoracio Puntuacio
        {
            get { return puntuacio; }
            set { puntuacio = value; }
        }

        // Metodes
        public Reserva RealitzarReserva()
        {
            // Implementa la lògica aquí
            return new Reserva();
        }

        public void CancelarReserva()
        {
            // Implementa la lògica aquí
        }

        public void CrearValoracio()
        {
            // Implementa la lògica aquí
        }

        // Metodes
        public Reserva RealitzarReserva(Restaurant restaurante, DateTime data, TimeSpan hora, int numComensals, string preferencies)
        {
            Reserva novaReserva = new Reserva()
            {
                //IdReserva = reserves.Count + 1, // Suposem que l'ID de la reserva és simplement el nombre de reserves + 1
                Data = data,
                Hora = hora,
                NumComensals = numComensals,
                Preferencies = preferencies
            };

            //reserves.Add(novaReserva);
            // restaurante.GestionarReserves(novaReserva);  Suposem que el restaurant té un mètode per gestionar les reserves

            return novaReserva;
        }

        /*public void CancelarReserva(int idReserva)
        {
            Reserva reservaACancelar = reserves.Find(r => r.IdReserva == idReserva);
            if (reservaACancelar != null)
            {
                reserves.Remove(reservaACancelar);
            }
        }*/

        public void CrearValoracio(int puntuacio, string comentari)
        {
            Valoracio novaValoracio = new Valoracio()
            {
                Puntuacio = puntuacio,
                Comentari = comentari
            };

            this.puntuacio = novaValoracio; // Suposem que cada usuari només pot tenir una valoració a la vegada
        }
    }
}
