using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeLevelsForGymAndSwimming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "SportId" },
                values: new object[,]
                {
                    { new Guid("9f3b6877-2312-40ed-b1cd-3c94149ec0c0"), "Beginner", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("c881f3bb-245f-4a6c-8aed-c861d8722cd5"), "Intermediate", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("883ffd49-5bea-4949-808f-f9da3a6027ed"), "Advanced", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("9ae67650-6368-445d-a54a-86b36f315452"), "Beginner", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("0dfe7a76-f899-4b8c-aa86-495c70ff3959"), "Intermediate", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("5619f4ed-e839-411c-a991-0382b18e7453"), "Advanced", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("0dfe7a76-f899-4b8c-aa86-495c70ff3959"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("5619f4ed-e839-411c-a991-0382b18e7453"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("883ffd49-5bea-4949-808f-f9da3a6027ed"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("9ae67650-6368-445d-a54a-86b36f315452"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("9f3b6877-2312-40ed-b1cd-3c94149ec0c0"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c881f3bb-245f-4a6c-8aed-c861d8722cd5"));
        }
    }
}
