using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Entities;
using FerieRegistreringBackend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FerieRegistreringBackend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("FerieRegistreringBackend.API")));

            // Repository
            builder.Services.AddScoped<IUser, UserRepo>();
            builder.Services.AddScoped<IVacation, VacationRepo>();
            builder.Services.AddScoped<ITimeEntry, TimeEntryRepo>();

            // --- CORS config ---
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // Angular dev server
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // --- Enable CORS before Authorization ---
            app.UseCors("AllowAngular");

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
