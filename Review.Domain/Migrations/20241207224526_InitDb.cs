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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                table: "Ratings",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9421), 2.7799999999999998, new Guid("1a0b4e57-f3a5-4431-ba0b-44f22d4445ad") },
                    { 2, new DateTime(2024, 9, 8, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9453), 1.1699999999999999, new Guid("6e81fd57-86d1-48d4-a67b-77deb3ca49fa") },
                    { 3, new DateTime(2024, 11, 29, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9492), 2.5, new Guid("36fbfacc-2eeb-4d5c-b59c-9a537d6555ce") },
                    { 4, new DateTime(2024, 10, 30, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9506), 1.5, new Guid("744c50db-51fa-4372-ae48-7af6a27a0f9f") },
                    { 5, new DateTime(2024, 10, 21, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9520), 2.5, new Guid("2de79e70-3efb-46ed-ad60-1038b9062ae1") },
                    { 6, new DateTime(2024, 9, 7, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9534), 3.3300000000000001, new Guid("0230702b-5ed8-49a6-8954-6f88c02fa56f") },
                    { 7, new DateTime(2024, 10, 10, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9543), 3.4399999999999999, new Guid("4bdc4182-b784-4239-a0be-f177f21322e8") },
                    { 8, new DateTime(2024, 11, 29, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9558), 1.8, new Guid("12cfda6b-c3f8-4ed8-9057-e62dbe5f7ee3") },
                    { 9, new DateTime(2024, 11, 16, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9572), 2.1699999999999999, new Guid("87eb8f90-6825-4e40-809e-5a1b5b70abe4") },
                    { 10, new DateTime(2024, 10, 21, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9587), 3.3300000000000001, new Guid("8517b8a9-3d54-4e5c-aba7-f955e241f399") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId", "RatingId", "Status", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 22, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(7935), 3, new Guid("1a0b4e57-f3a5-4431-ba0b-44f22d4445ad"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing ", "2e5f75cb-9551-47ec-a800-12fd0198ad55" },
                    { 2, new DateTime(2024, 10, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(7977), 4, new Guid("3cbe38ca-46e7-4c1a-9c24-ec92922a4ef1"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipis", "49fa8992-8e5b-406d-80be-5102c929760d" },
                    { 3, new DateTime(2024, 10, 7, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8001), 2, new Guid("66df5b5b-3862-4b03-a0bb-ff1a26609c9e"), 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut la", "9bd71a24-2335-49cd-8605-29019e401039" },
                    { 4, new DateTime(2024, 11, 8, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8030), 5, new Guid("e3f38cac-1536-421b-91f8-af004f69619a"), 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do e", "8e523598-e12b-4815-a5d5-a1fd8e1d1a18" },
                    { 5, new DateTime(2024, 9, 1, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8054), 2, new Guid("8ceecc51-142c-44f9-8f21-9658852a243a"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ", "cf19620b-d47c-4dd6-9822-c9c0a64da7d6" },
                    { 6, new DateTime(2024, 11, 10, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8077), 0, new Guid("75d5be46-561e-45f1-a598-9e454cda700b"), 1, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing eli", "1a72f978-1397-4ce3-8684-0cc1fbd9a19a" },
                    { 7, new DateTime(2024, 10, 31, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8096), 3, new Guid("693828f9-cfc0-4b93-b74b-c59ce0b1db55"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod t", "086a8c5c-fa3e-447e-8af4-c083577935b7" },
                    { 8, new DateTime(2024, 10, 17, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8115), 4, new Guid("14ec0fa5-c728-4dde-9dd5-6b256df3c899"), 1, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor inc", "a26d02bf-1204-44f1-9ab6-d90aedb852ce" },
                    { 9, new DateTime(2024, 9, 9, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8138), 2, new Guid("3674333e-9316-4f9f-a46f-dcb7205e35b3"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,", "96a4285e-1d56-490a-95c7-2a489bb2e756" },
                    { 10, new DateTime(2024, 11, 7, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8157), 2, new Guid("6e81fd57-86d1-48d4-a67b-77deb3ca49fa"), 2, 0, "Lorem ipsum dolor sit am", "7a51f572-797a-455c-8d20-2e0baa927672" },
                    { 11, new DateTime(2024, 9, 13, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8176), 2, new Guid("2fff7465-e35f-44e1-8949-1ae8e02560f5"), 2, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt u", "a53a5ead-388a-45c0-8125-974e1f2c701b" },
                    { 12, new DateTime(2024, 11, 13, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8200), 0, new Guid("8b1220a0-4535-40e5-aa31-5baf2489c1b1"), 2, 0, "Lorem ipsum dolor sit amet, consectetur adipis", "1d0aa7a3-489e-436d-9ab5-d3c7657ae3bb" },
                    { 13, new DateTime(2024, 11, 7, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8223), 1, new Guid("c800e2ec-49d0-48f8-bbb9-b1e90446a3de"), 2, 1, "Lorem ipsum dolor sit amet, ", "4c4261ef-00b2-4c14-a0d4-c87b1c48cf42" },
                    { 14, new DateTime(2024, 11, 29, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8242), 2, new Guid("c813e839-7bff-49ae-8d6b-6c935725f856"), 2, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing e", "a1fff49c-78e0-4731-8b93-ee0061d42458" },
                    { 15, new DateTime(2024, 10, 21, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8262), 0, new Guid("593cbb12-fa1b-4ce5-b6ce-a0917af5e38a"), 2, 1, "Lorem ipsum dolor sit amet, co", "4f7d04ad-48ae-4ded-9ee1-ec5c209ae3b6" },
                    { 16, new DateTime(2024, 10, 23, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8285), 0, new Guid("36fbfacc-2eeb-4d5c-b59c-9a537d6555ce"), 3, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed", "9fc60d83-a6ef-4232-9ee2-33c1a346ce42" },
                    { 17, new DateTime(2024, 9, 5, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8304), 1, new Guid("a1c600e4-8bec-42a5-a99b-19b70021f5fd"), 3, 2, "Lorem ipsum dolor sit am", "071778c3-b4b1-4142-84c6-6e1740a5dc9f" },
                    { 18, new DateTime(2024, 11, 17, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8323), 5, new Guid("fa2bfb7a-16f4-4dce-ac4f-7828e34a967f"), 3, 1, "Lorem ipsum dolor sit amet, conse", "ba562c04-22db-4219-ac87-e525c212f21c" },
                    { 19, new DateTime(2024, 10, 15, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8342), 5, new Guid("5bd54185-88ac-42a8-800f-521372c85628"), 3, 1, "Lorem ipsum dolor sit amet", "c426e9d6-e2c2-410c-8ba6-9a910e1c1bcf" },
                    { 20, new DateTime(2024, 11, 8, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8366), 0, new Guid("511a890d-cb87-4cfc-9006-0a3e2cf66454"), 3, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt", "ad4e5fc8-7c13-4998-becb-1b4a2cdf640b" },
                    { 21, new DateTime(2024, 10, 28, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8408), 1, new Guid("1c2e1586-44ab-4677-baff-3d268d443462"), 3, 0, "Lorem ipsum dolor sit amet, consectetur adipi", "83b3e6c8-8ecd-4828-bef5-a1574bd802d4" },
                    { 22, new DateTime(2024, 10, 19, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8432), 5, new Guid("987416cf-0c31-445b-81f9-65e4c0c750ad"), 3, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing eli", "d008fc18-0b2c-459c-90c3-6b49ce7b3a59" },
                    { 23, new DateTime(2024, 11, 25, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8451), 2, new Guid("9909757d-1273-44ca-b995-43be4202035e"), 3, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod te", "5dfd6195-4c58-4df9-b092-418975e27e4b" },
                    { 24, new DateTime(2024, 11, 5, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8470), 1, new Guid("e71199e9-28d1-4a68-8f4a-3fa8f1086587"), 3, 2, "Lorem ipsum dolor sit amet,", "411ac3c0-d9a8-4f03-9882-271e34272fa8" },
                    { 25, new DateTime(2024, 9, 27, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8489), 5, new Guid("4e70dbf6-d01b-4b6b-8284-4d48e6bda37b"), 3, 2, "Lorem ipsum dolor sit amet,", "8b1e6299-3a06-4c97-a5fb-ab699a07cac9" },
                    { 26, new DateTime(2024, 10, 24, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8513), 0, new Guid("744c50db-51fa-4372-ae48-7af6a27a0f9f"), 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor ", "c2786dc9-35a4-4706-ab9f-b1857fb53666" },
                    { 27, new DateTime(2024, 10, 18, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8531), 2, new Guid("aced3166-6aa9-4609-a20d-1237903feeb2"), 4, 0, "Lorem ipsum dolor sit amet, consectetur adipi", "19f28431-b557-4d5d-a3ba-eaebc0fbcb0b" },
                    { 28, new DateTime(2024, 11, 1, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8550), 0, new Guid("c1fa525c-4e6a-4392-81ae-78e135cdd626"), 4, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,", "1c1c794f-f753-4e3c-97ff-de7c15915a06" },
                    { 29, new DateTime(2024, 11, 23, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8573), 2, new Guid("d70fcbca-01d4-4a9d-b1da-a0997ba4bc38"), 4, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt u", "d359e49c-038b-4e88-a4a8-52f0b482a29b" },
                    { 30, new DateTime(2024, 9, 20, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8593), 3, new Guid("462c8628-ecc6-45b0-a7c4-807d0e48c7fe"), 4, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing", "9fbbabc2-92f0-4891-9815-90fd490d10c4" },
                    { 31, new DateTime(2024, 9, 9, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8612), 2, new Guid("167dacd7-8397-46d1-9f20-dc5b5105cfe6"), 4, 2, "Lorem ipsum dolor sit amet, consectetur adip", "106300c6-21d5-49fa-8553-a57fbec7657c" },
                    { 32, new DateTime(2024, 11, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8635), 3, new Guid("2de79e70-3efb-46ed-ad60-1038b9062ae1"), 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed ", "67e8284e-388f-40af-854a-e30f32df80db" },
                    { 33, new DateTime(2024, 12, 5, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8654), 2, new Guid("74a0af35-a8e2-4724-b7ba-92f3619cc476"), 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempo", "9428fcb9-6242-4681-82db-5193a1c845dc" },
                    { 34, new DateTime(2024, 11, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8673), 1, new Guid("0230702b-5ed8-49a6-8954-6f88c02fa56f"), 6, 2, "Lorem ipsum dolor sit amet", "25df5d26-3ee8-453e-8a71-012cea720b4e" },
                    { 35, new DateTime(2024, 10, 16, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8692), 4, new Guid("af904661-bbca-499a-9f1f-c8067ba5bfda"), 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidi", "425d873a-80b7-4176-91f2-b17fd4539c88" },
                    { 36, new DateTime(2024, 10, 5, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8716), 5, new Guid("e7ea66d0-ba02-4a16-ac15-0efa06f570f0"), 6, 0, "Lorem ipsum dolor sit amet, c", "4688b5e0-93aa-4260-84a1-1bd1ac3b9ddb" },
                    { 37, new DateTime(2024, 10, 19, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8735), 3, new Guid("4bdc4182-b784-4239-a0be-f177f21322e8"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do", "f85870ec-1d84-4dff-82fe-fd96de07c437" },
                    { 38, new DateTime(2024, 9, 3, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8753), 5, new Guid("bb8b7564-5817-4413-a74d-6a80e430f05b"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed d", "6ff15237-0d66-4dfa-b7da-b49acf45be24" },
                    { 39, new DateTime(2024, 12, 2, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8773), 4, new Guid("173c7222-b086-4932-b955-2ab68d2e8ed4"), 7, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed d", "cd469971-0140-403d-9e5d-e47b81be2f6c" },
                    { 40, new DateTime(2024, 10, 14, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8796), 2, new Guid("5dfb16df-3b1c-411d-af35-be02d350eb43"), 7, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, s", "ef83c56f-83a6-4040-b560-7b3a4ecc4a45" },
                    { 41, new DateTime(2024, 10, 23, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8815), 3, new Guid("ade6af9a-315f-4531-8f9e-49a6250e9b0c"), 7, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod", "fca49997-df39-473e-b6f1-b92f577684bd" },
                    { 42, new DateTime(2024, 10, 1, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8834), 2, new Guid("c92c2d99-fba7-40ee-bcd7-2f9c6758aa96"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun", "c0f48eaf-2a75-4b3c-b7b1-21f0b726d005" },
                    { 43, new DateTime(2024, 10, 9, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8853), 5, new Guid("6d94b582-8d1e-4250-bdf3-24ef68be77e0"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i", "aee4d564-7eb5-40e3-8d9d-b4c87eadeb10" },
                    { 44, new DateTime(2024, 11, 21, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8876), 4, new Guid("51e87650-7cda-4770-98fb-f8deaf502f66"), 7, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing el", "7c7fc9fa-c2dc-492c-8b9c-a35686872a82" },
                    { 45, new DateTime(2024, 9, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8895), 3, new Guid("80073931-6070-44b0-8f48-188eb359146a"), 7, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing eli", "21f187d1-fa27-4c40-b9ce-b3f97978e5ec" },
                    { 46, new DateTime(2024, 10, 23, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8920), 3, new Guid("12cfda6b-c3f8-4ed8-9057-e62dbe5f7ee3"), 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp", "06425404-226b-406c-89f0-10aace2dfdc7" },
                    { 47, new DateTime(2024, 8, 31, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8938), 2, new Guid("a3d1ae5f-6df7-48ee-be47-2dd9bcb8c7fb"), 8, 2, "Lorem ipsum dolor sit amet,", "a2bb9451-2013-4409-979d-b617fcf8b466" },
                    { 48, new DateTime(2024, 9, 7, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8957), 3, new Guid("8161da29-5345-413c-8f29-4a59dd309483"), 8, 1, "Lorem ipsum dolor sit amet, consectetur adipisic", "8a587f49-f071-4bc0-a538-6b9501c989e6" },
                    { 49, new DateTime(2024, 9, 8, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(8980), 1, new Guid("b71f10e6-d1b8-4280-a327-93571c01aa7b"), 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisic", "30a7014f-e6f1-430c-a90d-4fdf446b419c" },
                    { 50, new DateTime(2024, 10, 17, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9000), 0, new Guid("7214d8ae-fb2a-4f55-9203-4c108da3caf0"), 8, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, ", "53bdbe8d-015b-48f7-affc-45cfc6f3a507" },
                    { 51, new DateTime(2024, 11, 10, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9019), 3, new Guid("87eb8f90-6825-4e40-809e-5a1b5b70abe4"), 9, 2, "Lorem ipsum dolor sit amet, c", "ceb10535-9af7-43f2-ace1-a0f17e0b2bdf" },
                    { 52, new DateTime(2024, 9, 8, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9095), 2, new Guid("22764704-3a80-4291-8814-4eff46934840"), 9, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed", "3751c8f5-b5b4-42aa-8b6b-2271c18963b6" },
                    { 53, new DateTime(2024, 9, 28, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9118), 5, new Guid("bb9d0073-ea5b-40fa-a109-108ef698342f"), 9, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod te", "0e340fba-78d5-4eae-a9da-0c50cbc0f44b" },
                    { 54, new DateTime(2024, 9, 20, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9137), 2, new Guid("da0b9fcc-4571-49e0-82c0-6c82ce4c0ae3"), 9, 2, "Lorem ipsum dolor sit a", "abb35341-7195-46d6-83cf-82de1d200df4" },
                    { 55, new DateTime(2024, 9, 13, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9156), 0, new Guid("9127723d-f387-497a-9dd4-ae8cb2e19171"), 9, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed ", "eb92cd1a-5276-4fcb-80f4-5bfa985d951a" },
                    { 56, new DateTime(2024, 10, 6, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9179), 1, new Guid("67ce374c-a619-446d-9676-6a1c77bee0ef"), 9, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod te", "7b7855be-d808-45e0-b9d4-076fd9841ee2" },
                    { 57, new DateTime(2024, 9, 25, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9198), 4, new Guid("8517b8a9-3d54-4e5c-aba7-f955e241f399"), 10, 1, "Lorem ipsum dolor sit amet, consectetur", "b845a5de-7863-41e4-9570-13dbc276bd85" },
                    { 58, new DateTime(2024, 9, 4, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9217), 4, new Guid("89954212-b525-4ec9-bd0b-515d538fe2c8"), 10, 1, "Lorem ipsum dolor sit amet, consectetur adi", "53121b7a-b468-4e0e-8b89-560e4c30452a" },
                    { 59, new DateTime(2024, 9, 11, 22, 45, 25, 814, DateTimeKind.Utc).AddTicks(9236), 2, new Guid("3eb39790-4e7f-4b97-80d5-29617790a904"), 10, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor ", "11d358b6-e907-4637-a68a-6c8dd800f659" }
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
