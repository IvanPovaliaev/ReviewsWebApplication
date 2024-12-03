using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reviews.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3170), 0.5, 1 },
                    { 2, new DateTime(2024, 9, 16, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3213), 2.2999999999999998, 2 },
                    { 3, new DateTime(2024, 11, 18, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3270), 2.0, 3 },
                    { 4, new DateTime(2024, 10, 29, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3284), 2.7799999999999998, 4 },
                    { 5, new DateTime(2024, 9, 18, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3298), 3.0, 5 },
                    { 6, new DateTime(2024, 9, 5, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3316), 3.29, 6 },
                    { 7, new DateTime(2024, 9, 5, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3331), 2.3300000000000001, 7 },
                    { 8, new DateTime(2024, 9, 11, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3340), 1.6699999999999999, 8 },
                    { 9, new DateTime(2024, 10, 17, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3355), 3.25, 9 },
                    { 10, new DateTime(2024, 10, 3, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(3369), 1.3799999999999999, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId", "RatingId", "Status", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 26, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1864), 1, 1, 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmo", 1 },
                    { 2, new DateTime(2024, 9, 24, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1889), 0, 1, 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, se", 7 },
                    { 3, new DateTime(2024, 9, 9, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1898), 0, 2, 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisici", 8 },
                    { 4, new DateTime(2024, 10, 2, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1907), 2, 2, 2, 1, "Lorem ipsum dolor sit amet, consectetur a", 2 },
                    { 5, new DateTime(2024, 10, 18, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1916), 5, 2, 2, 0, "Lorem ipsum dolor sit amet, conse", 1 },
                    { 6, new DateTime(2024, 11, 10, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1931), 1, 2, 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut la", 7 },
                    { 7, new DateTime(2024, 9, 11, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1944), 4, 2, 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor in", 7 },
                    { 8, new DateTime(2024, 11, 27, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1954), 1, 2, 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut ", 2 },
                    { 9, new DateTime(2024, 10, 17, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1964), 4, 2, 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ", 5 },
                    { 10, new DateTime(2024, 9, 27, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1982), 3, 2, 2, 1, "Lorem ipsum dolor sit amet, consectetur", 5 },
                    { 11, new DateTime(2024, 9, 14, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(1992), 1, 2, 2, 1, "Lorem ipsum dolor sit amet, consectet", 2 },
                    { 12, new DateTime(2024, 10, 8, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2001), 2, 2, 2, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor inc", 1 },
                    { 13, new DateTime(2024, 11, 2, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2011), 0, 3, 3, 1, "Lorem ipsum dolor sit amet, consectetu", 3 },
                    { 14, new DateTime(2024, 10, 19, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2020), 4, 3, 3, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ", 1 },
                    { 15, new DateTime(2024, 11, 16, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2067), 2, 4, 4, 0, "Lorem ipsum dolor sit amet, consectetur adip", 1 },
                    { 16, new DateTime(2024, 9, 16, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2077), 4, 4, 4, 0, "Lorem ipsum dolor sit a", 9 },
                    { 17, new DateTime(2024, 11, 7, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2086), 0, 4, 4, 1, "Lorem ipsum dolor sit amet, consectetur a", 9 },
                    { 18, new DateTime(2024, 10, 3, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2096), 3, 4, 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut la", 2 },
                    { 19, new DateTime(2024, 10, 3, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2105), 2, 4, 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tem", 9 },
                    { 20, new DateTime(2024, 11, 19, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2115), 0, 4, 4, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor in", 1 },
                    { 21, new DateTime(2024, 10, 20, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2125), 5, 4, 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor in", 4 },
                    { 22, new DateTime(2024, 11, 8, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2134), 5, 4, 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor ", 1 },
                    { 23, new DateTime(2024, 9, 18, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2144), 4, 4, 4, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididu", 9 },
                    { 24, new DateTime(2024, 9, 1, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2153), 3, 5, 5, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod", 8 },
                    { 25, new DateTime(2024, 9, 20, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2333), 4, 5, 5, 0, "Lorem ipsum dolor sit amet, consec", 7 },
                    { 26, new DateTime(2024, 11, 12, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2371), 3, 5, 5, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labo", 4 },
                    { 27, new DateTime(2024, 10, 26, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2385), 1, 5, 5, 2, "Lorem ipsum dolor sit amet, consectetur adipi", 4 },
                    { 28, new DateTime(2024, 11, 24, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2394), 2, 5, 5, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,", 6 },
                    { 29, new DateTime(2024, 11, 19, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2403), 3, 5, 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod ", 8 },
                    { 30, new DateTime(2024, 11, 4, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2413), 3, 5, 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor inc", 5 },
                    { 31, new DateTime(2024, 10, 23, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2436), 3, 5, 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labor", 4 },
                    { 32, new DateTime(2024, 11, 22, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2446), 5, 5, 5, 2, "Lorem ipsum dolor sit amet, conse", 1 },
                    { 33, new DateTime(2024, 10, 15, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2461), 2, 6, 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp", 5 },
                    { 34, new DateTime(2024, 9, 18, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2480), 4, 6, 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incid", 5 },
                    { 35, new DateTime(2024, 9, 4, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2489), 2, 6, 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisi", 5 },
                    { 36, new DateTime(2024, 9, 13, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2503), 5, 6, 6, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut", 9 },
                    { 37, new DateTime(2024, 10, 30, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2512), 5, 6, 6, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, s", 4 },
                    { 38, new DateTime(2024, 9, 3, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2522), 1, 6, 6, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, s", 8 },
                    { 39, new DateTime(2024, 8, 24, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2531), 4, 6, 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidi", 4 },
                    { 40, new DateTime(2024, 11, 2, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2541), 1, 7, 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ei", 2 },
                    { 41, new DateTime(2024, 11, 17, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2555), 4, 7, 7, 2, "Lorem ipsum dolor sit amet, consectetur a", 2 },
                    { 42, new DateTime(2024, 10, 19, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2565), 0, 7, 7, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod ", 2 },
                    { 43, new DateTime(2024, 9, 2, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2574), 3, 7, 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmo", 7 },
                    { 44, new DateTime(2024, 10, 17, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2583), 2, 7, 7, 1, "Lorem ipsum dolor sit amet, consec", 1 },
                    { 45, new DateTime(2024, 8, 27, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2593), 4, 7, 7, 1, "Lorem ipsum dolor sit amet, consectetur ", 2 },
                    { 46, new DateTime(2024, 10, 29, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2603), 3, 8, 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tem", 8 },
                    { 47, new DateTime(2024, 11, 28, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2612), 0, 8, 8, 1, "Lorem ipsum dolor sit amet, con", 9 },
                    { 48, new DateTime(2024, 11, 29, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2621), 2, 8, 8, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labo", 2 },
                    { 49, new DateTime(2024, 11, 17, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2693), 3, 9, 9, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed ", 8 },
                    { 50, new DateTime(2024, 10, 4, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2707), 5, 9, 9, 0, "Lorem ipsum dolor sit", 9 },
                    { 51, new DateTime(2024, 11, 26, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2716), 5, 9, 9, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do e", 5 },
                    { 52, new DateTime(2024, 9, 23, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2725), 0, 9, 9, 2, "Lorem ipsum dolor sit amet, cons", 3 },
                    { 53, new DateTime(2024, 10, 28, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2735), 2, 10, 10, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod te", 3 },
                    { 54, new DateTime(2024, 11, 7, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2744), 3, 10, 10, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt", 8 },
                    { 55, new DateTime(2024, 10, 7, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2753), 0, 10, 10, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut la", 9 },
                    { 56, new DateTime(2024, 10, 13, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2763), 3, 10, 10, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut la", 8 },
                    { 57, new DateTime(2024, 10, 22, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2773), 0, 10, 10, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod te", 6 },
                    { 58, new DateTime(2024, 10, 31, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2783), 2, 10, 10, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt", 9 },
                    { 59, new DateTime(2024, 9, 15, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2797), 1, 10, 10, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eius", 3 },
                    { 60, new DateTime(2024, 11, 11, 18, 29, 4, 938, DateTimeKind.Utc).AddTicks(2806), 0, 10, 10, 1, "Lorem ipsum dolor sit ", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RatingId",
                table: "Reviews",
                column: "RatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
