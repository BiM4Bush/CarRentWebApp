using CarRentWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentWebApi.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
