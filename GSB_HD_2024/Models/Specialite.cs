using System;
using System.Collections.Generic;

namespace GSB_HD_2024.Models
{
    public partial class Specialite
    {
        public Specialite()
        {
            Medecins = new HashSet<Medecin>();
        }

        public int IdSpecialite { get; set; }
        public string NomSpe { get; set; } = null!;

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
