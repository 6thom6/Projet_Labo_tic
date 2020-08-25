using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository.Crud
{
    interface ITendiniteRepository
    {
        void Create(Tendinite NouvelleTendinite);
        void Delete(int idADelete);
        Tendinite Get(int idAChercher);
        List<Tendinite> GetallHistorique();
        void Update(Tendinite TendiniteAModifier);
    }
}