
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0
{
    class Persona
    {
        // -------- Atributs --------
        protected string dni;
        protected string nom;
        protected string cognom;
        protected string password;
        protected string esAdmin;

        // -------- Constructors --------

        /// <summary>
        /// Constructor buit de Persona
        /// </summary>
        public Persona() 
        {
            dni = "";
            nom = "";
            cognom = "";
            password = "";
            esAdmin = "no";
        }

        /// <summary>
        /// Contructor amb tots els atributs de persona
        /// </summary>
        /// <param name="dni">El DNI de la persona</param>
        /// <param name="nom">El nom de la persona</param>
        /// <param name="cognom">El cognom de la persona</param>
        /// <param name="password">La contrasenya de la persona</param>
        public Persona(string dni, string nom, string cognom, string password, string esAdmin)
        {
            this.dni = dni;
            this.nom = nom;
            this.cognom = cognom;
            this.password = password;
            this.esAdmin = esAdmin;
        }

        // -------- Propietats --------
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Cognom
        { 
            get { return cognom; } 
            set { cognom = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string EsAdmin
        {
            get { return esAdmin;}
            set { esAdmin = value; }
        }
        // -------- Metodes --------
        /*public bool ComprovarBDD()
        {
            
        }*/
    }
}
