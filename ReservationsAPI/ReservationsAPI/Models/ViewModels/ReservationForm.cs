using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models.ViewModels
{
    /// <summary>
    /// Model to help with the reservation form
    /// </summary>
    public class ReservationForm
    {
        public string ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactType { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string editorContent { get; set; }
    }
}
