using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class Vaccination
    {
        public int Id_Vaccination { get; set; }
        public string Nom_Vaccin { get; set; }
        public DateTime Indisponibilite_Vaccin { get; set; }
    }
}
