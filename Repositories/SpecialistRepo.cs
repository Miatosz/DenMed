using System.Collections.Generic;
using System.Linq;
using DenMed.Data;
using DenMed.Models;

namespace DenMed.Repositories
{
    public class SpecialistRepo : ISpecialistRepo
    {
        private AppDbContext _context;

        public SpecialistRepo(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Specialist> Specialists =>
             _context.Specialists;

        public void AddSpecialist(Specialist specialist)
        {
            if (specialist.Id == 0)
            {
                _context.Specialists.Add(specialist);
            }
            else
            {
                Specialist addSpecialist = _context.Specialists
                                                .FirstOrDefault(c => c.Id == specialist.Id);
                
                if (addSpecialist != null)
                {
                    addSpecialist.Name = specialist.Name;
                    addSpecialist.PhoneNumber = specialist.PhoneNumber;
                    addSpecialist.Surname = specialist.Surname;
                    addSpecialist.Age = specialist.Age;
                }
            }
            _context.SaveChanges();
        }

        public Specialist DeleteSpecialist(int specialistId)
        {
            var specialist = _context.Specialists              
                                .FirstOrDefault(c => c.Id == specialistId);

            if (specialist != null)
            {
                _context.Specialists.Remove(specialist);
                _context.SaveChanges();
            }
            return specialist;
        }
    }
}