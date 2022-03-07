using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeFootballLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "SportId" },
                values: new object[] { new Guid("eadd920f-74e3-4402-af5d-a5416f989a57"), "Players Born In 2010-2016", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "SportId" },
                values: new object[] { new Guid("07a478ef-58fb-4875-8ae8-b060f0632814"), "Players Born In 2005-2009", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "SportId" },
                values: new object[] { new Guid("9d9d2a15-d46e-406b-9c27-11c5a1dc31ca"), "For Professional Players", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("07a478ef-58fb-4875-8ae8-b060f0632814"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("9d9d2a15-d46e-406b-9c27-11c5a1dc31ca"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("eadd920f-74e3-4402-af5d-a5416f989a57"));
        }
    }
}
