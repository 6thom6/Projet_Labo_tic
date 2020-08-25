using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud
{
    class VaccinationRepository : IVaccinationRepository
    {
        public SqlConnection _connection;

        public VaccinationRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Vaccination> GetallVaccination()
        {
            List<Vaccination> GetallVaccination = new List<Vaccination>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Vaccination", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallVaccination.Add(
                        new Vaccination
                        {
                            Id_Vaccination = reader["Id_Vaccination"] == DBNull.Value ? 0 : (int)reader["Id_Vaccination"],
                            Nom_Vaccin = reader["Nom_Vaccin"] == DBNull.Value ? string.Empty : (string)reader["Nom_Vaccin"],
                            Indisponibilite_Vaccin = reader["Indisponibilite_Vaccin"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Indisponibilite_Vaccin"]

                        }
                        );
                }
            }

            return GetallVaccination;
        }
        public Vaccination Get(int idAChercher)
        {
            return new Vaccination();
        }
        public void Create(Vaccination Nouvellevaccination)
        {

        }
        public void Update(Vaccination VaccinationAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}
