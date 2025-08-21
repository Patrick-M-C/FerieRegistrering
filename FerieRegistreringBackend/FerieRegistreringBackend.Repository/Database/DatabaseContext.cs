using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Vacation> Vacations { get; set; }
        public DbSet<Models.TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.User>().HasData(
                new Models.User
                {
                    Id = 1,
                    Name = "Niklas",
                    LastName = "Hansen",
                    Email = "niklas@example.com",
                    DateOfBirth = new DateOnly(1995, 5, 12),
                    Password = "test123"
                },
                new Models.User
                {
                    Id = 2,
                    Name = "Frygtløss",
                    LastName = "frygtsomme hund",
                    Email = "frygtsommehund@example.com",
                    DateOfBirth = new DateOnly(1980, 5, 19),
                    Password = "password"
                },
                new Models.User
                {
                    Id = 3,
                    Name = "Homer",
                    LastName = "Simpson",
                    Email = "homer.simpson@springfield.com",
                    DateOfBirth = new DateOnly(1956, 5, 12),
                    Password = "donuts"
                },
                new Models.User
                {
                    Id = 4,
                    Name = "Peter",
                    LastName = "Griffin",
                    Email = "peter.griffin@quahog.com",
                    DateOfBirth = new DateOnly(1966, 7, 1),
                    Password = "lois123"
                },
                new Models.User
                {
                    Id = 10,
                    Name = "Patrick",
                    LastName = "Star",
                    Email = "patrick.star@bikinibottom.com",
                    DateOfBirth = new DateOnly(1999, 5, 1),
                    Password = "mayoi"
                }
            );

            modelBuilder.Entity<Models.Vacation>().HasData(
                new Models.Vacation
                {
                    Id = 1,
                    StartDate = new DateOnly(2025, 10, 10),
                    EndDate = new DateOnly(2025, 12, 12),
                    Reason = "Battlefield 6",
                    IsApproved = true,
                    UserId = 1
                },
                new Models.Vacation
                {
                    Id = 2,
                    StartDate = new DateOnly(2023, 7, 15),
                    EndDate = new DateOnly(2023, 7, 20),
                    Reason = "Sick leave",
                    IsApproved = false,
                    UserId = 2
                }
            );

            modelBuilder.Entity<Models.TimeEntry>().HasData(
                new Models.TimeEntry
                {
                    Id = 1,
                    UserId = 1,
                    Date = new DateOnly(2025, 8, 20),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    Description = "Første arbejdsdag efter ferie"
                },
                new Models.TimeEntry
                {
                    Id = 2,
                    UserId = 2,
                    Date = new DateOnly(2025, 8, 21),
                    StartTime = new TimeSpan(10, 30, 0),
                    EndTime = new TimeSpan(16, 30, 0),
                    Description = "Halv arbejdsdag pga. lægebesøg"
                },
                new Models.TimeEntry
                {
                    Id = 3,
                    UserId = 3,
                    Date = new DateOnly(2025, 8, 22),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    Description = "Donut pause hele dagen"
                },
                new Models.TimeEntry
                {
                    Id = 4,
                    UserId = 4,
                    Date = new DateOnly(2025, 8, 22),
                    StartTime = new TimeSpan(9, 15, 0),
                    EndTime = new TimeSpan(18, 15, 0),
                    Description = "Lang dag med kode"
                }
            );

        }

    }
}
