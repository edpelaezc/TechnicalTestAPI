using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models
{
    /// <summary>
    /// Contact model
    /// </summary>
    public class Contact
    {
        public Contact()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string ContactName { get; set; }        

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int ContactTypeId { get; set; }
        public string PhoneNumber { get; set; }

        public ContactType ContactType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
