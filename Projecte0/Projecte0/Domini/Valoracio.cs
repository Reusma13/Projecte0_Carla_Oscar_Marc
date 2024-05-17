using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    class Valoracio
    {
        // -------- Atributs --------
        protected string comentari;
        protected int puntuacio;

        // -------- Constructors --------
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

    }
}
>>>>>>> 61de0b1df7b480c63818765f156e52a9581fcbc5:Projecte0/Projecte0/Valoracio.cs
