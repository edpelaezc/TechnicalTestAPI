using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Services.Interfaces
{
    public interface IReservationsService
    {
        ActionResult<IEnumerable<ReservationViewModel>> GetReservations();
        ActionResult<EditReservationViewModel> GetReservation(int id);
        bool PutReservation(int id, EditReservationViewModel reservation);
        Task<bool> PostReservation(ReservationForm reservation);
        Task<bool> DeleteReservation(int id);
    }
}
