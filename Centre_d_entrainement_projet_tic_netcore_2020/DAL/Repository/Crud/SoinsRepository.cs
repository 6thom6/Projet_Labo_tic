using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL.Repository.Crud
{
    class SoinsRepository : ISoinsRepository
    {

        public SqlConnection _connection;

        public SoinsRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Soins> GetallSoins()
        {
            List<Soins> GetallSoins = new List<Soins>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Soins", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallSoins.Add(
                        new Soins
                        {
                            Id_Soins = reader["Id_Soins"] == DBNull.Value ? 0 : (int)reader["Id_Soins"],
                            Id_Cheval = reader["Id_Cheval"] == DBNull.Value ? 0 : (int)reader["Id_Cheval"],
                            Id_Employe = reader["Id_Employe"] == DBNull.Value ? 0 : (int)reader["Id_Employe"],
                            Alimentation = reader["Alimentation"] == DBNull.Value ? string.Empty : (string)reader["Alimentation"],
                            Complement_Alimentation = reader["Complement_Alimentation"] == DBNull.Value ? string.Empty : (string)reader["Complement_Alimentation"],
                            Note_Libre = reader["Note_Libre"] == DBNull.Value ? string.Empty : (string)reader["Note_Libre"],
                            Marechal = reader["Marechal"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Marechal"],
                            Vermifuge = reader["Vermifuge"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Vermifuge"],

                        }
                        );
                }
            }

            return GetallSoins;
        }
        public Soins Get(int idAChercher)
        {
            return new Soins();
        }
        public void Create(Soins NouveauSoins)
        {

        }
        public void Update(Soins SoinsAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }

    }
}
