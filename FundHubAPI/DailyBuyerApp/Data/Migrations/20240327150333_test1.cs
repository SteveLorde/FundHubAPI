using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundHubAPI.DailyBuyerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Paymenttype",
                table: "DonationLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e445054-8f22-4812-adb7-38cd849c976b"),
                column: "Hashedpassword",
                value: "8aijMdt2WmepGie830kchw==.T0rG3EwLIld1gK4lZMo6fGos8F/uzHXoNtmyt4H5+Lo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"),
                column: "Hashedpassword",
                value: "JEEEbj6eW/DSfnpDRVzqpw==.ANHjzWBFlati+AiWKPfYtMuXJp0ki6uozMNdff2gYkU=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9bdfe044-4b02-40a7-ade7-4570e68af19c"),
                column: "Hashedpassword",
                value: "8enEWZd9hOzxUYqiSPOF1g==.iVMhYVcUJSQUGEMGu8SRf32LIljlZJ19vgv3UHdGaCI=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"),
                column: "Hashedpassword",
                value: "T0NC9bpb89Fgw1arrZclCA==./zsKC1FRb0PLG3BbCM1o1saLFbRJIXBuf8toyrCOiCo=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"),
                column: "Hashedpassword",
                value: "2dkwzI9rUKeI/bOCkzhTfQ==.kcbi8/1GC3QD3ThFXGNrHT9P8cxmTv9z2rAl4Fxzdg4=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8b590f1-c920-4c1b-9237-852bc0b43518"),
                column: "Hashedpassword",
                value: "GrAbSH2rA1nOsjM2ZfU5fg==.Q4awJSjtLapHc/dpoD4sucV8PlT3immV3Paewz9Fng4=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paymenttype",
                table: "DonationLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e445054-8f22-4812-adb7-38cd849c976b"),
                column: "Hashedpassword",
                value: "N4WKpgyCPJ2kbh5V2hA3Lg==.5NmvuIMf4vNiobnSJ8BfMubU89a/xGvqck00YhZa/JY=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("913eedbd-a304-478e-beee-4c8db66bd86a"),
                column: "Hashedpassword",
                value: "xKxRXjZPE5eRjeYyut0AjA==.5FmgksD5GBZFKno1kuNP14h8DPo4sc4HlxuLA+EYXGU=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9bdfe044-4b02-40a7-ade7-4570e68af19c"),
                column: "Hashedpassword",
                value: "7mmR3jvXz1jvOtdOhTq2Mw==.OL4hVwtTbRrs7k+sOK9CX19uqkysQOGmBsjpV7FMzXA=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5379337-e6a4-4222-aa88-233358bda6e9"),
                column: "Hashedpassword",
                value: "yetxGNGDt69i8s6F4kRifg==.KQo5skRtWLfkK7tlh1ttqP/cFlpUInV+kSz0cJXVTF8=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"),
                column: "Hashedpassword",
                value: "tNt9z7cleFMm2HphcmtLxg==.k8PKwXzyPKNeWEy5gV2uQJPS2FswnyxFdpFYMlW5Wjc=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8b590f1-c920-4c1b-9237-852bc0b43518"),
                column: "Hashedpassword",
                value: "4JjobeF1CzdWECYu7ra7nw==.r+vPL+4VtXlchQ6kLYrBtCJSo6PgDWnR+ljxFSrMiqE=");
        }
    }
}
