using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models.ViewModels
{
    [Keyless]
    public class ContactsViewModel
    {
        public int Id { get; set; }       
        public string ContactName { get; set; }        
        public DateTime BirthDate { get; set; }        
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
