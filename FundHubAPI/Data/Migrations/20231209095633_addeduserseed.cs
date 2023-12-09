using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class addeduserseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("0f97ea1d-e247-4cf5-a6d9-5f9d3265e220"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" },
                    { new Guid("598004de-bc37-4300-8271-3c1c0bb5c430"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" },
                    { new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "currentfund", "description", "images", "subtitle", "title", "totalfundrequired" },
                values: new object[,]
                {
                    { new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Indie Egyptian Game", 60000 },
                    { new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"), new Guid("00000000-0000-0000-0000-000000000000"), "health", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine", 1000000 },
                    { new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Electric Koshary Machine", 120000 },
                    { new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", 500, "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "hashedpassword", "pass_salt", "phonenumber", "username", "usertype" },
                values: new object[] { new Guid("ae470835-2bbc-4ef3-89ab-d00c4e2343e2"), "test@gmail.com", null, null, 123456789, "testuser", "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("0f97ea1d-e247-4cf5-a6d9-5f9d3265e220"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("598004de-bc37-4300-8271-3c1c0bb5c430"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("a9437a37-1d37-4a9b-adbd-a18ef0490942"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae470835-2bbc-4ef3-89ab-d00c4e2343e2"));

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
    }
}
