using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundHubAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedmodelsnamingconventions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageCoverName",
                table: "News",
                newName: "Imagecovername");

            migrationBuilder.RenameColumn(
                name: "DonationAmount",
                table: "DonationLogs",
                newName: "Donationamount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagecovername",
                table: "News",
                newName: "ImageCoverName");

            migrationBuilder.RenameColumn(
                name: "Donationamount",
                table: "DonationLogs",
                newName: "DonationAmount");
        }
    }
}
