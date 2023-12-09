using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    published = table.Column<DateOnly>(type: "date", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    images = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    pass_salt = table.Column<string>(type: "text", nullable: true),
                    hashedpassword = table.Column<string>(type: "text", nullable: true),
                    usertype = table.Column<string>(type: "text", nullable: false),
                    phonenumber = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    accepted = table.Column<bool>(type: "boolean", nullable: false),
                    datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseLogs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("23e7841a-637e-4a4f-b781-f52c760b1cef"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "News 3" },
                    { new Guid("a52488df-b28e-408b-b0e2-0f96934c7a5e"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "News 2" },
                    { new Guid("d4d58cbf-6150-4e35-ab7f-5fd1017d54dc"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "News 1" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "description", "images", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("236a46aa-1cfa-4194-bd50-bbb040707bcf"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt" },
                    { new Guid("39db0943-282a-44e6-b734-ae308ce80806"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt" },
                    { new Guid("8569e852-027a-4565-b7b9-dcc4228d682d"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "" },
                    { new Guid("d77dd7cd-c0f2-47f0-a2ec-fd0a74cd22d2"), new Guid("00000000-0000-0000-0000-000000000000"), "health", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_ProjectId",
                table: "PurchaseLogs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_UserId",
                table: "PurchaseLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PurchaseLogs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
