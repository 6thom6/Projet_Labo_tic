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
                            Preé_Entrainement = reader["Preé_Entrainement"] == DBNull.Value ? string.Empty : (string)reader["Preé_Entrainement"],
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
            return new Historique();
        }
        public void Create(Historique NouvelHistorique)
        {

        }
        public void Update(Historique HistoriqueAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }
    }
}
