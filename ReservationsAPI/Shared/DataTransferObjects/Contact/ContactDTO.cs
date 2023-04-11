using System;
namespace Shared.DataTransferObjects.Contact
{
	public record ContactDTO
	{
        public int Id { get; set; }
        public string? ContactName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? ContactTypeName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

