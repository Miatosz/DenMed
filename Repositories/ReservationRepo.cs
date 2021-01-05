using System.Collections.Generic;
using System.Linq;
using DenMed.Data;
using DenMed.Models;

namespace DenMed.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        private AppDbContext _context;

        public ReservationRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        
        public IEnumerable<Reservation> Reservations => 
            _context.Reservations;

        public void AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                _context.Reservations.Add(reservation);
            }
            else
            {
                Reservation reservationAdd = _context.Reservations
                                                .FirstOrDefault(c => c.Id == reservation.Id);

                if (reservationAdd != null)
                {
                    reservationAdd.Surgery = reservation.Surgery;
                    reservationAdd.Customer = reservation.Customer;
                    reservationAdd.CustomerId = reservation.CustomerId;
                    reservationAdd.SurgeryId = reservation.SurgeryId;
                    reservationAdd.Data = reservation.Data;
                }
            }

            _context.SaveChanges();
        }

        public Reservation DeleteReservation(int reservationId)
        {
            var deletedReservation = _context.Reservations.FirstOrDefault(c => c.Id == reservationId);

            if (deletedReservation != null)
            {
                _context.Remove(deletedReservation);
                _context.SaveChanges();
            }
            return deletedReservation;        }
    }
}