using DAL.Models;
using System.Collections.Generic;
using DAL.Repository.Crud;

namespace DAL.Repository.Crud
{
    interface ICourseRepository
    {
        void Create(Course NouveauCheval);
        void Delete(int idADelete);
        List<Course> GetallCourses();
        Course Get(int idaChercher);
        void Update(Course ChevalAModifier);
    }
}