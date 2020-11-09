using System;
using System.Collections.Generic;

namespace foots.Models
{
    public partial class MessageRecu
    {
        public int Ids { get; set; }
        public string Destinataire { get; set; }
        public int Expediteur { get; set; }
        public string Message { get; set; }
        public DateTime Heure { get; set; }
        public int? Vue { get; set; }
        public int? NonVue { get; set; }
        public virtual Membre ExpediteurNavigation { get; set; }

        public MessageRecu()
        {
         
        }
        public MessageRecu(string destinataire, int expediteur, string message, DateTime heure, int? vue, int? nonVue)
        {
            Destinataire = destinataire;
            Expediteur = expediteur;
            Message = message;
            Heure = heure;
            Vue = vue;
            NonVue = nonVue;
        }

        
    }
}
