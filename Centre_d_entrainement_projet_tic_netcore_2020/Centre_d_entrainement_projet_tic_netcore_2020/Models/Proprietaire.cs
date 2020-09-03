using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
     public class Proprietaire
    {
        public int Id_Proprietaire { get; set; }
        public string Nom_Proprietaire { get; set; }
        public int Effectif { get; set; }
        public string Dernier_Resultats { get; set; }
        public DateTime Date_Arrivée { get; set; }
    }
}
