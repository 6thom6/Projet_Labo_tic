using System.Collections.Generic;
using DAL.Models;
using DAL.Repository.Crud;

namespace DAL.Repository.IRepository
{
    interface ICheval
    {
        void Create(Cheval NouveauCheval);
        void Delete(int idADelete);
        List<Cheval> Get();
        Cheval Get(int idAChercher);
        void Update(Cheval ChevalAModifier);

    }
}