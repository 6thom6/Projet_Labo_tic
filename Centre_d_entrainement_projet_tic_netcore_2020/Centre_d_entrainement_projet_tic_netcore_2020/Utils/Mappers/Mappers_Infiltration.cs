using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Infiltration
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Infiltration Dal_To_Consumme (this DAL.Models.Infiltration infiltration)
        {
            return new Models.Infiltration
            {
                Id_Infiltration = infiltration.Id_Infiltration,
                Type_Infiltration = infiltration.Type_Infiltration,
                Delai_Indisponibile = infiltration.Delai_Indisponibile,
            };
        }
        public static DAL.Models.Infiltration Consumme_To_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Infiltration infiltration)
        {
            return new DAL.Models.Infiltration
            {
                Id_Infiltration = infiltration.Id_Infiltration,
                Type_Infiltration = infiltration.Type_Infiltration,
                Delai_Indisponibile = infiltration.Delai_Indisponibile,
            };
        }
    }
}
