using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Repository.Crud.ChevalRepo
{
    class ChevalInfoChoisi 
    {

        public SqlConnection _connection;

        public ChevalInfoChoisi()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Cheval> ChevalVaccine()
        {
            List<Cheval> ChevalVaccine = new List<Cheval>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT ID_Cheval FROM CHEVAL UNION" +
                    "Select Id_vaccination FROM Vaccination WHERE ", _connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChevalVaccine.Add(
                            new Cheval
                            {
                                ID_Cheval = reader["ID_Cheval"] == DBNull.Value ? 0 : (int)reader["ID_Cheval"],
                                Nom_cheval = reader["Nom_cheval"] == DBNull.Value ? string.Empty : (string)reader["Nom_cheval"],
                                ID_Proprietaire = reader["ID_Proprietaire"] == DBNull.Value ? 0 : (int)reader["ID_Proprietaire"],
                                ID_Soins = reader["ID_Soins"] == DBNull.Value ? 0 : (int)reader["ID_Soins"],
                                Poids = reader["Poids"] == DBNull.Value ? 0 : (int)reader["Poids"],
                                Race = reader["Race"] == DBNull.Value ? string.Empty : (string)reader["Race"]
                            }
                            ); ;
                    }
                }
                return ChevalVaccine;
            }
        }


    }
}
   