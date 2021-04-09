using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;
using ReservationsAPI.Services.Interfaces;
using Newtonsoft;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService service)
        {
            _contactsService = service;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _contactsService.GetContactsAsync();
        }

        /// <summary>
        /// method to get the data in the users table
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/ContactsDetails")]
        public ActionResult<IEnumerable<ContactsViewModel>> GetContactsDetails()
        {
            return _contactsService.GetContactsList();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public ActionResult<EditContactViewModel> GetContact(int id)
        {
            var contact = _contactsService.ReadContact(id);
            return contact == null ? NotFound() : contact; 
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(ContactsForm contact)
        {
            bool result = await _contactsService.PutContactAsync(contact);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(ContactsForm contact)
        {
            var result = await _contactsService.PostContactAsync(contact);

            if (result)
            {
                return Ok();
            }

            return Problem();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _contactsService.DeleteContactAsync(id);
            return contact == null ? NotFound() : contact;
        }
    }
}
