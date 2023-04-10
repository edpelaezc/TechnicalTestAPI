using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Reservation
	{
		public Reservation()
		{
		}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }

        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }

        public Contact? Contact { get; set; }
    }
}

