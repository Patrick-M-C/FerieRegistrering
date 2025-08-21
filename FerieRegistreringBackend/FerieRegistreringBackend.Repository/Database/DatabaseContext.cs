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
                }
            );
        }

    }
}
