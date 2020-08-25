using DAL.Models;
using System.Collections.Generic;
using DAL.Repository.Crud;

namespace DAL.Repository.Crud
{
    interface IEmployeRepository
    {
        void Create(Employé NouvelEmploye);
        void Delete(int idADelete);
        Employé Get(int idAChercher);
        List<Employé> GetallEmploye();
        void Update(Employé EmployéAModifier);
    }
}