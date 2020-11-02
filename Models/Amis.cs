using System;
using System.Collections.Generic;

namespace foots.Models
{
    public partial class Amis
    {
        public int Id { get; set; }
        public int IdMembre { get; set; }
        public int IdAmis { get; set; }

        public virtual Membre IdAmisNavigation { get; set; }
        public virtual Membre IdMembreNavigation { get; set; }
    }
}
