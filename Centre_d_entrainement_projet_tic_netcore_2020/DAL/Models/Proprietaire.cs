using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class Proprietaire
    {
        public int Id_Proprietaire { get; set; }
        public string Nom_Proprietaire { get; set; }
        public int Effectif { get; set; }
        public string Dernier_Resultats { get; set; }
        public DateTime Arrive_ecurie { get; set; }

    }
}
