using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Historique
    {
        public int Id_Historique { get; set; }
        public int Id_Cheval { get; set; }
        public string Débourrage { get; set; }
        public string Preé_Entrainement { get; set; }
        public string Entraineur_Precedent { get; set; }
        public string Proprietaire_Precedent { get; set; }
  
    }
}
