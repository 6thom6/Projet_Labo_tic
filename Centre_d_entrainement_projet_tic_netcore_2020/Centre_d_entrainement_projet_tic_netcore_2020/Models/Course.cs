using System;
using System.Collections.Generic;
using System.Text;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Models
{
    public class Course
    {
        public int ID_Course { get; set; }
        public string Hippodrome { get; set; }
        public string Jockey { get; set; }
        public string Corde { get; set; }
        public string Discipline { get; set; }
        public string Terrain { get; set; }
        public string Avis { get; set; }
        public float Poids_De_Course { get; set; }
        public DateTime Date_Course { get; set; }

    }
}

