using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public string Description { get; set; }

        public Contact Contact { get; set; }
    }
}
