using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
	public class ContactType
	{
		public ContactType()
		{
		}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of contact type is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Contact description is a required field.")]
        public string? Description { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}

