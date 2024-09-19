using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class photosupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VictimId",
                table: "photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_photos_VictimId",
                table: "photos",
                column: "VictimId");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_victims_VictimId",
                table: "photos",
                column: "VictimId",
                principalTable: "victims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_victims_VictimId",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_VictimId",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "VictimId",
                table: "photos");
        }
    }
}
