using DAL.Repository.IRepository;
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

            return GetallInfiltration;
        }
        public Infiltration Get(int idAChercher)
        {
            return new Infiltration();
        }
        public void Create(Infiltration NouvelleInfiltration)
        {

        }
        public void Update(Infiltration InfiltrationModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}
