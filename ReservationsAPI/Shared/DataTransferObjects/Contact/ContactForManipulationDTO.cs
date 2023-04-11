using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Contact
{
	public record ContactForManipulationDTO
	{
        [Required(ErrorMessage = "Contact name is a required field.")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Birth date is a required field.")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "ContactType id is a required field.")]
        public int? ContactTypeId { get; set; }

        [MaxLength(15, ErrorMessage = "Maximum length for the phone number is 8 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

