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
        public Valoracio()
        {
            comentari = "";
            puntuacio = 0;
            dni = "";
        }
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
