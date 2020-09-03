using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Cheval
    {
        public int ID_Cheval { get; set; }
        public string Nom_cheval {get;set;}
        public string Pere_Cheval { get; set; }
        public string Mere_Cheval { get; set; }
        public string Sortie_Provisoire { get; set; }
        public string Raison_SortieProvisoire { get; set; }
        public int ID_Proprietaire { get; set; }
        public int ID_Soins { get; set; }
        public int Poids { get; set; }
        public string Race { get; set; }
    }
}
