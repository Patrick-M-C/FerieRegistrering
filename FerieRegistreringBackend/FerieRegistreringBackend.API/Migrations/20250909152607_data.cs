using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FerieRegistreringBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
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
                    { 1, new DateOnly(1995, 5, 12), "niklas@example.com", true, "Hansen", "Niklas", "AQAAAAIAAYagAAAAEBFGP99GHeOFv1RbqNRhPVZh1EDPFIKdnyBcTZE2YfkqttQJZPBZc8j/E8QLTIe46w==", 1, null },
                    { 2, new DateOnly(1980, 5, 19), "frygtsommehund@example.com", true, "Hund", "Frygtløss", "AQAAAAIAAYagAAAAECiNbPyRpeF6AMcwqbwQHRE4+dEyMwUFwo8Ws8M9CibXWX9E6+CYqfRVeJgxkrlbkQ==", 0, null },
                    { 3, new DateOnly(1956, 5, 12), "homer.simpson@springfield.com", true, "Simpson", "Homer", "AQAAAAIAAYagAAAAEHD+Iu5kZXJZFNZQvpV/3Xfqu4i7WH9dpM9lrAUD/X+lfVDVVeg9xIkKR5rvSl1ZPw==", 0, null },
                    { 4, new DateOnly(1966, 7, 1), "peter.griffin@quahog.com", true, "Griffin", "Peter", "AQAAAAIAAYagAAAAEJ0uGyidMTTv2xM3V9dF8RQ6ENdjxiufIOc6h+1bJnMRZSq+fAaO5IhnpUo7LmGLmQ==", 1, null },
                    { 5, new DateOnly(1999, 5, 1), "patrick.star@bikinibottom.com", true, "Star", "Patrick", "AQAAAAIAAYagAAAAENL75a4YAqu9+MYp0RwEnUepRt7M0RNLnPGTRc5KenmlUf7mTQv6jAX9yYiMevwBsQ==", 0, null },
                    { 6, new DateOnly(2005, 3, 9), "lisa.simpson@springfield.com", true, "Simpson", "Lisa", "AQAAAAIAAYagAAAAEHzRZWhLgmfo8LdmmBTzetq6vn6AQX85O0+hJvzFVshY6fMv41iozGTH9tGwN2VaVQ==", 0, null },
                    { 7, new DateOnly(1960, 10, 1), "marge.simpson@springfield.com", true, "Simpson", "Marge", "AQAAAAIAAYagAAAAEM/Nhf7/UgD9do3tI7xTK0ejegPA0vKK1HHz8qmkb3pupqlJ6PR/w3gEwbXXOTHJjg==", 0, null },
                    { 8, new DateOnly(2018, 7, 14), "stewie.griffin@quahog.com", true, "Griffin", "Stewie", "AQAAAAIAAYagAAAAEKH0GMuorOP3SeWcaBJH2cvDhuIzYL+Qf9i8HJll7tw8iICqs8BpgHG0QTfr4yy2Ow==", 0, null },
                    { 9, new DateOnly(2010, 11, 2), "brian.griffin@quahog.com", true, "Griffin", "Brian", "AQAAAAIAAYagAAAAEGiGumEqdtfEcqzM60SFXeVHpdPj3vhCC4cKawaYysM+CBX21FXPktLGFQduKTjInQ==", 1, null },
                    { 10, new DateOnly(1990, 6, 18), "sandy.cheeks@bikinibottom.com", true, "Cheeks", "Sandy", "AQAAAAIAAYagAAAAEISzNeLOu7H63JPstwI4oge/s1PXuYF/m3o0UdpG+1ZR28lXUl050lRdeyn10K31ow==", 0, null },
                    { 11, new DateOnly(1982, 4, 10), "squidward@bikinibottom.com", true, "Tentacles", "Squidward", "AQAAAAIAAYagAAAAEPHVWGQ3agIzCw/VkuFKNSC6MJc/PJd1fPrCOu4phvJvjsxxofBz7KnQvsYhOBwFpg==", 0, null },
                    { 12, new DateOnly(1970, 7, 5), "mr.krabs@bikinibottom.com", true, "Krabs", "Mr", "AQAAAAIAAYagAAAAECMh9VhVuMCSCZRZhESrchVvspRau+lyHR8CEMP7SwYzlcoc/bngd/Zeq27HWjB+eg==", 0, null },
                    { 13, new DateOnly(1972, 8, 22), "plankton@bikinibottom.com", true, "Plankton", "Sheldon", "AQAAAAIAAYagAAAAECgy5cYeZdOZ69AepbaRxI6VjhCrbGOnJUGgt8EUTcD9fL6eTbeJixeOuUYex8J4+g==", 0, null },
                    { 14, new DateOnly(2007, 4, 1), "bart.simpson@springfield.com", true, "Simpson", "Bart", "AQAAAAIAAYagAAAAEGweDVa90wqzUX06Uk0KiBh23ircw15os8AGhvBdlohb9Es4iOdCTrqhmSuFYvxfag==", 0, null },
                    { 15, new DateOnly(2003, 8, 21), "meg.griffin@quahog.com", true, "Griffin", "Meg", "AQAAAAIAAYagAAAAEBLgwDod2048GGwddpF67tOXmJzzX3jibQYDWdg+QfAIHmRMv6zJzNbHKN90E72bIw==", 0, null },
                    { 16, new DateOnly(1975, 3, 3), "lois.griffin@quahog.com", true, "Griffin", "Lois", "AQAAAAIAAYagAAAAEOjzd2o/q2ETPNzTagShgVIY5t7LbaSxxHP22KCIxL9zPp2QZKgG4j50NWck3RtUwg==", 0, null },
                    { 17, new DateOnly(2001, 2, 12), "chris.griffin@quahog.com", true, "Griffin", "Chris", "AQAAAAIAAYagAAAAEBd2i6pTU89vg2pogW7JiD1GxUgatfXyctAmCsa0j9wrG5IlF2D+KOWAHO5M/znFbQ==", 0, null },
                    { 18, new DateOnly(1965, 2, 9), "ned.flanders@springfield.com", true, "Flanders", "Ned", "AQAAAAIAAYagAAAAEMpoQrLdbMaTpF3JuxN4EzAkaoiMZ2JjFQHpoALHXQOlG8LmmML/s1L+6s8wwlBj3w==", 0, null },
                    { 19, new DateOnly(1963, 11, 5), "moe.szyslak@springfield.com", true, "Szyslak", "Moe", "AQAAAAIAAYagAAAAELAt3LNVCU2ZbsMRZb61y1+c6hkJkswl+o8SL0xWZ2mXXQIQ34o4/XKg6qh0hVg2+w==", 0, null },
                    { 20, new DateOnly(1970, 4, 14), "carl.carlson@springfield.com", true, "Carlson", "Carl", "AQAAAAIAAYagAAAAEFZ1Jsrzr6gfI9X+OdaAWZbC041eSfmY0A/DwNhFPl39Y7ebRf16PeRLwSs4/vCTQQ==", 0, null },
                    { 21, new DateOnly(1970, 6, 6), "lenny.leonard@springfield.com", true, "Leonard", "Lenny", "AQAAAAIAAYagAAAAEMLQr68QsLjM/6hfETQ9lJ+Yv59r/Q/VfL3d3K9oj4YHKAc5vjy0kDSHY5MNwK54mA==", 0, null },
                    { 22, new DateOnly(1930, 9, 15), "mr.burns@springfield.com", true, "Burns", "Mr", "AQAAAAIAAYagAAAAEEbwXy5Xt0iMHW2iEiuDUhVmaKNoynOF9By36FS/1k9TGZt0YibXV2iPBiLJ51uEfQ==", 1, null },
                    { 23, new DateOnly(1968, 7, 30), "smithers@springfield.com", true, "Smithers", "Waylon", "AQAAAAIAAYagAAAAENbG6uuasqx5LowoxcwBggcjChwrqGcHPDvkzICs9TQn4G5Wb0MvwCrrM4kXBEyC6g==", 0, null },
                    { 24, new DateOnly(2012, 2, 14), "ralph.wiggum@springfield.com", true, "Wiggum", "Ralph", "AQAAAAIAAYagAAAAEBUkhqIkBcoWHsg1Fv2j1BHLpZei9nheUJ4gHQJpT9LzA0dnNM+BGxgeKtSTobdb0A==", 0, null },
                    { 25, new DateOnly(1971, 12, 7), "apu@springfield.com", true, "Nahasapeemapetilon", "Apu", "AQAAAAIAAYagAAAAECFbc0WTYflUnjLxVu3FBNubPm1wE2nOK3PUPvYz5JKK9z/1sAkSInkwzUP4HuxekA==", 0, null },
                    { 26, new DateOnly(2006, 7, 1), "milhouse@springfield.com", true, "Van Houten", "Milhouse", "AQAAAAIAAYagAAAAENUsPfVEbp/L2caUKowVTxhBW8XE0CY6/M2TJJqThtrBgnvD4xxJMZ2Mn+NxYfGTHQ==", 0, null },
                    { 27, new DateOnly(1975, 1, 1), "comic.bookguy@springfield.com", true, "Book Guy", "Comic", "AQAAAAIAAYagAAAAECZqcUSH4yvQ2K5SZqFlkfyLlhVo0e3JASKTAN38DOKP9mj3EHtEmuFVVW2ulwTWoQ==", 0, null },
                    { 28, new DateOnly(1960, 11, 1), "edna.krabappel@springfield.com", true, "Krabappel", "Edna", "AQAAAAIAAYagAAAAECbxXTOd07IZXYJ8IZdGx5ty355VRn8cJSA4pBlzcXdsWKOukusJvIcOtXMpFjBDcw==", 0, null },
                    { 29, new DateOnly(1961, 5, 30), "seymour.skinner@springfield.com", true, "Skinner", "Principal", "AQAAAAIAAYagAAAAEKOZMCMy1ToUqdYzW1arFzioWoMbr6WXG2hka2csLhdqYt70IAW2lQv6z5uv7vsdGA==", 0, null },
                    { 30, new DateOnly(1962, 6, 1), "willie@springfield.com", true, "Willie", "Groundskeeper", "AQAAAAIAAYagAAAAEJKCBHX5XtbVtb33fVoW2omElYtVEcSXzrdvd/RLr/AiTHQNrWD3h+1AVYKbJ9Ew7g==", 0, null }
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
