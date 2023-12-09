using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class editedseed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae470835-2bbc-4ef3-89ab-d00c4e2343e2"));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"),
                column: "title",
                value: "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"),
                column: "title",
                value: "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"),
                columns: new[] { "category", "title", "totalfundrequired" },
                values: new object[] { "health", "My Super Awesome Health Machine", 1000000 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"),
                columns: new[] { "category", "title", "totalfundrequired" },
                values: new object[] { "enviornment", "Greener Egypt", 2000 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"),
                columns: new[] { "title", "totalfundrequired" },
                values: new object[] { "Indie Egyptian Game", 60000 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "hashedpassword", "pass_salt", "phonenumber", "username", "usertype" },
                values: new object[] { new Guid("0a9714cc-87cc-489d-9ba6-26fe5faf19e1"), "test@gmail.com", null, null, 123456789, "testuser", "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a9714cc-87cc-489d-9ba6-26fe5faf19e1"));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"),
                column: "title",
                value: "From Campus to Capital: Student-Led Ventures Garner Investment for Impactful Initiatives");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"),
                column: "title",
                value: "Empowering Tomorrow's Leaders: College Projects Receive Major Funding Boost");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("694d6683-d3e6-4bc1-ab5d-f2f67f887332"),
                columns: new[] { "category", "title", "totalfundrequired" },
                values: new object[] { "enviornment", "Indie Egyptian Game", 60000 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("7e4788cd-77a9-4b03-9412-385a482cf489"),
                columns: new[] { "category", "title", "totalfundrequired" },
                values: new object[] { "health", "My Super Awesome Health Machine", 1000000 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9c8eccf-76aa-42d6-be67-803d8622c951"),
                columns: new[] { "title", "totalfundrequired" },
                values: new object[] { "Greener Egypt", 2000 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "hashedpassword", "pass_salt", "phonenumber", "username", "usertype" },
                values: new object[] { new Guid("ae470835-2bbc-4ef3-89ab-d00c4e2343e2"), "test@gmail.com", null, null, 123456789, "testuser", "user" });
        }
    }
}
