using Bookings.Interfaces;
using Bookings.Models;
using Bookings.Services;
using Microsoft.EntityFrameworkCore;

namespace Bookings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>
              (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped<IRepo<Booking, int>, BookingRepo>();
            builder.Services.AddScoped<IRepo<AdditionalTravellers, int>, AdditionalTravellersRepo>();
            builder.Services.AddScoped<IManageBooking, ManageBookingService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseCors("MyCors");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}