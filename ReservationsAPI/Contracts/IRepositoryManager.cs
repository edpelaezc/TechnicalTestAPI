using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		IContactRepository Contact { get; }
        IContactTypeRepository ContactType { get; }
        IReservationRepository Reservation { get; }
        Task SaveAsync();
    }
}

