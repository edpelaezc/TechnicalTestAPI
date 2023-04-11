using System;
using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Contact;

namespace ReservationsAPI
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Contact, ContactDTO>()
				.ForMember(c => c.ContactTypeName,
				opt => opt.MapFrom(x => x.ContactType.Name.ToString()));

            CreateMap<ContactForUpdateDTO, Contact>().ReverseMap();
        }
	}
}

