using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using ReservationsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly ReservationsContext _context;

        public ReservationsService(ReservationsContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteReservation(int id)
        {
            // check if exists, if not, it is a bad request to delete
            if (ReservationExists(id))
            {
                var result = await _context.Database.ExecuteSqlInterpolatedAsync($"sp_DeleteReservation {id}");
                return true;
            }
            else
            {
                return false;
            }            
        }

        public ActionResult<EditReservationViewModel> GetReservation(int id)
        {
            // using sp to get the data joined
            var reservation = _context.EditReservationViewModels.FromSqlInterpolated($"sp_GetReservation {id}").ToList();

            try
            {
                return reservation.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult<IEnumerable<ReservationViewModel>> GetReservations()
        { 
            // get the reservations fields to show in the list view: id and reservation user
            var list = (from reservations in _context.Reservations
                        join contacts in _context.Contacts on reservations.ContactId equals contacts.Id
                        select new ReservationViewModel()
                        {
                            id = reservations.Id,
                            userName = contacts.ContactName
                        }).ToList();
            return list;
        }

        public async Task<bool> PostReservation(ReservationForm reservation)
        {
            try
            {
                int contactID = 0;

                // check if the user exists, if not, create a new user with the provided data.
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

                    // save the contact to get the id and relate the new reservation 
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();
                    contactID = contact.Id;
                }

                // create the reservation
                _context.Reservations.Add(new Reservation()
                {
                    ContactId = contactID,
                    Description = reservation.editorContent
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PutReservation(int id, EditReservationViewModel reservation)
        {
            if (ReservationExists(id))
            {
                // update in sp the reservation
                var test = _context.Database.ExecuteSqlInterpolated($"sp_UpdateReservation {id}, {reservation.ContactId}, {reservation.Description}");
                return true;
            }
            else
            {
                return false;
            }
        }

        // auxiliary methods 

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
