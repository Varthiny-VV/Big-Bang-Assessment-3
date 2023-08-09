using Microsoft.EntityFrameworkCore;
using TourImages.Interfaces;
using TourImages.Models;
using TourImages.Services;

namespace TourImages
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
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            builder.Services.AddScoped<IRepo<int, ImageTourism>, TourImageRepo>();
            builder.Services.AddScoped<ITourImageServices, TourImageService>();
            builder.Services.AddDbContext<ImageContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
            });

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