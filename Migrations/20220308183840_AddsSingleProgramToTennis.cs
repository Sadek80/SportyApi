using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class AddsSingleProgramToTennis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("333ffd40-d4be-4da8-be7c-bc6ba7e78db0"), "Stars Tennis Academy is the practicing grounds for Egypt's top tennis players.Our goal is to inspire and develop a new generation of players that will compete with the world's elite within the coming 10 years. By combining tennis, fitness and mental instructions from sports science in a safe and caring environment. We offer the ideal training for players from beginners to top touring professionals to reach their full potential", "At Stars Academy, we train tennis professionals, we train athletes, and we train individuals.", "Programs/Tennis/StarsTennisAcademy.jpg", new Guid("c8a2734e-d7f5-431e-b77b-a4b35b6a7f3a"), "Smouha Club - Alexandria", "Stars Tennis Academy", 1000.0, "Stars Tennis Academy", new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("333ffd40-d4be-4da8-be7c-bc6ba7e78db0"));
        }
    }
}
