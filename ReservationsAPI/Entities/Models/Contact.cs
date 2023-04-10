using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Contact
	{
		public Contact()
		{
		}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Contact name is a required field.")]        
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Birth date is a required field.")]
        public DateTime? BirthDate { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        [ForeignKey(nameof(ContactType))]
        public int ContactTypeId { get; set; }

        public ContactType? ContactType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}

