using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Fracture
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Fracture Dal_To_Consumme (this DAL.Models.Fracture fracture)
        {
            return new Models.Fracture
            {
                Id_Fracture = fracture.Id_Fracture,
                Type_Fracture = fracture.Type_Fracture,
                Fracture_Indisponibilité = fracture.Fracture_Indisponibilité,
            };
        }
        public static DAL.Models.Fracture Consumme_To_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Fracture fracture)
        {
            return new DAL.Models.Fracture
            {
                Id_Fracture = fracture.Id_Fracture,
                Type_Fracture = fracture.Type_Fracture,
                Fracture_Indisponibilité = fracture.Fracture_Indisponibilité,
            };
        }
    }
}
