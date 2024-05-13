using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Restaurant
    {
        // Atributs
        protected string nom;
        protected string direccio;
        protected string tipusCuina;
        protected int capacitat;
        protected List<string> fotos;

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
    }
}
