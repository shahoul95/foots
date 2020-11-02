using System;
using System.Collections.Generic;

namespace foots.Models
{
    public partial class Membre
    {
        public Membre()
        {
            AmisIdAmisNavigation = new HashSet<Amis>();
            AmisIdMembreNavigation = new HashSet<Amis>();
            MessageRecu = new HashSet<MessageRecu>();
        }

        public int IdMembres { get; set; }
        public string Login { get; set; }
        public string MotPasses { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Phone { get; set; }
        public string Equipe { get; set; }
        public string Poste { get; set; }

        public Membre(string login, string motPasses, string nom, string prenom, string phone)
        {
            Login = login;
            MotPasses = motPasses;
            Nom = nom;
            Prenom = prenom;
            Phone = phone;
        }

        public virtual ICollection<Amis> AmisIdAmisNavigation { get; set; }
        public virtual ICollection<Amis> AmisIdMembreNavigation { get; set; }
        public virtual ICollection<MessageRecu> MessageRecu { get; set; }

        public string getnom()
        {
            return Nom;
        }
        public string getprenom()
        {
            return Prenom;
        }
        public string getequipe()
        {
            return Equipe;
        }
        public string getposte()
        {
            return Poste;
        }
        public int getid()
        {
            return IdMembres;
        }
    }
}
