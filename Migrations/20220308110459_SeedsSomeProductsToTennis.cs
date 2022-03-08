using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeProductsToTennis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "DescriptionMinimized", "ImageUrl", "Name", "Price", "Quantity", "SportId" },
                values: new object[,]
                {
                    { new Guid("8f0afcf5-88d3-4679-9a66-ec3462b5f00b"), "Dunlop", "DUNLOP AUSTRALIAN OPEN TENNIS BALL: The official ball of the AO, Australian Open, usable on all tournament events including finals, the Dunlop Australian Open tennis balls are designed for competitive, tournament level of play, and to suit the style of tennis presented by the world-class players participating in the most prestigious tourneys in tennis.", "The first Slam of the year, the 2019 Australian Open, opens with Dunlop as its new ball sponsor!", "Products/Tennis/AustralianOpen4BallTube.JPG", "Australian Open 4 Ball Tube.", 870.0, 150, new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") },
                    { new Guid("23be7e57-5950-44a6-a2ee-74b1a0dd689b"), "Wilson", "Co-designed by Roger Federer, the Pro Staff delivers the pure, classic feel players have come to love but with an all-new uncontaminated design. Meticulous in detail and bold in its beauty, the new Pro Staff introduces a whole new dimension of engineered paint finishes and textures with matte black velvet, chrome touches, and laser engraving never before seen in tennis.", "Cross Section: 23mm Flat Beam, String Pattern:18x16, Unstrung weight: 290g, Unstrung Balance: 32.5 CM / 6 Pts HL, Head Size: 104 sq. in.", "Products/Tennis/WilsonBlade104WRT73331UTennisRacket.JPG", "Wilson Blade 104 WRT73331U Tennis Racket", 3500.0, 5, new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") },
                    { new Guid("6335ed1f-fc72-48f8-a8ee-69b407cb96a6"), "Head", "There´s no need to compromise with the RADICAL 12R MONSTERCOMBI, which combines all the space you need with all the innovations you desire. Refreshed with a new colorway to match HEAD´s new RADICAL racquet series, the bag has three spacious main compartments that allow you to take whatever you need onto court, while the integrated shoe compartment lets you keep those dirty shoes or laundry locked away if you need to. Two big external accessory pockets ensure your belongings are right where you need them to be. And on the technology side, it comes with the climate control technology CCT+ which protects your racquets from extreme temperatures.", "The RADICAL bag series puts an end to compromise and the RADICAL 12R MONSTERCOMBI is the best proof as it combines all the room you need with all of the innovations you desire.", "Products/Tennis/HeadRadicalMonstercombiRacketBag.JPG", "Head Radical Monstercombi Racket Bag", 1122.0, 150, new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") },
                    { new Guid("ce84c3c5-90ff-4255-a711-6a0cd9a271d1"), "Head", "Asymmetrical Waistband, Waist with elastic cord, Elastic waist, Printed logo, High-quality glued stitching, Integrated shorts, Pleats (fold-look), Reflective logo, Slots for more freedom of movement, Narrow waistband", "multi-layer fabric, Structured fabric, Fit: slim fit, straight cut, high-waist cut, loose cut", "Products/Tennis/CourtDriFitSkirtWomen.JPG", "Court Dri-Fit Skirt Women", 487.0, 7, new Guid("246b70f0-2df6-4d0c-8ca1-8a431b544ecb") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("23be7e57-5950-44a6-a2ee-74b1a0dd689b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6335ed1f-fc72-48f8-a8ee-69b407cb96a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("8f0afcf5-88d3-4679-9a66-ec3462b5f00b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ce84c3c5-90ff-4255-a711-6a0cd9a271d1"));

        }
    }
}
