using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Historique
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Historique Dal_To_Consumme (DAL.Models.Historique historique)
        {
            return new Models.Historique
            {
                Id_Cheval = historique.Id_Cheval,
                Id_Historique = historique.Id_Historique,
                Débourrage = historique.Débourrage,
                Preé_Entrainement = historique.Preé_Entrainement,
                Entraineur_Precedent = historique.Entraineur_Precedent,
                Proprietaire_Precedent = historique.Proprietaire_Precedent
            };


        }
        public static DAL.Models.Historique Consumme_to_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Historique historique)
        {
            return new DAL.Models.Historique
            {
                Id_Cheval = historique.Id_Cheval,
                Id_Historique = historique.Id_Historique,
                Débourrage = historique.Débourrage,
                Preé_Entrainement = historique.Preé_Entrainement,
                Entraineur_Precedent = historique.Entraineur_Precedent,
                Proprietaire_Precedent = historique.Proprietaire_Precedent

            };
        }
    }
}
