using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using Newtonsoft.Json;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationsContext _context;

        public ReservationsController(ReservationsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a formated representation of the reservations: Reservation id and the associated contact
        /// </summary>
        /// <returns>Reservation list</returns>
        // GET: api/Reservations
        [HttpGet]
        public ActionResult<IEnumerable<ReservationViewModel>> GetReservations()
        {
            var list = (from reservations in _context.Reservations
                        join contacts in _context.Contacts on reservations.ContactId equals contacts.Id
                        select new ReservationViewModel()
                        {
                            id = reservations.Id,
                            userName = contacts.ContactName
                        }).ToList();
            return list;
        }

        /// <summary>
        /// Gets a reservation by id
        /// </summary>
        /// <param name="id">Reservation id</param>
        /// <returns>An reservation object</returns>
        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
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
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
            try
            {
                int contactID = 0;
                if (ContactExists(Convert.ToInt32(reservation.ContactID)))
                {
                    contactID = Convert.ToInt32(reservation.ContactID);
                }
                else
                {
                    Contact contact = new Contact()
                    {
                        ContactName = reservation.ContactName,
                        BirthDate = Convert.ToDateTime(reservation.BirthDate),
                        ContactTypeId = Convert.ToInt32(reservation.ContactType),
                        PhoneNumber = reservation.Phone,
                    };

                    _context.Contacts.Add(contact);
                    _context.SaveChanges();
                    contactID = contact.Id;
                }

                _context.Reservations.Add(new Reservation()
                {
                    ContactId = contactID,
                    Description = reservation.editorContent
                });

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);                
            }           
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        /// <summary>
        /// Checks if the reservation exists
        /// </summary>
        /// <param name="id">reservation id</param>
        /// <returns>True if exists, false if not</returns>
        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

        /// <summary>
        /// Checks if the contact exists
        /// </summary>
        /// <param name="id">Contact id</param>
        /// <returns>True if exists, false if not</returns>
        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
