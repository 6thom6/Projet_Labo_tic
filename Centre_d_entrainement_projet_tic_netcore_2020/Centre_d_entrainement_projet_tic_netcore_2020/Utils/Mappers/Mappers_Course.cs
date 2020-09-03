using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Centre_d_entrainement_projet_tic_netcore_2020;
using Centre_d_entrainement_projet_tic_netcore_2020.Models;
using DAL.Models;

namespace Centre_d_entrainement_projet_tic_netcore_2020.Utils.Mappers
{
   public static class Mappers_Course
    {
        public static Centre_d_entrainement_projet_tic_netcore_2020.Models.Course Dal_To_Consumme (this DAL.Models.Course course)
        {
            return new Centre_d_entrainement_projet_tic_netcore_2020.Models.Course
            {
                ID_Course = course.ID_Course,
                Hippodrome = course.Hippodrome,
                Jockey = course.Jockey,
                Corde = course.Corde,
                Discipline = course.Discipline,
                Terrain = course.Terrain,
                Avis = course.Avis,
                Poids_De_Course = course.Poids_De_Course,
                Date_Course = course.Date_Course
            };
        }

        public static DAL.Models.Course Consumme_To_Dal(this Models.Course course)
        {
            return new DAL.Models.Course
            {
                ID_Course = course.ID_Course,
                Hippodrome = course.Hippodrome,
                Jockey = course.Jockey,
                Corde = course.Corde,
                Discipline = course.Discipline,
                Terrain = course.Terrain,
                Avis = course.Avis,
                Poids_De_Course = course.Poids_De_Course,
                Date_Course = course.Date_Course
            };

        }
    }

}
