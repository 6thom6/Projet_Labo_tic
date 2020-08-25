using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository.Crud
{
    interface IInfiltrationRepository
    {
        void Create(Infiltration NouvelleInfiltration);
        void Delete(int idADelete);
        Infiltration Get(int idAChercher);
        List<Infiltration> GetallInfiltration();
        void Update(Infiltration InfiltrationModifier);
    }
}