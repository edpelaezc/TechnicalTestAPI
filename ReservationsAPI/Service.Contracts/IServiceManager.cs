using System;
namespace Service.Contracts
{
	public interface IServiceManager
	{
		IContactService ContactService { get; }
		//IContactTypeService ContactTypeService { get; }
		//IReservationService ReservationService { get; }
	}
}

