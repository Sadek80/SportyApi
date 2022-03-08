using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class AddsProgramToTennis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "SportId" },
                values: new object[] { new Guid("c8a2734e-d7f5-431e-b77b-a4b35b6a7f3a"), "All Levles", new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c8a2734e-d7f5-431e-b77b-a4b35b6a7f3a"));
        }
    }
}
