using System;
using System.Collections.Generic;
using System.Text;
//1.10 video loic//
namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Vaccination
    {
        public int Id_Vaccination { get; set; }
        public string Nom_Vaccin { get; set; }
        public DateTime Delai_Indisponibilité { get; set; }
    }
}
