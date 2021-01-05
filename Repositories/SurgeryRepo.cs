using System.Collections.Generic;
using System.Linq;
using DenMed.Data;
using DenMed.Models;

namespace DenMed.Repositories
{
    public class SurgeryRepo : ISurgeryRepo
    {

        private AppDbContext _context;

        public SurgeryRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        
        public IEnumerable<Surgery> Surgeries => 
            _context.Surgeries;


        public void AddSurgery(Surgery surgery)
        {
            if (surgery.Id == 0)
            {
                _context.Surgeries.Add(surgery);
            }
            else
            {
                Surgery addSurgery = _context.Surgeries
                                        .FirstOrDefault(c => c.Id == surgery.Id);

                if (addSurgery != null)
                {
                    addSurgery.Name = surgery.Name;
                    addSurgery.Price = surgery.Price;
                    addSurgery.Reservations = surgery.Reservations;
                }
            }
            _context.SaveChanges();
        }

        public Surgery DeleteSurgery(int surgeryId)
        {
            var surgery = _context.Surgeries   
                                .FirstOrDefault(c => c.Id == surgeryId);

            if (surgery != null)
            {
                _context.Surgeries.Remove(surgery);
                _context.SaveChanges();
            }
            return surgery;
        }
    }
}