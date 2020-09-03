using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Proprietaire
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Proprietaire Dal_To_Consumme (this DAL.Models.Proprietaire proprietaire)
        {
            return new Models.Proprietaire
            {
                Id_Proprietaire = proprietaire.Id_Proprietaire,
                Nom_Proprietaire = proprietaire.Nom_Proprietaire,
                Effectif = proprietaire.Effectif,
                Dernier_Resultats = proprietaire.Dernier_Resultats,

            };
        }
        public static DAL.Models.Proprietaire Consumme_To_Dal(this Centre_d_entrainement_projet_tic_netcore_2020.Models.Proprietaire proprietaire)
        {
            return new DAL.Models.Proprietaire
            {
                Id_Proprietaire = proprietaire.Id_Proprietaire,
                Nom_Proprietaire = proprietaire.Nom_Proprietaire,
                Effectif = proprietaire.Effectif,
                Dernier_Resultats = proprietaire.Dernier_Resultats,
            };
        }
    }
}
