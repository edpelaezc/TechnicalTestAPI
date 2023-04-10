using System;
using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
		public ContactRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

        public void CreateContact(Contact contact)
        {
            Create(contact);
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.ContactName).ToListAsync();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Contact> GetContactAsync(int contactId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(contactId), trackChanges).SingleOrDefaultAsync();
        }
#pragma warning restore CS8603 // Possible null reference return.

    }
}

