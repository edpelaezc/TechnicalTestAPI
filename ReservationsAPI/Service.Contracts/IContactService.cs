using System;
using Shared.DataTransferObjects.Contact;

namespace Service.Contracts
{
	public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContactsAsync(bool trackChanges);

        Task<ContactDTO> GetContactAsync(int companyId, bool trackChanges);

        Task<ContactDTO> CreateContactAsync(ContactForCreationDTO company);

        Task DeleteContactAsync(int contactId, bool trackChanges);

        Task UpdateContactAsync(int contactId, ContactForUpdateDTO contactForUpdateDTO, bool trackChanges);
    }
}

