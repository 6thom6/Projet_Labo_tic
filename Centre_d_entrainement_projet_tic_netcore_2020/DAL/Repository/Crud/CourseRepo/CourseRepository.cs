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

            Course GetCourses = new Course();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM COURSE where id =@idCherch", _connection);
                    command.Parameters.AddWithValue("idCherch", idAChercher);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

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
                        Date_Course = reader["Date_Course"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Date_Course"],

                    };
             
                }
                return GetCourses;

            }


        }
        public void Create(Course NouvelleCourse)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO COURSE (ID_Course,Hippodrome,Jockey," + //les champs de la table
                                                     "Corde,Discipline," +
                                                     "Terrain,Avis,Poids,Date_Course,Poids_De_Course)" +
                                                     "VALUES (@id_course, @hippodrome, @jockey," + //les champs a rentrer
                                                     "@corde, @discipline, " +
                                                     "@terrain, @avis, @date_course,@poids_de_course)");

                command.Parameters.AddWithValue("id_course", NouvelleCourse.ID_Course);
                command.Parameters.AddWithValue("hippodrome", NouvelleCourse.Hippodrome);
                command.Parameters.AddWithValue("jockey", NouvelleCourse.Jockey);
                command.Parameters.AddWithValue("corde", NouvelleCourse.Corde);
                command.Parameters.AddWithValue("discipline", NouvelleCourse.Discipline);
                command.Parameters.AddWithValue("terrain", NouvelleCourse.Terrain);
                command.Parameters.AddWithValue("avis", NouvelleCourse.Avis);
                command.Parameters.AddWithValue("date_course", NouvelleCourse.Date_Course);
                command.Parameters.AddWithValue("poids_de_course", NouvelleCourse.Poids_De_Course);


                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Update(Course CourseAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE COURSE" + "SET Hippodrome = @hippodrome , " +
                    "Jockey = @jockey" + "Corde = @corde , Discipline = @discipline , " +
                    "Terrain = @terrain, Avis = @avis, " +
                    "Date_Course = @date_course, Poids_De_Course = @Poids_De_Course " +
                    "WHERE ID_Course = @id_course");

                command.Parameters.AddWithValue("id_course", CourseAModifier.ID_Course);
                command.Parameters.AddWithValue("hippodrome", CourseAModifier.Hippodrome);
                command.Parameters.AddWithValue("jockey", CourseAModifier.Jockey);
                command.Parameters.AddWithValue("corde", CourseAModifier.Corde);
                command.Parameters.AddWithValue("discipline", CourseAModifier.Discipline);
                command.Parameters.AddWithValue("terrain", CourseAModifier.Terrain);
                command.Parameters.AddWithValue("avis", CourseAModifier.Avis);
                command.Parameters.AddWithValue("date_course", CourseAModifier.Date_Course);
                command.Parameters.AddWithValue("poids_de_course", CourseAModifier.Poids_De_Course);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {
        
                using (_connection)
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM COURSE where ID = @id");
                    command.Parameters.AddWithValue("id", idADelete);
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            
        }
    }
}


