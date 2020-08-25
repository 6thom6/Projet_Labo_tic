using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    class Entrainement
    {
        public int Id_Entainement { get; set; }
        public string Cheval { get; set; }
        public string Plat { get; set; }
        public string Obstacle { get; set; }
        public string Marcheur { get; set; }
        public string Pré { get; set; }
        public DateTime Durée { get; set; }
    }
}
