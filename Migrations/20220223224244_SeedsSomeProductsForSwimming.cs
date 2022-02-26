using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeProductsForSwimming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "DescriptionMinimized", "ImageUrl", "Name", "Price", "Quantity", "SportId" },
                values: new object[,]
                {
                    { new Guid("4bc6b8b7-2d46-4b16-9845-9169e1cfc143"), "Arena", "Arena swimming cap men's and women's long hair ear protection comfortable silicone waterproof swimming cap adult plus bubble swimming cap At last a water resistant swim cap which has been designed specifically for people with long hair!!  The evolution of the Arena has become this model that holds your hair in place and than a cap which also protects it.", "unisex long hair ear protection comfortable silicone waterproof swimming cap", "Products/Swimming/Arena Swimming Cap.jpg", "Arena Swimming Cap", 490.0, 150, new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("5bade43f-9b1b-4734-9f98-09d7407a2783"), "COPOZZ", "COPOZZ White swim cap for long hair - Swimming Cap for women ladies and adult, Comfortable waterproof silicone swimming hat. COPOZZ Swimming cap, premium silicone swim caps for ultimate stretch and durability, non - toxic no odd smell, no deformation, quick dry and wrinkle - free.Designed for indoor pool swimming, competition, training and also outdoor water sports.", "COPOZZ Swimming Cap for women ladies and adult, Comfortable waterproof silicone swimming hat.", "Products/Swimming/COPOZZ long hair swim cap.jpg", "COPOZZ Long Hair Swim Cap", 650.0, 150, new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("3f52ad2f-8e0a-4c75-b79a-e32dc25749b2"), "COPOZZ", "Large swim cap, Designed for long hair, Silicone bathing cap swimming hat for women. COPOZZ Swimming cap, Designed for indoor pool swimming, competition, training and also outdoor water sports. Very thick mill silicone cap, fits XXL head (24 1/4) perfect and stays in place for my entire 2500 swim.", "COPOZZ Large swim cap, Designed for long hair, Silicone bathing cap swimming hat for women.", "Products/Swimming/COPOZZ swim cap with Littel Hearts.jpg", "COPOZZ Swim Cap with Littel Hearts", 650.0, 150, new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("fbdec713-f929-4937-a88e-9cf548bf058f"), "Queshark", "Queshark swimming goggles for adult  men and women with earplugs. New upgrade comfortable large frame design to used on the goggles ensure a snug fit on different facial forms and never allows water leak in. Nose pads with removable design, able to adapt to various high bridge nose, wear more comfortable. The latest technology which enhances the anti-fog ability and provides a clear vision when swimming. It easy to wear and take off the goggles.", "Queshark swimming goggles for adult  men and women with earplugs.", "Products/Swimming/Queshark Glasses for Swimming.jpg", "Queshark Glasses for Swimming", 190.0, 150, new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") },
                    { new Guid("5a4ecc08-d24f-47f4-a52b-6b60a10f26ea"), "Speedo", "A short and straight blade fin improves kick efficiency and develops kick strength without overtraining muscles, allowing swimmers to focus on proper kick mechanics.Swim fins are color coded, making this a great choice for swim teams and aquatic facilities, allowing quick sorting for the perfect fit.They're made with a super soft rubber for comfortable extended wear with secure fitting. These essential tools help strengthen and speed up your kick for overall better performance in the pool.", "Original speedo, short blade swim training fins, Silver with black ankle.", "Products/Swimming/Queshark Glasses for Swimming.jpg", "Speedo Short Blade Training Fin", 450.0, 150, new Guid("560408b9-1dea-4fe6-9f68-1cc1d6c703b5") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3f52ad2f-8e0a-4c75-b79a-e32dc25749b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4bc6b8b7-2d46-4b16-9845-9169e1cfc143"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5a4ecc08-d24f-47f4-a52b-6b60a10f26ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5bade43f-9b1b-4734-9f98-09d7407a2783"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("fbdec713-f929-4937-a88e-9cf548bf058f"));
        }
    }
}
