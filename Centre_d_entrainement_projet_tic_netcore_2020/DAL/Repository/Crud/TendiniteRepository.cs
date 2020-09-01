using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud
{
    class TendiniteRepository : ITendiniteRepository
    {
        public SqlConnection _connection;

        public TendiniteRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Tendinite> GetallHistorique()
        {
            List<Tendinite> GetallTendinite = new List<Tendinite>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Tendinite", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallTendinite.Add(
                        new Tendinite
                        {
                            Id_Tendinite = reader["Id_Tendinite"] == DBNull.Value ? 0 : (int)reader["Id_Tendinite"],
                            Type_Tendinite = reader["Type_Tendinite"] == DBNull.Value ? string.Empty : (string)reader["Type_Tendinite"],
                            Tendinite_Indisponibilité = reader["Tendinite_Indisponibilité"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Tendinite_Indisponibilité"]
                        }
                        );
                }
            }
            _connection.Close();
            return GetallTendinite;
        }
        public Tendinite Get(int idAChercher)
        {
            Tendinite GetTendinite = new Tendinite();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Tendinite where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Tendinite
                    {
                        Id_Tendinite = reader["Id_Tendinite"] == DBNull.Value ? 0 : (int)reader["Id_Tendinite"],
                        Type_Tendinite = reader["Type_Tendinite"] == DBNull.Value ? string.Empty : (string)reader["Type_Tendinite"],
                        Tendinite_Indisponibilité = reader["Tendinite_Indisponibilité"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Tendinite_Indisponibilité"]
                    };
                     
                }
            }
            _connection.Close();
            return GetTendinite;
        }
        public void Create(Tendinite NouvelleTendinite)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Tendinite (Type_tendinite,tendinite_Indisponibilité,Id_Tendinite," //les champs de la table
                                                     +
                                                     "VALUES (@type_tendinite, @tendinite_indisponibilite, @id_tendinite)");



                command.Parameters.AddWithValue("id_tendinite", NouvelleTendinite.Id_Tendinite);
                command.Parameters.AddWithValue("type_tendinite", NouvelleTendinite.Type_Tendinite);
                command.Parameters.AddWithValue("tendinite_indisponibilite", NouvelleTendinite.Tendinite_Indisponibilité);



                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Update(Tendinite TendiniteAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Tendinite SET Id_Tendinite = @id_tendinite, Type_Tendinite = @type_tendinite, Tendinite_Indisponibilité = @tendinite_indisponibilite"); //les champs de la table




                command.Parameters.AddWithValue("id_tendinite", TendiniteAModifier.Id_Tendinite);
                command.Parameters.AddWithValue("type_tendinite", TendiniteAModifier.Type_Tendinite);
                command.Parameters.AddWithValue("tendinite_indisponibilite", TendiniteAModifier.Tendinite_Indisponibilité);



                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

        }
    }
}
