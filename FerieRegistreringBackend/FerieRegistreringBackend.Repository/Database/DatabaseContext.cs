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

            // --- USERS ---
            /* modelBuilder.Entity<Models.User>().HasData(
                new Models.User { Id = 1, Name = "Niklas", LastName = "Hansen", Email = "niklas@example.com", DateOfBirth = new DateOnly(1995, 5, 12), Password = "test123" },
                new Models.User { Id = 2, Name = "Frygtløss", LastName = "Hund", Email = "frygtsommehund@example.com", DateOfBirth = new DateOnly(1980, 5, 19), Password = "password" },
                new Models.User { Id = 3, Name = "Homer", LastName = "Simpson", Email = "homer.simpson@springfield.com", DateOfBirth = new DateOnly(1956, 5, 12), Password = "donuts" },
                new Models.User { Id = 4, Name = "Peter", LastName = "Griffin", Email = "peter.griffin@quahog.com", DateOfBirth = new DateOnly(1966, 7, 1), Password = "lois123" },
                new Models.User { Id = 5, Name = "Patrick", LastName = "Star", Email = "patrick.star@bikinibottom.com", DateOfBirth = new DateOnly(1999, 5, 1), Password = "mayoi" },
                new Models.User { Id = 6, Name = "Lisa", LastName = "Simpson", Email = "lisa.simpson@springfield.com", DateOfBirth = new DateOnly(2005, 3, 9), Password = "saxophone" },
                new Models.User { Id = 7, Name = "Marge", LastName = "Simpson", Email = "marge.simpson@springfield.com", DateOfBirth = new DateOnly(1960, 10, 1), Password = "bluehair" },
                new Models.User { Id = 8, Name = "Stewie", LastName = "Griffin", Email = "stewie.griffin@quahog.com", DateOfBirth = new DateOnly(2018, 7, 14), Password = "worlddomination" },
                new Models.User { Id = 9, Name = "Brian", LastName = "Griffin", Email = "brian.griffin@quahog.com", DateOfBirth = new DateOnly(2010, 11, 2), Password = "martini" },
                new Models.User { Id = 10, Name = "Sandy", LastName = "Cheeks", Email = "sandy.cheeks@bikinibottom.com", DateOfBirth = new DateOnly(1990, 6, 18), Password = "karate" },
                new Models.User { Id = 11, Name = "Squidward", LastName = "Tentacles", Email = "squidward@bikinibottom.com", DateOfBirth = new DateOnly(1982, 4, 10), Password = "clarinet" },
                new Models.User { Id = 12, Name = "Mr", LastName = "Krabs", Email = "mr.krabs@bikinibottom.com", DateOfBirth = new DateOnly(1970, 7, 5), Password = "money" },
                new Models.User { Id = 13, Name = "Sheldon", LastName = "Plankton", Email = "plankton@bikinibottom.com", DateOfBirth = new DateOnly(1972, 8, 22), Password = "chumbucket" },
                new Models.User { Id = 14, Name = "Bart", LastName = "Simpson", Email = "bart.simpson@springfield.com", DateOfBirth = new DateOnly(2007, 4, 1), Password = "eatmyshorts" },
                new Models.User { Id = 15, Name = "Meg", LastName = "Griffin", Email = "meg.griffin@quahog.com", DateOfBirth = new DateOnly(2003, 8, 21), Password = "ignored" },
                new Models.User { Id = 16, Name = "Lois", LastName = "Griffin", Email = "lois.griffin@quahog.com", DateOfBirth = new DateOnly(1975, 3, 3), Password = "familyfirst" },
                new Models.User { Id = 17, Name = "Chris", LastName = "Griffin", Email = "chris.griffin@quahog.com", DateOfBirth = new DateOnly(2001, 2, 12), Password = "artsy" },
                new Models.User { Id = 18, Name = "Ned", LastName = "Flanders", Email = "ned.flanders@springfield.com", DateOfBirth = new DateOnly(1965, 2, 9), Password = "okelydokely" },
                new Models.User { Id = 19, Name = "Moe", LastName = "Szyslak", Email = "moe.szyslak@springfield.com", DateOfBirth = new DateOnly(1963, 11, 5), Password = "bar123" },
                new Models.User { Id = 20, Name = "Carl", LastName = "Carlson", Email = "carl.carlson@springfield.com", DateOfBirth = new DateOnly(1970, 4, 14), Password = "powerplant" },
                new Models.User { Id = 21, Name = "Lenny", LastName = "Leonard", Email = "lenny.leonard@springfield.com", DateOfBirth = new DateOnly(1970, 6, 6), Password = "duffbeer" },
                new Models.User { Id = 22, Name = "Mr", LastName = "Burns", Email = "mr.burns@springfield.com", DateOfBirth = new DateOnly(1930, 9, 15), Password = "excellent" },
                new Models.User { Id = 23, Name = "Waylon", LastName = "Smithers", Email = "smithers@springfield.com", DateOfBirth = new DateOnly(1968, 7, 30), Password = "loyal" },
                new Models.User { Id = 24, Name = "Ralph", LastName = "Wiggum", Email = "ralph.wiggum@springfield.com", DateOfBirth = new DateOnly(2012, 2, 14), Password = "choochoo" },
                new Models.User { Id = 25, Name = "Apu", LastName = "Nahasapeemapetilon", Email = "apu@springfield.com", DateOfBirth = new DateOnly(1971, 12, 7), Password = "kwikemart" },
                new Models.User { Id = 26, Name = "Milhouse", LastName = "Van Houten", Email = "milhouse@springfield.com", DateOfBirth = new DateOnly(2006, 7, 1), Password = "bestfriend" },
                new Models.User { Id = 27, Name = "Comic", LastName = "Book Guy", Email = "comic.bookguy@springfield.com", DateOfBirth = new DateOnly(1975, 1, 1), Password = "worstpasswordever" },
                new Models.User { Id = 28, Name = "Edna", LastName = "Krabappel", Email = "edna.krabappel@springfield.com", DateOfBirth = new DateOnly(1960, 11, 1), Password = "teacher" },
                new Models.User { Id = 29, Name = "Principal", LastName = "Skinner", Email = "seymour.skinner@springfield.com", DateOfBirth = new DateOnly(1961, 5, 30), Password = "discipline" },
                new Models.User { Id = 30, Name = "Groundskeeper", LastName = "Willie", Email = "willie@springfield.com", DateOfBirth = new DateOnly(1962, 6, 1), Password = "scotland" }
            ); */

            var hasher = new PasswordHasher<Models.User>();

            var u1 = new Models.User { Id = 1, Name = "Niklas", LastName = "Hansen", Email = "niklas@example.com", DateOfBirth = new DateOnly(1995, 5, 12), Role = Models.UserRole.Leader, };
            u1.Password = hasher.HashPassword(u1, "test123");

            var u2 = new Models.User { Id = 2, Name = "Frygtløss", LastName = "Hund", Email = "frygtsommehund@example.com", DateOfBirth = new DateOnly(1980, 5, 19) };
            u2.Password = hasher.HashPassword(u2, "password");

            var u3 = new Models.User { Id = 3, Name = "Homer", LastName = "Simpson", Email = "homer.simpson@springfield.com", DateOfBirth = new DateOnly(1956, 5, 12) };
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

            var u12 = new Models.User { Id = 12, Name = "Mr", LastName = "Krabs", Email = "mr.krabs@bikinibottom.com", DateOfBirth = new DateOnly(1970, 7, 5) };
            u12.Password = hasher.HashPassword(u12, "money");

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

            modelBuilder.Entity<Models.User>().HasData(
                u1, u2, u3, u4, u5, u6, u7, u8, u9, u10,
                u11, u12, u13, u14, u15, u16, u17, u18, u19, u20,
                u21, u22, u23, u24, u25, u26, u27, u28, u29, u30
            );

            modelBuilder.Entity<Team>()
    .HasMany(t => t.Members)
    .WithOne(u => u.Team)
    .HasForeignKey(u => u.TeamId)
    .OnDelete(DeleteBehavior.SetNull);



            // --- VACATIONS ---
            /*
            modelBuilder.Entity<Models.Vacation>().HasData(
                new Models.Vacation { Id = 1, StartDate = new DateOnly(2025, 7, 1), EndDate = new DateOnly(2025, 7, 14), Reason = "Sommerferie", IsApproved = true, UserId = 1 },
                new Models.Vacation { Id = 2, StartDate = new DateOnly(2025, 3, 3), EndDate = new DateOnly(2025, 3, 7), Reason = "Sygdom", IsApproved = false, UserId = 2 },
                new Models.Vacation { Id = 3, StartDate = new DateOnly(2025, 9, 10), EndDate = new DateOnly(2025, 9, 12), Reason = "Konference", IsApproved = true, UserId = 3 },
                new Models.Vacation { Id = 4, StartDate = new DateOnly(2025, 12, 20), EndDate = new DateOnly(2026, 1, 2), Reason = "Juleferie", IsApproved = true, UserId = 4 },
                new Models.Vacation { Id = 5, StartDate = new DateOnly(2025, 5, 15), EndDate = new DateOnly(2025, 5, 20), Reason = "Strandferie", IsApproved = true, UserId = 5 },
                new Models.Vacation { Id = 6, StartDate = new DateOnly(2025, 10, 1), EndDate = new DateOnly(2025, 10, 5), Reason = "Barsel", IsApproved = true, UserId = 6 },
                new Models.Vacation { Id = 7, StartDate = new DateOnly(2025, 4, 8), EndDate = new DateOnly(2025, 4, 12), Reason = "Forårsferie", IsApproved = true, UserId = 7 },
                new Models.Vacation { Id = 8, StartDate = new DateOnly(2025, 2, 20), EndDate = new DateOnly(2025, 2, 25), Reason = "Skiferie", IsApproved = false, UserId = 8 },
                new Models.Vacation { Id = 9, StartDate = new DateOnly(2025, 6, 1), EndDate = new DateOnly(2025, 6, 7), Reason = "Personlige årsager", IsApproved = true, UserId = 9 },
                new Models.Vacation { Id = 10, StartDate = new DateOnly(2025, 11, 10), EndDate = new DateOnly(2025, 11, 14), Reason = "Efterårsferie", IsApproved = true, UserId = 10 },
                new Models.Vacation { Id = 11, StartDate = new DateOnly(2025, 8, 1), EndDate = new DateOnly(2025, 8, 15), Reason = "Sommerferie", IsApproved = true, UserId = 11 },
                new Models.Vacation { Id = 12, StartDate = new DateOnly(2025, 1, 5), EndDate = new DateOnly(2025, 1, 9), Reason = "Sygdom", IsApproved = false, UserId = 12 },
                new Models.Vacation { Id = 13, StartDate = new DateOnly(2025, 9, 20), EndDate = new DateOnly(2025, 9, 25), Reason = "Bryllup", IsApproved = true, UserId = 13 },
                new Models.Vacation { Id = 14, StartDate = new DateOnly(2025, 12, 22), EndDate = new DateOnly(2025, 12, 30), Reason = "Juleferie", IsApproved = true, UserId = 14 },
                new Models.Vacation { Id = 15, StartDate = new DateOnly(2025, 5, 10), EndDate = new DateOnly(2025, 5, 15), Reason = "Familiebesøg", IsApproved = true, UserId = 15 },
                new Models.Vacation { Id = 16, StartDate = new DateOnly(2025, 3, 14), EndDate = new DateOnly(2025, 3, 18), Reason = "Sygdom", IsApproved = false, UserId = 16 },
                new Models.Vacation { Id = 17, StartDate = new DateOnly(2025, 6, 20), EndDate = new DateOnly(2025, 6, 28), Reason = "Fødselsdagsrejse", IsApproved = true, UserId = 17 },
                new Models.Vacation { Id = 18, StartDate = new DateOnly(2025, 4, 1), EndDate = new DateOnly(2025, 4, 7), Reason = "Påskeferie", IsApproved = true, UserId = 18 },
                new Models.Vacation { Id = 19, StartDate = new DateOnly(2025, 2, 14), EndDate = new DateOnly(2025, 2, 16), Reason = "Weekendtur", IsApproved = true, UserId = 19 },
                new Models.Vacation { Id = 20, StartDate = new DateOnly(2025, 11, 1), EndDate = new DateOnly(2025, 11, 5), Reason = "Efterårsferie", IsApproved = true, UserId = 20 },
                new Models.Vacation { Id = 21, StartDate = new DateOnly(2025, 7, 20), EndDate = new DateOnly(2025, 7, 25), Reason = "Sommerferie", IsApproved = true, UserId = 21 },
                new Models.Vacation { Id = 22, StartDate = new DateOnly(2025, 1, 15), EndDate = new DateOnly(2025, 1, 20), Reason = "Sygdom", IsApproved = false, UserId = 22 },
                new Models.Vacation { Id = 23, StartDate = new DateOnly(2025, 9, 5), EndDate = new DateOnly(2025, 9, 9), Reason = "Kursus", IsApproved = true, UserId = 23 },
                new Models.Vacation { Id = 24, StartDate = new DateOnly(2025, 12, 24), EndDate = new DateOnly(2026, 1, 1), Reason = "Juleferie", IsApproved = true, UserId = 24 },
                new Models.Vacation { Id = 25, StartDate = new DateOnly(2025, 5, 1), EndDate = new DateOnly(2025, 5, 3), Reason = "Weekendtur", IsApproved = true, UserId = 25 },
                new Models.Vacation { Id = 26, StartDate = new DateOnly(2025, 3, 21), EndDate = new DateOnly(2025, 3, 25), Reason = "Sygdom", IsApproved = false, UserId = 26 },
                new Models.Vacation { Id = 27, StartDate = new DateOnly(2025, 6, 10), EndDate = new DateOnly(2025, 6, 15), Reason = "Familieferie", IsApproved = true, UserId = 27 },
                new Models.Vacation { Id = 28, StartDate = new DateOnly(2025, 4, 20), EndDate = new DateOnly(2025, 4, 23), Reason = "Påskeferie", IsApproved = true, UserId = 28 },
                new Models.Vacation { Id = 29, StartDate = new DateOnly(2025, 2, 5), EndDate = new DateOnly(2025, 2, 9), Reason = "Skiferie", IsApproved = true, UserId = 29 },
                new Models.Vacation { Id = 30, StartDate = new DateOnly(2025, 10, 15), EndDate = new DateOnly(2025, 10, 20), Reason = "Efterårsferie", IsApproved = true, UserId = 30 }
            );

            // --- TIME ENTRIES ---
            modelBuilder.Entity<Models.TimeEntry>().HasData(
                new Models.TimeEntry { Id = 1, UserId = 1, Date = new DateOnly(2025, 8, 20), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Almindelig arbejdsdag" },
                new Models.TimeEntry { Id = 2, UserId = 2, Date = new DateOnly(2025, 8, 21), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(15, 0, 0), Description = "Tidlig fri" },
                new Models.TimeEntry { Id = 3, UserId = 3, Date = new DateOnly(2025, 8, 22), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 0, 0), Description = "Konference dag" },
                new Models.TimeEntry { Id = 4, UserId = 4, Date = new DateOnly(2025, 8, 23), StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(17, 30, 0), Description = "Projektarbejde" },
                new Models.TimeEntry { Id = 5, UserId = 5, Date = new DateOnly(2025, 8, 24), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(14, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 6, UserId = 6, Date = new DateOnly(2025, 8, 25), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Almindelig arbejdsdag" },
                new Models.TimeEntry { Id = 7, UserId = 7, Date = new DateOnly(2025, 8, 26), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(12, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 8, UserId = 8, Date = new DateOnly(2025, 8, 27), StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(15, 0, 0), Description = "Skiftehold" },
                new Models.TimeEntry { Id = 9, UserId = 9, Date = new DateOnly(2025, 8, 28), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(16, 0, 0), Description = "Kontorarbejde" },
                new Models.TimeEntry { Id = 10, UserId = 10, Date = new DateOnly(2025, 8, 29), StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(19, 0, 0), Description = "Sen vagt" },
                new Models.TimeEntry { Id = 11, UserId = 11, Date = new DateOnly(2025, 8, 30), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Projektarbejde" },
                new Models.TimeEntry { Id = 12, UserId = 12, Date = new DateOnly(2025, 8, 31), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(14, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 13, UserId = 13, Date = new DateOnly(2025, 9, 1), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(15, 30, 0), Description = "Tidlig start" },
                new Models.TimeEntry { Id = 14, UserId = 14, Date = new DateOnly(2025, 9, 2), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Almindelig arbejdsdag" },
                new Models.TimeEntry { Id = 15, UserId = 15, Date = new DateOnly(2025, 9, 3), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(16, 0, 0), Description = "Møde dag" },
                new Models.TimeEntry { Id = 16, UserId = 16, Date = new DateOnly(2025, 9, 4), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(15, 0, 0), Description = "Kort dag" },
                new Models.TimeEntry { Id = 17, UserId = 17, Date = new DateOnly(2025, 9, 5), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 0, 0), Description = "Kursus" },
                new Models.TimeEntry { Id = 18, UserId = 18, Date = new DateOnly(2025, 9, 6), StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(17, 30, 0), Description = "Projektarbejde" },
                new Models.TimeEntry { Id = 19, UserId = 19, Date = new DateOnly(2025, 9, 7), StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(13, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 20, UserId = 20, Date = new DateOnly(2025, 9, 8), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Almindelig arbejdsdag" },
                new Models.TimeEntry { Id = 21, UserId = 21, Date = new DateOnly(2025, 9, 9), StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(16, 30, 0), Description = "Supportarbejde" },
                new Models.TimeEntry { Id = 22, UserId = 22, Date = new DateOnly(2025, 9, 10), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 23, UserId = 23, Date = new DateOnly(2025, 9, 11), StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(15, 30, 0), Description = "Kursusdag" },
                new Models.TimeEntry { Id = 24, UserId = 24, Date = new DateOnly(2025, 9, 12), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Almindelig arbejdsdag" },
                new Models.TimeEntry { Id = 25, UserId = 25, Date = new DateOnly(2025, 9, 13), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(15, 0, 0), Description = "Mødedag" },
                new Models.TimeEntry { Id = 26, UserId = 26, Date = new DateOnly(2025, 9, 14), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Projektarbejde" },
                new Models.TimeEntry { Id = 27, UserId = 27, Date = new DateOnly(2025, 9, 15), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(14, 0, 0), Description = "Halv dag" },
                new Models.TimeEntry { Id = 28, UserId = 28, Date = new DateOnly(2025, 9, 16), StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(15, 0, 0), Description = "Skiftehold" },
                new Models.TimeEntry { Id = 29, UserId = 29, Date = new DateOnly(2025, 9, 17), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(16, 0, 0), Description = "Kontorarbejde" },
                new Models.TimeEntry { Id = 30, UserId = 29, Date = new DateOnly(2025, 9, 18), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(17, 0, 0), Description = "Kontorarbejde" }
                );

                */

        }

    }
}
