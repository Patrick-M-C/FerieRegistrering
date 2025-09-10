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
                table: "Teams",
                columns: new[] { "TeamId", "CreatedAtUtc", "Description", "IsActive", "LeaderUserId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 14, 51, 4, 301, DateTimeKind.Utc).AddTicks(6174), "The Springfield team", true, 1, "Springfield" },
                    { 2, new DateTime(2025, 9, 10, 14, 51, 4, 301, DateTimeKind.Utc).AddTicks(6179), "The Quahog team", true, 4, "Quahog" },
                    { 3, new DateTime(2025, 9, 10, 14, 51, 4, 301, DateTimeKind.Utc).AddTicks(6247), "The Bikini Bottom team", true, 5, "Bikini Bottom" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "IsActive", "LastName", "Name", "Password", "Role", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateOnly(1995, 5, 12), "niklas@example.com", true, "Hansen", "Niklas", "AQAAAAIAAYagAAAAEFaud54Hyvtkep5p2uHHuUXJB/+fHM1yIBONCJgc2Hpz0OwlnfBuds8EqL7eVDpZWg==", 1, null },
                    { 2, new DateOnly(1980, 5, 19), "frygtsommehund@example.com", true, "Hund", "Frygtløss", "AQAAAAIAAYagAAAAEMsaeL9m8WhE57l9D/h2AaQMVXpGxwDgc4TOiGZ8BklPz2HPBKS8CkCTD1eCRTKbqg==", 0, null },
                    { 6, new DateOnly(2005, 3, 9), "lisa.simpson@springfield.com", true, "Simpson", "Lisa", "AQAAAAIAAYagAAAAEBkRUi7DNHTEkKhyPXbf5RpUM7YAgVssuGuohHu1z+aeft9YfwcNMnPCEWMx6S7Exw==", 0, null },
                    { 15, new DateOnly(2003, 8, 21), "meg.griffin@quahog.com", true, "Griffin", "Meg", "AQAAAAIAAYagAAAAEOUH123hkpe5kNrbC3rjPHzLH96Kc2LIVfs5DwSvkQWOfUU3Bz1a4vgCbFClF+HccA==", 0, null },
                    { 17, new DateOnly(2001, 2, 12), "chris.griffin@quahog.com", true, "Griffin", "Chris", "AQAAAAIAAYagAAAAEB+iivApc3AoIsyjkprrsJzMRq6e2+J0ILu03/999Yw9S4+j3AjSAEls7kUCF2Qh3A==", 0, null },
                    { 18, new DateOnly(1965, 2, 9), "ned.flanders@springfield.com", true, "Flanders", "Ned", "AQAAAAIAAYagAAAAEEuFeIHIdm4rhhrQRmdYLm3LG1jsUDQn+g+j1+u8iArQchGH4FY899wexCLQRi9SVA==", 0, null },
                    { 19, new DateOnly(1963, 11, 5), "moe.szyslak@springfield.com", true, "Szyslak", "Moe", "AQAAAAIAAYagAAAAENWVb3jfA+2VD0hc8srTILQ3YETIzTCW6ptvsrE4eAucnALvxZ/yQBs1lxGbuBrTQw==", 0, null },
                    { 20, new DateOnly(1970, 4, 14), "carl.carlson@springfield.com", true, "Carlson", "Carl", "AQAAAAIAAYagAAAAEIPX2JR3pbtLWauHXbto9iwnWXBjwuyaZSf7JpqBOS7E5AOP52qP+p0PCqTLPrLf2g==", 0, null },
                    { 21, new DateOnly(1970, 6, 6), "lenny.leonard@springfield.com", true, "Leonard", "Lenny", "AQAAAAIAAYagAAAAEOP1XeH+IHYsmoFzbMUaIzU2Cybkjv8TUl+2II/7q/jys23NA56KUf211T8tzO6FyQ==", 0, null },
                    { 22, new DateOnly(1930, 9, 15), "mr.burns@springfield.com", true, "Burns", "Mr", "AQAAAAIAAYagAAAAEFHl6aRWw1DvYsekbtU+hdBeLjOuMJISKe+XoUmbwk5rh2XS+pjG/og65056uh9GEQ==", 1, null },
                    { 23, new DateOnly(1968, 7, 30), "smithers@springfield.com", true, "Smithers", "Waylon", "AQAAAAIAAYagAAAAEP/3/tFdJUjIL7rnB+ZdwgWthhOsw1j8RfQrKfN8v2neLl8oeo4OaUcWRouO8S9efg==", 0, null },
                    { 24, new DateOnly(2012, 2, 14), "ralph.wiggum@springfield.com", true, "Wiggum", "Ralph", "AQAAAAIAAYagAAAAEBliMOPllQv5aNwI/F04objYVV8mwApXJAFMh6OpHcq7uDeMsTTjZJVHLBn3uN9Umg==", 0, null },
                    { 25, new DateOnly(1971, 12, 7), "apu@springfield.com", true, "Nahasapeemapetilon", "Apu", "AQAAAAIAAYagAAAAEIfKTxCsBxJYeSe7qO0BbcQG83su2A6d9U9PamaRjjUmKqCA447aSqCqh1/SYqY22Q==", 0, null },
                    { 26, new DateOnly(2006, 7, 1), "milhouse@springfield.com", true, "Van Houten", "Milhouse", "AQAAAAIAAYagAAAAEP7ISTjKQc7y3oto2awu7Ebe2g5tl/wPS/YpUpxJjyjhvOLqYW41p6r+9JrF0OBJ/A==", 0, null },
                    { 27, new DateOnly(1975, 1, 1), "comic.bookguy@springfield.com", true, "Book Guy", "Comic", "AQAAAAIAAYagAAAAEJH7wmHm7McHtdAk/8lI3FpRMZkblkuDfZf71iP/R0yJBpt22qr+uCYDMT1jTn1yzg==", 0, null },
                    { 28, new DateOnly(1960, 11, 1), "edna.krabappel@springfield.com", true, "Krabappel", "Edna", "AQAAAAIAAYagAAAAELickf6Ol98vwSnlTJWKtmWFkP4U3ohJP7tjnJCLvz0H1N2U5QxCgTIol5fM7FXPdA==", 0, null },
                    { 29, new DateOnly(1961, 5, 30), "seymour.skinner@springfield.com", true, "Skinner", "Principal", "AQAAAAIAAYagAAAAEJ/Wr0PLhlNcwwrpPHvxe0uJGQDzoXQ0VsLCw+cFw+Xb9esH1QP4+ZUihwJi48h0NQ==", 0, null },
                    { 30, new DateOnly(1962, 6, 1), "willie@springfield.com", true, "Willie", "Groundskeeper", "AQAAAAIAAYagAAAAEGD1Pduxcg6Fi4tnQmVZM2mWYSonTOG+rvDMo2+2h1rRwMZwdYlZiiZw9aeAEBQJ8Q==", 0, null },
                    { 3, new DateOnly(1956, 5, 12), "homer.simpson@springfield.com", true, "Simpson", "Homer", "AQAAAAIAAYagAAAAEGtZuzq8q9I3oMwtfjs/V8RNuhoHiG9nFjT1vndbqkk3Zufsy2H6yZ3a1fv2dbb2Cg==", 1, 1 },
                    { 4, new DateOnly(1966, 7, 1), "peter.griffin@quahog.com", true, "Griffin", "Peter", "AQAAAAIAAYagAAAAEG6NMO7aX4Uv4cD8qYj4hiTYLINHorf6fmQziVdozpt1maJmibw5fRQTj396XxU2PQ==", 1, 2 },
                    { 5, new DateOnly(1999, 5, 1), "patrick.star@bikinibottom.com", true, "Star", "Patrick", "AQAAAAIAAYagAAAAELM674PItqQQO/pxOP0qh3V0k4z/5fEnPNl0/jvfKMaeed+fF5oHnzZJebHZ/BL7oQ==", 0, 3 },
                    { 7, new DateOnly(1960, 10, 1), "marge.simpson@springfield.com", true, "Simpson", "Marge", "AQAAAAIAAYagAAAAEDkkWdarHBa6iQhuvXmiUmv2TYq38RFac2us/bXve/A8DI3Ago4LDB3R+f3oniaUOQ==", 0, 1 },
                    { 8, new DateOnly(2018, 7, 14), "stewie.griffin@quahog.com", true, "Griffin", "Stewie", "AQAAAAIAAYagAAAAEKbu6C+J6AWO2I660871Fpg20vABXLRI8qlOmRjA2Qh+8fy/vW9vmDlQvc03aggRQQ==", 0, 2 },
                    { 9, new DateOnly(2010, 11, 2), "brian.griffin@quahog.com", true, "Griffin", "Brian", "AQAAAAIAAYagAAAAEN+7Bq1qGsmmi2sRSB+vpkvq1zOztGy7oApuwBhiroPk2b8XFY0KECF9fbIo7yNCpg==", 1, 2 },
                    { 10, new DateOnly(1990, 6, 18), "sandy.cheeks@bikinibottom.com", true, "Cheeks", "Sandy", "AQAAAAIAAYagAAAAEK8RSVyz05f0FqPW1mxB4eFZ7EfbKsK1/1qdX5XUc3NLo0m9gK9mSbe8HDrdbJ84Mw==", 0, 3 },
                    { 11, new DateOnly(1982, 4, 10), "squidward@bikinibottom.com", true, "Tentacles", "Squidward", "AQAAAAIAAYagAAAAEHXcyoPF1k3n1IA6xTEEExk5gOWOllah3tvOJdlPav+aoc82eZGWQ2p+Qn95kkvGgw==", 0, 3 },
                    { 12, new DateOnly(1970, 7, 5), "mr.krabs@bikinibottom.com", true, "Krabs", "Mr", "AQAAAAIAAYagAAAAEIf8eTDlmKtrb1HRtlS1CMEP1WhgTwzFB9FR/Iw9y9hrLHCM0pIGPsCura1SfLWovA==", 1, 3 },
                    { 13, new DateOnly(1972, 8, 22), "plankton@bikinibottom.com", true, "Plankton", "Sheldon", "AQAAAAIAAYagAAAAEPkseQGWfbShg+J2LAgkyD5BJpvJKojxPsayVFHHr3EHD0BmRhcq64dobTuYJ011ng==", 0, 3 },
                    { 14, new DateOnly(2007, 4, 1), "bart.simpson@springfield.com", true, "Simpson", "Bart", "AQAAAAIAAYagAAAAENapsashro3wrZRhASRVYKC76QDeYfceTpPkfZZlAMPyZwkoJ61s43mcEbAM+lQ+VQ==", 0, 1 },
                    { 16, new DateOnly(1975, 3, 3), "lois.griffin@quahog.com", true, "Griffin", "Lois", "AQAAAAIAAYagAAAAEFZuYT6CKN9XF+Ld/9o0Pe3VOBh/0PetpbmOAEjy1s9bRcK/ffjcyIlYafxziLLbDw==", 0, 2 }
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
