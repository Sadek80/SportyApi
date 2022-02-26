using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[] { new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5"), "Swimming" });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[] { new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b"), "Gym" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5"));
        }
    }
}
