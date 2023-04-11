using System;
namespace Entities.Exceptions
{
	public sealed class ContactNotFoundException : NotFoundException
    {
		public ContactNotFoundException(int id) : base($"contact with {id} doesn't exist in db.")
		{
		}
	}
}

