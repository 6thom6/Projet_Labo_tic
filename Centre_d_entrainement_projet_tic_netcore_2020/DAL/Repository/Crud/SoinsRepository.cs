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
            _connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Soins (Id_Soins,Id_Cheval,Id_Employe," + //les champs de la table
                                              "Alimentation,Complement_Alimentation," +
                                              "Note_Libre,Marechal,Vermifuge)" +
                                              "VALUES (@id_soins, @id_cheval,@id_employe," + //les champs a rentrer
                                              "@alimentation, @complement_alimentation, " +
                                              "@note_libre, @marechal, @vermifuge )");

            command.Parameters.AddWithValue("id_soins", NouveauSoins.Id_Soins);
            command.Parameters.AddWithValue("id_cheval", NouveauSoins.Id_Cheval);
            command.Parameters.AddWithValue("id_employe", NouveauSoins.Id_Employe);
            command.Parameters.AddWithValue("alimentation", NouveauSoins.Alimentation);
            command.Parameters.AddWithValue("complement_alimentation", NouveauSoins.Complement_Alimentation);
            command.Parameters.AddWithValue("note_libre", NouveauSoins.Note_Libre);
            command.Parameters.AddWithValue("marechal", NouveauSoins.Marechal);
            command.Parameters.AddWithValue("vermifuge", NouveauSoins.Vermifuge);


            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Soins SoinsAModifier)
        {

        }
        public void Delete(int idADelete)
        {

        }

    }
}
