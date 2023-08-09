using Microsoft.EntityFrameworkCore;

namespace TourImages.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<ImageTourism> ImagesTourism { get; set; }

    }
}
