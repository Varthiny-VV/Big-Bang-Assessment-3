using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Feedbacks.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}
