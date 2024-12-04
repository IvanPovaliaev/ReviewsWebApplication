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
                table: "Logins",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 3, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8055), 2.0, new Guid("99ed296b-8842-42c5-b426-a94374a74136") },
                    { 2, new DateTime(2024, 10, 9, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8088), 3.0, new Guid("337f6d24-7f2e-47e1-8bbb-544c35716610") },
                    { 3, new DateTime(2024, 11, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8107), 4.0, new Guid("534c9309-f5ea-412a-a859-b2c5e67d22d3") },
                    { 4, new DateTime(2024, 10, 27, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8117), 5.0, new Guid("7810de42-0d84-41a0-b0da-e35b762976cb") },
                    { 5, new DateTime(2024, 10, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8131), 3.3999999999999999, new Guid("9dd2814e-fd38-4e98-8dfd-a169381b6efd") },
                    { 6, new DateTime(2024, 9, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8173), 2.6699999999999999, new Guid("e131f5a9-fe96-4e6a-8124-520056ba2060") },
                    { 7, new DateTime(2024, 11, 5, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8187), 2.1400000000000001, new Guid("2e9d973e-efd2-41f2-9e8d-56a84350d64d") },
                    { 8, new DateTime(2024, 11, 14, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8202), 3.2999999999999998, new Guid("a8a072b7-45cf-496b-89a0-ab2373076e00") },
                    { 9, new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8217), 4.0, new Guid("619238df-47bb-470c-9b64-10b4adc66733") },
                    { 10, new DateTime(2024, 10, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(8231), 1.0, new Guid("82faf50d-e506-4a71-94c6-ef72c81c2cd6") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreationDate", "Grade", "ProductId", "RatingId", "Status", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(6952), 5, new Guid("99ed296b-8842-42c5-b426-a94374a74136"), 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiu", "c0003160-e627-408b-9a05-f8d7f9e3e494" },
                    { 2, new DateTime(2024, 10, 31, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(6996), 0, new Guid("b408c25f-2ac0-4783-b2f6-9381d49920ad"), 1, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ei", "8874d691-d16b-4827-8fd4-09b2010a31e3" },
                    { 3, new DateTime(2024, 11, 27, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7015), 1, new Guid("b6a5a3df-198a-452f-ac60-7e8c3004e317"), 1, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut", "47e19264-71a5-4082-8857-6ec4f33ce033" },
                    { 4, new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7038), 4, new Guid("337f6d24-7f2e-47e1-8bbb-544c35716610"), 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing el", "5415b954-88d9-42c4-86e4-71d4e8890c40" },
                    { 5, new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7113), 2, new Guid("e1c477e9-9fd5-4186-80ec-fc8989d0b498"), 2, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed", "4d263476-137c-409f-9264-2a84491cb4ae" },
                    { 6, new DateTime(2024, 9, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7137), 4, new Guid("534c9309-f5ea-412a-a859-b2c5e67d22d3"), 3, 1, "Lorem ipsum dolor sit am", "b7a8b2a5-c95f-4ff5-829c-a002f6dc76db" },
                    { 7, new DateTime(2024, 11, 17, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7156), 5, new Guid("7810de42-0d84-41a0-b0da-e35b762976cb"), 4, 1, "Lorem ipsum dolor sit amet, consectetur adi", "c9fa7dbb-e6f1-495b-a5f2-18da36699df4" },
                    { 8, new DateTime(2024, 11, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7180), 4, new Guid("9dd2814e-fd38-4e98-8dfd-a169381b6efd"), 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiu", "ddb2af6c-d8cb-403f-84e3-61774da4cb35" },
                    { 9, new DateTime(2024, 10, 20, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7198), 3, new Guid("0f97a69a-78ad-4410-811c-18b9810546ca"), 5, 0, "Lorem ipsum dolor sit amet, cons", "16f8c9a4-4db8-4ea4-afcf-685f9b04a22e" },
                    { 10, new DateTime(2024, 11, 12, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7222), 3, new Guid("262f1831-cc72-430a-ae59-4a669969ed7b"), 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing", "8148a282-282b-47f6-8f91-9b39c5164fbe" },
                    { 11, new DateTime(2024, 9, 3, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7242), 4, new Guid("c6dbfe7f-91b5-4bcf-93b7-ba3155f61dca"), 5, 1, "Lorem ipsum dolor sit amet, c", "01d31bf3-ee27-43ff-afab-9509e8db1379" },
                    { 12, new DateTime(2024, 10, 29, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7260), 3, new Guid("3900c019-617e-4903-bb21-a31fefb2defe"), 5, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,", "81bc8d48-5325-4e15-ba85-a882b44af87a" },
                    { 13, new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7284), 4, new Guid("e131f5a9-fe96-4e6a-8124-520056ba2060"), 6, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing eli", "3012882b-354a-4306-9f20-ec2f3f55922e" },
                    { 14, new DateTime(2024, 9, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7303), 3, new Guid("983c1d4e-0bf3-4070-bd5f-9e1273f9ca6a"), 6, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing", "b0f08e90-3918-4856-80ed-04206eccb912" },
                    { 15, new DateTime(2024, 9, 26, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7323), 1, new Guid("b141f699-6cc4-49b2-9982-49d07d9cbd52"), 6, 2, "Lorem ipsum dolor sit amet,", "a9d00c3e-6ccb-40cf-b626-9f4a669695d2" },
                    { 16, new DateTime(2024, 9, 7, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7341), 5, new Guid("2e9d973e-efd2-41f2-9e8d-56a84350d64d"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ei", "12c57af2-065e-4795-bd9a-78c5edd23f2a" },
                    { 17, new DateTime(2024, 9, 21, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7365), 1, new Guid("af0e199c-0535-47a9-a93a-9f0b16baf59b"), 7, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ", "908e36d6-748c-4210-b174-b0f3ab6626d2" },
                    { 18, new DateTime(2024, 11, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7383), 4, new Guid("b09728c0-e44a-4e3c-b9d7-fcdca97e8e2b"), 7, 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i", "bcd47fa8-71e9-4a72-aed6-a4a8880ee309" },
                    { 19, new DateTime(2024, 9, 6, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7408), 1, new Guid("66c430ed-09e6-4535-aca2-67f9c9c0a614"), 7, 1, "Lorem ipsum dolor sit a", "77c14ff2-1827-40b6-aa23-bd565be3d323" },
                    { 20, new DateTime(2024, 9, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7426), 4, new Guid("1e781af9-250c-4b85-b2bc-a4dbb1d44a40"), 7, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit,", "67e9e89f-affa-42fa-9709-8bc800005672" },
                    { 21, new DateTime(2024, 11, 21, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7450), 0, new Guid("d33479bb-3aa5-4957-8315-b58243608acd"), 7, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp", "ec9f6377-218c-4904-8ce0-720eca77f243" },
                    { 22, new DateTime(2024, 11, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7469), 0, new Guid("b78f2641-3616-431c-b83a-f9d4b96cc34e"), 7, 1, "Lorem ipsum dolor sit amet, consectetur", "de36b4f2-7380-4dd2-b41b-d393c64f4ee8" },
                    { 23, new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7488), 2, new Guid("a8a072b7-45cf-496b-89a0-ab2373076e00"), 8, 0, "Lorem ipsum dolor sit amet, consect", "e38b030c-b87f-44c6-a6e4-c70d51ab7387" },
                    { 24, new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7507), 5, new Guid("9c12b47f-1ec0-432c-9ade-1e9ee4e4b234"), 8, 1, "Lorem ipsum dolor sit amet, cons", "03dc5f0a-9eb3-415a-8f09-968faf093fa2" },
                    { 25, new DateTime(2024, 10, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7530), 5, new Guid("cc7db11f-a52e-4386-aa2a-28f565286775"), 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisic", "1af7dc8e-34c7-413c-8e1b-be9067933290" },
                    { 26, new DateTime(2024, 9, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7549), 4, new Guid("380106dc-3aff-4b00-a221-fb321c33684e"), 8, 2, "Lorem ipsum dolor sit amet, consectet", "f833c8b9-adad-456b-a639-a20e93794ee1" },
                    { 27, new DateTime(2024, 10, 12, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7568), 1, new Guid("a5c2d3a9-2cf5-4391-a920-5e7d6c7603c5"), 8, 2, "Lorem ipsum dolor sit amet, ", "eb185533-b1c7-418f-91f5-90f0f2dac655" },
                    { 28, new DateTime(2024, 10, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7587), 3, new Guid("e557fa60-1767-4357-a267-6d8c898fed13"), 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incidi", "1cd8314e-8c8f-4168-8efb-02657de58fee" },
                    { 29, new DateTime(2024, 10, 11, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7615), 5, new Guid("a1549e4e-ca85-4fa0-a6fb-c225f752718a"), 8, 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, ", "3742c2d1-d743-4496-837e-1e3eb3b4d5d5" },
                    { 30, new DateTime(2024, 10, 1, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7634), 2, new Guid("233e07c3-8c91-4ed1-8ee1-3bd85aa83777"), 8, 0, "Lorem ipsum dolor sit ame", "5ca7b7b0-8822-49e8-bd84-6fa2411a4e61" },
                    { 31, new DateTime(2024, 9, 18, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7686), 1, new Guid("05fe73da-6ae1-452a-a911-1250290bf45f"), 8, 0, "Lorem ipsum dolor sit amet, conse", "6352e190-0dca-4565-aad2-7df2c0368e93" },
                    { 32, new DateTime(2024, 11, 15, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7710), 5, new Guid("163662b1-22ef-4a8c-866d-edc509325405"), 8, 1, "Lorem ipsum dolor sit amet, con", "de9c2f89-ff43-4452-9b90-89ebca3d0529" },
                    { 33, new DateTime(2024, 11, 8, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7729), 4, new Guid("619238df-47bb-470c-9b64-10b4adc66733"), 9, 1, "Lorem ipsum dolor sit amet, consectetur adipis", "1e40677d-8709-4491-be72-7f0014e37adf" },
                    { 34, new DateTime(2024, 9, 11, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7753), 2, new Guid("82faf50d-e506-4a71-94c6-ef72c81c2cd6"), 10, 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temp", "a7614fbb-6d9c-424a-b933-1aeae2a72223" },
                    { 35, new DateTime(2024, 12, 2, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7771), 1, new Guid("ba79cb00-cb76-4986-99c2-f2ab24294ff8"), 10, 1, "Lorem ipsum dolor sit amet, consectetur adi", "46ccc73b-b13d-4d3d-bf56-30cbd63babd3" },
                    { 36, new DateTime(2024, 11, 23, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7790), 1, new Guid("f6e613c7-4f48-4a89-95b2-5dee5caaf678"), 10, 0, "Lorem ipsum dolor sit amet, consectetur adipisic", "5d053f25-6e73-47b5-8a37-5fe5a7ac5ed1" },
                    { 37, new DateTime(2024, 11, 28, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7814), 0, new Guid("39cf447f-5f72-487f-84eb-4490025ee8f5"), 10, 1, "Lorem ipsum dolor sit amet, consectetur adipis", "8f4468e2-a501-416d-9a69-9eb560f034a5" },
                    { 38, new DateTime(2024, 10, 24, 17, 42, 50, 782, DateTimeKind.Utc).AddTicks(7833), 1, new Guid("96e1c8d6-7383-483a-b451-d7caaf6ba57a"), 10, 2, "Lorem ipsum dolor sit amet, con", "36690a1a-f421-4b9e-9657-5a7a5fa6fec8" }
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
