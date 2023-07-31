using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SignInAndSignUp.Models
{
    public class Context : DbContext
    {
            public Context(DbContextOptions options) : base(options)
            {


            }
            public DbSet<Traveller> Travellers { get; set; }
            public DbSet<TravelAgent> TravelAgents { get; set; }
            public DbSet<Users> Users { get; set; }

  
        

    }
}
