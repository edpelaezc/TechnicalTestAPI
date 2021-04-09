using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Models;
using ReservationsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Services
{
    public class ContactTypesService : IContactTypesService
    {
        private readonly ReservationsContext _context;

        public ContactTypesService(ReservationsContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ContactType>>> GetContactTypesAsync()
        {
            return await _context.ContactTypes.ToListAsync();
        }
    }
}
