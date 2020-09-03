using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Vaccination
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Vaccination Dal_To_Consumme (this DAL.Models.Vaccination vaccination)
        {
            return new Models.Vaccination();
        }
        public static DAL.Models.Vaccination Consumme_To_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Vaccination vaccination)
        {
            return new DAL.Models.Vaccination();
        }
    }
}
