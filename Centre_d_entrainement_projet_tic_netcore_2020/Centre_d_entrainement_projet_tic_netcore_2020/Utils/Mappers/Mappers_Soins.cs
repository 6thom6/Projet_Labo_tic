using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
    public static class Mappers_Soins
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Soins Dal_To_Consumme(this DAL.Models.Soins soins)
        {
            return new Models.Soins();

        }
        public static DAL.Models.Soins Consumme_to_dal (this Centre_d_entrainement_projet_tic_netcore_2020.Models.Soins soins)
        {
            return new DAL.Models.Soins();
        }
    }
}
