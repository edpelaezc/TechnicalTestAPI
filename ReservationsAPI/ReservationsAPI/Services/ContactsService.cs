using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using ReservationsAPI.Services.Interfaces;

namespace ReservationsAPI.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ReservationsContext _context;

        public ContactsService(ReservationsContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Contact>>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<ActionResult<Contact>> DeleteContactAsync(int id)
        {
            // search the contact
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public ActionResult<IEnumerable<ContactsViewModel>> GetContactsList()
        {
            // get formatted data to the contacts list
            var list = _context.ContactsViewModels.FromSqlInterpolated($"sp_GetContactDetails").ToList();
            return list;
        }

        public async Task<bool> PostContactAsync(ContactsForm contact)
        {
            try
            {
                // add a new contact
                _context.Contacts.Add(new Contact()
                {
                    ContactName = contact.ContactName,
                    BirthDate = Convert.ToDateTime(contact.BirthDate),
                    ContactTypeId = Convert.ToInt32(contact.ContactTypeId),
                    PhoneNumber = contact.PhoneNumber
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutContactAsync(ContactsForm contact)
        {
            if (ContactExists(Convert.ToInt32(contact.id)))
            {
                // set the values from the from 
                _context.Entry(new Contact()
                {
                    Id = Convert.ToInt32(contact.id),
                    ContactName = contact.ContactName,
                    PhoneNumber = contact.PhoneNumber,
                    BirthDate = Convert.ToDateTime(contact.BirthDate),
                    ContactTypeId = Convert.ToInt32(contact.ContactTypeId)
                }).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult<EditContactViewModel> ReadContact(int id)
        {
            var contact = _context.EditContactViewModels.FromSqlInterpolated($"sp_GetContact {id}").ToList();

            try
            {
                return contact.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
