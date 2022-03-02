using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class ResolvessUsersInerests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserSport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserSport",
                columns: table => new
                {
                    InterestedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportingInterestSportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSport", x => new { x.InterestedUsersId, x.SportingInterestSportId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSport_AspNetUsers_InterestedUsersId",
                        column: x => x.InterestedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSport_Sports_SportingInterestSportId",
                        column: x => x.SportingInterestSportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSport_SportingInterestSportId",
                table: "ApplicationUserSport",
                column: "SportingInterestSportId");
        }
    }
}
