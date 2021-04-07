using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Models.ViewModels
{
    /// <summary>
    /// model to show in the list of reservations
    /// </summary>
    public class ReservationViewModel
    {
        public int id { get; set; }
        public string userName { get; set; }
    }
}
