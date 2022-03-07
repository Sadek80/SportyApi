using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class SeedsSomeFootballProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "DescriptionMinimized", "ImageUrl", "Name", "Price", "Quantity", "SportId" },
                values: new object[,]
                {
                    { new Guid("70431068-33cf-4e6e-b49b-499e553d34c1"), "adidas", "Now with 360° coverage of DEMONSKIN rubber spikes, deliberately positioned to align with key ball - contact points, enabling superior control and increased ball swerve.Informed by elite player feedback, adidas updated the Predator design by creating an enhanced fit and extending the coverage of Demonskin rubber spikes for extraordinary ball control.", "A CONTROL FREAK - the new adidas Predator Freak is the most aggressive - looking cleat in the game.", "Products/Football/AdidasPredatorFreakSoccerCleat.jpg", "Predator Freak + FG Firm Ground Soccer Cleat", 234.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") },
                    { new Guid("277d46c2-8f29-491d-aa39-81df68968553"), "adidas", "adidas Predator gloves turn any goalkeeper into a shot-stopping beast! Play with the confidence that you're competing in a superior set of gloves from a great soccer brand.Can be worn for both match and training, on all surfaces,in all conditions.", "adidas Predator gloves turn any goalkeeper into a shot - stopping beast.", "Products/Football/adidasPredatorGoalKeeperGloves.jpg", "Predator Pro Ultimate Goalkeeper Gloves", 179.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") },
                    { new Guid("ec043374-747d-4188-9f15-0c41a65258a9"), "adidas", "The Pro is the official on-field match ball for the 2022 Champions League finale.UCL details, Textured surface, Thermally bonded seamless construction, 100 % Polyurethane, Butyl bladder, and Meets FIFA Quality Pro Standards.", " The Pro is the official on-field match ball for the 2022 Champions League finale.", "Products/Football/adidasUCLChampionsLeagueBall.jpg", "UCL Champions League Pro Soccer Ball", 164.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") },
                    { new Guid("e43f48a9-3928-4035-9960-b25e011fa984"), "adidas", "rawing inspiration from past speed boots, the X 19.1 perfectly blends innovation and technology with the look of pure speed. Some of the fastest players around the world are lacing up in the adidas X, so why aren't you ? A redesigned SpeedMesh upper offers a softer feel around your foot, and a more plush feel on the ball.The upper stays lightweight, offering a second skin - like fit.", "The X 19.1 is the perfect boot for players looking to show off their speed.", "Products/Football/adidasX19.1FGSoccerCleats.jpg", "X 19.1 FG Soccer Cleats", 139.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") },
                    { new Guid("833dc10f-63a0-4d18-a919-f6f387dbbbdd"), "Nike", "Full zip training jacket. Ribbed collar, cuffs and waist, Mesh insert, Embroidered swoosh, Dri - FIT technology wicks sweat, and 100 % polyester.", "Nike Academy 21 Jacket", "Products/Football/NikeAcademyJacket.jpg", "Academy 21 Jacket", 59.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") },
                    { new Guid("ed310637-8a9b-4bdb-ae60-ae10383fad1f"), "SKLZ", " A shoot and finish trainer that fits regulation size goals. It gives strikers open zones where they statistically are four times more likely to score a goal.Easily attaches to any regulation goal.", "A shoot and finish trainer that fits regulation size goals", "Products/Football/SKLZGoalshot.jpg", "SKLZ Goalshot", 299.99, 150, new Guid("a2bfd329-eba3-4520-9184-8877cffd1aed") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("277d46c2-8f29-491d-aa39-81df68968553"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("70431068-33cf-4e6e-b49b-499e553d34c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("833dc10f-63a0-4d18-a919-f6f387dbbbdd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e43f48a9-3928-4035-9960-b25e011fa984"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ec043374-747d-4188-9f15-0c41a65258a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ed310637-8a9b-4bdb-ae60-ae10383fad1f"));
        }
    }
}
