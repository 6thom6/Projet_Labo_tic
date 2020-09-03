using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
   public static  class Mappers_Entrainement
    {
        public static Models.Entrainement Dal_to_consummme(this DAL.Models.Entrainement entrainement)
        {
            return new Models.Entrainement
            {
                Id_Entainement = entrainement.Id_Entainement,
                Cheval = entrainement.Cheval,
                Plat = entrainement.Plat,
                Obstacle = entrainement.Obstacle,
                Marcheur = entrainement.Marcheur,
                Pré = entrainement.Pré
            };
        }
        public static DAL.Models.Entrainement Consummme_To_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Entrainement entrainement)
        {
            return new DAL.Models.Entrainement
            {
                Id_Entainement = entrainement.Id_Entainement,
                Cheval = entrainement.Cheval,
                Plat = entrainement.Plat,
                Obstacle = entrainement.Obstacle,
                Marcheur = entrainement.Marcheur,
                Pré = entrainement.Pré
            };
        }
    }
}
