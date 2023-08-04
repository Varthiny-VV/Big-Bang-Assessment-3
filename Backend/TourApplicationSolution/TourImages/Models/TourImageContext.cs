using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TourImages.Models
{
    public class TourImageContext : DbContext
    {
        public TourImageContext(DbContextOptions<TourImageContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TourImage> TourImages { get; set; }
    }
}
