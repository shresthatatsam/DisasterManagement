using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class victimidinlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VictimId",
                table: "user_location",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_user_location_VictimId",
                table: "user_location",
                column: "VictimId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_location_victims_VictimId",
                table: "user_location",
                column: "VictimId",
                principalTable: "victims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_location_victims_VictimId",
                table: "user_location");

            migrationBuilder.DropIndex(
                name: "IX_user_location_VictimId",
                table: "user_location");

            migrationBuilder.DropColumn(
                name: "VictimId",
                table: "user_location");
        }
    }
}
