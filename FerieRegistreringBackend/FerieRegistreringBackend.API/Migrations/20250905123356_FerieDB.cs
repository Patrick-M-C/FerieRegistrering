using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FerieRegistreringBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class FerieDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "LastName", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateOnly(1995, 5, 12), "niklas@example.com", "Hansen", "Niklas", "test123" },
                    { 2, new DateOnly(1980, 5, 19), "frygtsommehund@example.com", "Hund", "Frygtløss", "password" },
                    { 3, new DateOnly(1956, 5, 12), "homer.simpson@springfield.com", "Simpson", "Homer", "donuts" },
                    { 4, new DateOnly(1966, 7, 1), "peter.griffin@quahog.com", "Griffin", "Peter", "lois123" },
                    { 5, new DateOnly(1999, 5, 1), "patrick.star@bikinibottom.com", "Star", "Patrick", "mayoi" },
                    { 6, new DateOnly(2005, 3, 9), "lisa.simpson@springfield.com", "Simpson", "Lisa", "saxophone" },
                    { 7, new DateOnly(1960, 10, 1), "marge.simpson@springfield.com", "Simpson", "Marge", "bluehair" },
                    { 8, new DateOnly(2018, 7, 14), "stewie.griffin@quahog.com", "Griffin", "Stewie", "worlddomination" },
                    { 9, new DateOnly(2010, 11, 2), "brian.griffin@quahog.com", "Griffin", "Brian", "martini" },
                    { 10, new DateOnly(1990, 6, 18), "sandy.cheeks@bikinibottom.com", "Cheeks", "Sandy", "karate" },
                    { 11, new DateOnly(1982, 4, 10), "squidward@bikinibottom.com", "Tentacles", "Squidward", "clarinet" },
                    { 12, new DateOnly(1970, 7, 5), "mr.krabs@bikinibottom.com", "Krabs", "Mr", "money" },
                    { 13, new DateOnly(1972, 8, 22), "plankton@bikinibottom.com", "Plankton", "Sheldon", "chumbucket" },
                    { 14, new DateOnly(2007, 4, 1), "bart.simpson@springfield.com", "Simpson", "Bart", "eatmyshorts" },
                    { 15, new DateOnly(2003, 8, 21), "meg.griffin@quahog.com", "Griffin", "Meg", "ignored" },
                    { 16, new DateOnly(1975, 3, 3), "lois.griffin@quahog.com", "Griffin", "Lois", "familyfirst" },
                    { 17, new DateOnly(2001, 2, 12), "chris.griffin@quahog.com", "Griffin", "Chris", "artsy" },
                    { 18, new DateOnly(1965, 2, 9), "ned.flanders@springfield.com", "Flanders", "Ned", "okelydokely" },
                    { 19, new DateOnly(1963, 11, 5), "moe.szyslak@springfield.com", "Szyslak", "Moe", "bar123" },
                    { 20, new DateOnly(1970, 4, 14), "carl.carlson@springfield.com", "Carlson", "Carl", "powerplant" },
                    { 21, new DateOnly(1970, 6, 6), "lenny.leonard@springfield.com", "Leonard", "Lenny", "duffbeer" },
                    { 22, new DateOnly(1930, 9, 15), "mr.burns@springfield.com", "Burns", "Mr", "excellent" },
                    { 23, new DateOnly(1968, 7, 30), "smithers@springfield.com", "Smithers", "Waylon", "loyal" },
                    { 24, new DateOnly(2012, 2, 14), "ralph.wiggum@springfield.com", "Wiggum", "Ralph", "choochoo" },
                    { 25, new DateOnly(1971, 12, 7), "apu@springfield.com", "Nahasapeemapetilon", "Apu", "kwikemart" },
                    { 26, new DateOnly(2006, 7, 1), "milhouse@springfield.com", "Van Houten", "Milhouse", "bestfriend" },
                    { 27, new DateOnly(1975, 1, 1), "comic.bookguy@springfield.com", "Book Guy", "Comic", "worstpasswordever" },
                    { 28, new DateOnly(1960, 11, 1), "edna.krabappel@springfield.com", "Krabappel", "Edna", "teacher" },
                    { 29, new DateOnly(1961, 5, 30), "seymour.skinner@springfield.com", "Skinner", "Principal", "discipline" },
                    { 30, new DateOnly(1962, 6, 1), "willie@springfield.com", "Willie", "Groundskeeper", "scotland" }
                });

            migrationBuilder.InsertData(
                table: "TimeEntries",
                columns: new[] { "Id", "Date", "Description", "EndTime", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 8, 20), "Almindelig arbejdsdag", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 2, new DateOnly(2025, 8, 21), "Tidlig fri", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), 2 },
                    { 3, new DateOnly(2025, 8, 22), "Konference dag", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 3 },
                    { 4, new DateOnly(2025, 8, 23), "Projektarbejde", new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0), 4 },
                    { 5, new DateOnly(2025, 8, 24), "Halv dag", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 5 },
                    { 6, new DateOnly(2025, 8, 25), "Almindelig arbejdsdag", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 6 },
                    { 7, new DateOnly(2025, 8, 26), "Halv dag", new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 7 },
                    { 8, new DateOnly(2025, 8, 27), "Skiftehold", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 8 },
                    { 9, new DateOnly(2025, 8, 28), "Kontorarbejde", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 9 },
                    { 10, new DateOnly(2025, 8, 29), "Sen vagt", new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), 10 },
                    { 11, new DateOnly(2025, 8, 30), "Projektarbejde", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 11 },
                    { 12, new DateOnly(2025, 8, 31), "Halv dag", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 12 },
                    { 13, new DateOnly(2025, 9, 1), "Tidlig start", new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0), 13 },
                    { 14, new DateOnly(2025, 9, 2), "Almindelig arbejdsdag", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 14 },
                    { 15, new DateOnly(2025, 9, 3), "Møde dag", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), 15 },
                    { 16, new DateOnly(2025, 9, 4), "Kort dag", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 16 },
                    { 17, new DateOnly(2025, 9, 5), "Kursus", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 17 },
                    { 18, new DateOnly(2025, 9, 6), "Projektarbejde", new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0), 18 },
                    { 19, new DateOnly(2025, 9, 7), "Halv dag", new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 19 },
                    { 20, new DateOnly(2025, 9, 8), "Almindelig arbejdsdag", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 20 },
                    { 21, new DateOnly(2025, 9, 9), "Supportarbejde", new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0), 21 },
                    { 22, new DateOnly(2025, 9, 10), "Halv dag", new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 22 },
                    { 23, new DateOnly(2025, 9, 11), "Kursusdag", new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0), 23 },
                    { 24, new DateOnly(2025, 9, 12), "Almindelig arbejdsdag", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 24 },
                    { 25, new DateOnly(2025, 9, 13), "Mødedag", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), 25 },
                    { 26, new DateOnly(2025, 9, 14), "Projektarbejde", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 26 },
                    { 27, new DateOnly(2025, 9, 15), "Halv dag", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 27 },
                    { 28, new DateOnly(2025, 9, 16), "Skiftehold", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 28 },
                    { 29, new DateOnly(2025, 9, 17), "Kontorarbejde", new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 29 },
                    { 30, new DateOnly(2025, 9, 18), "Kontorarbejde", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), 29 }
                });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "Id", "EndDate", "IsApproved", "Reason", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 7, 14), true, "Sommerferie", new DateOnly(2025, 7, 1), 1 },
                    { 2, new DateOnly(2025, 3, 7), false, "Sygdom", new DateOnly(2025, 3, 3), 2 },
                    { 3, new DateOnly(2025, 9, 12), true, "Konference", new DateOnly(2025, 9, 10), 3 },
                    { 4, new DateOnly(2026, 1, 2), true, "Juleferie", new DateOnly(2025, 12, 20), 4 },
                    { 5, new DateOnly(2025, 5, 20), true, "Strandferie", new DateOnly(2025, 5, 15), 5 },
                    { 6, new DateOnly(2025, 10, 5), true, "Barsel", new DateOnly(2025, 10, 1), 6 },
                    { 7, new DateOnly(2025, 4, 12), true, "Forårsferie", new DateOnly(2025, 4, 8), 7 },
                    { 8, new DateOnly(2025, 2, 25), false, "Skiferie", new DateOnly(2025, 2, 20), 8 },
                    { 9, new DateOnly(2025, 6, 7), true, "Personlige årsager", new DateOnly(2025, 6, 1), 9 },
                    { 10, new DateOnly(2025, 11, 14), true, "Efterårsferie", new DateOnly(2025, 11, 10), 10 },
                    { 11, new DateOnly(2025, 8, 15), true, "Sommerferie", new DateOnly(2025, 8, 1), 11 },
                    { 12, new DateOnly(2025, 1, 9), false, "Sygdom", new DateOnly(2025, 1, 5), 12 },
                    { 13, new DateOnly(2025, 9, 25), true, "Bryllup", new DateOnly(2025, 9, 20), 13 },
                    { 14, new DateOnly(2025, 12, 30), true, "Juleferie", new DateOnly(2025, 12, 22), 14 },
                    { 15, new DateOnly(2025, 5, 15), true, "Familiebesøg", new DateOnly(2025, 5, 10), 15 },
                    { 16, new DateOnly(2025, 3, 18), false, "Sygdom", new DateOnly(2025, 3, 14), 16 },
                    { 17, new DateOnly(2025, 6, 28), true, "Fødselsdagsrejse", new DateOnly(2025, 6, 20), 17 },
                    { 18, new DateOnly(2025, 4, 7), true, "Påskeferie", new DateOnly(2025, 4, 1), 18 },
                    { 19, new DateOnly(2025, 2, 16), true, "Weekendtur", new DateOnly(2025, 2, 14), 19 },
                    { 20, new DateOnly(2025, 11, 5), true, "Efterårsferie", new DateOnly(2025, 11, 1), 20 },
                    { 21, new DateOnly(2025, 7, 25), true, "Sommerferie", new DateOnly(2025, 7, 20), 21 },
                    { 22, new DateOnly(2025, 1, 20), false, "Sygdom", new DateOnly(2025, 1, 15), 22 },
                    { 23, new DateOnly(2025, 9, 9), true, "Kursus", new DateOnly(2025, 9, 5), 23 },
                    { 24, new DateOnly(2026, 1, 1), true, "Juleferie", new DateOnly(2025, 12, 24), 24 },
                    { 25, new DateOnly(2025, 5, 3), true, "Weekendtur", new DateOnly(2025, 5, 1), 25 },
                    { 26, new DateOnly(2025, 3, 25), false, "Sygdom", new DateOnly(2025, 3, 21), 26 },
                    { 27, new DateOnly(2025, 6, 15), true, "Familieferie", new DateOnly(2025, 6, 10), 27 },
                    { 28, new DateOnly(2025, 4, 23), true, "Påskeferie", new DateOnly(2025, 4, 20), 28 },
                    { 29, new DateOnly(2025, 2, 9), true, "Skiferie", new DateOnly(2025, 2, 5), 29 },
                    { 30, new DateOnly(2025, 10, 20), true, "Efterårsferie", new DateOnly(2025, 10, 15), 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_UserId",
                table: "TimeEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
