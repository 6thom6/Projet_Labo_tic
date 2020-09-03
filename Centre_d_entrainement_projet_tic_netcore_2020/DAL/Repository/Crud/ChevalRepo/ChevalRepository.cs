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
                                ID_Cheval = reader["ID_Cheval"] == DBNull.Value ? 0 : (int)reader["ID_Cheval"],
                                Nom_cheval = reader["Nom_cheval"] == DBNull.Value ? string.Empty : (string)reader["Nom_cheval"],
                                Pere_Cheval = reader["Pere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Pere_Cheval"],
                                Mere_Cheval = reader["Mere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Mere_Cheval"],
                                Sortie_Provisoire = reader["Sortie_Provisoire"] == DBNull.Value ? string.Empty : (string)reader["Sortie_Provisoire"],
                                Raison_SortieProvisoire = reader["Raison_SortieProvisoire"] == DBNull.Value ? string.Empty : (string)reader["Raison_SortieProvisoire"],
                                ID_Proprietaire = reader["ID_Proprietaire"] == DBNull.Value ? 0 : (int)reader["ID_Proprietaire"],
                                ID_Soins = reader["ID_Soins"] == DBNull.Value ? 0 : (int)reader["ID_Soins"],
                                Poids = reader["Poids"] == DBNull.Value ? 0 : (int)reader["Poids"],
                                Race = reader["Race"] == DBNull.Value ? string.Empty : (string)reader["Race"]
                            }
                            );  ;
                    }
                }
                return GetAllChevaux;
            }
        }
        public Cheval Get(int idAChercher)
        {
          Cheval  GetCheval = new Cheval();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM CHEVAL where id = @idCherch",_connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        new Cheval
                        {
                            ID_Cheval = reader["ID_Cheval"] == DBNull.Value ? 0 : (int)reader["ID_Cheval"],
                            Nom_cheval = reader["Nom_cheval"] == DBNull.Value ? string.Empty : (string)reader["Nom_cheval"],
                            Pere_Cheval = reader["Pere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Pere_Cheval"],
                            Mere_Cheval = reader["Mere_Cheval"] == DBNull.Value ? string.Empty : (string)reader["Mere_Cheval"],
                            Sortie_Provisoire = reader["Sortie_Provisoire"] == DBNull.Value ? string.Empty : (string)reader["Sortie_Provisoire"],
                            Raison_SortieProvisoire = reader["Raison_SortieProvisoire"] == DBNull.Value ? string.Empty : (string)reader["Raison_SortieProvisoire"],
                            ID_Proprietaire = reader["ID_Proprietaire"] == DBNull.Value ? 0 : (int)reader["ID_Proprietaire"],
                            ID_Soins = reader["ID_Soins"] == DBNull.Value ? 0 : (int)reader["ID_Soins"],
                            Poids = reader["Poids"] == DBNull.Value ? 0 : (int)reader["Poids"],
                            Race = reader["Race"] == DBNull.Value ? string.Empty : (string)reader["Race"]
                        };
                           
                    }
                }
                _connection.Close();
                return GetCheval;
            }
        }

        public void Delete(int idADelete)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM CHEVAL where ID = @id");
                command.Parameters.AddWithValue("id", idADelete);
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Create(Cheval NouveauCheval)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO CHEVAL (ID_Cheval,Pere_Cheval,Mere_Cheval," + //les champs de la table
                                                     "Sortie_Provisoire,Raison_SortieProvisoire,Nom_cheval," +
                                                     "ID_Proprietaire,ID_Soins,Poids,Race)" +
                                                     "VALUES (@nom_cheval, @id_cheval, @pere_cheval, @mere_cheval," + //les champs a rentrer
                                                     "@sortie_provisoire, @raison_sortieprovisoire, " +
                                                     "@id_proprietaire, @id_soins, @poids, @race )");

                command.Parameters.AddWithValue("id_cheval", NouveauCheval.ID_Cheval);
                command.Parameters.AddWithValue("nom_cheval", NouveauCheval.Nom_cheval);
                command.Parameters.AddWithValue("nom_cheval", NouveauCheval.Nom_cheval);
                command.Parameters.AddWithValue("pere_cheval", NouveauCheval.Pere_Cheval);
                command.Parameters.AddWithValue("mere_cheval", NouveauCheval.Mere_Cheval);
                command.Parameters.AddWithValue("sortie_provisoire", NouveauCheval.Sortie_Provisoire);
                command.Parameters.AddWithValue("raison_sortieprovisoire", NouveauCheval.Raison_SortieProvisoire);
                command.Parameters.AddWithValue("id_proprietaire", NouveauCheval.ID_Proprietaire);
                command.Parameters.AddWithValue("id_soins", NouveauCheval.ID_Soins);
                command.Parameters.AddWithValue("poids", NouveauCheval.Poids);
                command.Parameters.AddWithValue("race", NouveauCheval.Race);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }


        public void Update(Cheval ChevalAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE CHEVAL SET Nom_cheval=@nom_cheval, Pere_Cheval= @pere_cheval, Mere_Cheval=@mere_cheval" +
                                                     "Sortie_Provisoire = @sortie_provisoire, Raison_SortieProvisoire = @sortie_provisoire" +
                                                     "ID_Proprietaire = @id_proprietaire, ID_Soins = @id_soins, Poids = @poids, Race = @race" +
                                                     "WHERE ID_Cheval = @id_cheval");

                command.Parameters.AddWithValue("id_cheval", ChevalAModifier.ID_Cheval);
                command.Parameters.AddWithValue("nom_cheval", ChevalAModifier.Nom_cheval);
                command.Parameters.AddWithValue("pere_cheval", ChevalAModifier.Pere_Cheval);
                command.Parameters.AddWithValue("mere_cheval", ChevalAModifier.Mere_Cheval);
                command.Parameters.AddWithValue("sortie_provisoire", ChevalAModifier.Sortie_Provisoire);
                command.Parameters.AddWithValue("raison_sortieprovisoire", ChevalAModifier.Raison_SortieProvisoire);
                command.Parameters.AddWithValue("id_proprietaire", ChevalAModifier.ID_Proprietaire);
                command.Parameters.AddWithValue("id_soins", ChevalAModifier.ID_Soins);
                command.Parameters.AddWithValue("poids", ChevalAModifier.Poids);
                command.Parameters.AddWithValue("race", ChevalAModifier.Race);


                command.ExecuteNonQuery();

                _connection.Close();
            }
        }


    }
}
