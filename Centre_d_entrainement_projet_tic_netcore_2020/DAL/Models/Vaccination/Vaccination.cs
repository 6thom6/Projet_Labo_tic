using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Vaccination
    {
        public int Id_Vaccination { get; set; }
        public string Nom_Vaccin { get; set; }
        public DateTime Delai_Indisponibilité { get; set; }
    }
}
