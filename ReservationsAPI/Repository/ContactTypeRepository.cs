using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ContactTypeRepository : RepositoryBase<ContactType>, IContactTypeRepository
    {
		public ContactTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
		}

        public void CreateContactType(ContactType contactType)
        {
            Create(contactType);
        }

        public void DeleteContactType(ContactType contactType)
        {
            Delete(contactType);
        }

        public async Task<IEnumerable<ContactType>> GetAllContactTypesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<ContactType> GetContactTypeAsync(int contactTypeId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(contactTypeId), trackChanges).SingleOrDefaultAsync();
        }
#pragma warning restore CS8603 // Possible null reference return.

    }
}

