using System;
using Entities.Models;

namespace Contracts
{
	public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges);

        Task<Contact> GetContactAsync(int contactId, bool trackChanges);

        void CreateContact(Contact contact);

        void DeleteContact(Contact contact);
    }
}

