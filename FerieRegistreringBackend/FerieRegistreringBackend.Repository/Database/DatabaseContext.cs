using FerieRegistreringBackend.Repository.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Models.Team> Teams { get; set; }
        public DbSet<Models.Vacation> Vacations { get; set; }
        public DbSet<Models.TimeEntry> TimeEntries { get; set; }
        public DbSet<Models.Absence> Absences { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var hasher = new PasswordHasher<Models.User>();

            var u1 = new Models.User { Id = 1, Name = "Niklas", LastName = "Hansen", Email = "niklas@example.com", DateOfBirth = new DateOnly(1995, 5, 12), Role = Models.UserRole.Leader, };
            u1.Password = hasher.HashPassword(u1, "test123");

            var u2 = new Models.User { Id = 2, Name = "Frygtløss", LastName = "Hund", Email = "frygtsommehund@example.com", DateOfBirth = new DateOnly(1980, 5, 19) };
            u2.Password = hasher.HashPassword(u2, "password");

            var u3 = new Models.User { Id = 3, Name = "Homer", LastName = "Simpson", Email = "homer.simpson@springfield.com", DateOfBirth = new DateOnly(1956, 5, 12), Role = Models.UserRole.Leader, };
            u3.Password = hasher.HashPassword(u3, "donuts");

            var u4 = new Models.User { Id = 4, Name = "Peter", LastName = "Griffin", Email = "peter.griffin@quahog.com", DateOfBirth = new DateOnly(1966, 7, 1), Role = Models.UserRole.Leader, };
            u4.Password = hasher.HashPassword(u4, "lois123");

            var u5 = new Models.User { Id = 5, Name = "Patrick", LastName = "Star", Email = "patrick.star@bikinibottom.com", DateOfBirth = new DateOnly(1999, 5, 1) };
            u5.Password = hasher.HashPassword(u5, "mayoi");

            var u6 = new Models.User { Id = 6, Name = "Lisa", LastName = "Simpson", Email = "lisa.simpson@springfield.com", DateOfBirth = new DateOnly(2005, 3, 9) };
            u6.Password = hasher.HashPassword(u6, "saxophone");

            var u7 = new Models.User { Id = 7, Name = "Marge", LastName = "Simpson", Email = "marge.simpson@springfield.com", DateOfBirth = new DateOnly(1960, 10, 1) };
            u7.Password = hasher.HashPassword(u7, "bluehair");

            var u8 = new Models.User { Id = 8, Name = "Stewie", LastName = "Griffin", Email = "stewie.griffin@quahog.com", DateOfBirth = new DateOnly(2018, 7, 14) };
            u8.Password = hasher.HashPassword(u8, "worlddomination");

            var u9 = new Models.User { Id = 9, Name = "Brian", LastName = "Griffin", Email = "brian.griffin@quahog.com", DateOfBirth = new DateOnly(2010, 11, 2), Role = Models.UserRole.Leader };
            u9.Password = hasher.HashPassword(u9, "martini");

            var u10 = new Models.User { Id = 10, Name = "Sandy", LastName = "Cheeks", Email = "sandy.cheeks@bikinibottom.com", DateOfBirth = new DateOnly(1990, 6, 18) };
            u10.Password = hasher.HashPassword(u10, "karate");

            var u11 = new Models.User { Id = 11, Name = "Squidward", LastName = "Tentacles", Email = "squidward@bikinibottom.com", DateOfBirth = new DateOnly(1982, 4, 10) };
            u11.Password = hasher.HashPassword(u11, "clarinet");

            var u12 = new Models.User { Id = 12, Name = "Mr", LastName = "Krabs", Email = "mr.krabs@bikinibottom.com", DateOfBirth = new DateOnly(1970, 7, 5), Role = Models.UserRole.Leader, };
            u12.Password = hasher.HashPassword(u12, "moneys");

            var u13 = new Models.User { Id = 13, Name = "Sheldon", LastName = "Plankton", Email = "plankton@bikinibottom.com", DateOfBirth = new DateOnly(1972, 8, 22) };
            u13.Password = hasher.HashPassword(u13, "chumbucket");

            var u14 = new Models.User { Id = 14, Name = "Bart", LastName = "Simpson", Email = "bart.simpson@springfield.com", DateOfBirth = new DateOnly(2007, 4, 1) };
            u14.Password = hasher.HashPassword(u14, "eatmyshorts");

            var u15 = new Models.User { Id = 15, Name = "Meg", LastName = "Griffin", Email = "meg.griffin@quahog.com", DateOfBirth = new DateOnly(2003, 8, 21) };
            u15.Password = hasher.HashPassword(u15, "ignored");

            var u16 = new Models.User { Id = 16, Name = "Lois", LastName = "Griffin", Email = "lois.griffin@quahog.com", DateOfBirth = new DateOnly(1975, 3, 3) };
            u16.Password = hasher.HashPassword(u16, "familyfirst");

            var u17 = new Models.User { Id = 17, Name = "Chris", LastName = "Griffin", Email = "chris.griffin@quahog.com", DateOfBirth = new DateOnly(2001, 2, 12) };
            u17.Password = hasher.HashPassword(u17, "artsy");

            var u18 = new Models.User { Id = 18, Name = "Ned", LastName = "Flanders", Email = "ned.flanders@springfield.com", DateOfBirth = new DateOnly(1965, 2, 9) };
            u18.Password = hasher.HashPassword(u18, "okelydokely");

            var u19 = new Models.User { Id = 19, Name = "Moe", LastName = "Szyslak", Email = "moe.szyslak@springfield.com", DateOfBirth = new DateOnly(1963, 11, 5) };
            u19.Password = hasher.HashPassword(u19, "bar123");

            var u20 = new Models.User { Id = 20, Name = "Carl", LastName = "Carlson", Email = "carl.carlson@springfield.com", DateOfBirth = new DateOnly(1970, 4, 14) };
            u20.Password = hasher.HashPassword(u20, "powerplant");

            var u21 = new Models.User { Id = 21, Name = "Lenny", LastName = "Leonard", Email = "lenny.leonard@springfield.com", DateOfBirth = new DateOnly(1970, 6, 6) };
            u21.Password = hasher.HashPassword(u21, "duffbeer");

            var u22 = new Models.User { Id = 22, Name = "Mr", LastName = "Burns", Email = "mr.burns@springfield.com", DateOfBirth = new DateOnly(1930, 9, 15), Role = Models.UserRole.Leader };
            u22.Password = hasher.HashPassword(u22, "excellent");

            var u23 = new Models.User { Id = 23, Name = "Waylon", LastName = "Smithers", Email = "smithers@springfield.com", DateOfBirth = new DateOnly(1968, 7, 30) };
            u23.Password = hasher.HashPassword(u23, "loyal");

            var u24 = new Models.User { Id = 24, Name = "Ralph", LastName = "Wiggum", Email = "ralph.wiggum@springfield.com", DateOfBirth = new DateOnly(2012, 2, 14) };
            u24.Password = hasher.HashPassword(u24, "choochoo");

            var u25 = new Models.User { Id = 25, Name = "Apu", LastName = "Nahasapeemapetilon", Email = "apu@springfield.com", DateOfBirth = new DateOnly(1971, 12, 7) };
            u25.Password = hasher.HashPassword(u25, "kwikemart");

            var u26 = new Models.User { Id = 26, Name = "Milhouse", LastName = "Van Houten", Email = "milhouse@springfield.com", DateOfBirth = new DateOnly(2006, 7, 1) };
            u26.Password = hasher.HashPassword(u26, "bestfriend");

            var u27 = new Models.User { Id = 27, Name = "Comic", LastName = "Book Guy", Email = "comic.bookguy@springfield.com", DateOfBirth = new DateOnly(1975, 1, 1) };
            u27.Password = hasher.HashPassword(u27, "worstpasswordever");

            var u28 = new Models.User { Id = 28, Name = "Edna", LastName = "Krabappel", Email = "edna.krabappel@springfield.com", DateOfBirth = new DateOnly(1960, 11, 1) };
            u28.Password = hasher.HashPassword(u28, "teacher");

            var u29 = new Models.User { Id = 29, Name = "Principal", LastName = "Skinner", Email = "seymour.skinner@springfield.com", DateOfBirth = new DateOnly(1961, 5, 30) };
            u29.Password = hasher.HashPassword(u29, "discipline");

            var u30 = new Models.User { Id = 30, Name = "Groundskeeper", LastName = "Willie", Email = "willie@springfield.com", DateOfBirth = new DateOnly(1962, 6, 1) };
            u30.Password = hasher.HashPassword(u30, "scotland");

            // Laver et team
            var springfieldTeam = new Models.Team
            {
                TeamId = 1,
                Name = "Springfield",
                Description = "The Springfield team",
                LeaderUserId = u1.Id,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow
            };

            var quahogTeam = new Team
            {
                TeamId = 2,
                Name = "Quahog",
                Description = "The Quahog team",
                LeaderUserId = u4.Id,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow
            };

            var bikiniBottomTeam = new Team
            {
                TeamId = 3,
                Name = "Bikini Bottom",
                Description = "The Bikini Bottom team",
                LeaderUserId = u5.Id,
                IsActive = true,
                CreatedAtUtc = DateTime.UtcNow
            };


            // Tilknyt brugere til et team 
            // 
            u3.TeamId = springfieldTeam.TeamId; 
            u7.TeamId = springfieldTeam.TeamId; 
            u14.TeamId = springfieldTeam.TeamId; 

            u4.TeamId = quahogTeam.TeamId; 
            u16.TeamId = quahogTeam.TeamId; 
            u8.TeamId = quahogTeam.TeamId; 
            u9.TeamId = quahogTeam.TeamId; 

            u5.TeamId = bikiniBottomTeam.TeamId; 
            u10.TeamId = bikiniBottomTeam.TeamId; 
            u11.TeamId = bikiniBottomTeam.TeamId; 
            u12.TeamId = bikiniBottomTeam.TeamId; 
            u13.TeamId = bikiniBottomTeam.TeamId; 

            modelBuilder.Entity<Models.User>().HasData(
                u1, u2, u3, u4, u5, u6, u7, u8, u9, u10,
                u11, u12, u13, u14, u15, u16, u17, u18, u19, u20,
                u21, u22, u23, u24, u25, u26, u27, u28, u29, u30
            );

            // Relation 
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Members)
                .WithOne(u => u.Team)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.SetNull);

            // seeding team
            modelBuilder.Entity<Team>().HasData(springfieldTeam, quahogTeam, bikiniBottomTeam);


        }

    }
}
