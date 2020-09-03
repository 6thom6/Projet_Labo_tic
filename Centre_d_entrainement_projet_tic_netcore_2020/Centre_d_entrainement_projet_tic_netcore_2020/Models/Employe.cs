using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Employe
    {
        public int Id_Employé { get; set; }
        public int SoinsId_Cheval { get; set; }
        public string Nom_Employé { get; set; }
        public string Statut_Employé { get; set; }
        public DateTime Employé_Embauche { get; set; }
    }
}
