using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;

namespace ReservationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly ReservationsContext _context;

        public ContactTypesController(ReservationsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieve contact types 
        /// </summary>
        /// <returns>List of the contact types</returns>
        // GET: api/ContactTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactType>>> GetContactTypes()
        {
            return await _context.ContactTypes.ToListAsync();
        }
    }
}
