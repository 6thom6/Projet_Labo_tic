using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Repository.IRepository;
using DAL.Models;

namespace DAL.Repository.Crud
{
    class CourseRepository : ICourseRepository
    {
        public SqlConnection _connection;

        public CourseRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Course> GetallCourses()
        {
            List<Course> GetallCourses = new List<Course>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM COURSE", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallCourses.Add(
                        new Course
                        {
                            ID_Course = reader["ID_Course"] == DBNull.Value ? 0 : (int)reader["ID_Course"],
                            Hippodrome = reader["Hippodrome"] == DBNull.Value ? string.Empty : (string)reader["Hippodrome"],
                            Jockey = reader["Jockey"] == DBNull.Value ? string.Empty : (string)reader["Jockey"],
                            Corde = reader["Corde"] == DBNull.Value ? string.Empty : (string)reader["Corde"],
                            Discipline = reader["Discipline"] == DBNull.Value ? string.Empty : (string)reader["Discipline"],
                            Terrain = reader["Terrain"] == DBNull.Value ? string.Empty : (string)reader["Terrain"],
                            Avis = reader["Avis"] == DBNull.Value ? string.Empty : (string)reader["Avis"],
                            Date_Course = reader["Date_Course"] == DBNull.Value ? DateTime.Now:(DateTime)reader["Date_Course"],

                        }
                        ) ;
                }
            }

            return GetallCourses;
        }
        public Course Get(int idAChercher)
        {
            return new Course();
        }
        public void Create(Course NouveauCheval)
        {

        }
        public void Update(Course ChevalAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}


