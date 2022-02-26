using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeProgramsForSwimming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("5f396661-fafc-406a-948f-82725d74ef09"), "All kids starting age 2.5 - 13yo Being taught 12 sessions per month by the best coaches, who have been raised all their lives as swimmers and champions. starting with water safety drills & training and getting into learning beginner strokes until they perfect their technique in all four strokes. One thing all these levels focus on, is the fun component. No matter the age, we always make sure our kids have fun while learning.", "Changing the way kids learn and train swimming. We're building the champions of tomorrow.", "Programs/Swimming/Kids Swimming.jpg", new Guid("9f3b6877-2312-40ed-b1cd-3c94149ec0c0"), "1st Settlement - Merryland International School", "Swimming Training For Kids", 2500.0, "Fit4Life Egypt", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("0051b5dd-b941-43f2-b0bd-56efb23cceea"), "for adults  We train intermediate swimmers who want to adopt swimming as their workout. Intermediate Level - Peak Performance Swimming Training Camp 24 sessions per month including pool lane rental, i.e. swim training for any duration in 50m and 25m pool for both fits and special needs swimmers worldwide.", "Get to learn the skill of a lifetime, coached by certified, national swimming champions.", "Programs/Adult Swimming.jpg", new Guid("c881f3bb-245f-4a6c-8aed-c861d8722cd5"), "GUARD HOTEL - Almaza, Heliopolis", "Swimming Training For Adults", 4750.0, "Fit4Life Egypt", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[] { new Guid("7a1d7257-1512-4848-a4f6-eca39e29fd79"), "Have a tight schedule and want the option of more flexibility in your training timing? Prefer privacy & undivided attention in your training? Offering private training for all professionals, making your swimming journey easier than ever!. We prepare those who are interested to join competitions. Half sessions are swimming & half fitness. whether it be, Masters Championships, Triathlon Competitions or Open Water Competitions.", "We prepare those who are interested to join competitions, whether it be, Masters Championships, Triathlon Competitions or Open Water Competitions.", "Programs/Swimming/Pro Swimming.jpg", new Guid("883ffd49-5bea-4949-808f-f9da3a6027ed"), "5th Settlement - TOLIP, AL NARGES", "Private Swimming Training For Pro", 8500.0, "Fit4Life Egypt", new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("0051b5dd-b941-43f2-b0bd-56efb23cceea"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("5f396661-fafc-406a-948f-82725d74ef09"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("7a1d7257-1512-4848-a4f6-eca39e29fd79"));
        }
    }
}
