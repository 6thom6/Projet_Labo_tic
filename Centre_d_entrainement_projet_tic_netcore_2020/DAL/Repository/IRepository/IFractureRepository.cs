using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository.Crud
{
    interface IFractureRepository
    {
        void Create(Fracture NouvelleFracture);
        void Delete(int idADelete);
        Fracture Get(int idAChercher);
        List<Fracture> GetallFracture();
        void Update(Fracture FractureModifier);
    }
}