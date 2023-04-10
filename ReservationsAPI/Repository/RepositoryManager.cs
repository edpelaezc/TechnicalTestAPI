using System;
using Contracts;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IContactRepository> _contactRepository;
        private readonly Lazy<IContactTypeRepository> _contactTypeRepository;
        private readonly Lazy<IReservationRepository> _reservationRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(repositoryContext));
            _contactTypeRepository = new Lazy<IContactTypeRepository>(() => new ContactTypeRepository(repositoryContext));
            _reservationRepository = new Lazy<IReservationRepository>(() => new ReservationRepository(repositoryContext));
        }

        public IContactRepository contactRepository => _contactRepository.Value;

        public IContactTypeRepository contactTypeRepository => _contactTypeRepository.Value;

        public IReservationRepository reservationRepository => _reservationRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}

