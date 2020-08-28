﻿using DAL.Repository.IRepository;
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
                            Date_Arrivée = reader["Date_Arrivée"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Date_Arrivée"],

                        }
                        );
                }
            }

            return GetallProprietaire;
        }
        public Proprietaire Get(int idAChercher)
        {
            return new Proprietaire();
        }
        public void Create(Proprietaire NouveauProprietaire)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Proprietaire (Id_Proprietaire,Nom_Proprietaire,Effectif," + //les champs de la table
                                              "Date_Arrivée,Dernier_Resultat)" +
                                              "VALUES (@id_proprietaire, @nom,effectif," + //les champs a rentrer
                                              "@date_arrivée, @dernier_resultat)");

            command.Parameters.AddWithValue("id_proprietaire", NouveauProprietaire.Id_Proprietaire);
            command.Parameters.AddWithValue("nom", NouveauProprietaire.Nom_Proprietaire);
            command.Parameters.AddWithValue("effectif", NouveauProprietaire.Effectif);
            command.Parameters.AddWithValue("date_arrivée", NouveauProprietaire.Date_Arrivée);
            command.Parameters.AddWithValue("dernier_resultat", NouveauProprietaire.Dernier_Resultats);



            command.ExecuteNonQuery();

            _connection.Close();
        }
        public void Update(Proprietaire ProprietaireAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}
