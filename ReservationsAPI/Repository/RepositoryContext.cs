using System;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository
{
	public class RepositoryContext : DbContext
    {
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Contact>? Contacts { get; set; }

        public DbSet<ContactType>? ContactTypes { get; set; }

        public DbSet<Reservation>? Reservations { get; set; }
    }
}

