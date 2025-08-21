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
                    StartDate = new DateOnly(2023, 6, 1),
                    EndDate = new DateOnly(2023, 6, 10),
                    Reason = "Family vacation",
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

        }

    }
}
