using System;
using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
	{
		public ReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
		}

        public void CreateReservationForContact(int contactId, Reservation reservation)
        {
            reservation.ContactId = contactId;
            Create(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            Delete(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync(int contactId, bool trackChanges)
        {
            return await FindByCondition(r => r.ContactId.Equals(contactId), trackChanges).ToListAsync();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Reservation> GetReservationAsync(int contactId, int id, bool trackChanges)
        {
            return await FindByCondition(r => r.ContactId.Equals(contactId) && r.Id.Equals(id) ,trackChanges)
                .SingleOrDefaultAsync();
        }
#pragma warning restore CS8603 // Possible null reference return.

    }
}

