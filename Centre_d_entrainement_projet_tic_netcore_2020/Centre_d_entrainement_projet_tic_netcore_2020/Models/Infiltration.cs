using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Infiltration
    {
        public int Id_Infiltration { get; set; }

        public string Type_Infiltration { get; set; }

        public DateTime Delai_Indisponibile { get; set; }
    }
}
