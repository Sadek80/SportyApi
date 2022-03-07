using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeGymPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "TrainingProgramId", "Description", "DescriptionMinimized", "ImageUrl", "LevelId", "Location", "Name", "PricePerMonth", "Provider", "SportId" },
                values: new object[,]
                {
                    { new Guid("07f08695-7f29-43a5-b991-07cd1e4370a2"), "This workout plan is designed to help you shred fat and get in shape.Every detail of your diet and training will be laid out for you. You will be told exactly what to eat, how much cardio to do, and how to weight train. The goal is simple: lose fat, maintain muscle mass, get in shape and transform your physique as much as possible over. You want to not only look better, but have the fitness level and strength to match your new body. For more info, please Enroll and we will contact you", "This is a complete program to help you get ripped. Feature includes detailed diet plan and cardio schedule, along with a 4 day upper/lower muscle building split.", "Programs/Gym/FatDestroyerCompleteFatLossWorkout&DietProgram.PNG", new Guid("9ae67650-6368-445d-a54a-86b36f315452"), "Leader Gym - 213 Abd El-Salam Aref", "Fat Destroyer: Complete Fat Loss Workout & Diet Program", 900.0, "Leader Gym", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("b87f9ac1-3448-4804-8463-35ea56f9f30f"), "Each workout should takes no more than 30 minutes to complete. Following a warm up set, each set of each exercise should be taken to absolute failure. The stipulated intensity methods will, where applicable, ensure complete failure on the final rep of each work set. It’s important to select a weight that will allow complete failure on the 8-12th rep. Do not exceed 12 reps, this is the ideal range for advanced muscle hypertrophy.Take 60 seconds rest between sets to further increase intensity. For more info, please Enroll and we will contact you", "Maximize your fat loss with this shred workout program. Plus, as a bonus - 5 tips to get the fattest loss out of the program!", "Programs/Gym/WorkoutstoShreddedMaximizeYourFatLosswiththisWorkout.PNG", new Guid("5619f4ed-e839-411c-a991-0382b18e7453"), "Blow Up Gym - Gamal Abd El-Nasir Rd, Al Mandarah Bahri, Alexandria", "Workouts to Shredded: Maximize Your Fat Loss with this Workout", 2500.0, "Blow Up Gym", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("671a7491-5a55-4089-8def-4555bb79a8f3"), "We all have our favorite superheroes. We identify with them based on their backstories, their special super powers and their ability to save the day. What follows is a workout that’ll take you around 90 minutes to complete. You train everything from shoulders to legs and will burn tons of calories along the way. Get into your own superhero mode and start developing your powers today. Note: Don’t wear a cape when doing this.People at the gym will look at you funny.For more info, please Enroll and we will contact you", "Become a superhero! This full body workout routine trains several different necessary skill sets one may need.", "Programs/Gym/TrainLikeaSuperheroFullBodyWorkout.PNG", new Guid("0dfe7a76-f899-4b8c-aa86-495c70ff3959"), "Hammer Gym - 25 Mohammed Awad Allah, Sidi Beshr Bahri, Alexandria", "Train Like a Superhero: Full Body Workout", 2100.0, "Hammer Gym", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("1aa5faa8-6e88-40de-a0ec-8663c21258c5"), "The goal is to get your form down pat on the most basic and most important exercises in the gym. Get a cheap notebook and track your weights and how many reps you did. Don't get discouraged. No matter how big any of the guys are at the gym, they all started somewhere. Some of them probably started with lighter weights than you did. For more info, please Enroll and we will contact you", "This full body workout is perfect for absolute beginners who need to develop good exercise form.", "Programs/Gym/BeginnerFullBodyWorkout.PNG", new Guid("9ae67650-6368-445d-a54a-86b36f315452"), "FIRST GYM - Sidi Beshr Bahri, Qesm Al Montazah, Alexandria", "Beginner Full-Body Workout", 700.0, "FIRST GYM", new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("07f08695-7f29-43a5-b991-07cd1e4370a2"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("1aa5faa8-6e88-40de-a0ec-8663c21258c5"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("671a7491-5a55-4089-8def-4555bb79a8f3"));

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "TrainingProgramId",
                keyValue: new Guid("b87f9ac1-3448-4804-8463-35ea56f9f30f"));
        }
    }
}
