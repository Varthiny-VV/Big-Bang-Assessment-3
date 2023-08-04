using Microsoft.EntityFrameworkCore;
using TourPackages.Interfaces;
using TourPackages.Models;
using TourPackages.Services;


namespace TourPackages
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
            builder.Services.AddDbContext<Context>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });
            builder.Services.AddScoped<IRepo<int, Itinerary>, ItineraryRepo>();
            builder.Services.AddScoped<IRepo<int, Package>, PackageRepo>();
            builder.Services.AddScoped<IRepo<int, AgentContact>, ContactDetailsRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}