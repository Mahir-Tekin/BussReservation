using BussReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace BussReservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Guzergahlar> guzergahlars { get; set; }
        public DbSet<Koltuk> Koltuks { get; set; }
    }
}
