using DenMed.Models;
using Microsoft.EntityFrameworkCore;

namespace DenMed.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers {get; set;}
        public DbSet<Specialist> Specialists {get; set;}
        public DbSet<Reservation> Reservations {get; set;}
        public DbSet<Surgery> Surgeries {get; set;}
        public DbSet<Address> Addresses {get; set;}
    }
}