using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class AddsMobileColumnToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "Address_MobileNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_MobileNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_MobileNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_MobileNumber",
                table: "AspNetUsers");
        }
    }
}
