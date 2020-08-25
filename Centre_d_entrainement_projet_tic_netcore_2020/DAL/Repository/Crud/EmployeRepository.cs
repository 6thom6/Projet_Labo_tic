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
            return new Employé();
        }
        public void Create(Employé NouvelEmploye)
        {

        }
        public void Update(Employé EmployéAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}

