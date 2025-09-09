using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FerieRegistreringBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class testv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ManagerComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DecidedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecidedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "Id", "DateOfBirth", "Email", "IsActive", "LastName", "Name", "Password", "Role", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateOnly(1995, 5, 12), "niklas@example.com", true, "Hansen", "Niklas", "AQAAAAIAAYagAAAAEGU2X5virsaYduePQ9+lqbYZy3hDiFecSruFm9GBw8fwuR8uHT6FnVkd64QxWm5Oag==", 1, null },
                    { 2, new DateOnly(1980, 5, 19), "frygtsommehund@example.com", true, "Hund", "Frygtløss", "AQAAAAIAAYagAAAAEONVbZUhQc+iw5Vv9mlJROEzGrpRTVpG94PD4H80KPcfKaTzbdEGPAeIYjiMZm4Kew==", 0, null },
                    { 3, new DateOnly(1956, 5, 12), "homer.simpson@springfield.com", true, "Simpson", "Homer", "AQAAAAIAAYagAAAAEB3b33zhR1mGF024RvqjCzA6m3mZGMvr2fQ6KIM1S8z45r4pSe+2VzaP1MWBYrYRoQ==", 0, null },
                    { 4, new DateOnly(1966, 7, 1), "peter.griffin@quahog.com", true, "Griffin", "Peter", "AQAAAAIAAYagAAAAEEYeI3t3mJ2wQlRJbXs0PeldLgFvaVny4PatWKgQoEpP8jl9EEfzBZ/lFjhAgwlY4A==", 1, null },
                    { 5, new DateOnly(1999, 5, 1), "patrick.star@bikinibottom.com", true, "Star", "Patrick", "AQAAAAIAAYagAAAAEMfA2QyJTuJy1L+AZWY3WHvgxEEExNFj7CFRbPZTbnOX97ZQ7RbKrSI1W/140sMp1A==", 0, null },
                    { 6, new DateOnly(2005, 3, 9), "lisa.simpson@springfield.com", true, "Simpson", "Lisa", "AQAAAAIAAYagAAAAEBq4cX1NDG4uyEs3v0zLQz3faR7805YcbnqYZ8yi5nRWNeabCGQ2+9XTeSrKu4y3Sw==", 0, null },
                    { 7, new DateOnly(1960, 10, 1), "marge.simpson@springfield.com", true, "Simpson", "Marge", "AQAAAAIAAYagAAAAEKw64HCi2M+fqGFzP+VfLWreW6g3OPuVr8hssx/Gy/fe7RIhQNy5wu+ayPkr662sYw==", 0, null },
                    { 8, new DateOnly(2018, 7, 14), "stewie.griffin@quahog.com", true, "Griffin", "Stewie", "AQAAAAIAAYagAAAAECapunPNxGxZLHEd2hsUWJBoy6ozXX5zQLHWurboNEo8s8zXxU6aPS+em7svVy28bQ==", 0, null },
                    { 9, new DateOnly(2010, 11, 2), "brian.griffin@quahog.com", true, "Griffin", "Brian", "AQAAAAIAAYagAAAAEIgXSlUCjkMotRgbuZvvwW3QXh08hMYkQ1J8oQBPFjxCBf9mMWdaOewk9h5zwsZARw==", 1, null },
                    { 10, new DateOnly(1990, 6, 18), "sandy.cheeks@bikinibottom.com", true, "Cheeks", "Sandy", "AQAAAAIAAYagAAAAENiA3s63t6slaJTdkdoUd8oSNDg1tK6R7PFmwGAMRUiqtDRmFFZFpjvNaCvGeZftqQ==", 0, null },
                    { 11, new DateOnly(1982, 4, 10), "squidward@bikinibottom.com", true, "Tentacles", "Squidward", "AQAAAAIAAYagAAAAEESegEzBC59RGKcd03Qk/RMU6hK4ZPwiyi/rXvwACm4m/0dg7+8rZ5ELn/TSL34OlQ==", 0, null },
                    { 12, new DateOnly(1970, 7, 5), "mr.krabs@bikinibottom.com", true, "Krabs", "Mr", "AQAAAAIAAYagAAAAEFZa4/5WUFT/PG1aeY5Q1uAHLLTo6GU8hWmgQJFp2gx2vgxcUGhF2YGxB2XcxIo/uQ==", 0, null },
                    { 13, new DateOnly(1972, 8, 22), "plankton@bikinibottom.com", true, "Plankton", "Sheldon", "AQAAAAIAAYagAAAAECVFibw/44MOsGebbFCuctc2n+fCP9FETQ4avq5jMlTGSLpV711N7RNPNthMJ9ybuQ==", 0, null },
                    { 14, new DateOnly(2007, 4, 1), "bart.simpson@springfield.com", true, "Simpson", "Bart", "AQAAAAIAAYagAAAAELD59XNBBA6Z+51strwBk9Rzavgz7w1s4v63w2WsyKkNEoGOBPK3v893kAC26lX6+w==", 0, null },
                    { 15, new DateOnly(2003, 8, 21), "meg.griffin@quahog.com", true, "Griffin", "Meg", "AQAAAAIAAYagAAAAEEIE2aXp6XsydbzdaAGNFPi+Hfs8qpTu/EQFnItKjxkFI6PVryD8Zrpnb2eviuEmLQ==", 0, null },
                    { 16, new DateOnly(1975, 3, 3), "lois.griffin@quahog.com", true, "Griffin", "Lois", "AQAAAAIAAYagAAAAEFWlXzM06yQuR/zJsWsFe9t5AMVRRiBTd1G9MLA/ttJM6gfXGsCsZkpDsnEM0s+Eaw==", 0, null },
                    { 17, new DateOnly(2001, 2, 12), "chris.griffin@quahog.com", true, "Griffin", "Chris", "AQAAAAIAAYagAAAAECkPn8ehCVRpkrQKmoRqBoEfXnPIrH+rbN6tCFn9fiah5oI3zkTDUMWzP3K3yY+OLQ==", 0, null },
                    { 18, new DateOnly(1965, 2, 9), "ned.flanders@springfield.com", true, "Flanders", "Ned", "AQAAAAIAAYagAAAAEIHjxhC6g/lrAbkjXRgVG9v0PzC+WEWpOAyjNmDe2TDq2pip+uzychOaWY2zkKtSqQ==", 0, null },
                    { 19, new DateOnly(1963, 11, 5), "moe.szyslak@springfield.com", true, "Szyslak", "Moe", "AQAAAAIAAYagAAAAEA67T2GRrhfhWyfDSjIl5pxEQ5vaUwbIs9ZYcu9EaVvtJmZ+7rZL7+B5l+/relxgmQ==", 0, null },
                    { 20, new DateOnly(1970, 4, 14), "carl.carlson@springfield.com", true, "Carlson", "Carl", "AQAAAAIAAYagAAAAEELMI+lVrTlrEAIx09FdBUsj4YBUXnziw8/FxsJ5xWVJeqfkcpn0LxTnDoyLrMlAMg==", 0, null },
                    { 21, new DateOnly(1970, 6, 6), "lenny.leonard@springfield.com", true, "Leonard", "Lenny", "AQAAAAIAAYagAAAAECRgejY0o9uxmD26n8tLjoMzk/VnKhB8BpaVc4WwfKaJ3RBkJesTYcwjKUS5sPAJyw==", 0, null },
                    { 22, new DateOnly(1930, 9, 15), "mr.burns@springfield.com", true, "Burns", "Mr", "AQAAAAIAAYagAAAAEEOP0C6ds6vuUtHrwQZjsNnPnz+QsJY/fIKkHU5KlquWV8IAJ9RWpqYrhf0MzxrcEA==", 1, null },
                    { 23, new DateOnly(1968, 7, 30), "smithers@springfield.com", true, "Smithers", "Waylon", "AQAAAAIAAYagAAAAEJhPgF+TObeNTJC8Ikb0fifsLzm4iPiGR11MV7wUcwzVnEd5olwvTSpJp15UIwZCwA==", 0, null },
                    { 24, new DateOnly(2012, 2, 14), "ralph.wiggum@springfield.com", true, "Wiggum", "Ralph", "AQAAAAIAAYagAAAAEPcGKr2pyMH7w45HDPHv7zyIq+KfBW5Y+NXA2AWY6yGTYBCn07WGkkhK7wJr5wDqaQ==", 0, null },
                    { 25, new DateOnly(1971, 12, 7), "apu@springfield.com", true, "Nahasapeemapetilon", "Apu", "AQAAAAIAAYagAAAAEGN/YF6zWYRu/Iq1WR85JXuk86sYw6WwjF1+NLGuV4ioW3uhtMq186foDASdmb0uIA==", 0, null },
                    { 26, new DateOnly(2006, 7, 1), "milhouse@springfield.com", true, "Van Houten", "Milhouse", "AQAAAAIAAYagAAAAEN/EaHftFQzqraUiItb1kY7p8I+tvXGwZkCZLV+uzjNWBWLHPkbOoEo6usCvS6RFKQ==", 0, null },
                    { 27, new DateOnly(1975, 1, 1), "comic.bookguy@springfield.com", true, "Book Guy", "Comic", "AQAAAAIAAYagAAAAEPEChHCilFfdDqJcbpVp3qcpW+kCESRYCrVJpuQlzyD0F+bIlhgUS1k2SUn5A1KMEA==", 0, null },
                    { 28, new DateOnly(1960, 11, 1), "edna.krabappel@springfield.com", true, "Krabappel", "Edna", "AQAAAAIAAYagAAAAELXaR1HGuqRlSt2jS93KQ0paIFvrN+dM8FHjKc2D9vUjyAPjxAhOiZPK3qWj+MWuzw==", 0, null },
                    { 29, new DateOnly(1961, 5, 30), "seymour.skinner@springfield.com", true, "Skinner", "Principal", "AQAAAAIAAYagAAAAEJ7NqlB0lhrY+Zr3Q4UixTlW3mgh8NFtGuYo088jhoOqzieaf4Vbtq9rc5PLfbURbg==", 0, null },
                    { 30, new DateOnly(1962, 6, 1), "willie@springfield.com", true, "Willie", "Groundskeeper", "AQAAAAIAAYagAAAAEDTHfRgKh2y8hLJwWHR5fp9O2kWZSimwqjUGFtQnQtSpEJgzC0bFAnsJ4kk3LS7wqw==", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_UserId",
                table: "Absences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_UserId",
                table: "TimeEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
