﻿using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud
{
    class InfiltrationRepository : IInfiltrationRepository
    {
        public SqlConnection _connection;

        public InfiltrationRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Infiltration> GetallInfiltration()
        {
            List<Infiltration> GetallInfiltration = new List<Infiltration>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Infiltration", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallInfiltration.Add(
                        new Infiltration
                        {
                            Id_Infiltration = reader["Id_Infiltration"] == DBNull.Value ? 0 : (int)reader["Id_Infiltration"],
                            Type_Infiltration = reader["Type_Infiltration"] == DBNull.Value ? string.Empty : (string)reader["Type_Infiltration"],
                            Delai_Indisponibile = reader["Delai_Indisponibile"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Delai_Indisponibile"]
                        }
                        );
                }
            }
            _connection.Close();
            return GetallInfiltration;
        }
        public Infiltration Get(int idAChercher)
        {
            Infiltration GetInfiltration = new Infiltration();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Infiltration where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Infiltration
                    {
                        Id_Infiltration = reader["Id_Infiltration"] == DBNull.Value ? 0 : (int)reader["Id_Infiltration"],
                        Type_Infiltration = reader["Type_Infiltration"] == DBNull.Value ? string.Empty : (string)reader["Type_Infiltration"],
                        Delai_Indisponibile = reader["Delai_Indisponibile"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Delai_Indisponibile"]
                    };
                        
                }
            }
            _connection.Close();
            return GetInfiltration;
        }
        public void Create(Infiltration NouvelleInfiltration)
        {

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Infiltration (Id_Infiltration,Infiltration_Type,Delai_infiltration_indisponibilité," //les champs de la table
                                                     +
                                                     "VALUES (@id_infiltration, @infiltration_type, @délai_indisponibilité)");



                command.Parameters.AddWithValue("id_infiltration", NouvelleInfiltration.Id_Infiltration);
                command.Parameters.AddWithValue("infiltration_type", NouvelleInfiltration.Type_Infiltration);
                command.Parameters.AddWithValue("délai_indisponibilité", NouvelleInfiltration.Delai_Indisponibile);



                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Update(Infiltration InfiltrationModifier)
        {

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("Type_Infiltration = @infiltration_type" +
                    "Delai_Indisponibile = @délai_indisponibilité " +
                    "WHERE Id_Infiltration = @id_infiltration");



                command.Parameters.AddWithValue("id_infiltration", InfiltrationModifier.Id_Infiltration);
                command.Parameters.AddWithValue("infiltration_type", InfiltrationModifier.Type_Infiltration);
                command.Parameters.AddWithValue("délai_indisponibilité", InfiltrationModifier.Delai_Indisponibile);



                command.ExecuteNonQuery();



                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

        }
    }
}
