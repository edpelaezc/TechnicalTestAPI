using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects.Contact;

namespace Service
{
	internal sealed class ContactService : IContactService
	{

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ContactService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
		}

        public Task<ContactDTO> CreateContactAsync(ContactForCreationDTO company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(int contactId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync(bool trackChanges)
        {
            var contacts = await _repository.Contact.GetAllContactsAsync(trackChanges);
            var contactsDTO = _mapper.Map<IEnumerable<ContactDTO>>(contacts);
            return contactsDTO;
        }

        public Task<ContactDTO> GetContactAsync(int companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateContactAsync(int contactId, ContactForUpdateDTO contactForUpdateDTO, bool trackChanges)
        {
            var contact = await _repository.Contact.GetContactAsync(contactId, trackChanges);

            if (contact is null)
                throw new ContactNotFoundException(contactId);

            _mapper.Map(contactForUpdateDTO, contact);
            await _repository.SaveAsync();
        }
    }
}

