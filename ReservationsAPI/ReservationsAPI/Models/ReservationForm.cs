using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models
{
    public class ReservationForm
    {
        public string ContactName { get; set; }
        public string ContactType { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string editorContent { get; set; }
    }
}
