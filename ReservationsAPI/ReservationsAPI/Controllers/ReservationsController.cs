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
        public ActionResult<EditReservationViewModel> GetReservation(int id)
        {
            var reservation = _context.EditReservationViewModels.FromSqlInterpolated($"sp_GetReservation {id}").ToList();

            try
            {
                return reservation.First();
            }
            catch (Exception)
            {
                return NotFound();
            }
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
            if (ReservationExists(id))
            {
                var test = _context.Database.ExecuteSqlInterpolated($"sp_UpdateReservation {id}, {reservation.ContactId}, {reservation.Description}");
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
            if (ReservationExists(id))
            {
                var result = await _context.Database.ExecuteSqlInterpolatedAsync($"sp_DeleteReservation {id}");
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
