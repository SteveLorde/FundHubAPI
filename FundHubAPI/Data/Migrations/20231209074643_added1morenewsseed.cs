using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class added1morenewsseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("23e7841a-637e-4a4f-b781-f52c760b1cef"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("a52488df-b28e-408b-b0e2-0f96934c7a5e"));

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("d4d58cbf-6150-4e35-ab7f-5fd1017d54dc"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("236a46aa-1cfa-4194-bd50-bbb040707bcf"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("39db0943-282a-44e6-b734-ae308ce80806"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("8569e852-027a-4565-b7b9-dcc4228d682d"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("d77dd7cd-c0f2-47f0-a2ec-fd0a74cd22d2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
