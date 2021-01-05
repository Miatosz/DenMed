using System.Collections.Generic;
using DenMed.Models;

namespace DenMed.Repositories
{
    public interface IReservationRepo
    {
         IEnumerable<Reservation> Reservations {get;}
         void AddReservation(Reservation reservation);
         Reservation DeleteReservation(int reservationId);
    }
}