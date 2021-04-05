using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models
{
    public class ContactsForm
    {
        public string id { get; set; }
        public string ContactName { get; set; }
        public string BirthDate { get; set; }
        public string ContactTypeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
