using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Repository.IRepository;
using DAL.Models;

namespace DAL.Repository.Crud
{
    class EntrainementRepository : IEntrainementRepository
    {

        public SqlConnection _connection;

        public EntrainementRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Entrainement> GetallEntrainement()
        {
            List<Entrainement> GetallEntrainement = new List<Entrainement>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Entrainement", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallEntrainement.Add(
                        new Entrainement
                        {
                            Id_Entainement = reader["Id_Entainement"] == DBNull.Value ? 0 : (int)reader["Id_Entainement"],
                            Cheval = reader["Cheval"] == DBNull.Value ? string.Empty : (string)reader["Cheval"],
                            Plat = reader["Plat"] == DBNull.Value ? string.Empty : (string)reader["Plat"],
                            Obstacle = reader["Obstacle"] == DBNull.Value ? string.Empty : (string)reader["Obstacle"],
                            Marcheur = reader["Marcheur"] == DBNull.Value ? string.Empty : (string)reader["Marcheur"],
                            Pré = reader["Pré"] == DBNull.Value ? string.Empty : (string)reader["Pré"],
                            Durée = reader["Durée"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Durée"],

                        }
                        );
                }

                return GetallEntrainement;
            }

        }
        public Entrainement Get(int idAChercher)
        {
            Entrainement GetEntrainement = new Entrainement();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Entrainement where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Entrainement
                    {
                        Id_Entainement = reader["Id_Entainement"] == DBNull.Value ? 0 : (int)reader["Id_Entainement"],
                        Cheval = reader["Cheval"] == DBNull.Value ? string.Empty : (string)reader["Cheval"],
                        Plat = reader["Plat"] == DBNull.Value ? string.Empty : (string)reader["Plat"],
                        Obstacle = reader["Obstacle"] == DBNull.Value ? string.Empty : (string)reader["Obstacle"],
                        Marcheur = reader["Marcheur"] == DBNull.Value ? string.Empty : (string)reader["Marcheur"],
                        Pré = reader["Pré"] == DBNull.Value ? string.Empty : (string)reader["Pré"],
                        Durée = reader["Durée"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Durée"],

                    };
                     
                }
                return GetEntrainement;
            }
        }
        public void Create(Entrainement NouvelEntrainement)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Entrainement (Id_Entainement,Cheval,Plat," + //les champs de la table
                                                     "Obstacle,Marcheur," +
                                                     "Pré,Durée)" +
                                                     "VALUES (@id_entrainement, @cheval, @plat," + //les champs a rentrer
                                                     "@obstacle, @marcheur, " +
                                                     "@pré, @durée)");

                command.Parameters.AddWithValue("id_entrainement", NouvelEntrainement.Id_Entainement);
                command.Parameters.AddWithValue("cheval", NouvelEntrainement.Cheval);
                command.Parameters.AddWithValue("plat", NouvelEntrainement.Plat);
                command.Parameters.AddWithValue("obstacle", NouvelEntrainement.Obstacle);
                command.Parameters.AddWithValue("marcheur", NouvelEntrainement.Marcheur);
                command.Parameters.AddWithValue("pré", NouvelEntrainement.Pré);
                command.Parameters.AddWithValue("durée", NouvelEntrainement.Durée);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Entrainement EntrainementAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Entrainement SET Cheval = @cheval, Plat = @plat" +
                    "Obstacle = @obstacle , Marcheur = @obstacle, Pré = @pré , Durée = @durée" +
                    "Where Id_Entainement = @id_entrainement");

                command.Parameters.AddWithValue("id_entrainement", EntrainementAModifier.Id_Entainement);
                command.Parameters.AddWithValue("cheval", EntrainementAModifier.Cheval);
                command.Parameters.AddWithValue("plat", EntrainementAModifier.Plat);
                command.Parameters.AddWithValue("obstacle", EntrainementAModifier.Obstacle);
                command.Parameters.AddWithValue("marcheur", EntrainementAModifier.Marcheur);
                command.Parameters.AddWithValue("pré", EntrainementAModifier.Pré);
                command.Parameters.AddWithValue("durée", EntrainementAModifier.Durée);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

        }

    }
}
