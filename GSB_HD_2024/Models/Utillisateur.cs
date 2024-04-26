using System;
using System.Collections.Generic;

namespace GSB_HD_2024.Models
{
    public partial class Utillisateur
    {
        public int IdUser { get; set; }
        public string NomUser { get; set; } = null!;
        public string PrenomUser { get; set; } = null!;
        public string TelUser { get; set; } = null!;
        public string MdpUser { get; set; } = null!;
        public string LoginUser { get; set; } = null!;
    }
}
