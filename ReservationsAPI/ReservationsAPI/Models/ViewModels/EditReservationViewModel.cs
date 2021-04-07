using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models.ViewModels
{
    public class EditReservationViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
