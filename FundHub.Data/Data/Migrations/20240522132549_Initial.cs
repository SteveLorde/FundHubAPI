using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHub.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Published = table.Column<DateOnly>(type: "date", nullable: false),
                    Imagecovername = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Hashedpassword = table.Column<string>(type: "text", nullable: false),
                    Usertype = table.Column<string>(type: "text", nullable: false),
                    Phonenumber = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Facebook = table.Column<string>(type: "text", nullable: false),
                    X = table.Column<string>(type: "text", nullable: false),
                    Instagram = table.Column<string>(type: "text", nullable: false),
                    Profileimage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Currentfund = table.Column<int>(type: "integer", nullable: false),
                    Totalfundrequired = table.Column<int>(type: "integer", nullable: false),
                    Imagesnames = table.Column<string[]>(type: "text[]", nullable: false),
                    Facebook = table.Column<string>(type: "text", nullable: false),
                    X = table.Column<string>(type: "text", nullable: false),
                    Instagram = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonationAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationLogs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"), "product" },
                    { new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"), "environment" },
                    { new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"), "society" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Description", "Imagecovername", "Published", "Subtitle", "Title" },
                values: new object[,]
                {
                    { new Guid("0f97ea1d-e247-4cf5-a6d9-5f9d3265e220"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), "", "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), "", "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" },
                    { new Guid("598004de-bc37-4300-8271-3c1c0bb5c430"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), "", "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" },
                    { new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), "", "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Facebook", "Hashedpassword", "Instagram", "Phonenumber", "Profileimage", "Username", "Usertype", "X" },
                values: new object[,]
                {
                    { new Guid("2e445054-8f22-4812-adb7-38cd849c976b"), "test@gmail.com", "", "oXFbbQQobrIbmUtFpYGszQ==.3mDp1D3VXZQSEw4OU641t083g6DyJ0slwZAX6u7yHWs=", "", 123456789, "profile.jpg", "testuser3", "user", "" },
                    { new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"), "test@gmail.com", "", "7hSmeUC0KT1PAVKQ1rR69w==.ywsTWK6zAUzua86GYr3akqaT4gWmSXEI9fQyqmD7I7I=", "", 123456789, "profile.jpg", "testuser2", "user", "" },
                    { new Guid("9bdfe044-4b02-40a7-ade7-4570e68af19c"), "test@gmail.com", "", "UEi36lmIDWwA8t7BkrdQng==.+rtzatRTFbuMJPn0upq9fEZRGvYqvWGTQ1/M/PTSky4=", "", 123456789, "profile.jpg", "testuser5", "user", "" },
                    { new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"), "test@gmail.com", "", "wSyLm4mMYVUJrWNttUOIZQ==.Rwiimrp/JfgY8KDJz5UfDhaymRCKWc7gCXpgQpMx1d0=", "", 123456789, "profile.jpg", "testuser4", "user", "" },
                    { new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"), "test@gmail.com", "", "l7KlGmDy9VjpekaMMqffjA==.Ar9EOmtuXvV32e2NO+l722/vROY9S/FpqzBgIumYsik=", "", 123456789, "profile.jpg", "testuser1", "user", "" },
                    { new Guid("c8b590f1-c920-4c1b-9237-852bc0b43518"), "test@gmail.com", "", "7qxsRaxVZ+elPOfiRD0rwQ==.Iaw8WmYOtJSLk7JeoySALdokrMmR2R+BNbiAWr1BHb8=", "", 123456789, "profile.jpg", "testadmin", "admin", "" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "Currentfund", "Description", "Facebook", "Imagesnames", "Instagram", "Subtitle", "Title", "Totalfundrequired", "UserId", "X" },
                values: new object[,]
                {
                    { new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"), new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"), 500, "Description Test", "", new[] { "1.jpg", "2.jpg" }, "", "Subtitle Test", "My Super Awesome Health Machine Research Paper", 1000000, new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"), "" },
                    { new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"), new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"), 500, "Description Test", "", new[] { "1.jpg", "2.jpg" }, "", "Subtitle Test", "Greener Egypt", 2000, new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"), "" },
                    { new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"), new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"), 500, "Description Test", "", new[] { "1.jpg", "2.jpg" }, "", "Subtitle Test", "Electric Koshary Machine", 120000, new Guid("2e445054-8f22-4812-adb7-38cd849c976b"), "" },
                    { new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"), new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"), 500, "Description Test", "", new[] { "1.jpg", "2.jpg" }, "", "Subtitle Test", "Indie Egyptian Game", 60000, new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"), "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationLogs_ProjectId",
                table: "DonationLogs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationLogs_UserId",
                table: "DonationLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationLogs");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
