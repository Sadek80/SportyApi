using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class AddsOneGymProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("b838b47f-333c-4110-b5a2-70e3d09cc9fd"), "That would be the best split, but let’s face facts. There are a lot of you that have jobs that don’t allow this to happen, so here’s what you need to know. The only rule I suggest you follow is that you don’t train for more than three days in a row before taking a day off. Two would be best, but if you must train a third consecutive day, go for it. I don’t suggest you do this normally. For more info, please Enroll and we will contact you", "This program will help intermediate trainees gain size and strength. Rest-pause set, drop sets, and negatives will kick your muscle gains into high gear!", "Programs/Gym/MassBuildingHypertrophyWorKout.PNG", new Guid("0dfe7a76-f899-4b8c-aa86-495c70ff3959"), "Gold's Gym - Elite San Stefano", "Mass Building Hypertrophy Workout", 3000.0, "Gold's Gym", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("b838b47f-333c-4110-b5a2-70e3d09cc9fd"));
        }
    }
}
