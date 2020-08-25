using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class Employé
    {
        public int Id_Employé { get; set; }
        public int SoinsId_Cheval { get; set; }
        public string Nom_Employé  { get; set; }
        public string Statut_Employé { get; set; }

        public DateTime Employé_Embauche { get; set; }

    }
}
