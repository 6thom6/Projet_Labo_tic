using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
   public class Tendinite
    {
        public int Id_Tendinite { get; set; }
        public string Type_Tendinite { get; set; }
        public DateTime Tendinite_Indisponibilité { get; set; }
    }
}
