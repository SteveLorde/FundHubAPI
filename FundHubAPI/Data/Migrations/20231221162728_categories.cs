using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"), "Product" },
                    { new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"), "EnvironmentProject" },
                    { new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"), "SocietalProject" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"),
                column: "CategoryId",
                value: new Guid("fafaad46-3fbe-40ac-ad63-c311829668a4"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"),
                column: "CategoryId",
                value: new Guid("59cb7c8b-8e33-45d6-b066-214f3145a3c0"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"),
                column: "CategoryId",
                value: new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"),
                column: "CategoryId",
                value: new Guid("4a858ba2-cc64-4752-973a-2b1acba5d78d"));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Categories_CategoryId",
                table: "Projects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Categories_CategoryId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"),
                column: "category",
                value: "health");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"),
                column: "category",
                value: "enviornment");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"),
                column: "category",
                value: "enviornment");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"),
                column: "category",
                value: "enviornment");
        }
    }
}
