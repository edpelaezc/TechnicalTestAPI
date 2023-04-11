using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Text.Json;
using Shared.DataTransferObjects.Contact;

namespace ReservationsAPI.Presentation.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ContactController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet(Name = "GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _service.ContactService.GetAllContactsAsync(trackChanges: false);
            return Ok(contacts);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactForUpdateDTO contactForUpdateDTO)
        {
            await _service.ContactService.UpdateContactAsync(id, contactForUpdateDTO, trackChanges: true);
            return NoContent();
        }
    }
}

