using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    public class Usuari : Persona
    {
        // -------- Atributs --------
        protected Valoracio puntuacio;
        protected List<Reserva> reserves;

        // -------- Constructors --------
        /// <summary>
        /// Constructor buit amb la base de la clase pare
        /// </summary>
        public Usuari() : base()
        {
            puntuacio = new Valoracio();
            reserves = new List<Reserva>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dni">El DNI de la persona</param>
        /// <param name="nom">El nom de la persona</param>
        /// <param name="cognom">El cognom de la persona</param>
        /// <param name="password">La contrasenya de la persona</param>
        /// <param name="esAdmin">Indicant si es admin o no</param>
        /// <param name="puntuacio">Valoracio de aquest usuari</param>
        public Usuari(string dni, string nom, string cognom, string password,string esAdmin, Valoracio puntuacio) : base(dni, nom, cognom, password, esAdmin)
        {
            this.dni = dni;
            this.nom = nom;
            this.cognom = cognom;
            this.password = password;
            this.esAdmin = esAdmin;
            this.puntuacio = puntuacio;
            this.reserves = new List<Reserva>();
        }

        // -------- Propietats --------
        public Valoracio Puntuacio
        {
            get { return puntuacio; }
            set { puntuacio = value; }
        }



        // -------- Metodes --------

        //FALTA COMENTARIO
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

        /// <summary>
        /// Per crear una valoracio
        /// </summary>
        /// <param name="puntuacio">La puntuacio que vol posar</param>
        /// <param name="comentari">El comentari que es vol posar</param>
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

