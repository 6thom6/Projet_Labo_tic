using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository.Crud
{
    interface IVaccinationRepository
    {
        void Create(Vaccination Nouvellevaccination);
        void Delete(int idADelete);
        Vaccination Get(int idAChercher);
        List<Vaccination> GetallVaccination();
        void Update(Vaccination VaccinationAModifier);
    }
}