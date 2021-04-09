using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsAPI.Services.Interfaces
{
    public interface IContactTypesService
    {
        Task<ActionResult<IEnumerable<ContactType>>> GetContactTypesAsync();
    }
}
