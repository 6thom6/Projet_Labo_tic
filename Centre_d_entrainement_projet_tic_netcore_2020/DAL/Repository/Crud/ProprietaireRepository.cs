using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL.Repository.Crud
{
    class ProprietaireRepository : IProprietaireRepository
    {
        public SqlConnection _connection;

        public ProprietaireRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Proprietaire> GetallProprietaire()
        {
            List<Proprietaire> GetallProprietaire = new List<Proprietaire>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Proprietaire", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallProprietaire.Add(
                        new Proprietaire
                        {
                            Id_Proprietaire = reader["Id_Proprietaire"] == DBNull.Value ? 0 : (int)reader["Id_Proprietaire"],
                            Nom_Proprietaire = reader["Nom_Proprietaire"] == DBNull.Value ? string.Empty : (string)reader["Nom_Proprietaire"],
                            Dernier_Resultats = reader["Dernier_Resultats"] == DBNull.Value ? string.Empty : (string)reader["Dernier_Resultats"],
                            Effectif = reader["Effectif"] == DBNull.Value ? 0 : (int)reader["Effectif"],
                            Arrive_ecurie = reader["Arrive_ecurie"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Arrive_ecurie"],

                        }
                        );
                }
            }

            return GetallProprietaire;
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
