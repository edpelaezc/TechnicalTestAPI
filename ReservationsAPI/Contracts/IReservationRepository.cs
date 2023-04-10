using System;
using Entities.Models;

namespace Contracts
{
	public interface IReservationRepository
	{
        Task<IEnumerable<Reservation>> GetAllReservationsAsync(int contactId, bool trackChanges);

        Task<Reservation> GetReservationAsync(int contactId, int id, bool trackChanges);

        void CreateReservationForContact(int contactId, Reservation reservation);

        void DeleteReservation(Reservation reservation);
    }
}

