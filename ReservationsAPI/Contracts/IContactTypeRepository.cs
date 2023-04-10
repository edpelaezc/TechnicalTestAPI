using System;
using Entities.Models;

namespace Contracts
{
	public interface IContactTypeRepository
	{
        Task<IEnumerable<ContactType>> GetAllContactTypesAsync(bool trackChanges);

        Task<ContactType> GetContactTypeAsync(int contactTypeId, bool trackChanges);

        void CreateContactType(ContactType contactType);

        void DeleteContactType(ContactType contactType);
    }
}

