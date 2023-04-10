using System;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repository.Configuration;

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

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
        }

        public DbSet<Contact>? Contacts { get; set; }

        public DbSet<ContactType>? ContactTypes { get; set; }

        public DbSet<Reservation>? Reservations { get; set; }
    }
}

