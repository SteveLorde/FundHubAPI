using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedfundpropertiestoprojects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("3137b3bd-8c76-4cf6-bae1-a1f94001b3be"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("c14842e9-d3c4-4ee2-8d65-e4097caf421a"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("c52202be-80d5-44c9-a8f9-a4a2f760ddd8"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("d6b0d29e-10d5-4745-b83d-c6f8b153e6a5"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("1e29759d-eb10-4125-bbab-a7ffaa33dc71"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4f3d49f5-d3c9-40c1-8bb8-2a1c414265b1"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("6290ee3d-24c8-4df5-b572-19a8b4344a7a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c0ce80ee-e09a-49f0-bd80-544524f31895"));

            migrationBuilder.AddColumn<int>(
                name: "currentfund",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalfundrequired",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("212d823f-0946-4e71-b484-5b89930fc3f4"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" },
                    { new Guid("6569b211-2ea3-44ca-9580-972a05c8d82d"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("6b6d27b3-832c-4f7d-a818-d6fb598b55ab"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" },
                    { new Guid("b9699eda-35a8-482c-9416-03a9dd709869"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "currentfund", "description", "images", "subtitle", "title", "totalfundrequired" },
                values: new object[,]
                {
                    { new Guid("3d200ef5-68da-435a-911b-0d5eca0bd7a1"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 0, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Electric Koshary Machine", 0 },
                    { new Guid("50f86273-8768-43d1-9a02-d74a38397462"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 0, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt", 0 },
                    { new Guid("5cbe793b-26af-4c5c-9ab7-698ce3a66827"), new Guid("00000000-0000-0000-0000-000000000000"), "health", 0, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine", 0 },
                    { new Guid("f6c75da3-85bd-48f5-9982-5d0ae33a65d9"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 0, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Indie Egyptian Game", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("212d823f-0946-4e71-b484-5b89930fc3f4"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("6569b211-2ea3-44ca-9580-972a05c8d82d"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("6b6d27b3-832c-4f7d-a818-d6fb598b55ab"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("b9699eda-35a8-482c-9416-03a9dd709869"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("3d200ef5-68da-435a-911b-0d5eca0bd7a1"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("50f86273-8768-43d1-9a02-d74a38397462"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("5cbe793b-26af-4c5c-9ab7-698ce3a66827"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("f6c75da3-85bd-48f5-9982-5d0ae33a65d9"));

            migrationBuilder.DropColumn(
                name: "currentfund",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "totalfundrequired",
                table: "Projects");

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("3137b3bd-8c76-4cf6-bae1-a1f94001b3be"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" },
                    { new Guid("c14842e9-d3c4-4ee2-8d65-e4097caf421a"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" },
                    { new Guid("c52202be-80d5-44c9-a8f9-a4a2f760ddd8"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("d6b0d29e-10d5-4745-b83d-c6f8b153e6a5"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "description", "images", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("1e29759d-eb10-4125-bbab-a7ffaa33dc71"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Electric Koshary Machine" },
                    { new Guid("4f3d49f5-d3c9-40c1-8bb8-2a1c414265b1"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Indie Egyptian Game" },
                    { new Guid("6290ee3d-24c8-4df5-b572-19a8b4344a7a"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt" },
                    { new Guid("c0ce80ee-e09a-49f0-bd80-544524f31895"), new Guid("00000000-0000-0000-0000-000000000000"), "health", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine" }
                });
        }
    }
}
