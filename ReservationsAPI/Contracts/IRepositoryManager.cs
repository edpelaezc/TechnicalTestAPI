using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		IContactRepository contactRepository { get; }
        IContactTypeRepository contactTypeRepository { get; }
        IReservationRepository reservationRepository { get; }
        Task SaveAsync();
    }
}

