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
                            Poids_De_Course = reader["Poids_De_Course"] == DBNull.Value ? 0 : (float)reader["Poids_De_Course"],
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
        public void Create(Course NouvelleCourse)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO CHEVAL (ID_Course,Hippodrome,Jockey," + //les champs de la table
                                                 "Corde,Discipline," +
                                                 "Terrain,Avis,Poids,Date_Course,Poids_De_Course)" +
                                                 "VALUES (@id_course, @hippodrome, @jockey," + //les champs a rentrer
                                                 "@corde, @discipline, " +
                                                 "@terrain, @avis, @date_course,@poids_de_course)");

            command.Parameters.AddWithValue("id_course",NouvelleCourse.ID_Course);
            command.Parameters.AddWithValue("hippodrome", NouvelleCourse.Hippodrome);
            command.Parameters.AddWithValue("Jockey", NouvelleCourse.Jockey);
            command.Parameters.AddWithValue("corde", NouvelleCourse.Corde);
            command.Parameters.AddWithValue("discipline", NouvelleCourse.Discipline);
            command.Parameters.AddWithValue("terrain", NouvelleCourse.Terrain);
            command.Parameters.AddWithValue("avis", NouvelleCourse.Avis);
            command.Parameters.AddWithValue("date_course", NouvelleCourse.Date_Course);
            command.Parameters.AddWithValue("poids_de_course", NouvelleCourse.Poids_De_Course);
   

            command.ExecuteNonQuery();



            _connection.Close();

        }
        public void Update(Course CourseAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}


