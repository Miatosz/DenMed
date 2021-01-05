using System.Collections.Generic;
using DenMed.Models;

namespace DenMed.Repositories
{
    public interface ISpecialistRepo
    {
         IEnumerable<Specialist> Specialists {get;}
         void AddSpecialist(Specialist specialist);
         Specialist DeleteSpecialist(int specialistId);
    }
}