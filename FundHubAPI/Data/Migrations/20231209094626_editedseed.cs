using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class editedseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("1f96537e-eb42-4832-bc41-f27eb8045831"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("5c1c6efd-a640-4c5c-8772-7c6d4e2afb7b"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("a1939c78-6cf2-4482-a229-4747bea0bfe0"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("ae1ae9f6-91e1-44e2-a05e-e03cbc1bbc68"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("10d24a93-1993-4619-8b55-51b0c4f2908d"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("190162ec-afeb-4d0b-b2d6-add76b23baab"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("43b77480-fd96-4d56-a90f-dc630f5edd14"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b132a8d1-c004-40c5-93ae-af039179b143"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("1f96537e-eb42-4832-bc41-f27eb8045831"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shaping the Future: College Students' Ambitious Projects Win Substantial Funding" },
                    { new Guid("5c1c6efd-a640-4c5c-8772-7c6d4e2afb7b"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost" },
                    { new Guid("a1939c78-6cf2-4482-a229-4747bea0bfe0"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Innovative Breakthroughs: College Students Secure Funding for Groundbreaking Projects" },
                    { new Guid("ae1ae9f6-91e1-44e2-a05e-e03cbc1bbc68"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "UserId", "category", "description", "images", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("10d24a93-1993-4619-8b55-51b0c4f2908d"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "" },
                    { new Guid("190162ec-afeb-4d0b-b2d6-add76b23baab"), new Guid("00000000-0000-0000-0000-000000000000"), "health", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "My Super Awesome Health Machine" },
                    { new Guid("43b77480-fd96-4d56-a90f-dc630f5edd14"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt" },
                    { new Guid("b132a8d1-c004-40c5-93ae-af039179b143"), new Guid("00000000-0000-0000-0000-000000000000"), "enviornment", "Description Test", new[] { "1.jpg", "2.jpg" }, "Subtitle Test", "Greener Egypt" }
                });
        }
    }
}
