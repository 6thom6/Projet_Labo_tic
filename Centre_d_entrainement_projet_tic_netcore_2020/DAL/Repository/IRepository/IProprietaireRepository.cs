using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository.Crud
{
    interface IProprietaireRepository
    {
        void Create(Entrainement NouvelEntrainement);
        void Delete(int idADelete);
        Entrainement Get(int idAChercher);
        List<Proprietaire> GetallProprietaire();
        void Update(Entrainement EntrainementAModifier);
    }
}