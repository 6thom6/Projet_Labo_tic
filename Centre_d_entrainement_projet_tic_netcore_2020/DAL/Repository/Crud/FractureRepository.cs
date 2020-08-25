using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud
{
    class FractureRepository : IFractureRepository
    {
        public SqlConnection _connection;

        public FractureRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Fracture> GetallFracture()
        {
            List<Fracture> GetallFracture = new List<Fracture>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employé", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallFracture.Add(
                        new Fracture
                        {
                            Id_Fracture = reader["Id_Fracture"] == DBNull.Value ? 0 : (int)reader["Id_Fracture"],
                            Type_Fracture = reader["Type_Fracture"] == DBNull.Value ? string.Empty : (string)reader["Type_Fracture"],
                            Fracture_Indisponibilité = reader["Fracture_Indisponibilité"] == DBNull.Value ? DateTime.Now : (DateTime)reader["Fracture_Indisponibilité"]
                        }
                        );
                }
            }

            return GetallFracture;
        }
        public Fracture Get(int idAChercher)
        {
            return new Fracture();
        }
        public void Create(Fracture NouvelleFracture)
        {

        }
        public void Update(Fracture FractureModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }

    }
}
