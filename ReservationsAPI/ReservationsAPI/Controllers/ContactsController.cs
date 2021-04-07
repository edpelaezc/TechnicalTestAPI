using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using Newtonsoft;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ReservationsContext _context;

        public ContactsController(ReservationsContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        [HttpGet("/api/ContactsDetails")]
        public ActionResult<IEnumerable<ContactsViewModel>> GetContactsDetails()
        {
            var list = _context.ContactsViewModels.FromSqlInterpolated($"sp_GetContactDetails").ToList();
            return list;
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public ActionResult<EditContactViewModel> GetContact(int id)
        {
            var contact = _context.EditContactViewModels.FromSqlInterpolated($"sp_GetContact {id}").ToList();

            try
            {
                return contact.First();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(ContactsForm contact)
        {

            if (ContactExists(Convert.ToInt32(contact.id)))
            {
                _context.Entry(new Contact()
                {
                    Id = Convert.ToInt32(contact.id),
                    ContactName = contact.ContactName,
                    PhoneNumber = contact.PhoneNumber,
                    BirthDate = Convert.ToDateTime(contact.BirthDate),
                    ContactTypeId = Convert.ToInt32(contact.ContactTypeId)
                }).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(ContactsForm contact)
        {
            try
            {
                _context.Contacts.Add(new Contact() 
                {
                    ContactName = contact.ContactName,
                    BirthDate = Convert.ToDateTime(contact.BirthDate),
                    ContactTypeId = Convert.ToInt32(contact.ContactTypeId),
                    PhoneNumber = contact.PhoneNumber
                });
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return Problem();                
            }
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
