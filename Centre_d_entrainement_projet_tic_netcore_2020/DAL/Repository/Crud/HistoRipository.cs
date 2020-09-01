using DAL.Repository.IRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL.Repository.Crud
{
    class HistoRipository : IHistoRipository
    {
        public SqlConnection _connection;

        public HistoRipository()
        {
            _connection = new SqlConnection(ConnectionStringService.ConnString);
        }
        public List<Historique> GetallHistorique()
        {
            List<Historique> GetallHistorique = new List<Historique>();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Historique", _connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetallHistorique.Add(
                        new Historique
                        {
                            Id_Historique = reader["Id_Historique"] == DBNull.Value ? 0 : (int)reader["Id_Historique"],
                            Id_Cheval = reader["Id_Cheval"] == DBNull.Value ? 0 : (int)reader["Id_Cheval"],
                            Débourrage = reader["Débourrage"] == DBNull.Value ? string.Empty : (string)reader["Débourrage"],
                            Preé_Entrainement = reader["Pré-entrainement"] == DBNull.Value ? string.Empty : (string)reader["Pré-entrainement"],
                            Entraineur_Precedent = reader["Entraineur_Precedent"] == DBNull.Value ? string.Empty : (string)reader["Entraineur_Precedent"],
                            Proprietaire_Precedent = reader["Proprietaire_Precedent"] == DBNull.Value ? string.Empty : (string)reader["Proprietaire_Precedent"],

                        }
                        );
                }
            }

            return GetallHistorique;
        }
        public Historique Get(int idAChercher)
        {
            Historique GetHistorique = new Historique();

            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Historique where id = @idCherch", _connection);
                command.Parameters.AddWithValue("idCherch", idAChercher);


                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    new Historique
                    {
                        Id_Historique = reader["Id_Historique"] == DBNull.Value ? 0 : (int)reader["Id_Historique"],
                        Id_Cheval = reader["Id_Cheval"] == DBNull.Value ? 0 : (int)reader["Id_Cheval"],
                        Débourrage = reader["Débourrage"] == DBNull.Value ? string.Empty : (string)reader["Débourrage"],
                        Preé_Entrainement = reader["Pré-entrainement"] == DBNull.Value ? string.Empty : (string)reader["Pré-entrainement"],
                        Entraineur_Precedent = reader["Entraineur_Precedent"] == DBNull.Value ? string.Empty : (string)reader["Entraineur_Precedent"],
                        Proprietaire_Precedent = reader["Proprietaire_Precedent"] == DBNull.Value ? string.Empty : (string)reader["Proprietaire_Precedent"],

                    };
                        
                }
                
            }
            _connection.Close();
            return GetHistorique;

        }
        public void Create(Historique NouvelHistorique)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Historique (Id_Historique,Id_Cheval,Débourrage," + //les champs de la table
                                                     "Preé_Entrainement," +
                                                     "Entraineur_Precedent,Proprietaire_Precedent)" +
                                                     "VALUES (@id_hitorique, @id_cheval,@debourrage," + //les champs a rentrer
                                                     "@pré_entrainement, @entraineur_précédent, " +
                                                     "@proprietaire_precedent)");

                command.Parameters.AddWithValue("id_hitorique", NouvelHistorique.Id_Historique);
                command.Parameters.AddWithValue("id_cheval", NouvelHistorique.Id_Cheval);
                command.Parameters.AddWithValue("debourrage", NouvelHistorique.Débourrage);
                command.Parameters.AddWithValue("pré_entrainement", NouvelHistorique.Preé_Entrainement);
                command.Parameters.AddWithValue("entraineur_précédent", NouvelHistorique.Entraineur_Precedent);
                command.Parameters.AddWithValue("proprietaire_precedent", NouvelHistorique.Proprietaire_Precedent);


                command.ExecuteNonQuery();



                _connection.Close();

            }
        }
        public void Update(Historique HistoriqueAModifier)
        {
            using (_connection)
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("UPDATE Historique SET Id_Cheval = @id_cheval" +
                    "Débourrage =  @debourrage, Preé_Entrainement = pré_entrainement" +
                    "Entraineur_Precedent = @entraineur_précédent, Proprietaire_Precedent = @proprietaire_precedent" +
                             "WHERE Id_Historique = @id_hitorique");

                command.Parameters.AddWithValue("id_hitorique", HistoriqueAModifier.Id_Historique);
                command.Parameters.AddWithValue("id_cheval", HistoriqueAModifier.Id_Cheval);
                command.Parameters.AddWithValue("debourrage", HistoriqueAModifier.Débourrage);
                command.Parameters.AddWithValue("pré_entrainement", HistoriqueAModifier.Preé_Entrainement);
                command.Parameters.AddWithValue("entraineur_précédent", HistoriqueAModifier.Entraineur_Precedent);
                command.Parameters.AddWithValue("proprietaire_precedent", HistoriqueAModifier.Proprietaire_Precedent);


                command.ExecuteNonQuery();



                _connection.Close();
            }

        }
        public void Delete(int idADelete)
        {

        }
    }
}
