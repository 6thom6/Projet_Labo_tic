using DAL.Models;
using System.Collections.Generic;
using DAL.Repository.Crud;

namespace DAL.Repository.Crud
{
    interface IEntrainementRepository
    {
        void Create(Entrainement NouvelEntrainement);
        void Delete(int idADelete);
        Entrainement Get(int idAChercher);
        List<Entrainement> GetallEntrainement();
        void Update(Entrainement EntrainementAModifier);
    }
}