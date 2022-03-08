using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class AddsTennisToSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[] { new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb"), "Tennis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb"));
        }
    }
}
