using System.Collections.Generic;
using DenMed.Models;

namespace DenMed.Repositories
{
    public interface ISurgeryRepo
    {
         IEnumerable<Surgery> Surgeries {get;}
         void AddSurgery(Surgery surgery);
         Surgery DeleteSurgery(int surgeryId);
    }
}