using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.Models;
using ReservationsAPI.Models.ViewModels;

namespace ReservationsAPI.Services.Interfaces
{
    public interface IContactsService
    {
        Task<ActionResult<IEnumerable<Contact>>> GetContactsAsync();
        ActionResult<IEnumerable<ContactsViewModel>> GetContactsList();
        ActionResult<EditContactViewModel> ReadContact(int id);
        Task<bool> PutContactAsync(ContactsForm contact);
        Task<bool> PostContactAsync(ContactsForm contact);
        Task<ActionResult<Contact>> DeleteContactAsync(int id);
    }
}
