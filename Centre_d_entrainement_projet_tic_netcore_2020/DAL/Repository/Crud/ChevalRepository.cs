using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;



namespace DAL.Repository.Crud
{
    class ChevalRepository : ICheval
    {
        public SqlConnection _connection;

        public ChevalRepository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Cheval> Get()
        {
            List<Cheval> GetAllChevaux = new List<Cheval>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM CHEVAL",_connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetAllChevaux.Add(
                            new Cheval
                            {
                                ID_Cheval = reader["ID_Cheval"] == DBNull.Value ? 0:(int)reader["ID_Cheval"],
                                Pere_Cheval = reader["Pere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Pere_Cheval"],
                                Mere_Cheval = reader["Mere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Mere_Cheval"],
                                Sortie_Provisoire = reader["Sortie_Provisoire"] == DBNull.Value ? string.Empty : (string)reader["Sortie_Provisoire"],
                                Raison_SortieProvisoire = reader["Raison_SortieProvisoire"] == DBNull.Value ? string.Empty : (string)reader["Raison_SortieProvisoire"],
                                ID_Proprietaire = reader["ID_Proprietaire"]==DBNull.Value?0: (int)reader["ID_Proprietaire"],
                                ID_Soins = reader["ID_Soins"]==DBNull.Value?0:(int)reader["ID_Soins"],
                                Poids = reader["Poids"]==DBNull.Value?0:(int)reader["Poids"],
                                Race = reader["Race"]==DBNull.Value?string.Empty:(string)reader["Race"]
                            }
                            )  ;
                    }
                }
                return GetAllChevaux;
            }
        }
        public Cheval Get(int idAChercher)
        {
            return new Cheval();
        }

        public void Delete(int idADelete)
        {

        }

        public void Create(Cheval NouveauCheval)
        {
            throw new NotImplementedException();
        }


        public void Update(Cheval ChevalAModifier)
        {
            throw new NotImplementedException();
        }
    }
}
