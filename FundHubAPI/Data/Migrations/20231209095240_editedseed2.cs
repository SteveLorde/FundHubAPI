using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class editedseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("01a099c1-1862-4a4b-8824-9be48f395af9"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("1b0bc230-fadb-4666-82f8-e5b01e276256"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" },
                    { new Guid("285d828a-3716-4809-aeda-772f0151d7d0"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" },
                    { new Guid("77c20967-fe1d-4ca7-8d97-a4551588b7fa"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "currentfund", "description", "images", "subtitle", "title", "totalfundrequired" },
                values: new object[,]
                {
                    { new Guid("024c444f-195e-4eae-b876-4022943370d6"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Electric Koshary Machine", 120000 },
                    { new Guid("17420167-873e-4e89-9bfb-fb16843efe68"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Indie Egyptian Game", 60000 },
                    { new Guid("9542a85c-cb09-473d-b79d-3daa4352109f"), new Guid("00000000-0000-0000-0000-000000000000"), "health", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine", 1000000 },
                    { new Guid("b3e6a4a3-f0e0-47e0-9d0b-e20372a31ef7"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt", 2000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("01a099c1-1862-4a4b-8824-9be48f395af9"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("1b0bc230-fadb-4666-82f8-e5b01e276256"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("285d828a-3716-4809-aeda-772f0151d7d0"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("77c20967-fe1d-4ca7-8d97-a4551588b7fa"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("024c444f-195e-4eae-b876-4022943370d6"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("17420167-873e-4e89-9bfb-fb16843efe68"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("9542a85c-cb09-473d-b79d-3daa4352109f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b3e6a4a3-f0e0-47e0-9d0b-e20372a31ef7"));

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
    }
}
