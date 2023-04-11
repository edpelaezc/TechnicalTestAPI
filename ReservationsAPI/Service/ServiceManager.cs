using System;
using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
        private readonly Lazy<IContactService> _contactService;
        //private readonly Lazy<IContactTypeService> _contactTypeService;
        //private readonly Lazy<IReservationService> _reservationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _contactService = new Lazy<IContactService>(() => new ContactService(repositoryManager, logger, mapper));
            //_contactTypeService = new Lazy<IContactTypeService>(() => new ContactTypeService(repositoryManager, logger, mapper));
            //_reservationService = new Lazy<IReservationService>(() => new ReservationService(repositoryManager, logger, mapper));
        }

        public IContactService ContactService => _contactService.Value;

        //public IContactTypeService ContactTypeService => _contactTypeService.Value;

        //public IReservationService ReservationService => _reservationService.Value;
    }
}

