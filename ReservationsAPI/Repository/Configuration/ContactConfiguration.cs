using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData
            (
                new Contact
                {
                    Id = 1,
                    ContactName = "Ed Pelaez",
                    BirthDate = DateTime.Now.AddYears(-30),
                    ContactTypeId = 1,
                    PhoneNumber = "50212345678",
                }
            );
        }
    }
}

