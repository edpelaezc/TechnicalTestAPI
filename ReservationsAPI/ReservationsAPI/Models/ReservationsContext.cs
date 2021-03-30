using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            }
        }
    }
}
