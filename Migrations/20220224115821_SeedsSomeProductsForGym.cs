using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeProductsForGym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "DescriptionMinimized", "ImageUrl", "Name", "Price", "Quantity", "SportId" },
                values: new object[,]
                {
                    { new Guid("805be8f0-fb90-45e6-af93-1e6e4cf40f3c"), "Papababe", "150 lb dumbbell set package include- 5,10,15,20,25 lbs pair with rack . Total 2 boxes. For anyone who wants to build strength, burn fat, and create a shapely body, free weight training with dumbbells is more effective than exercise machines.Even if you’re beyond the age of 40 , it’s never too late to start. Dumbbells are great workout equipment , if you prefer to exercise in the comfort of your home.", "150 lb dumbbell set package include- 5,10,15,20,25 lbs pair with rack. Total 2 boxes.", "papababe Free Weights Dumbbells Set.jpg", "Papababe Free Weights Dumbbells Set", 7068.0, 150, new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("f9a62370-99c7-4f6b-a709-30f191f65f4b"), "Garage Gear", "The traditional collars trusted for decades and made from high quality steel that will clamp on your barbell without sliding or snapping. A rubber handle covers the handle part for mild and soft quick exchange of weights. A simple yet effective solution to lock weights on your barbell.", "The traditional high quality collars steel that will clamp on your barbell without sliding or snapping.", "Products/Swimming/Spring Collars.jpg", "Spring Collars", 150.0, 150, new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("41b436e9-7e6f-49fb-9888-318e82aebc14"), "Reebok", "Equipped with a strong 2.5 HP motor at the heart of the treadmill, the Jet 300 delivers powerful and quiet performance with a top speed of 20 kph. Providing you with 15 levels of power incline to intensify your runs, the 300 delivers three user-defined, three heart rate control and three custom target workouts whilst 24 pre-set programmes kick-start your regime straight from set up.", "Reebok Treadmill delivers powerful and quiet performance with a top speed of 20 kph", "Products/Swimming/Reebok Jet 300 Series Treadmill.jpg", "Jet 300 Series Treadmill", 21845.0, 150, new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("e6c0ff11-decf-4652-b362-cfc5874347bf"), "Garage Gear", "The Classic speed rope with an Aluminum soft knurled Handles, a 3-meter adjustable length steel wire coated with PVC cover chord, a handle bearing, and a chord ball bearing ensures the most swift and smooth spin for performing double and even triple under.  Rope Weight: 150 grams. Handel Length: 14.5 cm.", "The Classic speed rope with an Aluminum soft knurled Handles", "Products/Swimming/Aluminum Speed Rope.jpg", "Aluminum Speed Rope", 350.0, 150, new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                    { new Guid("2f8ca6a5-bf57-4824-8bfe-572b862f2bc1"), "Garage Gear", "2 Hole palm grips made of 3 mm split cow leather that will ensure the best natural feel while protecting your skin from chaffing & direct contact of textured steel with your skin.", "Garage Gear 2 Hole palm grips", "Products/Gym/Gymnastic Hand Gear.jpg", "Gym Hand Grips", 300.0, 150, new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b") },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2f8ca6a5-bf57-4824-8bfe-572b862f2bc1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("41b436e9-7e6f-49fb-9888-318e82aebc14"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("805be8f0-fb90-45e6-af93-1e6e4cf40f3c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e6c0ff11-decf-4652-b362-cfc5874347bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f9a62370-99c7-4f6b-a709-30f191f65f4b"));
        }
    }
}
