using Microsoft.EntityFrameworkCore;

namespace Bookings.Models
{
    public class Context : DbContext
    {
  
    public Context(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<AdditionalTravellers> AdditionalTravellers { get; set; }
    }
}
