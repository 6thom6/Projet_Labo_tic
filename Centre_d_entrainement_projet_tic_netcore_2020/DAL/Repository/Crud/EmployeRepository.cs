using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud
{
    class EmployeRepository : IEmployeRepository
    {
        public SqlConnection _connection;

        public EmployeRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Employé> GetallEmploye()
        {
            List<Employé> GetallEmploye = new List<Employé>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employé", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallEmploye.Add(
                        new Employé
                        {
                            Id_Employé = reader["Id_Employé"] == DBNull.Value ? 0 : (int)reader["Id_Employé"],
                            SoinsId_Cheval = reader["SoinsId_Cheval"] == DBNull.Value ? 0 : (int)reader["SoinsId_Cheval"],
                            Nom_Employé = reader["Nom_Employé"] == DBNull.Value ? string.Empty : (string)reader["Nom_Employé"],
                            Statut_Employé = reader["Statut_Employé"] == DBNull.Value ? string.Empty : (string)reader["Statut_Employé"],
                            Employé_Embauche = reader["Employé_Embauche"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Employé_Embauche"]
                        }
                        );
                }
            }

            return GetallEmploye;
        }
        public Employé Get(int idAChercher)
        {
            Employé GetEmploye = new Employé();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employé where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Employé
                    {
                        Id_Employé = reader["Id_Employé"] == DBNull.Value ? 0 : (int)reader["Id_Employé"],
                        SoinsId_Cheval = reader["SoinsId_Cheval"] == DBNull.Value ? 0 : (int)reader["SoinsId_Cheval"],
                        Nom_Employé = reader["Nom_Employé"] == DBNull.Value ? string.Empty : (string)reader["Nom_Employé"],
                        Statut_Employé = reader["Statut_Employé"] == DBNull.Value ? string.Empty : (string)reader["Statut_Employé"],
                        Employé_Embauche = reader["Employé_Embauche"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Employé_Embauche"]
                    };
                        
                }
            }

            return GetEmploye;

        }
        public void Create(Employé NouvelEmploye)
        {
            using (_connection)
            {

                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Employé (Id_Employé,SoinsId_Cheval,Nom_Employé," + //les champs de la table
                                                   "Statut_Employé,Employé_Embauche," +
                                                   "VALUES (@id_employe, @soinsid_cheval, @nom_employe," + //les champs a rentrer
                                                   "@status_employe, @employe_embauche");

                command.Parameters.AddWithValue("id_employe", NouvelEmploye.Id_Employé);
                command.Parameters.AddWithValue("soinsid_cheval", NouvelEmploye.SoinsId_Cheval);
                command.Parameters.AddWithValue("nom_employe", NouvelEmploye.Nom_Employé);
                command.Parameters.AddWithValue("status_employe", NouvelEmploye.Statut_Employé);
                command.Parameters.AddWithValue("employe_embauche", NouvelEmploye.Employé_Embauche);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Update(Employé EmployéAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Employé Id_Employé = @id_employe, SoinsId_Cheval = @soinsid_cheval" +
                    "Nom_Employé = @nom_employe, Statut_Employé = @status_employe, Employé_Embauche = @employe_embauche" +
                    "where Employé Id_Employé = @id_employe");

                command.Parameters.AddWithValue("id_employe", EmployéAModifier.Id_Employé);
                command.Parameters.AddWithValue("soinsid_cheval", EmployéAModifier.SoinsId_Cheval);
                command.Parameters.AddWithValue("nom_employe", EmployéAModifier.Nom_Employé);
                command.Parameters.AddWithValue("status_employe", EmployéAModifier.Statut_Employé);
                command.Parameters.AddWithValue("employe_embauche", EmployéAModifier.Employé_Embauche);

                command.ExecuteNonQuery();

                _connection.Close();
            }
        }
        public void Delete(int idADelete)
        {

        }
    }
}

