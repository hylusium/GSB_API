using System;
using System.Collections.Generic;

namespace GSB_HD_2024.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Medecins = new HashSet<Medecin>();
        }

        public string IdDepartement { get; set; } = null!;
        public string NomDepartement { get; set; } = null!;
        public string CodeRegion { get; set; } = null!;
        public string NomRegionDepartement { get; set; } = null!;

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}
