using Projecte0.AccesDades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projecte0.Domini
{
    public class Persona
    {

        PersonaBD personaBD;
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
            personaBD = new PersonaBD();
        }

        /// <summary>
        /// Contructor amb tots els atributs de persona
        /// </summary>
        /// <param name="dni">El DNI de la persona</param>
        /// <param name="nom">El nom de la persona</param>
        /// <param name="cognom">El cognom de la persona</param>
        /// <param name="password">La contrasenya de la persona</param>
        public Persona(string dni, string nom, string cognom, string password) : this()
        {
            this.dni = dni;
            this.nom = nom;
            this.cognom = cognom;
            this.password = password;
        }

        /// <summary>
        /// Contructor amb tots els atributs de persona i indicant si es admin o no
        /// </summary>
        /// <param name="dni">El DNI de la persona</param>
        /// <param name="nom">El nom de la persona</param>
        /// <param name="cognom">El cognom de la persona</param>
        /// <param name="password">La contrasenya de la persona</param>
        /// <param name="esAdmin">Indicant si es admin o no</param>
        public Persona(string dni, string nom, string cognom, string password, string esAdmin) : this(dni,nom,cognom,password)
        {
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
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        // -------- Metodes --------
        /// <summary>
        /// Selecciona una persona en concret de la base de dades
        /// </summary>
        /// <param name="dni">Dni de la persona que vols seleccionar</param>
        /// <param name="password">Contrasenya de la persona que vols seleccionar</param>
        /// <returns>Retorna la persona seleccionada si existeix a la base de dades, si no existeix, retorna null.</returns>
        public Persona SelectPersona(string dni, string password)
        {
            Persona p = personaBD.SelectPersonesBDD(dni, password);
            return p;
        }

        /// <summary>
        /// Afegeix una persona a la base de dades
        /// </summary>
        /// <param name="persona">Persona que es vol afegir</param>
        /// <returns>Torna true si la persona s'ha afegit correctament, si no, retorna false</returns>
        public bool InsertPersona(Persona persona)
        {
            return personaBD.InsertPersonaBDD(persona);
        }
        public bool DeletePersona(string dni)
        {
            return personaBD.DeletePersonaBDD(dni);
        }

        // Sobreescriptura
        /// <summary>
        /// Comprova si dos persones son iguals
        /// </summary>
        /// <param name="a">Primera persona a comparar</param>
        /// <param name="b">Segona persona a comparar</param>
        /// <returns>Retorna true si els dos objectes Persona son iguals, si no, retorna false</returns>
        public static bool operator==(Persona a, Persona b)
        {
            return a.dni == b.dni;
        }

        /// <summary>
        /// Comprova si dos persones son diferents
        /// </summary>
        /// <param name="a">Primera persona a comparar</param>
        /// <param name="b">Segona persona a comparar</param>
        /// <returns>Retorna true si els dos objectes Persona son diferents, si no, retorna false</returns>
        public static bool operator!=(Persona a, Persona b)
        {
            return !(a.dni == b.dni);
        }
    }
}
