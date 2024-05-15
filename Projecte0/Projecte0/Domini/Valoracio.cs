using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    class Valoracio
    {
        // Atributs
        protected string comentari;
        protected int puntuacio;

        // Constructors
        public Valoracio()
        {
            comentari = "";
            puntuacio = 0;
        }
        public Valoracio(string comentari, int puntuacio)
        {
            this.comentari = comentari;
            this.puntuacio = puntuacio;
        }

        // Propietats
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
    }
}
