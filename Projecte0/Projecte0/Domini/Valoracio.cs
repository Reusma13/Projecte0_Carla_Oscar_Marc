using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projecte0.AccesDades;

namespace Projecte0.Domini
{
    public class Valoracio
    {
        // -------- Atributs --------
        protected int id;
        protected string comentari;
        protected int puntuacio;
        protected string dni;
        ValoracioBD valoracioBD = new ValoracioBD();

        // -------- Constructors --------
        /// <summary>
        /// Constructor buit
        /// </summary>
        public Valoracio()
        {
            id = 0;
            comentari = "";
            puntuacio = 0;
            dni = "";
        }

        /// <summary>
        /// Contructor amb els atributs de Valoracio
        /// </summary>
        /// <param name="puntuacio">La puntuacio que vol posar</param>
        /// <param name="comentari">El comentari que es vol posar</param>
        public Valoracio(string comentari, int puntuacio, string dni) : this()
        {
            this.comentari = comentari;
            this.puntuacio = puntuacio;
            this.dni = dni;
        }
        /// <summary>
        /// Constructor amb atribut de valoracio
        /// </summary>
        /// <param name="id">Id de la valoracio</param>
        /// <param name="comentari">Comentari del client</param>
        /// <param name="puntuacio">Puntacio del client</param>
        /// <param name="dni">Dni del client</param>
        public Valoracio(int id, string comentari, int puntuacio, string dni) : this(comentari,puntuacio,dni)
        {
            this.id = id;
        }
        // -------- Propietats --------
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Comentari
        {
            get { return comentari; }
            set { comentari = value; }
        }
        public int Puntuacio
        {
            get { return puntuacio; }
            set { puntuacio = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        /// <summary>
        /// Serveix per cridar al metode SelectValoracioBDD
        /// </summary>
        /// <returns>Retorna la llsita de valoracio</returns>
        public List<Valoracio> SelectValoracio()
        {
            return valoracioBD.SelectValoracioBDD();
        }

        public bool InsertValoracio(Valoracio valoracio, string nomRestaurant)
        {
            return valoracioBD.InsertValoracioBDD(valoracio, nomRestaurant);
        }

        public bool UpdateValoracio(Valoracio valoracio)
        {
            return valoracioBD.UpdateValoracioBDD(valoracio);
        }

        public bool DeleteValoracio(string dni)
        {
            return valoracioBD.DeleteValoracioBDD(dni);
        }
        public bool DeleteValoracio(Valoracio valoracio)
        {
            return valoracioBD.DeleteValoracioBDD(valoracio);
        }

        public List<Valoracio> ObtenirValoracions(string nom)
        {
            return valoracioBD.ObtenirValoracionsBDD(nom);
        }

        public bool EliminarValoracionsPorRestaurante(string nom)
        {
            return valoracioBD.EliminarValoracionsPorRestauranteBDD(nom);
        }
        public List<Valoracio> ObtenirValoracioClient(string dni)
        {
            return valoracioBD.ObtenirValoracioClient(dni);
        }
    }
}
