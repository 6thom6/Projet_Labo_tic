using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
   public static class Mappers_Tendinite
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Tendinite Dal_To_Consumme (this DAL.Models.Tendinite tendinite)
        {
            return new Models.Tendinite();
        }
        public static DAL.Models.Tendinite Consumme_To_Dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Tendinite tendinite)
        {
            return new DAL.Models.Tendinite();
        }
    }
}
