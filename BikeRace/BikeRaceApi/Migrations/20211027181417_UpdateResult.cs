using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRaceApi.Migrations
{
    public partial class UpdateResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdParticipant",
                table: "Results",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdParticipant",
                table: "Results");
        }
    }
}
