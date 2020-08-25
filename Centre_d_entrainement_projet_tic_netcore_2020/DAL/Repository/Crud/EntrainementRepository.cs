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
            }

            return GetallEntrainement;
        }
        public Entrainement Get(int idAChercher)
        {
            return new Entrainement();
        }
        public void Create(Entrainement NouvelEntrainement)
        {

        }
        public void Update(Entrainement EntrainementAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }

    }
}
