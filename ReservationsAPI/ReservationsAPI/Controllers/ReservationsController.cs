using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using Newtonsoft.Json;
using ReservationsAPI.Services.Interfaces;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService service)
        {
            _reservationsService = service;
        }

        /// <summary>
        /// Gets a formated representation of the reservations: Reservation id and the associated contact
        /// </summary>
        /// <returns>Reservation list</returns>
        // GET: api/Reservations
        [HttpGet]
        public ActionResult<IEnumerable<ReservationViewModel>> GetReservations()
        {
            return _reservationsService.GetReservations();
        }

        /// <summary>
        /// Gets a reservation by id
        /// </summary>
        /// <param name="id">Reservation id</param>
        /// <returns>An reservation object</returns>
        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public ActionResult<EditReservationViewModel> GetReservation(int id)
        {
            return _reservationsService.GetReservation(id);
        }

        /// <summary>
        /// To edit a reservation
        /// </summary>
        /// <param name="id">Reservation id</param>
        /// <param name="reservation">Object with updated properties</param>
        /// <returns></returns>
        // PUT: api/Reservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult PutReservation(int id, EditReservationViewModel reservation)
        {
            bool result = _reservationsService.PutReservation(id, reservation);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Creates a reservation, if the user doesnt exists also create the user
        /// </summary>
        /// <param name="reservation">Reservation form</param>
        /// <returns>Ok object if create, error if not</returns>
        // POST: api/Reservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(ReservationForm reservation)
        {
            var result = await _reservationsService.PostReservation(reservation);

            if (result)
            {
                return Ok();
            }

            return Problem();
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            bool result = await _reservationsService.DeleteReservation(id);

            if (result)
            {
                return Ok(200);
            }

            return BadRequest();
        }
    }
}
