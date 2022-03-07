using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeFootballPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("6752eccc-d87f-467b-a15b-8916fc68954c"), "l Ahly Soccer Training Academy is committed to youth player development and success. Our Academy focuses on individual foot skills, ball mastery, proper technique, tactical understanding of the game, as well as speed agility quickness(SAQ) training. To build talented and confident, players through proven training methods.Licensed professional coaches are committed to the overall growth of individuals and teams, while maintaining a fun and safe learning environment.", "A successful soccer career begins with a strong training foundation.", "Programs/Football/Al-Ahliclubacademy(2010-2016).png", new Guid("eadd920f-74e3-4402-af5d-a5416f989a57"), "Al-Ahly, Nasr City, Cairo", "Al-Ahly Football Academy (2010-2016)", 1500.0, "Al-Ahly SC", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("46e1d573-01c5-4988-85dd-d70c579b05d4"), "l Ahly Soccer Training Academy is committed to youth player development and success. Our Academy focuses on individual foot skills, ball mastery, proper technique, tactical understanding of the game, as well as speed agility quickness(SAQ) training. To build talented and confident, players through proven training methods.Licensed professional coaches are committed to the overall growth of individuals and teams, while maintaining a fun and safe learning environment.", "A successful soccer career begins with a strong training foundation.", "Programs/Football/Al-Ahliclubacademy(2005-2009).png", new Guid("07a478ef-58fb-4875-8ae8-b060f0632814"), "Al-Ahly, Nasr City, Cairo", "Al-Ahly Football Academy (2005-2009)", 3000.0, "Al-Ahly SC", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("736683bc-fdf4-47a6-b099-0d2a8778b0c8"), "Ensures the professional soccer player receives the most relevant technical, tactical, and physiological information in order to successfully identify in-play weaknesses & subsequently improve upon these in competitive games", "Performance analysis consist on tactical assessment, movement analysis, video and statistical databasing and modeling and coach and player data presentations.", "Programs/Football/performanceanalystfootball.jpg", new Guid("9d9d2a15-d46e-406b-9c27-11c5a1dc31ca"), "El Omraniya, Giza", "Football Performance Analysis", 5000.0, "Mohamed Abdel Fattah", new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("46e1d573-01c5-4988-85dd-d70c579b05d4"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("6752eccc-d87f-467b-a15b-8916fc68954c"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("736683bc-fdf4-47a6-b099-0d2a8778b0c8"));
        }
    }
}
