using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class Cheval
    {
        public int ID_Cheval { get; set; }
        public string Pere_Cheval { get; set; }
        public string Mere_Cheval { get; set; }
        public string Sortie_Provisoire { get; set; }
        public string Raison_SortieProvisoire { get; set; }
        public int ID_Proprietaire { get; set; }
        public int ID_Soins { get; set; }

    }
}
