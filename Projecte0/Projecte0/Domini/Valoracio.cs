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
            comentari = "";
            puntuacio = 0;
            dni = "";
        }

        /// <summary>
        /// Contructor amb els atributs de Valoracio
        /// </summary>
        /// <param name="puntuacio">La puntuacio que vol posar</param>
        /// <param name="comentari">El comentari que es vol posar</param>
        public Valoracio(string comentari, int puntuacio, string dni)
        {
            this.comentari = comentari;
            this.puntuacio = puntuacio;
            this.dni = dni;
        }

        // -------- Propietats --------
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

        public List<Valoracio> SelectValoracio() // M�todo para obtener todas las valoraciones de la base de datos.
        {
            return valoracioBD.SelectValoracioBDD();
        }

        public bool InsertValoracio(Valoracio valoracio)  // M�todo para insertar una nueva valoraci�n en la base de datos.
        {
            return valoracioBD.InsertValoracioBDD(valoracio);
        }

        public bool UpdateValoracio(Valoracio valoracio) // M�todo para actualizar una valoraci�n existente en la base de datos.
        {
            return valoracioBD.UpdateValoracioBDD(valoracio);
        }

        public bool DeleteValoracio(string dni)  // M�todo para eliminar una valoraci�n de la base de datos utilizando el DNI del cliente.
        {
            return valoracioBD.DeleteValoracioBDD(dni);
        }

        public List<Valoracio> ObtenirValoracions(string nom) // M�todo para obtener todas las valoraciones de un restaurante espec�fico.
        {
            return valoracioBD.ObtenirValoracionsBDD(nom);
        }

        public bool EliminarValoracionsPorRestaurante(string nom) // M�todo para eliminar todas las valoraciones de un restaurante espec�fico.
        {
            return valoracioBD.EliminarValoracionsPorRestauranteBDD(nom);
        }
    }
}
