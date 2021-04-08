using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationsAPI.Models.ViewModels;

namespace ReservationsAPI.Models
{
    public class ReservationsContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ReservationsContext(DbContextOptions<ReservationsContext> options, IConfiguration configuration = null)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // stored procedures
        public virtual DbSet<ContactsViewModel> ContactsViewModels { get; set; }
        public virtual DbSet<EditContactViewModel> EditContactViewModels { get; set; }
        public virtual DbSet<EditReservationViewModel> EditReservationViewModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            }
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<ContactType> range = new List<ContactType>()
            {
                new ContactType() { Id = 1, Description = "Contact Type 1" },
                new ContactType() { Id = 2, Description = "Contact Type 2" },
                new ContactType() { Id = 3, Description = "Contact Type 3" }
            };
            modelBuilder.Entity<ContactType>().HasData(range);
        }*/
    }
}
