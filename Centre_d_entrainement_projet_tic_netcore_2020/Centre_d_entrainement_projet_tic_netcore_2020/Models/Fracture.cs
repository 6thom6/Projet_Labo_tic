using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Fracture
    {
        public int Id_Fracture { get; set; }
        public string Type_Fracture { get; set; }
        public DateTime Fracture_Indisponibilité { get; set; }
    }
}
