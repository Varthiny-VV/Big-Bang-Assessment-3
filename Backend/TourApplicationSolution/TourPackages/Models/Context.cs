using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TourPackages.Models
{
    public class Context : DbContext
    {
        
            public Context(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Package> Packages { get; set; }

            public DbSet<Itinerary> Itinerary { get; set; }
            public DbSet<AgentContact> AgentContacts { get; set; }
            public DbSet<PackageImages> PackageImages { get; set; }
        
    }
}
