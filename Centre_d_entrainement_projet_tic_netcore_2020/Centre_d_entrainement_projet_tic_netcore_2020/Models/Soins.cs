using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Soins
    {
        public int Id_Soins { get; set; }
        public int Id_Cheval { get; set; }
        public int Id_Employe { get; set; }
        public string Alimentation { get; set; }
        public string Complement_Alimentation { get; set; }
        public DateTime Marechal { get; set; }
        public DateTime Vermifuge { get; set; }
        public string Note_Libre { get; set; }
    }
}
