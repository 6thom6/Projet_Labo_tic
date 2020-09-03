using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Employe
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Employe Dal_To_Consumme (this DAL.Models.Employé employé)
        {
            return new Models.Employe
            {
                Id_Employé = employé.Id_Employé,
                SoinsId_Cheval = employé.SoinsId_Cheval,
                Nom_Employé = employé.Nom_Employé,
                Statut_Employé = employé.Statut_Employé,
                Employé_Embauche = employé.Employé_Embauche
            };
        }
        public static DAL.Models.Employé Consumme_to_dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Employe employe)
        {
            return new DAL.Models.Employé
            {
                Id_Employé = employe.Id_Employé,
                SoinsId_Cheval = employe.SoinsId_Cheval,
                Nom_Employé = employe.Nom_Employé,
                Statut_Employé = employe.Statut_Employé,
                Employé_Embauche = employe.Employé_Embauche
            };
        }
    }
}
