using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    public class Valoracio
    {
        // -------- Atributs --------
        protected string comentari;
        protected int puntuacio;
        protected string dni;

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

    }
}
