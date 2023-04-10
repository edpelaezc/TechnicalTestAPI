using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasData
            (
                new ContactType
                {
                    Id = 1,
                    Name = "ADMIN",
                    Description = "System administrator"
                },
                new ContactType
                {
                    Id = 2,
                    Name = "USER",
                    Description = "Normal system user"
                }
            );
        }
    }
}

