using System;
using System.Collections.Generic;

namespace GSB_HD_2024.Models
{
    public partial class Medecin
    {
        public int IdMedecin { get; set; }
        public string PrenomMed { get; set; } = null!;
        public string NomMed { get; set; } = null!;
        public string TelMed { get; set; } = null!;
        public int IdSpecialite { get; set; }
        public string IdDepartement { get; set; } = null!;

        public virtual Departement? IdDepartementNavigation { get; set; } = null!;
        public virtual Specialite? IdSpecialiteNavigation { get; set; } = null!;
    }
}
