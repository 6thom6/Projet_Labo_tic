using DAL_ = DAL;
using Conso = Centre_d_entrainement_projet_tic_netcore_2020;

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Runtime.CompilerServices;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models.Utils.Mappers
{
    public static class Mappers_Cheval
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Cheval Dal_To_Consumme (this DAL.Models.Cheval cheval)
        {
            return new Cheval
            {
                ID_Cheval = cheval.ID_Cheval,
                Nom_cheval = cheval.Nom_cheval,
                Pere_Cheval = cheval.Pere_Cheval,
                Mere_Cheval = cheval.Mere_Cheval,
                Sortie_Provisoire = cheval.Sortie_Provisoire,
                Raison_SortieProvisoire = cheval.Raison_SortieProvisoire,
                ID_Proprietaire = cheval.ID_Proprietaire,
                ID_Soins = cheval.ID_Soins,
                Poids = cheval.Poids,
                Race = cheval.Race,
            };
        }
        public static DAL.Models.Cheval Consumme_to_dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Cheval cheval)
        {
            return new DAL_.Models.Cheval
            {
                ID_Cheval = cheval.ID_Cheval,
                Nom_cheval = cheval.Nom_cheval,
                Pere_Cheval = cheval.Pere_Cheval,
                Mere_Cheval = cheval.Mere_Cheval,
                Sortie_Provisoire = cheval.Sortie_Provisoire,
                Raison_SortieProvisoire = cheval.Raison_SortieProvisoire,
                ID_Proprietaire = cheval.ID_Proprietaire,
                ID_Soins = cheval.ID_Soins,
                Poids = cheval.Poids,
                Race = cheval.Race,
            };
        }

    }
}
